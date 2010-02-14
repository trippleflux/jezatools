#region
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

#endregion

namespace jeza.ioFTPD.Framework
{
    public class Race
    {
        public Race(string[] args)
        {
            this.args = args;
        }

        /// <summary>
        /// Parses input arguments based on UPLOAD.
        /// </summary>
        /// <returns></returns>
        public Race Parse()
        {
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(args [1]);
            CurrentUploadData = new CurrentUploadData
                                {
                                    FileExtension = Path.GetExtension(fileInfo.FullName),
                                    FileName = fileInfo.Name,
                                    DirectoryName = fileInfo.Directory == null ? "" : fileInfo.Directory.Name,
                                    DirectoryPath = fileInfo.Directory == null ? "" : fileInfo.Directory.FullName,
// ReSharper disable PossibleNullReferenceException
                                    DirectoryParent = fileInfo.Directory == null ? "" : fileInfo.Directory.Parent.FullName,
// ReSharper restore PossibleNullReferenceException
                                    FileSize = fileInfo.Length,
                                    UploadFile = args [1],
                                    UploadCrc = args [2],
                                    UploadVirtualFile = args [3],
                                    UploadVirtualPath = GetVirtualPath(),
                                    Speed = GetSpeed(),
                                    UserName = GetUserName(),
                                    GroupName = GetGroupName(),
                                    Uid = GetUid(),
                                    Gid = GetGid(),
                                };
            SelectRaceType();
            Log.Debug("CurrentUploadData: {0}", CurrentUploadData);
            return this;
        }

        /// <summary>
        /// Starts with the file check.
        /// </summary>
        public void Process()
        {
            if (SkipPath)
            {
                OutputFileName(true);
                return;
            }
            if (!IsValid)
            {
                Log.Debug("Not Valid!");
                return;
            }
            IDataParser dataParser;
            if (CurrentUploadData.RaceType == RaceType.Nfo)
            {
                OutputFileName(false);
                return;
            }
            if (CurrentUploadData.RaceType == RaceType.Zip)
            {
                OutputFileName(false);
                return;
            }
            if (CurrentUploadData.RaceType == RaceType.Sfv)
            {
                dataParser = new DataParserSfv(this);
                dataParser.Parse();
                dataParser.Process();
                return;
            }
            if (!SfvCheck())
            {
                return;
            }
            dataParser = new DataParser(this);
            dataParser.Parse();
            dataParser.Process();
        }

        private static string GetUid()
        {
            return Environment.GetEnvironmentVariable("UID") ?? "0";
        }

        private static string GetGid()
        {
            return Environment.GetEnvironmentVariable("GID") ?? "0";
        }

        private static string GetVirtualPath()
        {
            return Environment.GetEnvironmentVariable("VIRTUALPATH") ?? "/NoPath";
        }

        private static string GetGroupName()
        {
            return Environment.GetEnvironmentVariable("GROUP") ?? "NoGroup";
        }

        private static string GetUserName()
        {
            return Environment.GetEnvironmentVariable("USER") ?? "NoUser";
        }

        private static int GetSpeed()
        {
            string speed = Environment.GetEnvironmentVariable("SPEED");
            return speed == null ? 1 : Int32.Parse(speed);
        }

