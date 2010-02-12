#region
using System.IO;
using System.Threading;

#endregion

namespace jeza.ioFTPD.Framework
{
    public class DataParser : IDataParser
    {
        public DataParser (Race race)
        {
            this.race = race;
            RaceFile = Path.Combine (race.CurrentUploadData.DirectoryPath, Config.FileNameRace);
        }

        public void Parse ()
        {
            race.ClearRaceStats ();
            RaceMutex.WaitOne();
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(RaceFile);
            using (FileStream stream = new FileStream (fileInfo.FullName,
                                                       FileMode.OpenOrCreate,
                                                       FileAccess.ReadWrite,
                                                       FileShare.None))
            {
                using (BinaryReader reader = new BinaryReader (stream))
                {
                    stream.Seek (0, SeekOrigin.Begin);
                    race.TotalFilesExpected = reader.ReadInt32 ();
                    for (int i = 1; i <= race.TotalFilesExpected; i++)
                    {
                        stream.Seek (256 * i, SeekOrigin.Begin);
                        RaceStats raceStats = new RaceStats ();
                        raceStats
                            .AddFileName (reader.ReadString ())
                            .AddCrc32 (reader.ReadString ())
                            .AddFileUploaded (reader.ReadBoolean ())
                            .AddFileSize (reader.ReadUInt64 ())
                            .AddFileSpeed (reader.ReadInt32 ())
                            .AddUserName (reader.ReadString ())
                            .AddGroupName (reader.ReadString ());
                        race.AddRaceStats (raceStats);
                    }
                }
            }
            RaceMutex.ReleaseMutex ();
        }

        public void Process ()
        {
            if (GetCrc32ForFile (race.CurrentUploadData.FileName) != null)
            {
                UpdateRaceData ();
                Parse ();
                FileInfo fileInfo = new FileInfo ();
                fileInfo.DeleteFile (race.CurrentUploadData.DirectoryPath,
                                     race.CurrentUploadData.FileName + Config.FileExtensionMissing);
                fileInfo.DeleteFilesThatStartsWith (race.CurrentUploadData.DirectoryPath, Config.TagCleanUpString);
                Output output = new Output (race);
                output
                    .Client (Config.ClientHead)
                    .Client (Config.ClientFileNameOk);
                if (race.CurrentUploadData.RaceType == RaceType.Mp3)
                {
                    output
                        .Client(Config.ClientMp3InfoHead)
                        .ClientMp3(Config.ClientMp3Info);
                }
                output
                    .Client (Config.ClientStatsUsersHead)
                    .ClientStatsUsers (Config.ClientStatsUsers)
                    .Client (Config.ClientStatsGroupsHead)
                    .ClientStatsGroups(Config.ClientStatsGroups)
                    .Client(Config.ClientFootProgressBar);
                TagManager tagManager = new TagManager (race);
                if (race.IsRaceComplete)
                {
                    tagManager.Create (race.CurrentUploadData.DirectoryPath, output.Format (Config.TagCompleteRar));
                    tagManager.DeleteSymlink(race.CurrentUploadData.DirectoryParent, output.Format(Config.TagIncompleteLink));
                }
                else
                {
                    tagManager.Create (race.CurrentUploadData.DirectoryPath, output.Format (Config.TagIncompleteRar));
                }
                race.IsValid = true;
            }
            else
            {
                Output output = new Output (race);
                output
                    .Client (Config.ClientHead)
                    .Client (Config.ClientFileNameBadCrc)
                    .Client (Config.ClientFoot);
                race.IsValid = false;
            }
        }

        private void UpdateRaceData ()
        {
            RaceMutex.WaitOne();
            int position = 0;
            string fileName = "", fileCrc = "";
            System.IO.FileInfo fileInfo =
                new System.IO.FileInfo (Path.Combine (race.CurrentUploadData.DirectoryPath, Config.FileNameRace));
            using (FileStream stream = new FileStream (fileInfo.FullName,
                                                       FileMode.Open,
                                                       FileAccess.Read,
                                                       FileShare.None))
            {
                using (BinaryReader reader = new BinaryReader (stream))
                {
                    for (int i = 1; i <= race.TotalFilesExpected; i++)
                    {
                        stream.Seek (256 * i, SeekOrigin.Begin);
                        fileName = reader.ReadString ();
                        if (fileName.Equals (race.CurrentUploadData.FileName))
                        {
                            position = i;
                            fileCrc = reader.ReadString ();
                            break;
                        }
                    }
                }
            }
            if (position > 0)
            {
                using (FileStream stream = new FileStream (fileInfo.FullName,
                                                           FileMode.Open,
                                                           FileAccess.Write,
                                                           FileShare.None))
                {
                    using (BinaryWriter writer = new BinaryWriter (stream))
                    {
                        stream.Seek (position * 256, SeekOrigin.Begin);
                        writer.Write (fileName);
                        writer.Write (fileCrc);
                        writer.Write (true);
                        writer.Write (race.CurrentUploadData.FileSize); //file Size
                        writer.Write (race.CurrentUploadData.Speed); //upload speed
                        writer.Write (race.CurrentUploadData.UserName); //username
                        writer.Write (race.CurrentUploadData.GroupName); //groupname
                    }
                }
            }
            RaceMutex.ReleaseMutex ();
        }

        private string GetCrc32ForFile (string fileName)
        {
            foreach (RaceStats raceStats in race.RaceStats)
            {
                if (raceStats.FileName.Equals (fileName))
                {
                    return raceStats.Crc32;
                }
            }
            return null;
        }

        public string RaceFile { get; set; }

        private static readonly Mutex RaceMutex = new Mutex (false, "raceMutex");
        private readonly Race race;
    }
}