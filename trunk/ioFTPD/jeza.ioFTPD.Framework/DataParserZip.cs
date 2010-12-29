using System;
using System.IO;
using System.Threading;

namespace jeza.ioFTPD.Framework
{
    public class DataParserZip : IDataParser
    {
        public DataParserZip(Race race)
        {
            this.race = race;
            RaceFile = Path.Combine(race.CurrentUploadData.DirectoryPath, Config.FileNameRace);
        }

        public void Parse()
        {
            race.ClearRaceStats();
            RaceMutex.WaitOne();
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(RaceFile);
            using (FileStream stream = new FileStream(fileInfo.FullName,
                                                      FileMode.OpenOrCreate,
                                                      FileAccess.ReadWrite,
                                                      FileShare.None))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    race.TotalFilesExpected = reader.ReadInt32();
                    for (int i = 1; i <= race.TotalFilesExpected; i++)
                    {
                        stream.Seek(256 * i, SeekOrigin.Begin);
                        RaceStats raceStats = new RaceStats();
                        raceStats
                            .AddFileName(reader.ReadString())
                            .AddCrc32(reader.ReadString())
                            .AddFileUploaded(reader.ReadBoolean())
                            .AddFileSize(reader.ReadUInt64())
                            .AddFileSpeed(reader.ReadInt32())
                            .AddUserName(reader.ReadString())
                            .AddGroupName(reader.ReadString());
                        race.AddRaceStats(raceStats);
                    }
                }
            }
            RaceMutex.ReleaseMutex();
            Log.Debug("Current Race Stats : {0}", race.GetRaceStats);
        }

        public void Process()
        {
            Log.Debug("DataParserZip.Process()");
            UpdateRaceData();
            Parse();
            FileInfo fileInfo = new FileInfo();
            fileInfo.DeleteFile(race.CurrentUploadData.DirectoryPath,
                                race.CurrentUploadData.FileName + Config.FileExtensionMissing);
            fileInfo.DeleteFilesThatStartsWith(race.CurrentUploadData.DirectoryPath, Config.TagCleanUpString);
            Output output = new Output(race);
            output
                .Client(Config.ClientHead)
                .Client(Config.ClientFileNameOk);
            output
                .Client(Config.ClientStatsUsersHead)
                .ClientStatsUsers(Config.ClientStatsUsers)
                .Client(Config.ClientStatsGroupsHead)
                .ClientStatsGroups(Config.ClientStatsGroups)
                .Client(Config.ClientFootProgressBar);
            TagManager tagManager = new TagManager(race);
            if (race.IsRaceComplete)
            {
                tagManager.CreateTag(race.CurrentUploadData.DirectoryPath, output.Format(Config.TagComplete));
                tagManager.DeleteSymlink(race.CurrentUploadData.DirectoryParent, output.Format(Config.TagIncompleteLink));
            }
            else
            {
                tagManager.CreateTag(race.CurrentUploadData.DirectoryPath, output.Format(Config.TagIncomplete));
            }
            race.IsValid = true;
        }

        private void UpdateRaceData()
        {
            Log.Debug("UpdateRaceData");
            RaceMutex.WaitOne();
            int position = 1;
            System.IO.FileInfo fileInfo =
                new System.IO.FileInfo(Path.Combine(race.CurrentUploadData.DirectoryPath, Config.FileNameRace));
            using (FileStream stream = new FileStream(fileInfo.FullName,
                                                      FileMode.Open,
                                                      FileAccess.Read,
                                                      FileShare.None))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    for (int i = 1; i <= race.TotalFilesExpected; i++)
                    {
                        stream.Seek(256 * i, SeekOrigin.Begin);
                        string fileName = reader.ReadString();
                        if (String.IsNullOrEmpty(fileName))
                        {
                            position = i;
                        }
                        if (fileName.Equals(race.CurrentUploadData.FileName))
                        {
                            position = i;
                            break;
                        }
                    }
                }
            }
            using (FileStream stream = new FileStream(fileInfo.FullName,
                                                      FileMode.Open,
                                                      FileAccess.Write,
                                                      FileShare.None))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    stream.Seek(position * 256, SeekOrigin.Begin);
                    writer.Write(race.CurrentUploadData.FileName);
                    writer.Write(race.CurrentUploadData.UploadCrc);
                    writer.Write(true);
                    writer.Write(race.CurrentUploadData.FileSize); //file Size
                    writer.Write(race.CurrentUploadData.Speed); //upload speed
                    writer.Write(race.CurrentUploadData.UserName); //username
                    writer.Write(race.CurrentUploadData.GroupName); //groupname
                }
            }
            RaceMutex.ReleaseMutex();
        }

        public string RaceFile { get; set; }

        private static readonly Mutex RaceMutex = new Mutex(false, "raceMutexZip");
        private readonly Race race;
    }
}