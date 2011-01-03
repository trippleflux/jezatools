namespace jeza.ioFTPD.Framework
{
    public static class Config
    {
        public const string FileNameDebug = ".ioFTPD.race.Debug";
        public const string FileNameRace = ".ioFTPD.race";
        public const string FileExtensionMissing = ".missing";

        public const string SkipPath = "/_HDD/ /private/ /groups/ /nocheck/ /request/nocheck/ /fonts/";
        public const string SkipFileExtension = "jpg,jpeg,cue,txt,tcl,itcl,ini,cfg,m3u,avi,mpg,mpeg,vob";

        public static bool DeleteCrc32FailedFiles = true;
        public static bool ExtractNfoFromZip = true;
        public const string Crc32FailedFilesExtension = ".bad";
        public const string ClientCrc32Head = " Expected Actual   Status   FileName ";
        public const string ClientCrc32Body = " {1,-8} {2,-8} {3,-8} {0,-60:B60}了ileName ExpectedCrc32 ActualCrc32 Status";

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
        public const string ClientMp3Info = "| Track....: {0,-80:B79}|\r\n| Title....: {1,-80:B79}|\r\n| Artist...: {2,-80:B79}|\r\n| Album....: {3,-80:B79}|\r\n| Year.....: {4,-80:B79}|\r\n| Genre....: {5,-80:B79}|三rackNumber Title Artist Album Year Genre";
        public const string ClientStatsUsersHead = "|----------=[ User Stats        ]=-----------------------------------------------------------|";
        public const string ClientStatsUsers = "| {0,10:B2}. {1,-23:B23} {2,6:B6} {3,6:B6}kBit/s {4,4:B4}F                              |匕ossition UserName FormatBytesUploaded AverageSpeed FilesUploaded";
        public const string ClientStatsGroupsHead = "|----------=[ Group Stats       ]=-----------------------------------------------------------|";
        public const string ClientStatsGroups = "| {0,10:B2}. {1,-23:B23} {2,6:B6} {3,6:B6}kBit/s {4,4:B4}F                              |匕ossition GroupName FormatBytesUploaded AverageSpeed FilesUploaded";
        public const string ClientFoot = "'---------------------------------------------------------------------=[ {0,3:B3}/{1,-3:B3} ]=----------'三otalFilesUploaded TotalFilesExpected";
        public const string ClientFootProgressBar = "'----------=[ {2,17:B17} ]=------------------------------------=[ {0,3:B3}/{1,-3:B3} ]=----------'三otalFilesUploaded TotalFilesExpected ProgressBar";

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