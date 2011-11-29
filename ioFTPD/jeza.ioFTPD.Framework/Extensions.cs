using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using jeza.ioFTPD.Framework.Archive;
using jeza.ioFTPD.Framework.Json;
using jeza.ioFTPD.Framework.Manager;
using TagLib;
using File = TagLib.File;

namespace jeza.ioFTPD.Framework
{
    /// <summary>
    /// 
    /// </summary>
    public static class Extensions
    {
        public static string GetImdbId(string url)
        {
            string imdbId = String.Empty;
            string[] strings = url.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries);
            if (strings.Length == 0)
            {
                return imdbId;
            }
            foreach (string s in strings)
            {
                if (s.StartsWith("tt"))
                {
                    imdbId = s;
                    break;
                }
            }
            return imdbId;
        }

        /// <summary>
        /// Gets the imdb response for specified event name.
        /// </summary>
        /// <param name="searchString">The event name.</param>
        /// <returns></returns>
        public static dynamic GetImdbResponseForEventName(string searchString)
        {
            Log.Debug("GetImdbResponseForEventName: '{0}'", searchString);
            string what = searchString.Trim().Replace(" ", "%20");
            string htmlUri = "http://www.imdbapi.com/?t=" + what;
            return GetImdbInfo(htmlUri);
        }

        /// <summary>
        /// Gets the imdb response for event id.
        /// </summary>
        /// <param name="eventId">The event id.</param>
        /// <returns></returns>
        public static dynamic GetImdbResponseForEventId(string eventId)
        {
            Log.Debug("GetImdbResponseForEventId: '{0}'", eventId);
            string htmlUri = "http://www.imdbapi.com/?i=" + eventId;
            return GetImdbInfo(htmlUri);
        }

        private static object GetImdbInfo(string htmlUri)
        {
            Log.Debug("GetImdbInfo: '{0}'", htmlUri);
            WebRequest requestHtml = WebRequest.Create(htmlUri);
            WebResponse responseHtml = requestHtml.GetResponse();
            string stringResponse = String.Empty;
            if (responseHtml != null)
            {
// ReSharper disable AssignNullToNotNullAttribute
                using (StreamReader r = new StreamReader(responseHtml.GetResponseStream())) // ReSharper restore AssignNullToNotNullAttribute
                {
                    stringResponse = r.ReadToEnd();
                }
            }

            JsonParser jsonParser = new JsonParser {CamelizeProperties = true};
            dynamic output = jsonParser.Parse(stringResponse);
            //{"Response":"Parse Error"}
            return output;
        }

        /// <summary>
        /// Removes the folder.
        /// </summary>
        /// <param name="path">The path.</param>
        public static void RemoveFolder(this string path)
        {
            try
            {
                if (path.DirectoryExists())
                {
                    Directory.Delete(path);
                }
            }
            catch (Exception exception)
            {
                Log.Debug(exception.ToString());
            }
        }

        /// <summary>
        /// Kicks the users from directory.
        /// </summary>
        /// <param name="fullName">The full name.</param>
        public static void KickUsersFromDirectory(this string fullName)
        {
            Console.WriteLine("!unlock " + fullName + "\\*");
        }

        /// <summary>
        /// Determines whether the given path refers to an existing directory on disk.
        /// </summary>
        /// <param name="fullName">The full name.</param>
        /// <returns></returns>
        public static bool DirectoryExists(this string fullName)
        {
            return Directory.Exists(fullName);
        }

        /// <summary>
        /// Determines whether the specified file exists.
        /// </summary>
        /// <param name="fullName">The full name.</param>
        /// <returns></returns>
        public static bool FileExists(this string fullName)
        {
            return System.IO.File.Exists(fullName);
        }

        public static File GetMp3Info(string uploadFile)
        {
            try
            {
                if (System.IO.File.Exists(uploadFile) && !String.IsNullOrEmpty(uploadFile))
                {
                    Log.Debug("GetMp3Info: " + uploadFile);
                    File file = File.Create(uploadFile);
                    if (file != null)
                    {
                        return file;
                    }
                }
            }
            catch (CorruptFileException)
            {
            }
            return null;
        }

