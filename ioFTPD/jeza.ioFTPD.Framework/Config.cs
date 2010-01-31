namespace jeza.ioFTPD.Framework
{
    public static class Config
    {
        public const string FileNameRace = ".ioFTPD.race";
        public const string FileExtensionMissing = ".missing";

        public const string ClientHead =
            ",----------=[ ZipScript by Jeza ]=-----------------------------------------------------------,";

        public const string ClientFileName = "| File.....: {0,-80:B79}|了ileName";
        public const string ClientFileNameOk = "| File OK..: {0,-80:B79}|了ileName";
        public const string ClientFileNameBadCrc = "| Bad CRC..: {0,-80:B79}|了ileName";
        public const string ClientFileNameSfv = "| SFV......: {0,-80:B79}|了ileName";
        public const string ClientFileNameSfvExists = "| Deleting.: {0,-80:B79}|又FV allready exists!";
        public const string ClientFileNameSfvFirst = "| Deleting.: {0,-80:B79}|下pload SFV first!";

        public const string ClientFoot =
            "'---------------------------------------------------------------------=[ {0,3:B3}/{1,-3:B3} ]=----------'三otalFilesUploaded TotalFilesExpected";

        /*
         * Th tag cannot contain the following characters : \ / : * ? " < > |
         */
        public const bool TagAsFile = true;
        public const string TagCleanUpString = "]-[";  //deete all files that start with this string in race folder
        public const string TagIncompleteRar = "]-[iNCOMPLETE]-[ {0}% ]-[{1}FiLE(s) of {2}FiLE(s)]-[iNCOMPLETE]-[匕ercentComplete TotalFilesUploaded TotalFilesExpected";
        public const string TagCompleteRar = "]-[Complete {0}MB - {1}F]-[三otalMegaBytesUploaded TotalFilesUploaded";
    }
}