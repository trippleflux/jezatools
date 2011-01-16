namespace jeza.ioFTPD.Framework
{
    public static class Config
    {
        public const string FileNameDebug = ".ioFTPD.race.Debug";
        public const string FileNameRace = ".ioFTPD.race";
        public const string FileNameIoFtpdMessage = ".ioFTPD.Message";
        public const string FileNameInternalLog = "e:\\server\\ioFTPD\\logs\\jeza.ioFTPD.log";
        public const string FileExtensionMissing = ".missing";

        public const string SkipPath = "/_HDD/ /private/ /groups/ /nocheck/ /request/nocheck/ /fonts/";
        public const string SkipFileExtension = "jpg,jpeg,cue,txt,tcl,itcl,ini,cfg,m3u,avi,mpg,mpeg,vob";

        public static bool DeleteCrc32FailedFiles = true;
        public static bool ExtractNfoFromZip = true;
        public static bool WriteStatsToMesasageFileWhenRace = true;
        public static bool WriteStatsToMesasageFileWhenComplete = true;

        public static int MaxNumberOfUserStats = 30;
        public static int MaxNumberOfGroupStats = 30;

        public static bool LogToIoFtpdSfv = true;
        public static bool LogToIoFtpdUpdate = true;
        public static bool LogToIoFtpdUpdateMp3 = true;
        public static bool LogToIoFtpdRace = true;
        public static bool LogToIoFtpdHalfway = true;
        public static bool LogToIoFtpdComplete = true;
        public static bool LogToIoFtpdUserStatsHead = true;
        public static bool LogToIoFtpdUserStatsBody = true;
        public static bool LogToIoFtpdGroupStatsHead = true;
        public static bool LogToIoFtpdGroupStatsBody = true;

        public static int LogToIoFtpdUserStatsBodyMaxNumber = 3;
        public static int LogToIoFtpdGroupStatsBodyMaxNumber = 1;
        public static int LogToIoFtpdHalfwayMinFiles = 10;

        public static bool LogToInternalSfv = true;
        public static bool LogToInternalUpdate = true;
        public static bool LogToInternalUpdateMp3 = true;
        public static bool LogToInternalRace = true;
        public static bool LogToInternalHalfway = true;
        public static bool LogToInternalComplete = true;
        public static bool LogToInternalUserStatsHead = true;
        public static bool LogToInternalUserStatsBody = true;
        public static bool LogToInternalGroupStatsHead = true;
        public static bool LogToInternalGroupStatsBody = true;

        public static int LogToInternalUserStatsBodyMaxNumber = 3;
        public static int LogToInternalGroupStatsBodyMaxNumber = 1;
        public static int LogToInternalHalfwayMinFiles = 10;

        /// <summary>
        /// The format used for output of autoformated bytes uploaded.
        /// </summary>
        /// <example>
        /// <list type="table">
        /// <item><term>{0}{1}</term><description>123MB</description></item>
        /// <item><term>{0} {1}</term><description>123 MB</description></item>
        /// <item><term>{0}_{1}</term><description>123_MB</description></item>
        /// </list>
        /// </example>
        public const string FormatedBytes = "{0}{1}";

        public const string Crc32FailedFilesExtension = ".bad";
        public const string ClientCrc32Head = " Expected Actual   Status   FileName ";
        public const string ClientCrc32Body = " {1,-8} {2,-8} {3,-8} {0,-60:B60}了ileName ExpectedCrc32 ActualCrc32 Status";
        public const string ClientCrc32Foot =   "\r\n" + 
                                                "TotalFiles...: {0}\r\n" + 
                                                "MissingFiles.: {1}\r\n" +
                                                "OkFiles......: {2}\r\n" +
                                                "FailedFiles..: {3}" + 
                                                "三otalFiles MissingFiles OkFiles FailedFiles";

        public const string ClientHead = ",----------=[ ZipScript by Jeza ]=-----------------------------------------------------------,";
        public const string ClientFileName = "| File.....: {0,-80:B79}|了ileName";
        public const string ClientFileNameOk = "| File OK..: {0,-80:B79}|了ileName";
        public const string ClientFileNameSkip = "| Skip.....: {0,-80:B79}|了ileName";
        public const string ClientFileNameBadCrc = "| Bad CRC..: {0,-80:B79}|了ileName";
        public const string ClientFileNameNoDiz = "| No DIZ...: {0,-80:B79}|了ileName";
        public const string ClientFileNameSfv = "| SFV......: {0,-80:B79}|了ileName";
        public const string ClientFileNameSfvExists = "| Deleting.: SFV allready exists!                                                            |";
        public const string ClientFileNameSfvFirst = "| Deleting.: Upload SFV first!                                                               |";
        public const string ClientMp3InfoHead = "|----------=[ Mp3 Info          ]=-----------------------------------------------------------|";
        public const string ClientMp3Info = "| Track....: {0,-80:B79}|\r\n" + 
                                            "| Title....: {1,-80:B79}|\r\n" + 
                                            "| Artist...: {2,-80:B79}|\r\n" + 
                                            "| Album....: {3,-80:B79}|\r\n" + 
                                            "| Year.....: {4,-80:B79}|\r\n" +
                                            "| Genre....: {5,-80:B79}|" + 
                                            "三rackNumber Title Artist Album Year Genre";
        public const string ClientStatsUsersHead = "|----------=[ User Stats        ]=-----------------------------------------------------------|";
        public const string ClientStatsUsers = "| {0,10:B2}. {1,-23:B23} {2,6:B6} {3,6:B6}kBit/s {4,4:B4}F                              |匕ossition UserName FormatBytesUploaded AverageSpeed FilesUploaded";
        public const string ClientStatsGroupsHead = "|----------=[ Group Stats       ]=-----------------------------------------------------------|";
        public const string ClientStatsGroups = "| {0,10:B2}. {1,-23:B23} {2,6:B6} {3,6:B6}kBit/s {4,4:B4}F                              |匕ossition GroupName FormatBytesUploaded AverageSpeed FilesUploaded";
        public const string ClientFoot = "'---------------------------------------------------------------------=[ {0,3:B3}/{1,-3:B3} ]=----------'三otalFilesUploaded TotalFilesExpected";
        public const string ClientFootProgressBar = "'----------=[ {2,17:B17} ]=------------------------------------=[ {0,3:B3}/{1,-3:B3} ]=----------'三otalFilesUploaded TotalFilesExpected ProgressBar";

        public const string MessageMp3InfoHead = "|----------=[ Mp3 Info          ]=-----------------------------------------------------------|";
        public const string MessageMp3Info =    "| Artist...: {0,-80:B79}|\r\n" +
                                                "| Album....: {1,-80:B79}|\r\n" +
                                                "| Year.....: {2,-80:B79}|\r\n" +
                                                "| Genre....: {3,-80:B79}|" +
                                                "乙rtist Album Year Genre";
        public const string MessageStatsUsersHead = "|----------=[ User Stats        ]=-----------------------------------------------------------|";
        public const string MessageStatsUsers = "| {0,10:B2}. {1,-23:B23} {2,6:B6} {3,6:B6}kBit/s {4,4:B4}F                              |匕ossition UserName FormatBytesUploaded AverageSpeed FilesUploaded";
        public const string MessageStatsGroupsHead = "|----------=[ Group Stats       ]=-----------------------------------------------------------|";
        public const string MessageStatsGroups = "| {0,10:B2}. {1,-23:B23} {2,6:B6} {3,6:B6}kBit/s {4,4:B4}F                              |匕ossition GroupName FormatBytesUploaded AverageSpeed FilesUploaded";
        public const string MessageFoot = "'---------------------------------------------------------------------=[ {0,3:B3}/{1,-3:B3} ]=----------'三otalFilesUploaded TotalFilesExpected";

        public const string LogLineIoFtpdSfv = "SFV: \"{0}\" \"{4}03{3}sfv{3}{4} {3}{1}{3} [{3}{2}{3}F]\"下ploadVirtualPath ReleaseName TotalFilesExpected ircBold ircColor";
        public const string LogLineIoFtpdUpdate = "UPDATE: \"{0}\" \"{4}04{3}info{3}{4} {3}{1}{3} [{3}{5}{3} in {3}{2}F{3}]\"下ploadVirtualPath ReleaseName TotalFilesExpected ircBold ircColor FormatTotalBytesExpected";
        public const string LogLineIoFtpdUpdateMp3 = "UPDATE: \"{0}\" \"{4}04{3}info{3}{4} {3}{1}{3} [{3}{5}{3} in {3}{2}F{3} @ {3}{6}{7}{6}{3} {3}{8}{3}]\"下ploadVirtualPath ReleaseName TotalFilesExpected ircBold ircColor FormatTotalBytesExpected ircUnderline Genre Year";
        public const string LogLineIoFtpdHalfway = "HALFWAY: \"{0}\" \"{4}04{3}halfway{3}{4} {3}{1}{3} [{3}{5}{3}Groups / {3}{2}{3}Users @ {3}{6}kBps{3}]\"下ploadVirtualPath ReleaseName TotalUsersRacing ircBold ircColor TotalGroupsRacing TotalAvarageSpeed";
        public const string LogLineIoFtpdRace = "RACE: \"{0}\" \"{3}04{2}race{2}{3} {2}{1}{2} [{2}{4}{2}/{5} @ {2}{6}{2}kBps]\"下ploadVirtualPath ReleaseName ircBold ircColor UserName GroupName AverageSpeed";
        public const string LogLineIoFtpdComplete = "COMPLETE: \"{0}\" \"{4}12{3}complete{3}{4} {3}{1}{3} [{3}{5}{3} in {3}{2}F{3} @ {3}{6}kBps{3}]\"下ploadVirtualPath ReleaseName TotalFilesExpected ircBold ircColor FormatBytesUploaded TotalAvarageSpeed";
        public const string LogLineIoFtpdUserStatsHead = "STATS: \"{0}\" \"User Stats:\"下ploadVirtualPath";
        public const string LogLineIoFtpdUserStatsBody = "STATS: \"{0}\" \"{1,2:B2}. {2,-14:B14} {3,6:B6} {4,6:B6}kBit/s {5,4:B4}F\"下ploadVirtualPath Possition UserName FormatBytesUploaded AverageSpeed FilesUploaded";
        public const string LogLineIoFtpdGroupStatsHead = "STATS: \"{0}\" \"Group Stats:\"下ploadVirtualPath";
        public const string LogLineIoFtpdGroupStatsBody = "STATS: \"{0}\" \"{1,2:B2}. {2,-14:B14} {3,6:B6} {4,6:B6}kBit/s {5,4:B4}F\"下ploadVirtualPath Possition GroupName FormatBytesUploaded AverageSpeed FilesUploaded";

        public const string LogLineInternalSfv = "SFV: \"{0}\" \"{4}03{3}sfv{3}{4} {3}{1}{3} [{3}{2}{3}F]\"下ploadVirtualPath ReleaseName TotalFilesExpected ircBold ircColor";
        public const string LogLineInternalUpdate = "UPDATE: \"{0}\" \"{4}04{3}info{3}{4} {3}{1}{3} [{3}{5}{3} in {3}{2}F{3}]\"下ploadVirtualPath ReleaseName TotalFilesExpected ircBold ircColor FormatTotalBytesExpected";
        public const string LogLineInternalUpdateMp3 = "UPDATE: \"{0}\" \"{4}04{3}info{3}{4} {3}{1}{3} [{3}{5}{3} in {3}{2}F{3} @ {3}{6}{7}{6}{3} {3}{8}{3}]\"下ploadVirtualPath ReleaseName TotalFilesExpected ircBold ircColor FormatTotalBytesExpected ircUnderline Genre Year";
        public const string LogLineInternalRace = "RACE: \"{0}\" \"{3}04{2}race{2}{3} {2}{1}{2} [{2}{4}{2}/{5} @ {2}{6}{2}kBps]\"下ploadVirtualPath ReleaseName ircBold ircColor UserName GroupName AverageSpeed";
        public const string LogLineInternalHalfway = "HALFWAY: \"{0}\" \"{4}04{3}halfway{3}{4} {3}{1}{3} [{3}{5}{3}Groups / {3}{2}{3}Users @ {3}{6}kBps{3}]\"下ploadVirtualPath ReleaseName TotalUsersRacing ircBold ircColor TotalGroupsRacing TotalAvarageSpeed";
        public const string LogLineInternalComplete = "COMPLETE: \"{0}\" \"{4}12{3}complete{3}{4} {3}{1}{3} [{3}{5}{3} in {3}{2}F{3} @ {3}{6}kBps{3}]\"下ploadVirtualPath ReleaseName TotalFilesExpected ircBold ircColor FormatBytesUploaded TotalAvarageSpeed";
        public const string LogLineInternalUserStatsHead = "STATS: \"{0}\" \"User Stats:\"下ploadVirtualPath";
        public const string LogLineInternalUserStatsBody = "STATS: \"{0}\" \"{1,2:B2}. {2,-14:B14} {3,6:B6} {4,6:B6}kBit/s {5,4:B4}F\"下ploadVirtualPath Possition UserName FormatBytesUploaded AverageSpeed FilesUploaded";
        public const string LogLineInternalGroupStatsHead = "STATS: \"{0}\" \"Group Stats:\"下ploadVirtualPath";
        public const string LogLineInternalGroupStatsBody = "STATS: \"{0}\" \"{1,2:B2}. {2,-14:B14} {3,6:B6} {4,6:B6}kBit/s {5,4:B4}F\"下ploadVirtualPath Possition GroupName FormatBytesUploaded AverageSpeed FilesUploaded";

        public const int ProgressBarLength = 17;
        public const char ProgressBarCharFilled = '#';
        public const char ProgressBarCharMissing = '-';

        public const string Mp3SortPathArtist = "c:\\sorted\\by.artist";
        public const string Mp3SortPathGenre = "c:\\sorted\\by.genre";
        public const string Mp3SortPathYear = "c:\\sorted\\by.year";

        /*
         * Th tag cannot contain the following characters : \ / : * ? " < > |
         */
        public const string TagCleanUpString = "]-["; //delete all files that start with this string in race folder
        public const string TagIncomplete = "]-[iNCOMPLETE]-[ {0}% ]-[{1}FiLE(s) of {2}FiLE(s)]-[iNCOMPLETE]-[匕ercentComplete TotalFilesUploaded TotalFilesExpected";
        public const string TagComplete = "]-[Complete]-[{2}%]-[ {0} - {1}F]-[了ormatBytesUploaded TotalFilesUploaded PercentComplete";
        public const string TagCompleteMp3 = "]-[Complete]-[{2}%]-[ {0} - {1}F]-[{4} - {3}]-[了ormatBytesUploaded TotalFilesUploaded PercentComplete Year Genre";
        public const string TagIncompleteLink = "[iNCOMPLETE]-{0}卜eleaseName";
        public const string TagIncompleteLinkDiscNumber = "[iNCOMPLETE]-{0}_{1}卜eleaseName DiscNumber";
        public const int TagIncompleteLinkChMod = 755;
    }
}