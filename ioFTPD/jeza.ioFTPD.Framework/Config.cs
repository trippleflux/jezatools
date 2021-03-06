using System.Configuration;

namespace jeza.ioFTPD.Framework
{
    //public const string {[a-zA-Z0-9]+} = {:q}
    //\<add key=\"\1\" value=\2 /\>

    //public const string {[a-zA-Z0-9]+} = {:q};
    //public static string \1 {get { return GetKeyValue("\1"); }}

    //public const int {[a-zA-Z0-9]+} = {:z};
    //public static int \1 {get { return Misc.String2Number(GetKeyValue("\1")); }}

    //public static int \1 {get { return Misc.String2Boolean(GetKeyValue("\1")); }}

    //public static string \1 {get { return GetKeyValue("\1"); }}
    //\<add key=\"\1\" value=\2 /\>
    public static class Config
    {
        /// <summary>
        /// Gets the key value from configuration file.
        /// </summary>
        /// <param name="keyName">Name of the key.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>Key value or <see cref="defaultValue"/></returns>
        public static string GetKeyValue(string keyName,
                                         string defaultValue)
        {
            return GetKeyValue(keyName) ?? defaultValue;
        }

        /// <summary>
        /// Gets the key value from configuration file.
        /// </summary>
        /// <param name="keyName">Name of the key.</param>
        /// <returns>Key value or <c>null</c>.</returns>
        public static string GetKeyValue(string keyName)
        {
            try
            {
                string appSetting = ConfigurationManager.AppSettings [keyName];
                if (appSetting == null)
                {
                    Log.Debug("Failed to get AppSettings[\"{0}\"]", keyName);
                }
                return appSetting;
            }
            catch (ConfigurationErrorsException configurationErrorsException)
            {
                Log.Debug(configurationErrorsException.ToString());
                return null;
            }
        }

        public const string DefaultNamespace = "http://jeza.ioFTPD.Tools/XMLSchema.xsd";
        public const string DefaultNamespaceTrialQuota = "http://jeza.ioFTPD.Tools/TrialQuotaSchema.xsd";

        public static bool UseResceneInfoOnRarComplete
        {
            get { return Misc.String2Boolean(GetKeyValue("UseResceneInfoOnRarComplete")); }
        }

        public static string ResceneInfoExecutable
        {
            get { return GetKeyValue("ResceneInfoExecutable"); }
        }

        public static string ExtractRarOnComplete
        {
            get { return GetKeyValue("ExtractRarOnComplete"); }
        }

        public static bool UpdateDupe
        {
            get { return Misc.String2Boolean(GetKeyValue("UpdateDupe")); }
        }

        public static string DataSourceDupeUpdateCommand
        {
            get { return GetKeyValue("DataSourceDupeUpdateCommand"); }
        }

        public static bool LogToConsole
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToConsole")); }
        }

        public static string TagCleanUpStringCrc32
        {
            get { return GetKeyValue("TagCleanUpStringCrc32"); }
        }

        public static string TagIncompleteCrc32
        {
            get { return GetKeyValue("TagIncompleteCrc32"); }
        }

        public static string TagCompleteCrc32
        {
            get { return GetKeyValue("TagCompleteCrc32"); }
        }

        public static string TagIncompleteLinkCrc32
        {
            get { return GetKeyValue("TagIncompleteLinkCrc32"); }
        }

        public static bool TagAsFolderCrc32
        {
            get { return Misc.String2Boolean(GetKeyValue("TagAsFolderCrc32")); }
        }

        public static bool TagAsFolder
        {
            get { return Misc.String2Boolean(GetKeyValue("TagAsFolder")); }
        }

        public static int TrialDefaultTime
        {
            get { return Misc.String2Number(GetKeyValue("TrialDefaultTime")); }
        }

        public static int TrialDefaultQuota
        {
            get { return Misc.String2Number(GetKeyValue("TrialDefaultQuota")); }
        }

        public static string ClientTrialListHead
        {
            get { return GetKeyValue("ClientTrialListHead"); }
        }

        public static string ClientTrialListBody
        {
            get { return GetKeyValue("ClientTrialListBody"); }
        }

        public static string ClientTrialListFoot
        {
            get { return GetKeyValue("ClientTrialListFoot"); }
        }

        public static string ClientTrialUserNotFound
        {
            get { return GetKeyValue("ClientTrialUserNotFound"); }
        }

        public static string ClientTrialUserExists
        {
            get { return GetKeyValue("ClientTrialUserExists"); }
        }

