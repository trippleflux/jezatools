namespace jeza.ioFTPD.Framework
{
    public static class Config
    {
        public const bool Debug = true;

        public const string FileNameDebug = ".ioFTPD.race.Debug";
        public const string FileNameRace = ".ioFTPD.race";
        public const string FileExtensionMissing = ".missing";

        public const string SkipPath = "/private/"; 
        
        public const string ClientHead = ",----------=[ ZipScript by Jeza ]=-----------------------------------------------------------,";
        public const string ClientFileName = "| File.....: {0,-80:B79}|了ileName";
        public const string ClientFileNameOk = "| File OK..: {0,-80:B79}|了ileName";
        public const string ClientFileNameSkip = "| Skip.....: {0,-80:B79}|了ileName";
        public const string ClientFileNameBadCrc = "| Bad CRC..: {0,-80:B79}|了ileName";
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
        /*
         * Th tag cannot contain the following characters : \ / : * ? " < > |
         */
        public const bool TagAsFile = true;
        public const string TagCleanUpString = "]-["; //deete all files that start with this string in race folder
        public const string TagIncomplete = "]-[iNCOMPLETE]-[ {0}% ]-[{1}FiLE(s) of {2}FiLE(s)]-[iNCOMPLETE]-[匕ercentComplete TotalFilesUploaded TotalFilesExpected";
        public const string TagComplete = "]-[Complete]-[{2}%]-[ {0} - {1}F]-[了ormatBytesUploaded TotalFilesUploaded PercentComplete";
        public const string TagIncompleteLink = "[iNCOMPLETE]-{0}卜eleaseName";
        public const string TagIncompleteLinkDiscNumber = "[iNCOMPLETE]-{0}_{1}卜eleaseName DiscNumber";
        public const int TagIncompleteLinkChMod = 755;
    }
}