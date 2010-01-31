#region
using System;
using System.IO;
using System.Threading;

#endregion

namespace jeza.ioFTPD.Framework
{
    public class DataParser : IDataParser
    {
        public DataParser (Race race)
        {
            this.race = race;
            RaceFile = Path.Combine (race.CurrentUploadData.DirectoryPath, Config.FileNameRace);
        }

        public void Parse ()
        {
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(RaceFile);
            RaceMutex.WaitOne();
            using (FileStream stream = new FileStream(fileInfo.FullName,
                                                      FileMode.OpenOrCreate,
                                                      FileAccess.ReadWrite,
                                                      FileShare.None))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    race.TotalFilesExpected = reader.ReadInt32();
                    for (int i = 1; i <= reader.ReadInt32(); i++)
                    {
                        stream.Seek(256 * i, SeekOrigin.Begin);
                        RaceStats raceStats = new RaceStats();
                        raceStats
                            .AddFileName (reader.ReadString())
                            .AddCrc32 (reader.ReadString())
                            .AddFileUploaded (reader.ReadBoolean())
                            .AddFileSize (reader.ReadUInt64())
                            .AddFileSpeed (reader.ReadInt32 ())
                            .AddUserName (reader.ReadString())
                            .AddGroupName (reader.ReadString());
                        race.AddRaceStats (raceStats);
                    }
                }
            }
            RaceMutex.ReleaseMutex();
        }

        public void Process ()
        {
            throw new NotImplementedException ();
        }

        public string RaceFile { get; set;}

        private static readonly Mutex RaceMutex = new Mutex(false, "rarMutex");
        private readonly Race race;
    }
}