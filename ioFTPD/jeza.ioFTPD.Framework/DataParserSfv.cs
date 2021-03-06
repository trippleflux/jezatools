#region
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;

#endregion

namespace jeza.ioFTPD.Framework
{
    public class DataParserSfv : IDataParser
    {
        public DataParserSfv(Race race)
        {
            this.race = race;
            currentRaceData = race.CurrentRaceData;
            fileName = currentRaceData.UploadFile;
        }

        public DataParserSfv(string fileName)
        {
            this.fileName = fileName;
        }

        public void Parse()
        {
            Log.Debug("Parsing SFV '{0}'", fileName);
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(fileName);
            using (StreamReader streamReader = new StreamReader(fileInfo.FullName))
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    if (line == null)
                    {
                        continue;
                    }
                    if ((line [0].Equals(';')) || (line.Length < 10))
                    {
                        continue;
                    }
                    if (line.IndexOf(' ') == -1)
                    {
                        Log.Debug("new ArgumentOutOfRangeException: Line in SFV file should be separated with [SPACE]. Line '{0}'", line);
                        continue;
                    }
                    //[FILENAME][SPACE][CRC32]
                    string[] data = line.Split(' ');
                    string key = data [0];
                    string crc32 = data [1];
                    if (sfvData.ContainsKey(key))
                    {
                        Log.Debug("ArgumentException: Duplicated entry in SFV file [{0}]", key);
                        continue;
                    }
                    if (!IsHex(crc32))
                    {
                        Log.Debug("ArgumentException: Incorrect CRC32 [{0}]. Line '{1}'", crc32, line);
                        continue;
                    }
                    sfvData.Add(key, crc32);
                }
            }
            Log.Debug("sfvData: {0}", SfvDataToString);
        }

        public void Process()
        {
            Log.Debug("Process with SFV");
            TagManager tagManager = new TagManager(race);
            Log.Debug("Create missing files");
            foreach (KeyValuePair<string, string> keyValuePair in sfvData)
            {
                FileInfo.Create0ByteFile(Misc.PathCombine(currentRaceData.DirectoryPath, keyValuePair.Key + Config.FileExtensionMissing));
            }
            race.TotalFilesExpected = sfvData.Count;
            Log.Debug("Total files expected: {0}", race.TotalFilesExpected);
            CreateSfvRaceDataFile();
            Output output = new Output(race);
            output
                .Client(Config.ClientHead)
                .Client(Config.ClientFileNameSfv)
                .Client(Config.ClientFoot);
            Log.Debug("Create INCOMPLETE Symlinks");
            tagManager.CreateTag(currentRaceData.DirectoryPath, output.Format(Config.TagIncomplete));
            tagManager.CreateSymLink(currentRaceData.DirectoryParent, output.Format(Config.TagIncompleteLink));
            if (Config.LogToIoFtpdSfv)
            {
                Log.IoFtpd(output.Format(Config.LogLineIoFtpdSfv));
            }
            if (Config.LogToInternalSfv)
            {
                Log.Internal(output.Format(Config.LogLineInternalSfv));
            }
        }

        protected string SfvDataToString
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (KeyValuePair<string, string> keyValuePair in sfvData)
                {
                    sb.AppendFormat(CultureInfo.InvariantCulture, "[{0}/{1}] ", keyValuePair.Key, keyValuePair.Value);
                }
                return sb.ToString();
            }
        }

        private static bool IsHex(string crc32)
        {
            int output;
            return Int32.TryParse(crc32, NumberStyles.HexNumber, null, out output);
        }

        private void CreateSfvRaceDataFile()
        {
            Log.Debug("CreateSfvRaceDataFile");
            RaceMutex.WaitOne();
            System.IO.FileInfo fileInfo =
                new System.IO.FileInfo(Misc.PathCombine(currentRaceData.DirectoryPath, Config.FileNameRace));
            using (FileStream stream = new FileStream(fileInfo.FullName,
                                                      FileMode.OpenOrCreate,
                                                      FileAccess.ReadWrite,
                                                      FileShare.None))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    writer.Write(race.TotalFilesExpected); //total files expected
                    writer.Write(DateTime.Now.Ticks); //start of race
                    int count = 1;
                    foreach (KeyValuePair<string, string> keyValuePair in sfvData)
                    {
                        stream.Seek(count * 256, SeekOrigin.Begin);
                        writer.Write(keyValuePair.Key); //file name
                        writer.Write(keyValuePair.Value); //CRC32
                        writer.Write(false); //was file already uploaded
                        writer.Write(1); //file Size
                        writer.Write(1); //upload speed
                        writer.Write(String.Empty); //username
                        writer.Write(String.Empty); //groupname
                        count++;
                    }
                    stream.Seek(count * 256, SeekOrigin.Begin);
                    writer.Write("END");
                }
            }
            RaceMutex.ReleaseMutex();
        }

        public Dictionary<string, string> SfvData
        {
            get { return sfvData; }
        }

        private static readonly Mutex RaceMutex = new Mutex(false, "sfvMutex");
        private readonly Dictionary<string, string> sfvData = new Dictionary<string, string>();
        private readonly CurrentRaceData currentRaceData;
        private readonly Race race;
        private readonly string fileName;
    }
}