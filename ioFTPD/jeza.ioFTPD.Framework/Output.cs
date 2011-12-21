using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using jeza.ioFTPD.Framework.Archive;
using jeza.ioFTPD.Framework.ioFTPD;
using jeza.ioFTPD.Framework.Manager;
using TagLib;
using File = TagLib.File;

namespace jeza.ioFTPD.Framework
{
    public class Output
    {
        public Output()
        {
        }

        public Output(RescanStatsData rescanStatsData,
                      RescanStats rescanStats)
        {
            Console.Write("!buffer off\n");
            this.rescanStatsData = rescanStatsData;
            this.rescanStats = rescanStats;
        }

        public Output(RescanStats rescanStats)
        {
            this.rescanStats = rescanStats;
            rescanStatsData = new RescanStatsData();
        }

        public Output(Race race)
        {
            this.race = race;
        }

        public Output(ArchiveTask archiveTask)
        {
            this.archiveTask = archiveTask;
        }

        public Output WriteLine(string line)
        {
            Console.WriteLine(line);
            return this;
        }

        public Output Write(string line)
        {
            Console.Write(line);
            return this;
        }

        public Output ClientRescan(string line)
        {
            WriteLine(FormatCrc32(line));
            return this;
        }

        public Output Client(string line)
        {
            WriteLine(Format(line));
            return this;
        }

        public Output ClientMp3(string line,
                                File audioInfo)
        {
            WriteLine(Format(line, audioInfo));
            return this;
        }

        public Output ClientStatsUsers(string line,
                                       int maxNumberOfStatsToShow)
        {
            Write(MessageStatsUsers(line, maxNumberOfStatsToShow));
            return this;
        }

        public Output ClientStatsGroups(string line,
                                        int maxNumberOfStatsToShow)
        {
            Write(MessageStatsGroups(line, maxNumberOfStatsToShow));
            return this;
        }

        public string MessageStatsUsers(string line,
                                        int maxNumberOfStatsToShow)
        {
            List<RaceStatsUsers> stats = race.GetUserStats();
            int possition = 1;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < stats.Count; i++)
            {
                if (i >= maxNumberOfStatsToShow)
                {
                    break;
                }
                RaceStatsUsers item = stats [i];
                sb.AppendLine(FormatUserStats(possition, item, line));
                possition++;
            }
            return sb.ToString();
        }

