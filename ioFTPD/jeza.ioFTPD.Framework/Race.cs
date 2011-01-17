#region
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

#endregion

namespace jeza.ioFTPD.Framework
{
    public class Race : IoEnvironment
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
// ReSharper disable ConditionIsAlwaysTrueOrFalse
            bool directoryIsNull = fileInfo.Directory == null;
// ReSharper restore ConditionIsAlwaysTrueOrFalse
            CurrentUploadData = new CurrentUploadData
                                {
                                    FileExtension = Path.GetExtension(fileInfo.FullName),
                                    FileName = fileInfo.Name,
                                    FileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileInfo.FullName),
// ReSharper disable ConditionIsAlwaysTrueOrFalse
                                    DirectoryName = directoryIsNull ? "" : fileInfo.Directory.Name,
                                    DirectoryPath = directoryIsNull ? "" : fileInfo.Directory.FullName,
// ReSharper disable PossibleNullReferenceException
                                    DirectoryParent = directoryIsNull ? "" : fileInfo.Directory.Parent.FullName,
// ReSharper restore PossibleNullReferenceException
// ReSharper restore ConditionIsAlwaysTrueOrFalse
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
            RaceFile = Path.Combine(CurrentUploadData.DirectoryPath, Config.FileNameRace);
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
            if (SkipFileExtension)
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
                dataParser = new DataParserZip(this);
                dataParser.Parse();
                dataParser.Process();
                return;
            }
            if (CurrentUploadData.RaceType == RaceType.Diz)
            {
                //dataParser = new DataParserDiz(this);
                //dataParser.Parse();
                //dataParser.Process();
                IsValid = false;
                Log.Debug("DIZ not allowed!");
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

        public bool SkipPath
        {
            get
            {
                IsValid = true;
                if (CurrentUploadData != null)
                {
                    string virtualPath = CurrentUploadData.UploadVirtualPath;
                    if (Config.SkipPath.IndexOf(' ') > -1)
                    {
                        string[] skipPaths = Config.SkipPath.Split(' ');
                        foreach (string skipPath in skipPaths)
                        {
                            if (virtualPath.StartsWith(skipPath, StringComparison.InvariantCultureIgnoreCase))
                            {
                                Log.Debug("Skip path match. ['{0}' => '{1}']", skipPath, Config.SkipPath);
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
        }

        public bool SkipFileExtension
        {
            get
            {
                IsValid = true;
                if (CurrentUploadData != null)
                {
                    string fileExtension = CurrentUploadData.FileExtension;
                    if (Config.SkipFileExtension.IndexOf(',') > -1)
                    {
                        string[] skipFileExtensions = Config.SkipFileExtension.Split(',');
                        foreach (string extension in skipFileExtensions)
                        {
                            if (fileExtension.EndsWith(extension, StringComparison.InvariantCultureIgnoreCase))
                            {
                                Log.Debug("Skip file extension match. ['{0}' => '{1}']", extension, Config.SkipFileExtension);
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// Gets or sets the start of the race.
        /// </summary>
        /// <value>The start.</value>
        public UInt64 Start { get; set; }

        /// <summary>
        /// Gets or sets the stop of the race.
        /// </summary>
        /// <value>The stop.</value>
        public UInt64 Stop { get; set; }

        /// <summary>
        /// Prints output to the client.
        /// </summary>
        /// <param name="skip">if set to <c>true</c> use skip file template.</param>
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
            OutputSfvFirst(Config.ClientFileName, fileInfo.Length == 1 ? Config.ClientFileNameSfvExists : Config.ClientFileNameSfvFirst);
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
                                                               : EqualsRaceType(".diz")
                                                                     ? RaceType.Diz
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

        public RaceStatsUsers UserUploadedFirstFile()
        {
            foreach (RaceStatsUsers raceStatsUser in GetUserStats())
            {
                if ((raceStatsUser.UserName == CurrentUploadData.UserName) && (raceStatsUser.FilesUplaoded == 1))
                {
                    return raceStatsUser;
                }
            }
            return null;
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

        /// <summary>
        /// Gets the lead group.
        /// </summary>
        /// <returns></returns>
        public RaceStatsGroups GetLeadGroup()
        {
            List<RaceStatsGroups> raceStatsGroupses = GetGroupStats();
            return raceStatsGroupses.Count > 0 ? raceStatsGroupses [0] : new RaceStatsGroups();
        }

        /// <summary>
        /// Gets the lead user.
        /// </summary>
        /// <returns></returns>
        public RaceStatsUsers GetLeadUser()
        {
            List<RaceStatsUsers> raceStatsUserses = GetUserStats();
            return raceStatsUserses.Count() > 0 ? raceStatsUserses [0] : new RaceStatsUsers();
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

        private Int32 GetTotalAvarageSpeed()
        {
            Int32 totalSpeed = 0;
            foreach (RaceStats stats in raceStats)
            {
                totalSpeed += stats.FileSpeed;
            }
            return TotalFilesUploaded > 0
                       ? totalSpeed / TotalFilesUploaded
                       : 1;
        }

        private UInt64 GetTotalBytesUploaded()
        {
            return raceStats.Where(stats => stats.FileUploaded).Aggregate<RaceStats, ulong>(0, (current,
                                                                                                stats) => current + stats.FileSize);
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
            return raceStats.Count(stats => stats.FileUploaded);
        }

        private string CreateProgressBar()
        {
            StringBuilder bar = new StringBuilder();
            for (int i = 0; i < Config.ProgressBarLength; i++)
            {
                bar.Append(
                    (TotalFilesExpected > 0) && (i < (TotalFilesUploaded * Config.ProgressBarLength / TotalFilesExpected))
                        ? Config.ProgressBarCharFilled
                        : Config.ProgressBarCharMissing);
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

        public Int32 TotalAvarageSpeed
        {
            get { return GetTotalAvarageSpeed(); }
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

        public RaceStatsGroups LeadGroup { get; set; }

        public RaceStatsUsers LeadUser { get; set; }

        public int PercentComplete
        {
            get
            {
                return TotalFilesExpected == 0
                           ? 0
                           : (TotalFilesUploaded * 100 / TotalFilesExpected);
            }
        }

        public string RaceFile { get; set; }

        private readonly string[] args;
        private readonly List<RaceStats> raceStats = new List<RaceStats>();
    }
}