        public static DateTime AddNextDate(this DateTime dateTime)
        {
            return dateTime.AddDays(1);
        }

        /// <summary>
        /// Copies source directory to destination directory.
        /// </summary>
        /// <param name="sourceDirectory">The source.</param>
        /// <param name="destinationDirectory">The dest directory.</param>
        /// <param name="recursive">if set to <c>true</c> do it recursive for all subdirectories.</param>
        public static void CopyTo(this DirectoryInfo sourceDirectory,
                                  DirectoryInfo destinationDirectory,
                                  bool recursive)
        {
            if (sourceDirectory == null)
            {
                throw new ArgumentNullException("sourceDirectory");
            }
            if (destinationDirectory == null)
            {
                throw new ArgumentNullException("destinationDirectory");
            }
            if (!sourceDirectory.Exists)
            {
                throw new DirectoryNotFoundException("Source directory not found: " + sourceDirectory.FullName);
            }
            if (!destinationDirectory.Exists)
            {
                destinationDirectory.Create();
            }
            Log.Debug("CopyTo: '{0}' to '{1}'", sourceDirectory.FullName, destinationDirectory.FullName);
            foreach (System.IO.FileInfo file in sourceDirectory.GetFiles())
            {
                string fileName = Misc.PathCombine(destinationDirectory.FullName, file.Name);
                Log.Debug("CopyFile: '{0}' to '{1}'", file.FullName, fileName);
                file.CopyTo(fileName, true);
            }
            if (!recursive)
            {
                return;
            }
            foreach (DirectoryInfo directory in sourceDirectory.GetDirectories())
            {
                CopyTo(directory, new DirectoryInfo(Misc.PathCombine(destinationDirectory.FullName, directory.Name)), true);
            }
        }