        public string MessageStatsGroups(string line,
                                         int maxNumberOfStatsToShow)
        {
            List<RaceStatsGroups> stats = race.GetGroupStats();
            int possition = 1;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < stats.Count; i++)
            {
                if (i >= maxNumberOfStatsToShow)
                {
                    break;
                }
                RaceStatsGroups item = stats [i];
                sb.AppendLine(FormatGroupStats(possition, item, line));
                possition++;
            }
            return sb.ToString();
        }

        public void LogUserStatsBody(int maxNumber,
                                     LogDestination destination)
        {
            List<RaceStatsUsers> stats = race.GetUserStats();
            int possition = 1;
            for (int i = 0; i < stats.Count; i++)
            {
                if (i >= maxNumber)
                {
                    break;
                }
                RaceStatsUsers item = stats [i];
                switch (destination)
                {
                    case LogDestination.IoFtpdLog:
                        Log.IoFtpd(FormatUserStats(possition, item, Config.LogLineIoFtpdUserStatsBody));
                        break;
                    default:
                        Log.Internal(FormatUserStats(possition, item, Config.LogLineInternalUserStatsBody));
                        break;
                }
                possition++;
            }
        }

        public void LogGroupStatsBody(int maxNumber,
                                      LogDestination destination)
        {
            List<RaceStatsGroups> stats = race.GetGroupStats();
            int possition = 1;
            for (int i = 0; i < stats.Count; i++)
            {
                if (i >= maxNumber)
                {
                    break;
                }
                RaceStatsGroups item = stats [i];
                switch (destination)
                {
                    case LogDestination.IoFtpdLog:
                        Log.IoFtpd(FormatGroupStats(possition, item, Config.LogLineIoFtpdGroupStatsBody));
                        break;
                    default:
                        Log.Internal(FormatGroupStats(possition, item, Config.LogLineInternalGroupStatsBody));
                        break;
                }
                possition++;
            }
        }

        public void LogFirstFileWasUploaded(bool isMp3Race,
                                            File mp3Info)
        {
            if (isMp3Race)
            {
                if (Config.LogToIoFtpdUpdateMp3)
                {
                    Log.IoFtpd(Format(Config.LogLineIoFtpdUpdateMp3, mp3Info));
                }
                if (Config.LogToInternalUpdateMp3)
                {
                    Log.Internal(Format(Config.LogLineInternalUpdateMp3, mp3Info));
                }
            }
            else
            {
                if (Config.LogToIoFtpdUpdate)
                {
                    Log.IoFtpd(Format(Config.LogLineIoFtpdUpdate));
                }
                if (Config.LogToInternalUpdate)
                {
                    Log.Internal(Format(Config.LogLineInternalUpdate));
                }
            }
        }

        public void LogSpeedTest()
        {
            if (Config.LogToIoFtpdSpeedTest)
            {
                Log.IoFtpd(Format(Config.LogLineIoFtpdSpeedTest));
            }
            if (Config.LogToInternalSpeedTest)
            {
                Log.Internal(Format(Config.LogLineInternalSpeedTest));
            }
        }

        public void LogRace(RaceStatsUsers usersRaceStats)
        {
            if (Config.LogToIoFtpdRace)
            {
                Log.IoFtpd(FormatUserStats(1, usersRaceStats, Config.LogLineIoFtpdRace));
            }
            if (Config.LogToInternalRace)
            {
                Log.Internal(FormatUserStats(1, usersRaceStats, Config.LogLineInternalRace));
            }
        }

        public void LogLeadGroup()
        {
            RaceStatsGroups lastLeadGroup = race.LeadGroup;
            RaceStatsGroups newLeadGroup = race.GetLeadGroup();
            if (!lastLeadGroup.GroupName.Equals(newLeadGroup.GroupName))
            {
                race.LeadGroup = newLeadGroup;
                if (Config.LogToIoFtpdLeadGroup)
                {
                    Log.IoFtpd(FormatGroupStats(1, race.LeadGroup, Config.LogLineIoFtpdLeadGroup));
                }
                if (Config.LogToInternalLeadGroup)
                {
                    Log.Internal(FormatGroupStats(1, race.LeadGroup, Config.LogLineInternalLeadGroup));
                }
            }
        }

        public void LogLeadUser()
        {
            RaceStatsUsers lastLeadUser = race.LeadUser;
            RaceStatsUsers newLeadUser = race.GetLeadUser();
            if (!lastLeadUser.UserName.Equals(newLeadUser.UserName))
            {
                race.LeadUser = newLeadUser;
                if (Config.LogToIoFtpdLeadUser)
                {
                    Log.IoFtpd(FormatUserStats(1, race.LeadUser, Config.LogLineIoFtpdLeadUser));
                }
                if (Config.LogToInternalRace)
                {
                    Log.Internal(FormatUserStats(1, race.LeadUser, Config.LogLineInternalLeadUser));
                }
            }
        }

        public void LogHalfway()
        {
            if (Config.LogToIoFtpdHalfway && race.TotalFilesExpected > Config.LogToIoFtpdHalfwayMinFiles)
            {
                Log.IoFtpd(Format(Config.LogLineIoFtpdHalfway));
            }
            if (Config.LogToInternalHalfway && race.TotalFilesExpected > Config.LogToInternalHalfwayMinFiles)
            {
                Log.Internal(Format(Config.LogLineInternalHalfway));
            }
        }

        public void LogCompleteStats()
        {
            Log.Debug("LogCompleteStats");
            if (Config.LogToIoFtpdComplete)
            {
                Log.IoFtpd(Format(Config.LogLineIoFtpdComplete));
            }
            if (Config.LogToIoFtpdUserStatsHead)
            {
                Log.IoFtpd(Format(Config.LogLineIoFtpdUserStatsHead));
            }
            if (Config.LogToIoFtpdUserStatsBody)
            {
                LogUserStatsBody(Config.LogToIoFtpdUserStatsBodyMaxNumber, LogDestination.IoFtpdLog);
            }
            if (Config.LogToIoFtpdGroupStatsHead)
            {
                Log.IoFtpd(Format(Config.LogLineIoFtpdGroupStatsHead));
            }
            if (Config.LogToIoFtpdGroupStatsBody)
            {
                LogGroupStatsBody(Config.LogToIoFtpdGroupStatsBodyMaxNumber, LogDestination.IoFtpdLog);
            }

            if (Config.LogToInternalComplete)
            {
                Log.Internal(Format(Config.LogLineInternalComplete));
            }
            if (Config.LogToInternalUserStatsHead)
            {
                Log.Internal(Format(Config.LogLineInternalUserStatsHead));
            }
            if (Config.LogToInternalUserStatsBody)
            {
                LogUserStatsBody(Config.LogToInternalUserStatsBodyMaxNumber, LogDestination.InternalLog);
            }
            if (Config.LogToInternalGroupStatsHead)
            {
                Log.Internal(Format(Config.LogLineInternalGroupStatsHead));
            }
            if (Config.LogToInternalGroupStatsBody)
            {
                LogGroupStatsBody(Config.LogToInternalGroupStatsBodyMaxNumber, LogDestination.InternalLog);
            }
        }

        private static bool MinimumLength(string line)
        {
            if ((line == null) || (line.Length < 2))
            {
                return true;
            }
            return false;
        }

        public string FormatUserStats
            (int possition,
             RaceStatsUsers stats,
             string line)
        {
            string formatUserStats = MinimumLength(line) || stats == null || race == null
                                         ? line
                                         : String.Format(new MyFormat(), line
                                                         , possition // {0}
                                                         , race.CurrentRaceData == null ? "" : race.CurrentRaceData.DirectoryName ?? "" // {1}
                                                         , stats.UserName // {2}
                                                         , stats.GroupName // {3}
                                                         , race.CurrentRaceData == null ? "" : race.CurrentRaceData.UploadVirtualPath ?? "" // {4}
                                                         , race.TotalFilesExpected // {5}
                                                         , stats.Speed // {6}
                                                         , stats.FilesUplaoded // {7}
                                                         , stats.BytesUplaoded.FormatSize() // {8}
                                                         , Constants.CodeIrcColor // {9}
                                                         , Constants.CodeIrcBold // {10}
                                                         , Constants.CodeIrcUnderline // {11}
                                                         , Constants.CodeNewLine); // {12}
            Log.Debug("FormatUserStats: " + formatUserStats);
            return formatUserStats;
        }

        public string FormatGroupStats
            (int possition,
             RaceStatsGroups stats,
             string line)
        {
            string formatGroupStats = MinimumLength(line) || stats == null || race == null
                                          ? line
                                          : String.Format(new MyFormat(), line
                                                          , possition // {0}
                                                          , race.CurrentRaceData == null ? "" : race.CurrentRaceData.DirectoryName ?? "" // {1}
                                                          , "UserName" // {2}
                                                          , stats.GroupName // {3}
                                                          , race.CurrentRaceData == null ? "" : race.CurrentRaceData.UploadVirtualPath ?? "" // {4}
                                                          , stats.Speed // {5}
                                                          , stats.FilesUplaoded // {6}
                                                          , stats.BytesUplaoded.FormatSize() // {7}
                                                          , Constants.CodeIrcColor // {8}
                                                          , Constants.CodeIrcBold // {9}
                                                          , Constants.CodeIrcUnderline // {10}
                                                          , Constants.CodeNewLine); // {11}
            Log.Debug("FormatGroupStats: " + formatGroupStats);
            return formatGroupStats;
        }

        public string FormatImdb
            (string line,
             dynamic imdbInfo)
        {
            string formatImdb = MinimumLength(line) || imdbInfo == null || race == null
                                    ? line
                                    : String.Format(new MyFormat(), line
                                                    , race.CurrentRaceData == null ? "" : race.CurrentRaceData.FileName ?? "" // {0}
                                                    , race.CurrentRaceData == null ? "" : race.CurrentRaceData.DirectoryName ?? "" // {1}
                                                    , race.CurrentRaceData == null ? "" : race.CurrentRaceData.UserName ?? "" // {2}
                                                    , race.CurrentRaceData == null ? "" : race.CurrentRaceData.GroupName ?? "" // {3}
                                                    , race.CurrentRaceData == null ? "" : race.CurrentRaceData.UploadVirtualPath ?? "" // {4}
                                                    , imdbInfo.Title ?? "" // {5}
                                                    , imdbInfo.Year ?? "" // {6}
                                                    , imdbInfo.Rated ?? "" // {7}
                                                    , imdbInfo.Released ?? "" // {8}
                                                    , imdbInfo.Genre ?? "" // {9}
                                                    , imdbInfo.Director ?? "" // {10}
                                                    , imdbInfo.Writer ?? "" // {11}
                                                    , imdbInfo.Actors ?? "" // {12}
                                                    , imdbInfo.Plot ?? "" // {13}
                                                    , imdbInfo.Poster ?? "" // {14}
                                                    , imdbInfo.Runtime ?? "" // {15}
                                                    , imdbInfo.Rating ?? "" // {16}
                                                    , imdbInfo.Votes ?? "" // {17}
                                                    , imdbInfo.Id ?? "" // {18}
                                                    , Constants.CodeIrcColor // {19}
                                                    , Constants.CodeIrcBold // {20}
                                                    , Constants.CodeIrcUnderline // {21}
                                                    , Constants.CodeNewLine); // {22}
            Log.Debug("formatImdb: " + formatImdb);
            return formatImdb;
        }

        public string Format(string line,
                             File audioInfo = null)
        {
            if (MinimumLength(line) || race == null)
            {
                return line;
            }
            string format = String.Format(new MyFormat(), line
                                          , race.CurrentRaceData == null ? "" : race.CurrentRaceData.FileName ?? "" // {0}
                                          , race.CurrentRaceData == null ? "" : race.CurrentRaceData.DirectoryName ?? "" // {1}
                                          , race.CurrentRaceData == null ? "" : race.CurrentRaceData.UserName ?? "" // {2}
                                          , race.CurrentRaceData == null ? "" : race.CurrentRaceData.GroupName ?? "" // {3}
                                          , race.CurrentRaceData == null ? "" : race.CurrentRaceData.UploadVirtualPath ?? "" // {4}
                                          , race.TotalFilesExpected // {5}
                                          , race.TotalFilesUploaded // {6}
                                          , race.TotalBytesUploaded // {7}
                                          , race.TotalMegaBytesUploaded // {8}
                                          , race.TotalBytesUploadedFormated // {9}
                                          , (race.TotalBytesUploaded * (UInt64) race.TotalFilesExpected).FormatSize() // {10} total bytes expected
                                          , race.TotalAvarageSpeed // {11}
                                          , race.TotalUsersRacing // {12}
                                          , race.TotalGroupsRacing // {13}
                                          , race.ProgressBar // {14}
                                          , race.PercentComplete // {15}
                                          , Constants.CodeIrcColor // {16}
                                          , Constants.CodeIrcBold // {17}
                                          , Constants.CodeIrcUnderline // {18}
                                          , Constants.CodeNewLine // {19}
                                          , audioInfo == null ? "" : audioInfo.Tag.FirstPerformer // {20}
                                          , audioInfo == null ? "" : audioInfo.Tag.Album // {21}
                                          , audioInfo == null ? "" : audioInfo.Tag.Title // {22}
                                          , audioInfo == null ? "" : audioInfo.Tag.FirstGenre // {23}
                                          , audioInfo == null ? 0 : audioInfo.Tag.Year // {24}
                                          , audioInfo == null ? 0 : audioInfo.Tag.Track //{25}
                                          , race.CurrentRaceData == null ? 0 : race.CurrentRaceData.Speed // {26}
                                          , audioInfo == null ? 0 : audioInfo.Properties.AudioBitrate // {27}
                                          , audioInfo == null ? 0 : audioInfo.Properties.AudioChannels // {28}
                                          , audioInfo == null ? 0 : audioInfo.Properties.AudioSampleRate // {29}
                                          , audioInfo == null ? 0 : audioInfo.Properties.BitsPerSample // {30}
                                          , audioInfo == null ? "" : audioInfo.Properties.Description // {31}
                                          , audioInfo == null ? "" : audioInfo.Properties.MediaTypes.ToString("g") // {32}
                                          , audioInfo == null || audioInfo.Properties.Codecs == null ? "" : GetCodecList(audioInfo.Properties.Codecs) // {33}
                                          , audioInfo == null ? "" : audioInfo.Properties.Duration.FormatTimeSpan() // {34}
                                          , race.CurrentRaceData == null ? "" : race.CurrentRaceData.LinkImdb ?? "") // {35}
                ;
            Log.Debug("Format: " + format);
            return format;
        }

        public string FormatNone(string line)
        {
            if (MinimumLength(line))
            {
                return line;
            }
            string format = String.Format(new MyFormat(), line
                                          , Constants.CodeIrcColor // {0}
                                          , Constants.CodeIrcBold // {1}
                                          , Constants.CodeIrcUnderline // {2}
                                          , Constants.CodeNewLine); // {3}
            Log.Debug("FormatNone: " + format);
            return format;
        }

        public string FormatTrial(string line,
                                  TrialQuota.Trial trial)
        {
            if (MinimumLength(line) || trial == null)
            {
                return line;
            }
            DateTime dateTime = new DateTime(DateTime.UtcNow.Ticks);
            int days = (dateTime - trial.DateAdded).Days;
            UInt64 usersAllUp = UserManager.GetStats(trial.Uid, UploadStats.AllUp);
            string formatTrial = String.Format(new MyFormat(), line
                                               , trial.Uid  //{0}
                                               , UserManager.UidToUsername(trial.Uid)  //{1}
                                               , UserManager.GetUser(trial.Uid).GroupName  //{2}
                                               , UserManager.GetUser(trial.Uid).Tag  //{3}
                                               , trial.DateAdded  //{4}
                                               , trial.Period  //{5}
                                               , trial.QuotaToPass  //{6}
                                               , trial.StartAllUp.FormatSize()  //{7}
                                               , days  //{8}
                                               , usersAllUp.FormatSize()  //{9}
                                               , (usersAllUp - trial.StartAllUp).FormatSize()  //{10}
                                               , Constants.CodeIrcColor  //{11}
                                               , Constants.CodeIrcBold  //{12}
                                               , Constants.CodeIrcUnderline  //{13}
                                               , Constants.CodeNewLine);  //{14}
            Log.Debug("FormatTrial: " + formatTrial);
            return formatTrial;
        }

        private static string GetCodecList(IEnumerable<ICodec> codecs)
        {
            const char separator = ',';
            StringBuilder sb = new StringBuilder();
            foreach (ICodec codec in codecs)
            {
                sb.Append(codec.Description).Append(separator);
            }
            return sb.ToString().TrimEnd(separator);
        }

        public string FormatArchive(string line,
                                    DirectoryInfo directoryInfo)
        {
            string formatArchive = MinimumLength(line) || archiveTask == null || directoryInfo == null
                                     ? line
                                     : String.Format(new MyFormat(), line
                                                     , directoryInfo.Name // {0}
                                                     , archiveTask.SourceVirtual ?? "" // {1}
                                                     , archiveTask.DestinationVirtual ?? ""); // {2}
            Log.Debug("FormatArchive: " + formatArchive);
            return formatArchive;
        }

        public string FormatCrc32(string line)
        {
            string formatCrc32 = MinimumLength(line) || rescanStatsData == null || rescanStats == null
                                     ? line
                                     : String.Format(new MyFormat(), line
                                                     , rescanStatsData.FileName // {0}
                                                     , rescanStatsData.ExpectedCrc32Value // {1}
                                                     , rescanStatsData.ActualCrc32Value // {2}
                                                     , rescanStatsData.Status // {3}
                                                     , rescanStats.TotalFiles // {4}
                                                     , rescanStats.MissingFiles // {5}
                                                     , rescanStats.OkFiles // {6}
                                                     , rescanStats.FailedFiles // {7}
                                                     , Constants.CodeNewLine    //{8}
                                                     , rescanStats.TotalBytesUploaded.FormatSize()   //{9}
                                                     , rescanStatsData.ReleaseName //{10}
                                                     , rescanStats.TotalFiles == 0 ? 0 : (rescanStats.OkFiles * 100 / rescanStats.TotalFiles)); //{11}
            Log.Debug("FormatCrc32: " + formatCrc32);
            return formatCrc32;
        }

        public string FormatDupe(string line,
                                 DataBaseDupe dataBaseDupe)
        {
            string formatDupe = MinimumLength(line) || dataBaseDupe == null
                                    ? line
                                    : String.Format(new MyFormat(), line
                                                    , dataBaseDupe.Id // {0}
                                                    , dataBaseDupe.UserName // {1}
                                                    , dataBaseDupe.GroupName // {2}
                                                    , dataBaseDupe.DateTime // {3}
                                                    , dataBaseDupe.PathReal // {4}
                                                    , dataBaseDupe.PathVirtual // {5}
                                                    , dataBaseDupe.ReleaseName // {6}
                                                    , dataBaseDupe.Nuked // {7}
                                                    , dataBaseDupe.NukedReason // {8}
                                                    , dataBaseDupe.Wiped // {9}
                                                    , dataBaseDupe.WipedReason // {10}
                                                    , Constants.CodeNewLine //{11}
                                                    , Constants.CodeIrcColor // {12}
                                                    , Constants.CodeIrcBold // {13}
                                                    , Constants.CodeIrcUnderline); // {14}
            Log.Debug("FormatDupe: " + formatDupe);
            return formatDupe;
        }

        public string FormatWeeklyTask(string line,
                                       WeeklyTask weeklyTask)
        {
            string formatWeeklyTask = MinimumLength(line) || weeklyTask == null
                                          ? line
                                          : String.Format(new MyFormat(), line
                                                          , weeklyTask.WeeklyTaskStatus // {0}
                                                          , weeklyTask.Uid // {1}
                                                          , weeklyTask.Username // {2}
                                                          , weeklyTask.Creator // {3}
                                                          , weeklyTask.Credits.FormatSize() // {4}
                                                          , weeklyTask.DateTimeStart // {5}
                                                          , weeklyTask.DateTimeStop // {6}
                                                          , weeklyTask.Notes // {7}
                                                          , Constants.CodeNewLine); //{8}
            Log.Debug("FormatWeeklyTask: " + formatWeeklyTask);
            return formatWeeklyTask;
        }

        public string FormatRequestTask(string line,
                                        RequestTask requestTask)
        {
            string formatRequestTask = MinimumLength(line) || requestTask == null
                                           ? line
                                           : String.Format(new MyFormat(), line
                                                           , requestTask.Name // {0}
                                                           , requestTask.DateAdded.ToString("yyyy-MM-dd") // {1}
                                                           , requestTask.Username // {2}
                                                           , Constants.CodeNewLine //{3}
                                                           , requestTask.Groupname); //{4}
            Log.Debug("FormatRequestTask: " + formatRequestTask);
            return formatRequestTask;
        }

        private readonly Race race;
        private readonly RescanStatsData rescanStatsData;
        private readonly RescanStats rescanStats;
        private readonly ArchiveTask archiveTask;
    }
}