        public static string ClientTrialUserRemove
        {
            get { return GetKeyValue("ClientTrialUserRemove"); }
        }

        public static string ClientTrialUserRemoveFail
        {
            get { return GetKeyValue("ClientTrialUserRemoveFail"); }
        }

        public static string ClientTrialUserAdd
        {
            get { return GetKeyValue("ClientTrialUserAdd"); }
        }

        public static int TrialFailedFlag
        {
            get { return Misc.String2Number(GetKeyValue("TrialFailedFlag")); }
        }

        public static string RequestFileMessage
        {
            get { return GetKeyValue("RequestFileMessage"); }
        }

        public static bool LogToIoFtpdDupe
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToIoFtpdDupe")); }
        }

        public static bool LogToInternalDupe
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToInternalDupe")); }
        }

        public static string ClientDupeRemove
        {
            get { return GetKeyValue("ClientDupeRemove"); }
        }

        public static string ClientDupeRemoveNotFound
        {
            get { return GetKeyValue("ClientDupeRemoveNotFound"); }
        }

        public static string LogLineIoFtpdDupe
        {
            get { return GetKeyValue("LogLineIoFtpdDupe"); }
        }

        public static string LogLineInternalDupe
        {
            get { return GetKeyValue("LogLineInternalDupe"); }
        }

        public static bool LogToIoFtpdRequest
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToIoFtpdRequest")); }
        }

        public static bool LogToIoFtpdRequestFilled
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToIoFtpdRequestFilled")); }
        }

        public static bool LogToIoFtpdRequestDeleted
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToIoFtpdRequestDeleted")); }
        }

        public static bool LogToInternalRequest
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToInternalRequest")); }
        }

        public static bool LogToInternalRequestFilled
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToInternalRequestFilled")); }
        }

        public static bool LogToInternalRequestDeleted
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToInternalRequestDeleted")); }
        }

        public static string LogLineIoFtpdRequest
        {
            get { return GetKeyValue("LogLineIoFtpdRequest"); }
        }

        public static string LogLineIoFtpdRequestFilled
        {
            get { return GetKeyValue("LogLineIoFtpdRequestFilled"); }
        }

        public static string LogLineIoFtpdRequestDeleted
        {
            get { return GetKeyValue("LogLineIoFtpdRequestDeleted"); }
        }

        public static string LogLineInternalRequest
        {
            get { return GetKeyValue("LogLineInternalRequest"); }
        }

        public static string LogLineInternalRequestFilled
        {
            get { return GetKeyValue("LogLineInternalRequestFilled"); }
        }

        public static string LogLineInternalRequestDeleted
        {
            get { return GetKeyValue("LogLineInternalRequestDeleted"); }
        }

        public static string TmdbApiKey
        {
            get { return GetKeyValue("TmdbApiKey"); }
        }

        public static string DataSourceDupe
        {
            get { return GetKeyValue("DataSourceDupe"); }
        }

        public static string ClientDupeNewDir
        {
            get { return GetKeyValue("ClientDupeNewDir"); }
        }

        public static string ClientDupeListHead
        {
            get { return GetKeyValue("ClientDupeListHead"); }
        }

        public static string ClientDupeListBody
        {
            get { return GetKeyValue("ClientDupeListBody"); }
        }

        public static string ClientDupeListFoot
        {
            get { return GetKeyValue("ClientDupeListFoot"); }
        }

        public static string RequestFolder
        {
            get { return GetKeyValue("RequestFolder"); }
        }

        public static string RequestPrefix
        {
            get { return GetKeyValue("RequestPrefix"); }
        }

        public static string RequestFilled
        {
            get { return GetKeyValue("RequestFilled"); }
        }

        public static string ClientRequestHead
        {
            get { return GetKeyValue("ClientRequestHead"); }
        }

        public static string ClientRequestBody
        {
            get { return GetKeyValue("ClientRequestBody"); }
        }

        public static string ClientRequestFoot
        {
            get { return GetKeyValue("ClientRequestFoot"); }
        }

        public static string FileNameDebug
        {
            get { return GetKeyValue("FileNameDebug", ".jeza.ioFTPD.Debug"); }
        }

        public static string FileNameRace
        {
            get { return GetKeyValue("FileNameRace", ".jeza.ioFTPD.Race"); }
        }

        public static string FileNameConfiguration
        {
            get { return GetKeyValue("FileNameConfiguration"); }
        }

        public static string ClientWeeklyList
        {
            get { return GetKeyValue("ClientWeeklyList"); }
        }

        public static string FileNameIoFtpdMessage
        {
            get { return GetKeyValue("FileNameIoFtpdMessage", ".ioFTPD.Message"); }
        }

        public static string FileNameInternalLog
        {
            get { return GetKeyValue("FileNameInternalLog"); }
        }

        public static string FileExtensionCrc32Failed
        {
            get { return GetKeyValue("FileExtensionCrc32Failed"); }
        }

        public static string FileExtensionMissing
        {
            get { return GetKeyValue("FileExtensionMissing"); }
        }

        public static string FileExtensionSfv
        {
            get { return GetKeyValue("FileExtensionSfv"); }
        }

        public static string FileExtensionAudio
        {
            get { return GetKeyValue("FileExtensionAudio"); }
        }

        public static string FileExtensionZip
        {
            get { return GetKeyValue("FileExtensionZip"); }
        }

        public static string FileExtensionNfo
        {
            get { return GetKeyValue("FileExtensionNfo"); }
        }

        public static string FileExtensionDiz
        {
            get { return GetKeyValue("FileExtensionDiz"); }
        }

        public static string FileExtensionRefuse
        {
            get { return GetKeyValue("FileExtensionRefuse"); }
        }

        public static string FileExtensionSkip
        {
            get { return GetKeyValue("FileExtensionSkip"); }
        }

        public static string SpeedTestFolder
        {
            get { return GetKeyValue("SpeedTestFolder"); }
        }

        public static string SkipPath
        {
            get { return GetKeyValue("SkipPath"); }
        }

        public static string SkipPathMessageFile
        {
            get { return GetKeyValue("SkipPathMessageFile"); }
        }

        public static bool DeleteCrc32FailedFiles
        {
            get { return Misc.String2Boolean(GetKeyValue("DeleteCrc32FailedFiles")); }
        }

        public static bool ExtractNfoFromZip
        {
            get { return Misc.String2Boolean(GetKeyValue("ExtractNfoFromZip")); }
        }

        public static bool WriteStatsToMesasageFileWhenRace
        {
            get { return Misc.String2Boolean(GetKeyValue("WriteStatsToMesasageFileWhenRace")); }
        }

        public static bool WriteStatsToMesasageFileWhenComplete
        {
            get { return Misc.String2Boolean(GetKeyValue("WriteStatsToMesasageFileWhenComplete")); }
        }

        public static bool DeleteSpeedTest
        {
            get { return Misc.String2Boolean(GetKeyValue("DeleteSpeedTest")); }
        }

        public static bool AudioGenresAllowedCheck
        {
            get { return Misc.String2Boolean(GetKeyValue("AudioGenresAllowedCheck")); }
        }

        public static bool AudioGenresBannedCheck
        {
            get { return Misc.String2Boolean(GetKeyValue("AudioGenresBannedCheck")); }
        }

        public static int MaxNumberOfUserStats
        {
            get { return Misc.String2Number(GetKeyValue("MaxNumberOfUserStats")); }
        }

        public static int MaxNumberOfGroupStats
        {
            get { return Misc.String2Number(GetKeyValue("MaxNumberOfGroupStats")); }
        }

        public static bool LogToIoFtpdSfv
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToIoFtpdSfv")); }
        }

        public static bool LogToIoFtpdUpdate
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToIoFtpdUpdate")); }
        }

        public static bool LogToIoFtpdUpdateNfo
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToIoFtpdUpdateNfo")); }
        }

        public static bool LogToIoFtpdUpdateImdb
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToIoFtpdUpdateImdb")); }
        }

        public static bool LogToIoFtpdUpdateMp3
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToIoFtpdUpdateMp3")); }
        }

        public static bool LogToIoFtpdRace
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToIoFtpdRace")); }
        }

        public static bool LogToIoFtpdHalfway
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToIoFtpdHalfway")); }
        }

        public static bool LogToIoFtpdLeadUser
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToIoFtpdLeadUser")); }
        }

        public static bool LogToIoFtpdLeadGroup
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToIoFtpdLeadGroup")); }
        }

        public static bool LogToIoFtpdComplete
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToIoFtpdComplete")); }
        }

        public static bool LogToIoFtpdUserStatsHead
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToIoFtpdUserStatsHead")); }
        }

        public static bool LogToIoFtpdUserStatsBody
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToIoFtpdUserStatsBody")); }
        }

        public static bool LogToIoFtpdGroupStatsHead
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToIoFtpdGroupStatsHead")); }
        }

        public static bool LogToIoFtpdGroupStatsBody
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToIoFtpdGroupStatsBody")); }
        }

        public static bool LogToIoFtpdSpeedTest
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToIoFtpdSpeedTest")); }
        }

        public static int LogToIoFtpdUserStatsBodyMaxNumber
        {
            get { return Misc.String2Number(GetKeyValue("LogToIoFtpdUserStatsBodyMaxNumber")); }
        }

        public static int LogToIoFtpdGroupStatsBodyMaxNumber
        {
            get { return Misc.String2Number(GetKeyValue("LogToIoFtpdGroupStatsBodyMaxNumber")); }
        }

        public static int LogToIoFtpdHalfwayMinFiles
        {
            get { return Misc.String2Number(GetKeyValue("LogToIoFtpdHalfwayMinFiles")); }
        }

        public static bool LogToInternalSfv
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToInternalSfv")); }
        }

        public static bool LogToInternalUpdate
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToInternalUpdate")); }
        }

        public static bool LogToInternalUpdateNfo
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToInternalUpdateNfo")); }
        }

        public static bool LogToInternalUpdateImdb
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToInternalUpdateImdb")); }
        }

        public static bool LogToInternalUpdateMp3
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToInternalUpdateMp3")); }
        }

        public static bool LogToInternalRace
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToInternalRace")); }
        }

        public static bool LogToInternalHalfway
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToInternalHalfway")); }
        }

        public static bool LogToInternalLeadUser
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToInternalLeadUser")); }
        }

        public static bool LogToInternalLeadGroup
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToInternalLeadGroup")); }
        }

        public static bool LogToInternalComplete
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToInternalComplete")); }
        }

        public static bool LogToInternalUserStatsHead
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToInternalUserStatsHead")); }
        }

        public static bool LogToInternalUserStatsBody
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToInternalUserStatsBody")); }
        }

        public static bool LogToInternalGroupStatsHead
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToInternalGroupStatsHead")); }
        }

        public static bool LogToInternalGroupStatsBody
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToInternalGroupStatsBody")); }
        }

        public static bool LogToInternalSpeedTest
        {
            get { return Misc.String2Boolean(GetKeyValue("LogToInternalSpeedTest")); }
        }

        public static int LogToInternalUserStatsBodyMaxNumber
        {
            get { return Misc.String2Number(GetKeyValue("LogToInternalUserStatsBodyMaxNumber")); }
        }

        public static int LogToInternalGroupStatsBodyMaxNumber
        {
            get { return Misc.String2Number(GetKeyValue("LogToInternalGroupStatsBodyMaxNumber")); }
        }

        public static int LogToInternalHalfwayMinFiles
        {
            get { return Misc.String2Number(GetKeyValue("LogToInternalHalfwayMinFiles")); }
        }

        public static string FormatedBytes
        {
            get { return GetKeyValue("FormatedBytes", "{0}{1}"); }
        }

        public static string ClientCrc32Head
        {
            get { return GetKeyValue("ClientCrc32Head"); }
        }

        public static string ClientCrc32Body
        {
            get { return GetKeyValue("ClientCrc32Body"); }
        }

        public static string ClientCrc32Foot
        {
            get { return GetKeyValue("ClientCrc32Foot"); }
        }

        public static string ClientHead
        {
            get { return GetKeyValue("ClientHead"); }
        }

        public static string ClientFileName
        {
            get { return GetKeyValue("ClientFileName"); }
        }

        public static string ClientFileNameOk
        {
            get { return GetKeyValue("ClientFileNameOk"); }
        }

        public static string ClientFileNameSkip
        {
            get { return GetKeyValue("ClientFileNameSkip"); }
        }

        public static string ClientFileNameBadCrc
        {
            get { return GetKeyValue("ClientFileNameBadCrc"); }
        }

        public static string ClientFileNameNoDiz
        {
            get { return GetKeyValue("ClientFileNameNoDiz"); }
        }

        public static string ClientFileNameSfv
        {
            get { return GetKeyValue("ClientFileNameSfv"); }
        }

        public static string ClientFileNameSfvExists
        {
            get { return GetKeyValue("ClientFileNameSfvExists"); }
        }

        public static string ClientFileNameSfvFirst
        {
            get { return GetKeyValue("ClientFileNameSfvFirst"); }
        }

        public static string ClientFileNameAudioGenreNotAllowed
        {
            get { return GetKeyValue("ClientFileNameAudioGenreNotAllowed"); }
        }

        public static string ClientMp3InfoHead
        {
            get { return GetKeyValue("ClientMp3InfoHead"); }
        }

        public static string ClientMp3Info
        {
            get { return GetKeyValue("ClientMp3Info"); }
        }

        public static string ClientStatsUsersHead
        {
            get { return GetKeyValue("ClientStatsUsersHead"); }
        }

        public static string ClientStatsUsers
        {
            get { return GetKeyValue("ClientStatsUsers"); }
        }

        public static string ClientStatsGroupsHead
        {
            get { return GetKeyValue("ClientStatsGroupsHead"); }
        }

        public static string ClientStatsGroups
        {
            get { return GetKeyValue("ClientStatsGroups"); }
        }

        public static string ClientFoot
        {
            get { return GetKeyValue("ClientFoot"); }
        }

        public static string ClientFootProgressBar
        {
            get { return GetKeyValue("ClientFootProgressBar"); }
        }

        public static string MessageMp3InfoHead
        {
            get { return GetKeyValue("MessageMp3InfoHead"); }
        }

        public static string MessageMp3Info
        {
            get { return GetKeyValue("MessageMp3Info"); }
        }

        public static string MessageStatsUsersHead
        {
            get { return GetKeyValue("MessageStatsUsersHead"); }
        }

        public static string MessageStatsUsers
        {
            get { return GetKeyValue("MessageStatsUsers"); }
        }

        public static string MessageStatsGroupsHead
        {
            get { return GetKeyValue("MessageStatsGroupsHead"); }
        }

        public static string MessageStatsGroups
        {
            get { return GetKeyValue("MessageStatsGroups"); }
        }

        public static string MessageFoot
        {
            get { return GetKeyValue("MessageFoot"); }
        }

        public static string LogLineIoFtpdSfv
        {
            get { return GetKeyValue("LogLineIoFtpdSfv"); }
        }

        public static string LogLineIoFtpdUpdate
        {
            get { return GetKeyValue("LogLineIoFtpdUpdate"); }
        }

        public static string LogLineIoFtpdUpdateNfo
        {
            get { return GetKeyValue("LogLineIoFtpdUpdateNfo"); }
        }

        public static string LogLineIoFtpdUpdateImdb
        {
            get { return GetKeyValue("LogLineIoFtpdUpdateImdb"); }
        }

        public static string LogLineIoFtpdUpdateMp3
        {
            get { return GetKeyValue("LogLineIoFtpdUpdateMp3"); }
        }

        public static string LogLineIoFtpdHalfway
        {
            get { return GetKeyValue("LogLineIoFtpdHalfway"); }
        }

        public static string LogLineIoFtpdRace
        {
            get { return GetKeyValue("LogLineIoFtpdRace"); }
        }

        public static string LogLineIoFtpdLeadUser
        {
            get { return GetKeyValue("LogLineIoFtpdLeadUser"); }
        }

        public static string LogLineIoFtpdLeadGroup
        {
            get { return GetKeyValue("LogLineIoFtpdLeadGroup"); }
        }

        public static string LogLineIoFtpdComplete
        {
            get { return GetKeyValue("LogLineIoFtpdComplete"); }
        }

        public static string LogLineIoFtpdUserStatsHead
        {
            get { return GetKeyValue("LogLineIoFtpdUserStatsHead"); }
        }

        public static string LogLineIoFtpdUserStatsBody
        {
            get { return GetKeyValue("LogLineIoFtpdUserStatsBody"); }
        }

        public static string LogLineIoFtpdGroupStatsHead
        {
            get { return GetKeyValue("LogLineIoFtpdGroupStatsHead"); }
        }

        public static string LogLineIoFtpdGroupStatsBody
        {
            get { return GetKeyValue("LogLineIoFtpdGroupStatsBody"); }
        }

        public static string LogLineIoFtpdSpeedTest
        {
            get { return GetKeyValue("LogLineIoFtpdSpeedTest"); }
        }

        public static string LogLineInternalSfv
        {
            get { return GetKeyValue("LogLineInternalSfv"); }
        }

        public static string LogLineInternalUpdate
        {
            get { return GetKeyValue("LogLineInternalUpdate"); }
        }

        public static string LogLineInternalUpdateNfo
        {
            get { return GetKeyValue("LogLineInternalUpdateNfo"); }
        }

        public static string LogLineInternalUpdateImdb
        {
            get { return GetKeyValue("LogLineInternalUpdateImdb"); }
        }

        public static string LogLineInternalUpdateMp3
        {
            get { return GetKeyValue("LogLineInternalUpdateMp3"); }
        }

        public static string LogLineInternalRace
        {
            get { return GetKeyValue("LogLineInternalRace"); }
        }

        public static string LogLineInternalLeadUser
        {
            get { return GetKeyValue("LogLineInternalLeadUser"); }
        }

        public static string LogLineInternalLeadGroup
        {
            get { return GetKeyValue("LogLineInternalLeadGroup"); }
        }

        public static string LogLineInternalHalfway
        {
            get { return GetKeyValue("LogLineInternalHalfway"); }
        }

        public static string LogLineInternalComplete
        {
            get { return GetKeyValue("LogLineInternalComplete"); }
        }

        public static string LogLineInternalUserStatsHead
        {
            get { return GetKeyValue("LogLineInternalUserStatsHead"); }
        }

        public static string LogLineInternalUserStatsBody
        {
            get { return GetKeyValue("LogLineInternalUserStatsBody"); }
        }

        public static string LogLineInternalGroupStatsHead
        {
            get { return GetKeyValue("LogLineInternalGroupStatsHead"); }
        }

        public static string LogLineInternalGroupStatsBody
        {
            get { return GetKeyValue("LogLineInternalGroupStatsBody"); }
        }

        public static string LogLineInternalSpeedTest
        {
            get { return GetKeyValue("LogLineInternalSpeedTest"); }
        }

        public static int ProgressBarLength
        {
            get { return Misc.String2Number(GetKeyValue("ProgressBarLength")); }
        }

        public static string ProgressBarCharFilled
        {
            get { return GetKeyValue("ProgressBarCharFilled"); }
        }

        public static string ProgressBarCharMissing
        {
            get { return GetKeyValue("ProgressBarCharMissing"); }
        }

        public static bool AudioSortByArtist
        {
            get { return Misc.String2Boolean(GetKeyValue("AudioSortByArtist")); }
        }

        public static bool AudioSortByGenre
        {
            get { return Misc.String2Boolean(GetKeyValue("AudioSortByGenre")); }
        }

        public static bool AudioSortByYear
        {
            get { return Misc.String2Boolean(GetKeyValue("AudioSortByYear")); }
        }

        public static string AudioSortByArtistPath
        {
            get { return GetKeyValue("AudioSortByArtistPath"); }
        }

        public static string AudioSortByGenrePath
        {
            get { return GetKeyValue("AudioSortByGenrePath"); }
        }

        public static string AudioSortByYearPath
        {
            get { return GetKeyValue("AudioSortByYearPath"); }
        }

        public static string AudioGenresAllowed
        {
            get { return GetKeyValue("AudioSortByYearPath"); }
        }

        public static string AudioGenresBanned
        {
            get { return GetKeyValue("AudioSortByYearPath"); }
        }

        public static string TagCleanUpString
        {
            get { return GetKeyValue("TagCleanUpString"); }
        }

        public static string TagIncomplete
        {
            get { return GetKeyValue("TagIncomplete"); }
        }

        public static string TagComplete
        {
            get { return GetKeyValue("TagComplete"); }
        }

        public static string TagCompleteMp3
        {
            get { return GetKeyValue("TagCompleteMp3"); }
        }

        public static string TagIncompleteLink
        {
            get { return GetKeyValue("TagIncompleteLink"); }
        }

        public static string TagIncompleteLinkDiscNumber
        {
            get { return GetKeyValue("TagIncompleteLinkDiscNumber"); }
        }

        public static int TagIncompleteLinkChMod
        {
            get { return Misc.String2Number(GetKeyValue("TagIncompleteLinkChMod")); }
        }

        public static bool AddDizToMessageFile
        {
            get { return Misc.String2Boolean(GetKeyValue("AddDizToMessageFile", "false")); }
        }

        public static string MessageImdbInfoHead
        {
            get { return GetKeyValue("MessageImdbInfoHead", " iMDB iNFO "); }
        }

        public static string MessageImdbInfo
        {
            get { return GetKeyValue("MessageImdbInfo", " 'MessageImdbInfo' is missing!!! "); }
        }

        public static bool AddImdbInfoToMessageFile
        {
            get { return Misc.String2Boolean(GetKeyValue("AddImdbInfoToMessageFile", "false")); }
        }
    }
}