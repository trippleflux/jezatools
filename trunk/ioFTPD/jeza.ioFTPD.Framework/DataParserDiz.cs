using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace jeza.ioFTPD.Framework
{
    public class DataParserDiz : IDataParser
    {
        public DataParserDiz(Race race)
        {
            this.race = race;
            currentUploadData = race.CurrentUploadData;
            fileName = "file_id.diz";
        }

        public void Parse()
        {
            RaceMutex.WaitOne();
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(Path.Combine(race.CurrentUploadData.DirectoryPath, fileName));
            Log.Debug("Parsing: '{0}'", fileInfo.FullName);
            using (StreamReader streamReader = new StreamReader(fileInfo.FullName))
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    Log.Debug("line: '{0}'", line);
                    line = Regex.Replace(line, @"x|o", "0");
                    line = Regex.Replace(line, @"\[|\]|\(|\)|\<|\>|\$|\""|\'|\!|\%|\&|\?|\:|;|_|-|\.|\,|[0-9]{1,4}/[0-9]{1,4}/[0-9]{1,4}", " ");
                    Log.Debug("Regex.Replace '{0}'", line);
                    if (line == null)
                    {
                        continue;
                    }
                    if (line.IndexOf('/') == -1)
                    {
                        continue;
                    }
                    //regsub -all {\[|\]|\(|\)|\<|\>|\$|\"|\'|\!|\%|\&|\?|\:|;|_|-|\.|\,|[0-9]{1,4}/[0-9]{1,4}/[0-9]{1,4}} $FILEin { } FILEin
                    string[] split = line.Split('/');
                    race.TotalFilesExpected = Misc.String2Number(split[1]);
                    break;
                }
            }
            RaceMutex.ReleaseMutex();
            Log.Debug("Total Files Expected: {0}", race.TotalFilesExpected);
        }

        public void Process()
        {
            TagManager tagManager = new TagManager(race);
            CreateZipRaceDataFile();
            Output output = new Output(race);
            //output
            //    .Client(Config.ClientHead)
            //    .Client(Config.ClientFileName)
            //    .Client(Config.ClientFoot);
            tagManager.CreateTag(currentUploadData.DirectoryPath, output.Format(Config.TagIncomplete));
            tagManager.CreateSymLink(currentUploadData.DirectoryParent, output.Format(Config.TagIncompleteLink));
        }

        private void CreateZipRaceDataFile()
        {
            Log.Debug("CreateZipRaceDataFile");
            RaceMutex.WaitOne();
            System.IO.FileInfo fileInfo =
                new System.IO.FileInfo(Path.Combine(currentUploadData.DirectoryPath, Config.FileNameRace));
            using (FileStream stream = new FileStream(fileInfo.FullName,
                                                      FileMode.OpenOrCreate,
                                                      FileAccess.ReadWrite,
                                                      FileShare.None))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    writer.Write(race.TotalFilesExpected);
                    int count = 1;
                    for (int i = 1; i < race.TotalFilesExpected + 1; i++)
                    {
                        stream.Seek(i * 256, SeekOrigin.Begin);
                        writer.Write(String.Empty); //file name
                        writer.Write(String.Empty); //CRC32
                        writer.Write(false); //was file already uploaded
                        writer.Write(1); //file Size
                        writer.Write(1); //upload speed
                        writer.Write(String.Empty); //username
                        writer.Write(String.Empty); //groupname
                        count = i;
                    }
                    stream.Seek(++count * 256, SeekOrigin.Begin); 
                    writer.Write("END");
                }
            }
            RaceMutex.ReleaseMutex();
        }

        private static readonly Mutex RaceMutex = new Mutex(false, "dizMutex");
        private readonly CurrentUploadData currentUploadData;
        private readonly Race race;
        private readonly string fileName;
    }
}