        /// <summary>
        /// String Formats the submited input arguments.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public static string FormatArgs(this IData data,
                                        string[] args)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in args)
            {
                sb.AppendFormat("{0} ", s);
            }
            return sb.ToString().Trim();
        }

        /// <summary>
        /// Deserializes the specified XML object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlObject">The XML object.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="defaultNamespace">The default namespace.</param>
        /// <returns></returns>
        public static T Deserialize<T>(T xmlObject,
                                       string fileName,
                                       string defaultNamespace)
        {
            if (System.IO.File.Exists(fileName))
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof (T), defaultNamespace);
                    return (T) xmlSerializer.Deserialize(fileStream);
                }
            }
            Log.Debug("File '{0}' not found!", fileName);
            throw new Exception("Failed to deserialize configuration!");
        }

        /// <summary>
        /// Reads the race data.
        /// </summary>
        /// <param name="race">The race.</param>
        public static void ReadRaceData(Race race)
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

        public static void Serialize<T>(T xmlObject,
                                        string fileName,
                                        string defaultNamespace)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof (T), defaultNamespace);
            using (TextWriter textWriter = new StreamWriter(fileName))
            {
                xmlSerializer.Serialize(textWriter, xmlObject);
            }
        }

        /// <summary>
        /// Updates the race data.
        /// </summary>
        /// <param name="race">The race.</param>
        public static void UpdateRaceData(Race race)
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
                            if (fileName.Equals(race.CurrentRaceData.FileName))
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
                        writer.Write(isZip ? race.CurrentRaceData.FileName : fileName);
                        writer.Write(isZip ? race.CurrentRaceData.UploadCrc : fileCrc);
                        writer.Write(race.CurrentRaceData.RaceType == RaceType.Delete ? false : true);
                        writer.Write(race.CurrentRaceData.FileSize); //file Size
                        writer.Write(race.CurrentRaceData.Speed); //upload speed
                        writer.Write(race.CurrentRaceData.UserName); //username
                        writer.Write(race.CurrentRaceData.GroupName); //groupname
                    }
                }
            }
            RaceMutex.ReleaseMutex();
        }

        /// <summary>
        /// Processes with the race data (Client output, complete/incompletetags creating/deletion...).
        /// </summary>
        /// <param name="race">The race.</param>
        public static void ProcessRaceData(Race race)
        {
            FileInfo fileInfo = new FileInfo();
            bool deletingFile = race.IsRaceTypeDelete();
            fileInfo.DeleteFilesThatStartsWith(race.CurrentRaceData.DirectoryPath, Config.TagCleanUpString);
            Output output = new Output(race);
            bool isAudioRace = race.IsAudioRace;
            File audioInfo = isAudioRace ? GetMp3Info(race.CurrentRaceData.UploadFile) : null;
            TagManager tagManager = new TagManager(race);
            if (!deletingFile)
            {
                fileInfo.DeleteFile(race.CurrentRaceData.DirectoryPath,
                                    race.CurrentRaceData.FileName + Config.FileExtensionMissing);
                output
                    .Client(Config.ClientHead)
                    .Client(Config.ClientFileNameOk);
                if (isAudioRace)
                {
                    if (Config.AudioGenresAllowedCheck)
                    {
                        if (audioInfo == null)
                        {
                            ProcessBannedAudio(race, output);
                        }
                        else
                        {
                            string firstGenre = audioInfo.Tag.FirstGenre.ToLowerInvariant();
                            if (Config.AudioGenresAllowed.IndexOf(firstGenre) == -1)
                            {
                                ProcessBannedAudio(race, output);
                            }
                        }
                    }
                    if (Config.AudioGenresBannedCheck)
                    {
                        if (audioInfo != null)
                        {
                            string firstGenre = audioInfo.Tag.FirstGenre.ToLowerInvariant();
                            if (Config.AudioGenresBanned.IndexOf(firstGenre) > -1)
                            {
                                ProcessBannedAudio(race, output);
                            }
                        }
                        else
                        {
                            ProcessBannedAudio(race, output);
                        }
                    }
                    output
                        .ClientMp3(Config.ClientMp3InfoHead, audioInfo)
                        .ClientMp3(Config.ClientMp3Info, audioInfo);
                }
                output
                    .Client(Config.ClientStatsUsersHead)
                    .ClientStatsUsers(Config.ClientStatsUsers, Config.MaxNumberOfUserStats)
                    .Client(Config.ClientStatsGroupsHead)
                    .ClientStatsGroups(Config.ClientStatsGroups, Config.MaxNumberOfGroupStats)
                    .Client(Config.ClientFootProgressBar);
            }
            else
            {
                tagManager.CreateTag(race.CurrentRaceData.DirectoryPath,
                                     race.CurrentRaceData.FileName + Config.FileExtensionMissing);
            }
            if (race.IsRaceComplete)
            {
                fileInfo.DeleteFilesThatStartsWith(race.CurrentRaceData.DirectoryPath, Config.TagCleanUpString);
                tagManager.CreateTag(race.CurrentRaceData.DirectoryPath, output.Format(isAudioRace ? Config.TagCompleteMp3 : Config.TagComplete, audioInfo));
                tagManager.DeleteSymlink(race.CurrentRaceData.DirectoryParent, output.Format(Config.TagIncompleteLink));

                if (Config.WriteStatsToMesasageFileWhenComplete)
                {
                    SkipCreationOfMessageFile(race, isAudioRace, audioInfo);
                }
                output.LogCompleteStats();
                if (isAudioRace)
                {
                    SortAudio(race, audioInfo);
                }
            }
            else
            {
                tagManager.CreateTag(race.CurrentRaceData.DirectoryPath, output.Format(Config.TagIncomplete));
                if (Config.WriteStatsToMesasageFileWhenRace)
                {
                    SkipCreationOfMessageFile(race, isAudioRace, audioInfo);
                }
                if (race.TotalFilesUploaded == 1)
                {
                    output.LogFirstFileWasUploaded(isAudioRace, audioInfo);
                }
                else
                {
                    if (race.TotalUsersRacing > 1)
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

        private static void ProcessBannedAudio(Race race,
                                               Output output)
        {
            output.Client(Config.ClientFileNameAudioGenreNotAllowed);
            race.IsValid = false;
            race.CurrentRaceData.RaceType = RaceType.Delete;
            UpdateRaceData(race);
            KickUsersFromDirectory(race.CurrentRaceData.DirectoryPath);
            Misc.ChangeVfs(race.CurrentRaceData.DirectoryPath, 444, race.CurrentRaceData.Uid, race.CurrentRaceData.Gid);
        }

        private static void SkipCreationOfMessageFile(Race race,
                                                      bool isMp3Race,
                                                      File mp3Info)
        {
            if (!race.SkipPath(Config.SkipPathMessageFile))
            {
                WriteStatsToMesasageFile(race, isMp3Race, mp3Info);
            }
        }

        public static void SortAudio(Race race,
                                     File mp3Info)
        {
            if (mp3Info != null)
            {
                Log.Debug("AudioSort");
                if (Config.AudioSortByArtist)
                {
                    Log.Debug("AudioSortByArtist is enabled");
                    string path = Config.AudioSortByArtistPath;
                    bool directoryExists = DirectoryExists(path);
                    if (!directoryExists)
                    {
                        FileInfo.CreateFolder(path);
                    }
                    string firstPerformer = mp3Info.Tag.FirstPerformer;
                    if (firstPerformer != null)
                    {
                        string directoryRoot = Misc.PathCombine(path, firstPerformer [0].ToString().ToUpperInvariant());
                        FileInfo.CreateFolder(directoryRoot);
                        string directory = Misc.PathCombine(directoryRoot, race.CurrentRaceData.DirectoryName);
                        FileInfo.CreateFolder(directory);
                        Misc.CreateSymlink(directory, race.CurrentRaceData.UploadVirtualPath);
                    }
                    else
                    {
                        Log.Debug("AudioSortByArtist failed to get Artist!");
                    }
                }
                if (Config.AudioSortByGenre)
                {
                    Log.Debug("AudioSortByGenre is enabled");
                    string path = Config.AudioSortByGenrePath;
                    bool directoryExists = DirectoryExists(path);
                    if (!directoryExists)
                    {
                        FileInfo.CreateFolder(path);
                    }
                    string firstGenre = mp3Info.Tag.FirstGenre;
                    if (firstGenre != null)
                    {
                        string directoryRoot = Misc.PathCombine(path, firstGenre.ToLowerInvariant());
                        FileInfo.CreateFolder(directoryRoot);
                        string directory = Misc.PathCombine(directoryRoot, race.CurrentRaceData.DirectoryName);
                        FileInfo.CreateFolder(directory);
                        Misc.CreateSymlink(directory, race.CurrentRaceData.UploadVirtualPath);
                    }
                    else
                    {
                        Log.Debug("AudioSortByGenre failed to get Genre!");
                    }
                }
                if (Config.AudioSortByYear)
                {
                    Log.Debug("AudioSortByYear is enabled");
                    string path = Config.AudioSortByYearPath;
                    bool directoryExists = DirectoryExists(path);
                    if (!directoryExists)
                    {
                        FileInfo.CreateFolder(path);
                    }
                    UInt64 year = mp3Info.Tag.Year;
                    if (year > 0)
                    {
                        string directoryRoot = Misc.PathCombine(path, year.ToString());
                        FileInfo.CreateFolder(directoryRoot);
                        string directory = Misc.PathCombine(directoryRoot, race.CurrentRaceData.DirectoryName);
                        FileInfo.CreateFolder(directory);
                        Misc.CreateSymlink(directory, race.CurrentRaceData.UploadVirtualPath);
                    }
                    else
                    {
                        Log.Debug("AudioSortByYear failed to get year!");
                    }
                }
            }
            else
            {
                Log.Debug("AudioSort Skiped because no audio info!");
            }
        }

        /// <summary>
        /// Writes the stats to ioFTPD message file <see cref="Config.FileNameIoFtpdMessage"/>.
        /// </summary>
        /// <param name="race">The race.</param>
        /// <param name="isMp3Race">if set to <c>true</c> [is MP3 race].</param>
        /// <param name="mp3Info"><see cref="File"/></param>
        public static void WriteStatsToMesasageFile(Race race,
                                                    bool isMp3Race,
                                                    File mp3Info)
        {
            MessageMutex.WaitOne();
            Log.Debug("WriteStatsToMesasageFile");
            System.IO.FileInfo fileInfo =
                new System.IO.FileInfo(Misc.PathCombine(race.CurrentRaceData.DirectoryPath, Config.FileNameIoFtpdMessage));
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
                        textWriter.WriteLine(output.Format(Config.MessageMp3InfoHead, mp3Info));
                        textWriter.WriteLine(output.Format(Config.MessageMp3Info, mp3Info));
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

        private static readonly Mutex MessageMutex = new Mutex(false, "messageMutex");
        private static readonly Mutex RaceMutex = new Mutex(false, "raceMutex");

        public static UInt64 GetFolderSize(this DirectoryInfo directoryInfo)
        {
            return (UInt64) directoryInfo.GetFiles("*", SearchOption.AllDirectories).Sum(fi => fi.Length);
            //UInt64 totalSize = 0;
            //foreach (var fileInfo in directoryInfo.GetFiles("*", SearchOption.AllDirectories))
            //{
            //    totalSize += (UInt64)fileInfo.Length;
            //}
            //return totalSize;
        }

        /// <summary>
        /// Gets the folder count.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="archiveTask"><see cref="ArchiveTask"/>.</param>
        /// <returns></returns>
        public static List<DirectoryInfo> GetFolders(this DirectoryInfo source,
                                                     ArchiveTask archiveTask)
        {
            DirectoryInfo[] directories = source.GetDirectories();
            List<DirectoryInfo> allFolders = new List<DirectoryInfo>();
            foreach (DirectoryInfo directoryInfo in directories)
            {
                if (archiveTask.RegExpressionInclude != null)
                {
                    if (Misc.IsMatch(directoryInfo.Name, archiveTask.RegExpressionInclude))
                    {
                        allFolders.Add(directoryInfo);
                    }
                }
                else if (archiveTask.RegExpressionExclude != null)
                {
                    if (!Misc.IsMatch(directoryInfo.Name, archiveTask.RegExpressionExclude))
                    {
                        allFolders.Add(directoryInfo);
                    }
                }
                else
                {
                    allFolders.Add(directoryInfo);
                }
            }
            return allFolders;
        }

        public static string GetNewDayFolderFormat(this DateTime dateTime,
                                                   NewDayTask task)
        {
            CultureInfo cultureInfo = new CultureInfo(task.CultureInfo);
            Calendar calendar = cultureInfo.Calendar;
            return String.Format(CultureInfo.InvariantCulture, task.FolderFormat,
                                 dateTime.Day,
                                 calendar.GetWeekOfYear(dateTime, CalendarWeekRule.FirstDay, task.FirstDayOfWeek),
                                 dateTime.Month,
                                 dateTime.Year);
        }

        /// <summary>
        /// Format the time span to hh:mm:ss
        /// </summary>
        /// <param name="timeSpan"><see cref="TimeSpan"/></param>
        /// <returns><see cref="TimeSpan"/> formated as HH:MM:SS</returns>
        public static string FormatTimeSpan(this TimeSpan timeSpan)
        {
            return String.Format("{0:00}:{1:00}:{2:00}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        }

        /// <summary>
        /// Format size.
        /// </summary>
        /// <param name="bytes">total bytes.</param>
        /// <returns>Formated size like 123 MB, 123kB, ...</returns>
        public static string FormatSize(this UInt64 bytes)
        {
            UInt64 formatedSize = bytes;
            string[] postFix = new[] {"B", "kB", "MB", "GB", "TB", "PB", "EB"};
            int count = 0;
            while (formatedSize > 1024)
            {
                formatedSize = formatedSize / 1024;
                count++;
            }
            return String.Format(CultureInfo.InvariantCulture, Config.FormatedBytes, formatedSize, postFix [count]);
        }

        /// <summary>
        /// Checks if <see cref="fileExtension"/> is in <see cref="input"/>
        /// </summary>
        /// <param name="input">input string</param>
        /// <param name="fileExtension">file extension</param>
        /// <returns><c>true</c> if <see cref="input"/> contains <see cref="fileExtension"/></returns>
        public static bool StringContainsFileExt(this string input,
                                                 string fileExtension)
        {
            if (fileExtension.Length < 2)
            {
                return false;
            }
            if (fileExtension [0].Equals('.'))
            {
                fileExtension = fileExtension.Substring(1);
            }
            return input.IndexOf(fileExtension, StringComparison.InvariantCultureIgnoreCase) > -1;
        }
    }
}