        public bool SkipPath
        {
            get
            {
                IsValid = true;
                string virtualPath = CurrentUploadData.UploadVirtualPath;
                if (Config.SkipPath.IndexOf(' ') > -1)
                {
                    string[] skipPaths = Config.SkipPath.Split(' ');
                    foreach (string skipPath in skipPaths)
                    {
                        if (virtualPath.StartsWith(skipPath))
                        {
                            Log.Debug("Skip path match. ['{0}' => '{1}']", skipPath, Config.SkipPath);
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        private void OutputFileName(bool skip)
        {
            Output output = new Output(this);
            string filename = skip ? Config.ClientFileNameSkip : Config.ClientFileName;
            output
                .Client(Config.ClientHead)
                .Client(filename)
                .Client(Config.ClientFoot);
        }

        private void OutputSfvFirst
            (string fileInfo,
             string fileReason)
        {
            Output output = new Output(this);
            output
                .Client(Config.ClientHead)
                .Client(fileInfo)
                .Client(fileReason)
                .Client(Config.ClientFoot);
        }

        /// <summary>
        /// Checks if SFV exists.
        /// </summary>
        /// <returns><c>true</c> if SFV file was found.</returns>
        private bool SfvCheck()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(CurrentUploadData.DirectoryPath);
            System.IO.FileInfo[] fileInfo = directoryInfo.GetFiles("*.sfv");
            if (fileInfo.Length == 1)
            {
                return true;
            }
            if (fileInfo.Length == 1)
            {
                OutputSfvFirst(Config.ClientFileName, Config.ClientFileNameSfvFirst);
            }
            else
            {
                OutputSfvFirst(Config.ClientFileName, Config.ClientFileNameSfvExists);
            }
            IsValid = false;
            return false;
        }

        /// <summary>
        /// Selects the type of the race based on the file extension.
        /// </summary>
        private void SelectRaceType()
        {
            if (string.IsNullOrEmpty(CurrentUploadData.FileExtension))
            {
                IsValid = false;
                return;
            }
            IsValid = true;
            CurrentUploadData.RaceType = EqualsRaceType(".sfv")
                                             ? RaceType.Sfv
                                             : EqualsRaceType(".mp3")
                                                   ? RaceType.Mp3
                                                   : EqualsRaceType(".zip")
                                                         ? RaceType.Zip
                                                         : EqualsRaceType(".nfo")
                                                               ? RaceType.Nfo
                                                               : RaceType.Default;
        }

        /// <summary>
        /// Checks if the file extension matches.
        /// </summary>
        /// <param name="fileExtension">The file extension.</param>
        /// <returns><c>true</c> on match.</returns>
        private bool EqualsRaceType(string fileExtension)
        {
            return CurrentUploadData.FileExtension.Equals(fileExtension, StringComparison.InvariantCultureIgnoreCase);
        }

        public List<RaceStats> RaceStats
        {
            get { return raceStats; }
        }

        public void AddRaceStats(RaceStats stats)
        {
            if (raceStats.Contains(stats))
            {
                return;
            }
            raceStats.Add(stats);
        }

        public string GetRaceStats
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (RaceStats list in raceStats)
                {
                    sb.AppendLine(list.ToString());
                }
                return sb.ToString();
            }
        }

        public void ClearRaceStats()
        {
            raceStats.Clear();
        }

        public List<RaceStatsGroups> GetGroupStats()
        {
            List<RaceStatsGroups> stats = new List<RaceStatsGroups>();
            var query = from s in raceStats
                        group s by s.GroupName;
            foreach (var result in query)
            {
                UInt64 totalBytesUplaoded = 0ul;
                int speed = 0;
                int totalFileUploaded = 0;
                foreach (RaceStats raceStat in result)
                {
                    if (!raceStat.FileUploaded)
                    {
                        continue;
                    }
                    totalBytesUplaoded += raceStat.FileSize;
                    speed += raceStat.FileSpeed;
                    totalFileUploaded++;
                }
                if (totalFileUploaded > 0)
                {
                    RaceStatsGroups raceStatsGroups = new RaceStatsGroups
                                                      {
                                                          GroupName = result.Key,
                                                          BytesUplaoded = totalBytesUplaoded,
                                                          Speed = speed / totalFileUploaded,
                                                          FilesUplaoded = totalFileUploaded,
                                                      };
                    stats.Add(raceStatsGroups);
                }
            }
            //stats.Sort((stats1, stats2) => Comparer<UInt64>.Default.Compare(stats1.BytesUplaoded, stats2.BytesUplaoded));
            stats.Sort();
            stats.Reverse();
            return stats;
        }

        public List<RaceStatsUsers> GetUserStats()
        {
            List<RaceStatsUsers> stats = new List<RaceStatsUsers>();
            var query = from s in raceStats
                        group s by s.UserName;
            foreach (var result in query)
            {
                UInt64 totalBytesUplaoded = 0ul;
                int speed = 0;
                string groupName = "";
                int totalFileUploaded = 0;
                foreach (RaceStats raceStat in result)
                {
                    if (!raceStat.FileUploaded)
                    {
                        continue;
                    }
                    totalBytesUplaoded += raceStat.FileSize;
                    speed += raceStat.FileSpeed;
                    groupName = raceStat.GroupName;
                    totalFileUploaded++;
                }
                if (totalFileUploaded > 0)
                {
                    RaceStatsUsers raceStatsUsers = new RaceStatsUsers
                                                    {
                                                        UserName = result.Key,
                                                        GroupName = groupName,
                                                        BytesUplaoded = totalBytesUplaoded,
                                                        Speed = speed / totalFileUploaded,
                                                        FilesUplaoded = totalFileUploaded,
                                                    };
                    stats.Add(raceStatsUsers);
                }
            }
            //stats.Sort ((stats1, stats2) => Comparer<UInt64>.Default.Compare (stats1.BytesUplaoded, stats2.BytesUplaoded));
            //UserStatsSortOrder<RaceStatsUsers> order = new UserStatsSortOrder<RaceStatsUsers>();
            stats.Sort();
            stats.Reverse();
            return stats;
        }

        private UInt64 GetTotalBytesUploaded()
        {
            UInt64 total = 0;
            foreach (RaceStats stats in raceStats)
            {
                if (stats.FileUploaded)
                {
                    total += stats.FileSize;
                }
            }
            return total;
        }

        private int GetTotalGroupsRacing()
        {
            List<string> groups = new List<string>();
            foreach (RaceStats stats in raceStats)
            {
                if (stats.FileUploaded)
                {
                    string groupName = stats.GroupName;
                    if (groups.Contains(groupName))
                    {
                        continue;
                    }
                    groups.Add(groupName);
                }
            }
            return groups.Count;
        }

        private int GetTotalUsersRacing()
        {
            List<string> users = new List<string>();
            foreach (RaceStats stats in raceStats)
            {
                if (stats.FileUploaded)
                {
                    string userName = stats.UserName;
                    if (users.Contains(userName))
                    {
                        continue;
                    }
                    users.Add(userName);
                }
            }
            return users.Count;
        }

        private int GetTotalFilesUploaded()
        {
            int total = 0;
            foreach (RaceStats stats in raceStats)
            {
                if (stats.FileUploaded)
                {
                    total++;
                }
            }
            return total;
        }

        private string CreateProgressBar()
        {
            StringBuilder bar = new StringBuilder();
            for (int i = 0; i < Config.ProgressBarLength; i++)
            {
                if (i < (TotalFilesUploaded * Config.ProgressBarLength / TotalFilesExpected))
                {
                    bar.Append(Config.ProgressBarCharFilled);
                }
                else
                {
                    bar.Append(Config.ProgressBarCharMissing);
                }
            }
            return bar.ToString();
        }

        public int TotalFilesExpected { get; set; }

        public int TotalGroupsRacing
        {
            get { return GetTotalGroupsRacing(); }
        }

        public int TotalFilesUploaded
        {
            get { return GetTotalFilesUploaded(); }
        }

        public UInt64 TotalBytesUploaded
        {
            get { return GetTotalBytesUploaded(); }
        }

        public bool IsRaceComplete
        {
            get { return TotalFilesExpected == TotalFilesUploaded; }
        }

        public UInt64 TotalMegaBytesUploaded
        {
            get { return TotalBytesUploaded / (1024 * 1024); }
        }

        public CurrentUploadData CurrentUploadData { get; set; }

        public bool IsValid { get; set; }

        public int TotalUsersRacing
        {
            get { return GetTotalUsersRacing(); }
        }

        public string ProgressBar
        {
            get { return CreateProgressBar(); }
        }

        public int PercentComplete
        {
            get { return (TotalFilesUploaded * 100 / TotalFilesExpected); }
        }

        private readonly string[] args;
        private readonly List<RaceStats> raceStats = new List<RaceStats>();
    }
}