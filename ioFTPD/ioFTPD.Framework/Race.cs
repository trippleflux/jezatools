#region
using System;
using System.Collections.Generic;
using System.IO;

#endregion

namespace jeza.ioFTPD.Framework
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
            RaceData = new RaceData
                {
                    FileExtension = Path.GetExtension (fileInfo.FullName),
                    FileName = fileInfo.Name,
                    DirectoryName = fileInfo.Directory == null ? "" : fileInfo.Directory.Name,
                    DirectoryPath = fileInfo.Directory == null ? "" : fileInfo.Directory.FullName,
                    FileSize = fileInfo.Length,
                    UploadFile = args [1],
                    UploadCrc = args [2],
                    UploadVirtualFile = args [3],
                    Speed = GetSpeed (),
                    UserName = GetUserName (),
                    GroupName = GetGroupName (),
                    TotalBytesUploaded = 0
                };
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
            switch (RaceData.RaceType)
            {
                case RaceType.Sfv:
                {
                    if (!SfvCheck ())
                    {
                        OutputSfvFirst (Config.ClientFileNameSfv, Config.ClientFileNameSfvExists);
                        return;
                    }
                    ProcessSfv ();
                    break;
                }

                case RaceType.Rar:
                {
                    if (!SfvCheck ())
                    {
                        OutputSfvFirst (Config.ClientFileName, Config.ClientFileNameSfvFirst);
                        return;
                    }
                    ProcessRar ();
                    break;
                }

                case RaceType.Mp3:
                {
                    if (!SfvCheck ())
                    {
                        OutputSfvFirst (Config.ClientFileName, Config.ClientFileNameSfvFirst);
                        return;
                    }
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

        private void OutputSfvFirst
            (string fileInfo,
             string fileReason)
        {
            Output output = new Output (this);
            output
                .Client (Config.ClientHead)
                .Client (fileInfo)
                .Client (fileReason)
                .Client (Config.ClientFoot);
        }

        /// <summary>
        /// Processes with file check for type <see cref="RaceType.Rar"/>.
        /// </summary>
        private void ProcessRar ()
        {
            FileInfo fileInfo = new FileInfo ();
            fileInfo.ParseRaceFile (this);
            if (fileInfo.GetCrc32ForFile (RaceData.FileName).Equals (RaceData.UploadCrc))
            {
                fileInfo.UpdateRaceData (this);
                fileInfo.DeleteFile (RaceData.DirectoryPath, RaceData.FileName + Config.FileExtensionMissing);
                fileInfo.DeleteFilesThatStartsWith (RaceData.DirectoryPath, Config.TagCleanUpString);
                Output output = new Output (this);
                output
                    .Client (Config.ClientHead)
                    .Client (Config.ClientFileNameOk)
                    .Client (Config.ClientFoot);
                if (RaceData.IsRaceComplete)
                {
                    fileInfo.Create0ByteFile (Path.Combine (RaceData.DirectoryPath,
                                                            output.Format (Config.TagCompleteRar)));
                }
                else
                {
                    fileInfo.Create0ByteFile (Path.Combine (RaceData.DirectoryPath,
                                                            output.Format (Config.TagInCompleteRar)));
                }
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
        /// Processes with file check for type <see cref="RaceType.Sfv"/>.
        /// </summary>
        private void ProcessSfv ()
        {
            FileInfo fileInfo = new FileInfo ();
            fileInfo.ParseSfv (RaceData.UploadFile);
            sfvData = fileInfo.SfvData;
            foreach (KeyValuePair<string, string> keyValuePair in fileInfo.SfvData)
            {
                fileInfo.Create0ByteFile (Path.Combine (RaceData.DirectoryPath, keyValuePair.Key) +
                                          Config.FileExtensionMissing);
            }
            RaceData.TotalFilesExpected = fileInfo.SfvData.Count;
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
            DirectoryInfo directoryInfo = new DirectoryInfo (RaceData.DirectoryPath);
            System.IO.FileInfo[] fileInfo = directoryInfo.GetFiles ("*.sfv");
            if (fileInfo.Length == 1)
            {
                return true;
            }
            IsValid = false;
            return false;
        }

        /// <summary>
        /// Selects the type of the race based on the file extension.
        /// </summary>
        private void SelectRaceType ()
        {
            if (string.IsNullOrEmpty (RaceData.FileExtension))
            {
                IsValid = false;
                return;
            }
            IsValid = true;
            RaceData.RaceType = EqualsRaceType (".sfv")
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
            return RaceData.FileExtension.Equals (fileExtension, StringComparison.InvariantCultureIgnoreCase);
        }

        public Dictionary<string, string> SfvData
        {
            get { return sfvData; }
        }

        public RaceData RaceData { get; set; }
        public bool IsValid { get; set; }
        private readonly string[] args;
        private Dictionary<string, string> sfvData = new Dictionary<string, string> ();
    }
}