#region
using System;
using System.Collections.Generic;
using System.Text;
using TagLib;
using File = System.IO.File;

#endregion

namespace jeza.ioFTPD.Framework
{
    public class Output
    {
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
        }

        public Output(Race race)
        {
            this.race = race;
        }

        public Output ClientRescan(string line)
        {
            Console.WriteLine(FormatCrc32(line));
            return this;
        }

        public Output Client(string line)
        {
            Console.WriteLine(Format(line));
            return this;
        }

        public Output ClientMp3(string line)
        {
            Console.WriteLine(Format(line));
            return this;
        }

        public Output ClientStatsUsers(string line,
                                       int maxNumberOfStatsToShow)
        {
            Console.Write(MessageStatsUsers(line, maxNumberOfStatsToShow));
            return this;
        }

        public Output ClientStatsGroups(string line,
                                        int maxNumberOfStatsToShow)
        {
            Console.Write(MessageStatsGroups(line, maxNumberOfStatsToShow));
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

        public void LogFirstFileWasUploaded(bool isMp3Race)
        {
            if (isMp3Race)
            {
                if (Config.LogToIoFtpdUpdateMp3)
                {
                    Log.IoFtpd(Format(Config.LogLineIoFtpdUpdateMp3));
                }
                if (Config.LogToInternalUpdateMp3)
                {
                    Log.Internal(Format(Config.LogLineInternalUpdateMp3));
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

        private static bool NotFormated(string line)
        {
            if ((line == null) || (line.IndexOf(SplitChar) == -1))
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
            if (MinimumLength(line))
            {
                return "";
            }
            if (NotFormated(line))
            {
                return line;
            }
            string[] sections = line.Split(SplitChar);
            string text = sections [0];
            string[] args = sections [1].Split(' ');
            int count = args.Length;
            for (int i = 0; i < count; i++)
            {
                string arg = args [i].ToLowerInvariant();
                switch (arg)
                {
                    case "possition":
                    {
                        args [i] = possition.ToString();
                        break;
                    }
                    case "username":
                    {
                        args [i] = stats.UserName;
                        break;
                    }
                    case "groupname":
                    {
                        args [i] = stats.GroupName;
                        break;
                    }
                    case "kilobytesuploaded":
                    {
                        args [i] = (stats.BytesUplaoded / 1024).ToString();
                        break;
                    }
                    case "megabytesuploaded":
                    {
                        args [i] = (stats.BytesUplaoded / 1024 * 1024).ToString();
                        break;
                    }
                    case "gigabytesuploaded":
                    {
                        args [i] = (stats.BytesUplaoded / 1024 * 1024 * 1204).ToString();
                        break;
                    }
                    case "formatbytesuploaded":
                    {
                        args [i] = stats.BytesUplaoded.FormatSize();
                        break;
                    }
                    case "averagespeed":
                    {
                        args [i] = stats.Speed.ToString();
                        break;
                    }
                    case "filesuploaded":
                    {
                        args [i] = stats.FilesUplaoded.ToString();
                        break;
                    }
                    case "uploadvirtualpath":
                    {
                        args [i] = race.CurrentRaceData.UploadVirtualPath;
                        break;
                    }
                    case "releasename":
                    {
                        args [i] = race.CurrentRaceData.DirectoryName;
                        break;
                    }
                    case "irccolor":
                    {
                        args [i] = CodeIrcColor;
                        break;
                    }
                    case "ircbold":
                    {
                        args [i] = CodeIrcBold;
                        break;
                    }
                    case "ircunderline":
                    {
                        args [i] = CodeIrcUnderline;
                        break;
                    }
                    case "newline":
                    {
                        args [i] = codeNewLine;
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }
            text = String.Format(new MyFormat(), text, args);
            return text;
        }

        public string FormatGroupStats
            (int possition,
             RaceStatsGroups stats,
             string line)
        {
            if (MinimumLength(line))
            {
                return "";
            }
            if (NotFormated(line))
            {
                return line;
            }
            string[] sections = line.Split(SplitChar);
            string text = sections [0];
            string[] args = sections [1].Split(' ');
            int count = args.Length;
            for (int i = 0; i < count; i++)
            {
                string arg = args [i].ToLowerInvariant();
                switch (arg)
                {
                    case "possition":
                    {
                        args [i] = possition.ToString();
                        break;
                    }
                    case "groupname":
                    {
                        args [i] = stats.GroupName;
                        break;
                    }
                    case "kilobytesuploaded":
                    {
                        args [i] = (stats.BytesUplaoded / 1024).ToString();
                        break;
                    }
                    case "megabytesuploaded":
                    {
                        args [i] = (stats.BytesUplaoded / 1024 * 1024).ToString();
                        break;
                    }
                    case "gigabytesuploaded":
                    {
                        args [i] = (stats.BytesUplaoded / 1024 * 1024 * 1024).ToString();
                        break;
                    }
                    case "formatbytesuploaded":
                    {
                        args [i] = stats.BytesUplaoded.FormatSize();
                        break;
                    }
                    case "averagespeed":
                    {
                        args [i] = stats.Speed.ToString();
                        break;
                    }
                    case "filesuploaded":
                    {
                        args [i] = stats.FilesUplaoded.ToString();
                        break;
                    }
                    case "uploadvirtualpath":
                    {
                        args [i] = race.CurrentRaceData.UploadVirtualPath;
                        break;
                    }
                    case "releasename":
                    {
                        args [i] = race.CurrentRaceData.DirectoryName;
                        break;
                    }
                    case "irccolor":
                    {
                        args [i] = CodeIrcColor;
                        break;
                    }
                    case "ircbold":
                    {
                        args [i] = CodeIrcBold;
                        break;
                    }
                    case "ircunderline":
                    {
                        args [i] = CodeIrcUnderline;
                        break;
                    }
                    case "newline":
                    {
                        args [i] = codeNewLine;
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }
            text = String.Format(new MyFormat(), text, args);
            return text;
        }

        public string Format(string line)
        {
            if (MinimumLength(line) || race == null)
            {
                return line;
            }
            Mp3Info mp3Info = new Mp3Info();
            if (race.IsMp3Race())
            {
                mp3Info = GetMp3Info();
            }
            return String.Format(new MyFormat(), line
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
                                          , CodeIrcColor // {16}
                                          , CodeIrcBold // {17}
                                          , CodeIrcUnderline // {18}
                                          , codeNewLine // {19}
                                          , mp3Info.Artist // {20}
                                          , mp3Info.Album // {21}
                                          , mp3Info.Title // {22}
                                          , mp3Info.Genre // {23}
                                          , mp3Info.Year // {24}
                                          , mp3Info.TrackNumber //{25}
                                          , race.CurrentRaceData == null ? 0 : race.CurrentRaceData.Speed); // {26}
        }

        private Mp3Info GetMp3Info()
        {
            Mp3Info mp3Info = new Mp3Info();
            try
            {
                string uploadFile = race.CurrentRaceData.UploadFile;
                if (File.Exists(uploadFile) && !String.IsNullOrEmpty(uploadFile))
                {
                    TagLib.File file = TagLib.File.Create(uploadFile);
                    if (file != null)
                    {
                        mp3Info.Artist = file.Tag.FirstAlbumArtist;
                        mp3Info.Album = file.Tag.Album;
                        mp3Info.Title = file.Tag.Title;
                        mp3Info.Genre = file.Tag.FirstGenre;
                        mp3Info.Year = file.Tag.Year;
                        mp3Info.TrackNumber = file.Tag.Track;
                    }
                }
            }
            catch (CorruptFileException)
            {
            }
            return mp3Info;
        }

        public string FormatCrc32(string line)
        {
            return MinimumLength(line) || rescanStatsData == null || rescanStats == null
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
                                       , codeNewLine); // {8}
        }

        private readonly Race race;
        private const char SplitChar = '¤';
        private readonly RescanStatsData rescanStatsData;
        private readonly RescanStats rescanStats;
        private const string CodeIrcBold = "\\002";
        private const string CodeIrcUnderline = "\\037";
        private const string CodeIrcColor = "\\003";
        private readonly string codeNewLine = Environment.NewLine;
    }
}