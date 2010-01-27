#region
using System;
using System.Collections.Generic;
using System.IO;

#endregion

namespace ioFTPD.Framework
{
    public class Race
    {
        public Race (string[] args)
        {
            this.args = args;
        }

        /// <summary>
        /// Parses input arguments based on UPLOAD.
        /// </summary>
        /// <returns></returns>
        public Race Parse ()
        {
            System.IO.FileInfo fileInfo = new System.IO.FileInfo (args [1]);
            FileExtension = Path.GetExtension (fileInfo.FullName);
            FileName = fileInfo.Name;
            DirectoryName = fileInfo.Directory == null ? "" : fileInfo.Directory.Name;
            DirectoryPath = fileInfo.Directory == null ? "" : fileInfo.Directory.FullName;
            FileSize = fileInfo.Length;
            UploadFile = args [1];
            UploadCrc = args [2];
            UploadVirtualFile = args [3];
            Speed = GetSpeed ();
            UserName = GetUserName ();
            GroupName = GetGroupName ();
            TotalBytesUploaded = 0;
            return this;
        }

        private string GetGroupName ()
        {
            return "Non Existing GroupName";
        }

        private string GetUserName ()
        {
            return "Non Existing Username";
        }

        private ulong GetSpeed ()
        {
            return 0;
        }

        /// <summary>
        /// Starts with the file check.
        /// </summary>
        public void Process ()
        {
            SelectRaceType ();
            if (!IsValid)
            {
                return;
            }
            switch (RaceType)
            {
                case RaceType.Sfv:
                {
                    if (SfvCheck ())
                    {
                        return;
                    }
                    ProcessSfv ();
                    break;
                }

                case RaceType.Rar:
                {
                    ProcessRar ();
                    break;
                }

                case RaceType.Mp3:
                {
                    IsValid = false;
                    throw new NotImplementedException ("MP3 file type is not supported");
                }

                case RaceType.Zip:
                {
                    IsValid = false;
                    throw new NotImplementedException ("ZIP file type is not supported");
                }

                default:
                {
                    IsValid = false;
                    Output output = new Output (this);
                    output
                        .Client (Config.ClientHead)
                        .Client (Config.ClientFileName)
                        .Client (Config.ClientFoot);
                    break;
                }
            }
        }

        /// <summary>
        /// Processes with file check for type <see cref="Framework.RaceType.Rar"/>.
        /// </summary>
        private void ProcessRar ()
        {
            FileInfo fileInfo = new FileInfo ();
            fileInfo.ParseRaceFile (this);
            if (fileInfo.GetCrc32ForFile (FileName).Equals (UploadCrc))
            {
                fileInfo.UpdateRaceData (this);
                fileInfo.DeleteFile (DirectoryPath, FileName + Config.FileExtensionMissing);
                Output output = new Output(this);
                fileInfo.DeleteFilesThatStartsWith(DirectoryPath, Config.TagCleanUpString);
                fileInfo.Create0ByteFile(Path.Combine(DirectoryPath, output.Format(Config.TagInCompleteRar)));
                output
                    .Client (Config.ClientHead)
                    .Client (Config.ClientFileNameOk)
                    .Client (Config.ClientFoot);
                IsValid = true;
            }
            else
            {
                Output output = new Output (this);
                output
                    .Client (Config.ClientHead)
                    .Client (Config.ClientFileNameBadCrc)
                    .Client (Config.ClientFoot);
                IsValid = false;
            }
        }

        /// <summary>
        /// Processes with file check for type <see cref="Framework.RaceType.Sfv"/>.
        /// </summary>
        private void ProcessSfv ()
        {
            FileInfo fileInfo = new FileInfo ();
            fileInfo.ParseSfv (UploadFile);
            sfvData = fileInfo.SfvData;
            foreach (KeyValuePair<string, string> keyValuePair in fileInfo.SfvData)
            {
                fileInfo.Create0ByteFile (Path.Combine (DirectoryPath, keyValuePair.Key) +
                                          Config.FileExtensionMissing);
            }
            TotalFilesExpected = fileInfo.SfvData.Count;
            fileInfo.CreateSfvRaceDataFile (this);
            Output output = new Output (this);
            output
                .Client (Config.ClientHead)
                .Client (Config.ClientFileNameSfv)
                .Client (Config.ClientFoot);
        }

        /// <summary>
        /// Checks if SFV exists.
        /// </summary>
        /// <returns><c>true</c> if SFV file was found.</returns>
        private bool SfvCheck ()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo (DirectoryPath);
            System.IO.FileInfo[] fileInfo = directoryInfo.GetFiles ("*.sfv");
            if (fileInfo.Length != 1)
            {
                IsValid = false;
                Output output = new Output (this);
                output
                    .Client (Config.ClientHead)
                    .Client (Config.ClientFileNameSfv)
                    .Client (Config.ClientFileNameSfvExists)
                    .Client (Config.ClientFoot);
            }
            return false;
        }

        /// <summary>
        /// Selects the type of the race based on the file extension.
        /// </summary>
        private void SelectRaceType ()
        {
            if (string.IsNullOrEmpty (FileExtension))
            {
                IsValid = false;
                return;
            }
            IsValid = true;
            RaceType = EqualsRaceType (".sfv")
                           ? RaceType.Sfv
                           : EqualsRaceType (".mp3")
                                 ? RaceType.Mp3
                                 : EqualsRaceType (".zip")
                                       ? RaceType.Zip
                                       : EqualsRaceType (".rar")
                                             ? RaceType.Rar
                                             : RaceType.None;
        }

        /// <summary>
        /// Checks if the file extension matches.
        /// </summary>
        /// <param name="fileExtension">The file extension.</param>
        /// <returns><c>true</c> on match.</returns>
        private bool EqualsRaceType (string fileExtension)
        {
            return FileExtension.Equals (fileExtension, StringComparison.InvariantCultureIgnoreCase);
        }

        public string FileExtension { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string DirectoryName { get; set; }
        public string DirectoryPath { get; set; }
        public RaceType RaceType { get; set; }
        public string UploadCrc { get; set; }
        public string UploadFile { get; set; }
        public string UploadVirtualFile { get; set; }
        public string UserName { get; set; }
        public string GroupName { get; set; }
        public int TotalFilesExpected { get; set; }
        public int TotalFilesUploaded { get; set; }
        public UInt64 Speed { get; set; }
        public UInt64 TotalBytesUploaded { get; set; }
        public UInt64 TotalMBytesUploaded
        {
            get { return TotalBytesUploaded / 1000; }
        }

        public Dictionary<string, string> SfvData
        {
            get { return sfvData; }
        }

        public bool IsValid { get; set; }

        private readonly string[] args;
        private Dictionary<string, string> sfvData = new Dictionary<string, string> ();
    }
}