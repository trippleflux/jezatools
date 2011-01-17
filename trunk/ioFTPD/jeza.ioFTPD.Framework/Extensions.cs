using System;
using System.IO;
using System.Text;
using System.Threading;

namespace jeza.ioFTPD.Framework
{
    public static class Extensions
    {
        /// <summary>
        /// String Formats the submited input arguments.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public static string FormatArgs(this IData data, string[] args)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in args)
            {
                sb.AppendFormat("{0} ", s);
            }
            return sb.ToString().Trim();
        }

        /// <summary>
        /// Reads the race data.
        /// </summary>
        /// <param name="dataParser">The data parser.</param>
        /// <param name="race">The race.</param>
        public static void ReadRaceData(this IDataParser dataParser, Race race)
        {
            race.ClearRaceStats();
            RaceMutex.WaitOne();
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(race.RaceFile);
            using (FileStream stream = new FileStream(fileInfo.FullName,
                                                      FileMode.OpenOrCreate,
                                                      FileAccess.ReadWrite,
                                                      FileShare.None))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    race.TotalFilesExpected = reader.ReadInt32();
                    race.Start = reader.ReadUInt64();
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

        /// <summary>
        /// Updates the race data.
        /// </summary>
        /// <param name="dataParser">The data parser.</param>
        /// <param name="race">The race.</param>
        public static void UpdateRaceData(this IDataParser dataParser, Race race)
        {
            Log.Debug("UpdateRaceData");
            RaceMutex.WaitOne();
            int position = 0;
            string fileName = String.Empty;
            string fileCrc = String.Empty;
            bool isZip = true;
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(race.RaceFile);
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
                        fileName = reader.ReadString();
                        if (String.IsNullOrEmpty(fileName))
                        {
                            position = i;
                        }
                        else
                        {
                            if (fileName.Equals(race.CurrentUploadData.FileName))
                            {
                                fileCrc = reader.ReadString();
                                position = i;
                                isZip = false;
                                break;
                            }
                        }
                    }
                } 
            }
            if (position > 0)
            {
                using (FileStream stream = new FileStream(fileInfo.FullName,
                                                          FileMode.Open,
                                                          FileAccess.Write,
                                                          FileShare.None))
                {
                    using (BinaryWriter writer = new BinaryWriter(stream))
                    {
                        stream.Seek(position * 256, SeekOrigin.Begin);
                        writer.Write(isZip ? race.CurrentUploadData.FileName : fileName);
                        writer.Write(isZip ? race.CurrentUploadData.UploadCrc : fileCrc);
                        writer.Write(true);
                        writer.Write(race.CurrentUploadData.FileSize); //file Size
                        writer.Write(race.CurrentUploadData.Speed); //upload speed
                        writer.Write(race.CurrentUploadData.UserName); //username
                        writer.Write(race.CurrentUploadData.GroupName); //groupname
                    }
                }
            }
            RaceMutex.ReleaseMutex();
        }

        /// <summary>
        /// Processes with the race data (Client output, complete/incompletetags creating/deletion...).
        /// </summary>
        /// <param name="dataParser">The data parser.</param>
        /// <param name="race">The race.</param>
        public static void ProcessRaceData(this IDataParser dataParser, Race race)
        {
            FileInfo fileInfo = new FileInfo();
            fileInfo.DeleteFile(race.CurrentUploadData.DirectoryPath,
                                race.CurrentUploadData.FileName + Config.FileExtensionMissing);
            fileInfo.DeleteFilesThatStartsWith(race.CurrentUploadData.DirectoryPath, Config.TagCleanUpString);
            Output output = new Output(race);
            output
                .Client(Config.ClientHead)
                .Client(Config.ClientFileNameOk);
            bool isMp3Race = IsMp3Race(race);
            if (isMp3Race)
            {
                output
                    .Client(Config.ClientMp3InfoHead)
                    .ClientMp3(Config.ClientMp3Info);
            }
            output
                .Client(Config.ClientStatsUsersHead)
                .ClientStatsUsers(Config.ClientStatsUsers, Config.MaxNumberOfUserStats)
                .Client(Config.ClientStatsGroupsHead)
                .ClientStatsGroups(Config.ClientStatsGroups, Config.MaxNumberOfGroupStats)
                .Client(Config.ClientFootProgressBar);
            TagManager tagManager = new TagManager(race);
            if (race.IsRaceComplete)
            {
                fileInfo.DeleteFilesThatStartsWith(race.CurrentUploadData.DirectoryPath, Config.TagCleanUpString);
                tagManager.CreateTag(race.CurrentUploadData.DirectoryPath, output.Format(isMp3Race ? Config.TagCompleteMp3 : Config.TagComplete));
                tagManager.DeleteSymlink(race.CurrentUploadData.DirectoryParent, output.Format(Config.TagIncompleteLink));

                if (Config.WriteStatsToMesasageFileWhenComplete)
                {
                    WriteStatsToMesasageFile(race, isMp3Race);
                }
                output.LogCompleteStats();
            }
            else
            {
                tagManager.CreateTag(race.CurrentUploadData.DirectoryPath, output.Format(Config.TagIncomplete));
                if (Config.WriteStatsToMesasageFileWhenRace)
                {
                    WriteStatsToMesasageFile(race, isMp3Race);
                }
                if (race.TotalFilesUploaded == 1)
                {
                    output.LogFirstFileWasUploaded(isMp3Race);
                }
                else
                {
                    if(race.TotalUsersRacing > 1)
                    {
                        RaceStatsUsers usersRaceStats = race.UserUploadedFirstFile();
                        if (usersRaceStats != null)
                        {
                            output.LogRace(usersRaceStats);
                        }
                        output.LogLeadUser();
                        output.LogLeadGroup();
                    }
                }
                if (race.TotalFilesExpected / 2 == race.TotalFilesUploaded)
                {
                    output.LogHalfway();
                }
            }
            race.IsValid = true;
        }
        
        /// <summary>
        /// Writes the stats to ioFTPD message file <see cref="Config.FileNameIoFtpdMessage"/>.
        /// </summary>
        /// <param name="race">The race.</param>
        /// <param name="isMp3Race">if set to <c>true</c> [is MP3 race].</param>
        public static void WriteStatsToMesasageFile(Race race, bool isMp3Race)
        {
            MessageMutex.WaitOne();
            Log.Debug("WriteStatsToMesasageFile");
            System.IO.FileInfo fileInfo =
                new System.IO.FileInfo(Path.Combine(race.CurrentUploadData.DirectoryPath, Config.FileNameIoFtpdMessage));
            using (FileStream fileStream = new FileStream(fileInfo.FullName,
                                                          FileMode.OpenOrCreate,
                                                          FileAccess.ReadWrite,
                                                          FileShare.None))
            {
                using (TextWriter textWriter = new StreamWriter(fileStream))
                {
                    Output output = new Output(race);
                    if (isMp3Race)
                    {
                        textWriter.WriteLine(output.FormatMp3(Config.MessageMp3InfoHead));
                        textWriter.WriteLine(output.FormatMp3(Config.MessageMp3Info));
                    }
                    textWriter.WriteLine(output.Format(Config.MessageStatsUsersHead));
                    textWriter.Write(output.MessageStatsUsers(Config.MessageStatsUsers, Config.MaxNumberOfUserStats));
                    textWriter.WriteLine(output.Format(Config.MessageStatsGroupsHead));
                    textWriter.Write(output.MessageStatsGroups(Config.MessageStatsGroups, Config.MaxNumberOfGroupStats));
                    textWriter.WriteLine(output.Format(Config.MessageFoot));
                }
            }
            MessageMutex.ReleaseMutex();
        }

        /// <summary>
        /// Determines whether current race is race with MP3 files.
        /// </summary>
        /// <param name="race">The race.</param>
        /// <returns>
        /// 	<c>true</c> if [is MP3 race] [the specified data parser]; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsMp3Race(Race race)
        {
            return race.CurrentUploadData.RaceType == RaceType.Mp3;
        }

        private static readonly Mutex MessageMutex = new Mutex(false, "messageMutex");
        private static readonly Mutex RaceMutex = new Mutex(false, "raceMutex");
    }
}