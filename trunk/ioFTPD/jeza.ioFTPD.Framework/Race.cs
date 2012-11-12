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
        public Race()
        {
        }

        public Race(string[] args)
        {
            this.args = args;
            SourceFolder = GetRealPath();
        }

        /// <summary>
        /// Parses input arguments based on DELETE.
        /// </summary>
        /// <returns></returns>
        public Race ParseDelete()
        {
            GetCurrentUploadData();
            string fileName = args [2];
            CurrentRaceData.RaceType = RaceType.Delete;
            CurrentRaceData.FileExtension = Path.GetExtension(fileName);
            CurrentRaceData.FileName = fileName;
            CurrentRaceData.FileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
            CurrentRaceData.UploadCrc = "00000000";
            DirectoryInfo directoryInfo = new DirectoryInfo(SourceFolder);
            bool directoryIsNull = !directoryInfo.Exists || directoryInfo.Parent == null;
            CurrentRaceData.DirectoryName = directoryIsNull ? "" : directoryInfo.Name;
            CurrentRaceData.DirectoryPath = directoryIsNull ? "" : directoryInfo.FullName;
            CurrentRaceData.DirectoryParent = directoryIsNull ? "" : directoryInfo.Parent.FullName;
            CurrentRaceData.FileSize = 0;
            RaceFile = Misc.PathCombine(SourceFolder, Config.FileNameRace);
            IsValid = true;
            Log.Debug("CurrentRaceData: {0}", CurrentRaceData);
            return this;
        }

        /// <summary>
        /// Parses input arguments based on UPLOAD.
        /// </summary>
        /// <returns></returns>
        public Race ParseUpload()
        {
            string fileName = args [1];
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(fileName);
            GetCurrentUploadData();
            CurrentRaceData.FileExtension = Path.GetExtension(fileInfo.FullName);
            CurrentRaceData.FileName = fileInfo.Name;
            CurrentRaceData.FileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileInfo.FullName);
            CurrentRaceData.UploadFile = fileName;
            CurrentRaceData.UploadCrc = args [2];
            CurrentRaceData.UploadVirtualFile = args [3];
// ReSharper disable ConditionIsAlwaysTrueOrFalse
            bool directoryIsNull = fileInfo.Directory == null || fileInfo.Directory.Parent == null;
