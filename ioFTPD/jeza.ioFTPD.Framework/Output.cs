#region
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TagLib;
using File=System.IO.File;

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
            Console.WriteLine(FormatMp3(line));
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

        public string FormatMp3(string line)
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
            try
            {
                if (race != null)
                {
                    if (race.CurrentUploadData != null)
                    {
                        string uploadFile = race.CurrentUploadData.UploadFile;
                        if (!File.Exists(uploadFile) || String.IsNullOrEmpty(uploadFile))
                        {
                            return line;
                        }
                        TagLib.File file = TagLib.File.Create(uploadFile);
                        for (int i = 0; i < count; i++)
                        {
                            switch (args [i].ToLower())
                            {
                                case "artist":
                                {
                                    args [i] = file.Tag.FirstAlbumArtist;
                                    break;
                                }
                                case "album":
                                {
                                    args [i] = file.Tag.Album;
                                    break;
                                }
                                case "genre":
                                {
                                    args [i] = file.Tag.FirstGenre;
                                    break;
                                }
                                case "year":
                                {
                                    args [i] = file.Tag.Year.ToString();
                                    break;
                                }
                                case "title":
                                {
                                    args [i] = file.Tag.Title;
                                    break;
                                }
                                case "tracknumber":
                                {
                                    args [i] = file.Tag.Track.ToString();
                                    break;
                                }
                                default:
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (CorruptFileException)
            {
            }
            text = String.Format(new MyFormat(), text, args);
            return text;
        }

        private static bool MinimumLength(string line)
        {
            if (line.Length < 2)
            {
                return true;
            }
            return false;
        }

        private static bool NotFormated(string line)
        {
            if (line.IndexOf(SplitChar) == -1)
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
                        args [i] = FormatSize(stats.BytesUplaoded);
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
                        args [i] = race.CurrentUploadData.UploadVirtualPath;
                        break;
                    }
                    case "releasename":
                    {
                        args[i] = race.CurrentUploadData.DirectoryName;
                        break;
                    }
                    case "irccolor":
                    {
                        args[i] = CodeIrcColor;
                        break;
                    }
                    case "ircbold":
                    {
                        args[i] = CodeIrcBold;
                        break;
                    }
                    case "ircunderline":
                    {
                        args[i] = CodeIrcUnderline;
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
                        args [i] = FormatSize(stats.BytesUplaoded);
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
                        args [i] = race.CurrentUploadData.UploadVirtualPath;
                        break;
                    }
                    case "releasename":
                    {
                        args[i] = race.CurrentUploadData.DirectoryName;
                        break;
                    }
                    case "irccolor":
                    {
                        args[i] = CodeIrcColor;
                        break;
                    }
                    case "ircbold":
                    {
                        args[i] = CodeIrcBold;
                        break;
                    }
                    case "ircunderline":
                    {
                        args[i] = CodeIrcUnderline;
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
            ArrayList unknownArgs = new ArrayList();
            int count = args.Length;
            for (int i = 0; i < count; i++)
            {
                string arg = args [i].ToLowerInvariant();
                switch (arg)
                {
                    case "filename":
                    {
                        args [i] = race.CurrentUploadData.FileName;
                        break;
                    }
                    case "releasename":
                    {
                        args [i] = race.CurrentUploadData.DirectoryName;
                        break;
                    }
                    case "totalfilesexpected":
                    {
                        args [i] = race.TotalFilesExpected.ToString();
                        break;
                    }
                    case "totalfilesuploaded":
                    {
                        args [i] = race.TotalFilesUploaded.ToString();
                        break;
                    }
                    case "totalbytesuploaded":
                    {
                        args [i] = race.TotalBytesUploaded.ToString();
                        break;
                    }
                    case "totalmegabytesuploaded":
                    {
                        args [i] = race.TotalMegaBytesUploaded.ToString();
                        break;
                    }
                    case "totalavaragespeed":
                    {
                        args [i] = race.TotalAvarageSpeed.ToString();
                        break;
                    }
                    case "formatbytesuploaded":
                    {
                        args [i] = FormatSize(race.TotalBytesUploaded);
                        break;
                    }
                    case "formattotalbytesexpected":
                    {
                        args [i] = FormatSize(race.TotalBytesUploaded * (UInt64) race.TotalFilesExpected);
                        break;
                    }
                    case "totalusersracing":
                    {
                        args[i] = race.TotalUsersRacing.ToString();
                        break;
                    }
                    case "totalgroupsracing":
                    {
                        args[i] = race.TotalGroupsRacing.ToString();
                        break;
                    }
                    case "progressbar":
                    {
                        args [i] = race.ProgressBar;
                        break;
                    }
                    case "percentcomplete":
                    {
                        args [i] = race.PercentComplete.ToString();
                        break;
                    }
                    case "username":
                    {
                        args [i] = race.CurrentUploadData.UserName;
                        break;
                    }
                    case "groupname":
                    {
                        args [i] = race.CurrentUploadData.GroupName;
                        break;
                    }
                    case "uploadvirtualpath":
                    {
                        args [i] = race.CurrentUploadData.UploadVirtualPath;
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
                    default:
                    {
                        unknownArgs.Add(arg);
                        break;
                    }
                }
            }
            if (unknownArgs.Count > 0)
            {
                //text = FormatMp3(text + SplitChar + String.Join(" ", args) +" " + String.Join(" ", unknownArgs.ToArray(typeof(string)) as string[]));
                text = FormatMp3(text + SplitChar + String.Join(" ", args));
            }
            text = String.Format(new MyFormat(), text, args);
            return text;
        }

        public string FormatCrc32(string line)
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
                switch (args [i].ToLowerInvariant())
                {
                    case "filename":
                    {
                        args [i] = rescanStatsData.FileName;
                        break;
                    }
                    case "expectedcrc32":
                    {
                        args [i] = rescanStatsData.ExpectedCrc32Value;
                        break;
                    }
                    case "actualcrc32":
                    {
                        args [i] = rescanStatsData.ActualCrc32Value;
                        break;
                    }
                    case "status":
                    {
                        args [i] = rescanStatsData.Status;
                        break;
                    }
                    case "totalfiles":
                    {
                        args [i] = rescanStats.TotalFiles.ToString();
                        break;
                    }
                    case "missingfiles":
                    {
                        args [i] = rescanStats.MissingFiles.ToString();
                        break;
                    }
                    case "okfiles":
                    {
                        args [i] = rescanStats.OkFiles.ToString();
                        break;
                    }
                    case "failedfiles":
                    {
                        args [i] = rescanStats.FailedFiles.ToString();
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

        public string FormatSize(UInt64 bytes)
        {
            UInt64 formatedSize = bytes;
            string[] postFix = new[] {"B", "kB", "MB", "GB", "TB"};
            int count = 0;
            while (formatedSize > 1024)
            {
                formatedSize = formatedSize / 1024;
                count++;
            }
            return String.Format(CultureInfo.InvariantCulture, Config.FormatedBytes, formatedSize, postFix [count]);
        }

        private readonly Race race;
        private const char SplitChar = '¤';
        private readonly RescanStatsData rescanStatsData;
        private readonly RescanStats rescanStats;
        private const string CodeIrcBold = "\\002";
        private const string CodeIrcUnderline = "\\037";
        private const string CodeIrcColor = "\\003";
    }
}