// ReSharper restore ConditionIsAlwaysTrueOrFalse
            CurrentRaceData.DirectoryName = directoryIsNull ? "" : fileInfo.Directory.Name;
            CurrentRaceData.DirectoryPath = directoryIsNull ? "" : fileInfo.Directory.FullName;
            CurrentRaceData.DirectoryParent = directoryIsNull ? "" : fileInfo.Directory.Parent.FullName;
            CurrentRaceData.FileSize = fileInfo.Length;
            SelectRaceType();
            RaceFile = Misc.PathCombine(CurrentRaceData.DirectoryPath, Config.FileNameRace);
            Log.Debug("CurrentRaceData: {0}", CurrentRaceData);
            return this;
        }

        private void GetCurrentUploadData()
        {
            CurrentRaceData = new CurrentRaceData
                              {
                                  UploadVirtualPath = GetVirtualPath(),
                                  Speed = GetSpeed(),
                                  UserName = GetUserName(),
                                  GroupName = GetGroupName(),
                                  Uid = GetUid(),
                                  Gid = GetGid(),
                              };
        }

        public void ProcessDelete()
        {
            if (SkipCheck())
            {
                return;
            }
            if (!File.Exists(RaceFile))
            {
                Log.Debug("Race File not found! Skiping check...");
                return;
            }
            DataParserDelete dataParser = new DataParserDelete(this);
            dataParser.Parse();
            dataParser.Process();
        }

        /// <summary>
        /// Starts with the file check.
        /// </summary>
        public void Process()
        {
            if (SkipCheck())
            {
                return;
            }
            RefuseFileExtension();
            if (!IsValid)
            {
                Log.Debug("Not Valid!");
                return;
            }
            IDataParser dataParser;
            if (CurrentRaceData.RaceType == RaceType.Nfo)
            {
                dataParser = new DataParserNfo(this);
                dataParser.Parse();
                dataParser.Process();
                return;
            }
            if (CurrentRaceData.RaceType == RaceType.Zip)
            {
                dataParser = new DataParserZip(this);
                dataParser.Parse();
                dataParser.Process();
                return;
            }
            if (CurrentRaceData.RaceType == RaceType.Diz)
            {
                IsValid = false;
                Log.Debug("DIZ not allowed!");
                return;
            }
            if (CurrentRaceData.RaceType == RaceType.Sfv)
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

        private bool SkipCheck()
        {
            if (SpeedTest() || VirtualPathMatch(Config.SkipPath) || SkipFileExtension())
            {
                if (!IsRaceTypeDelete())
                {
                    OutputFileName(true);
                }
                return true;
            }
            return false;
        }

        private void RefuseFileExtension()
        {
            if (CurrentRaceData != null)
            {
                string fileExtension = CurrentRaceData.FileExtension;
                bool containsFileExt = Config.FileExtensionRefuse.StringContainsFileExt(fileExtension);
                Log.Debug("Refuse file extension match=[{2}] :: ['{0}' => '{1}']", fileExtension, Config.FileExtensionRefuse, containsFileExt);
                IsValid = !containsFileExt;
            }
        }

        public bool IsRaceTypeDelete()
        {
            return CurrentRaceData.RaceType == RaceType.Delete;
        }

        public string SourceFolder { get; set; }

        public bool SpeedTest()
        {
            IsValid = true;
            if (CurrentRaceData != null)
            {
                string virtualPath = CurrentRaceData.UploadVirtualPath;
                if (virtualPath.StartsWith(Config.SpeedTestFolder, StringComparison.InvariantCultureIgnoreCase))
                {
                    Log.Debug("SpeedTest path match. ['{0}' => '{1}']", Config.SpeedTestFolder, virtualPath);
                    if (Config.DeleteSpeedTest)
                    {
                        IsValid = false;
                    }
                    Output output = new Output(this);
                    output.LogSpeedTest();
                    return true;
                }
            }
            return false;
        }

        public bool VirtualPathMatch(string skipPathConfig)
        {
            IsValid = true;
            if (CurrentRaceData != null)
            {
                string virtualPath = CurrentRaceData.UploadVirtualPath;
                char[] separator = new[] {' ', ','};
                string[] skipPaths = skipPathConfig.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                foreach (string skipPath in skipPaths)
                {
                    if (virtualPath.StartsWith(skipPath, StringComparison.InvariantCultureIgnoreCase))
                    {
                        Log.Debug("Skip path match. ['{0}' => '{1}']", skipPath, skipPath);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool SkipFileExtension()
        {
            IsValid = true;
            if (CurrentRaceData != null)
            {
                string fileExtension = CurrentRaceData.FileExtension;
                bool containsFileExt = Config.FileExtensionSkip.StringContainsFileExt(fileExtension);
                Log.Debug("Skip file extension match=[{2}] :: ['{0}' => '{1}']", fileExtension, Config.FileExtensionSkip, containsFileExt);
                return containsFileExt;
            }
            return false;
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
            DirectoryInfo directoryInfo = new DirectoryInfo(CurrentRaceData.DirectoryPath);
            System.IO.FileInfo[] fileInfo = directoryInfo.GetFiles("*.sfv");
            Log.Debug("SfvCheck: have {0} SFV files in '{1}'", fileInfo.Length, directoryInfo.FullName);
            if (fileInfo.Length == 1)
            {
                return true;
            }
            OutputSfvFirst(Config.ClientFileName,
                           fileInfo.Length > 1
                               ? Config.ClientFileNameSfvExists
                               : Config.ClientFileNameSfvFirst);
            IsValid = false;
            return false;
        }

        /// <summary>
        /// Selects the type of the race based on the file extension.
        /// </summary>
        private void SelectRaceType()
        {
            string fileExtension = CurrentRaceData.FileExtension;
            if (string.IsNullOrEmpty(fileExtension))
            {
                IsValid = false;
                return;
            }
            IsValid = true;
            CurrentRaceData.RaceType = EqualsRaceType(Config.FileExtensionSfv)
                                           ? RaceType.Sfv
                                           : EqualsRaceType(Config.FileExtensionZip)
                                                 ? RaceType.Zip
                                                 : EqualsRaceType(Config.FileExtensionNfo)
                                                       ? RaceType.Nfo
                                                       : EqualsRaceType(Config.FileExtensionDiz)
                                                             ? RaceType.Diz
                                                             : Config.FileExtensionAudio.StringContainsFileExt(fileExtension)
                                                                   ? RaceType.Audio
                                                                   : RaceType.Default;
        }

        /// <summary>
        /// Checks if the file extension matches.
        /// </summary>
        /// <param name="fileExtension">The file extension.</param>
        /// <returns><c>true</c> on match.</returns>
        private bool EqualsRaceType(string fileExtension)
        {
            return CurrentRaceData.FileExtension.Equals(fileExtension, StringComparison.InvariantCultureIgnoreCase);
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
            return GetUserStats().FirstOrDefault(raceStatsUser => (raceStatsUser.UserName == CurrentRaceData.UserName) && (raceStatsUser.FilesUplaoded == 1));
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
            Int32 totalSpeed = raceStats.Sum(stats => stats.FileSpeed);
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

        public string TotalBytesUploadedFormated
        {
            get { return TotalBytesUploaded.FormatSize(); }
        }

        public bool IsRaceComplete
        {
            get { return TotalFilesExpected == TotalFilesUploaded; }
        }

        public bool IsAudioRace
        {
            get { return CurrentRaceData.RaceType == RaceType.Audio; }
        }

        public UInt64 TotalMegaBytesUploaded
        {
            get { return TotalBytesUploaded / (1024 * 1024); }
        }

        public CurrentRaceData CurrentRaceData { get; set; }

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