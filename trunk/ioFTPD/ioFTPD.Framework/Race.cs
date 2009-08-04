#region

using System;
using System.Collections.Generic;
using System.IO;

#endregion

namespace ioFTPD.Framework
{
    public class Race
    {
        public Race(string[] args)
        {
            this.args = args;
        }

        public Race Parse()
        {
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(args[1]);
            FileExtension = Path.GetExtension(fileInfo.FullName);
            FileName = fileInfo.Name;
            DirectoryName = fileInfo.Directory == null ? "" : fileInfo.Directory.Name;
            DirectoryPath = fileInfo.Directory == null ? "" : fileInfo.Directory.FullName;
            FileSize = fileInfo.Length;
            UploadFile = args[1];
            UploadCrc = args[2];
            UploadVirtualFile = args[3];
            return this;
        }

        public void Process()
        {
            SelectRaceType();
            if (!IsValid)
            {
                return;
            }
            switch (RaceType)
            {
                case RaceType.Sfv:
                {
                    if(SfvCheck())
                    {
                        return;
                    }
                    FileInfo fileInfo = new FileInfo();
                    fileInfo.ParseSfv(UploadFile);
                    sfvData = fileInfo.SfvData;
                    foreach (KeyValuePair<string, string> keyValuePair in fileInfo.SfvData)
                    {
                        fileInfo.Create0ByteFile(Path.Combine(DirectoryPath, keyValuePair.Key) +
                                                 Config.FileExtensionMissing);
                    }
                    TotalFilesExpected = fileInfo.SfvData.Count;
                    fileInfo.CreateSfvRaceDataFile(this);
                    Output output = new Output(this);
                    output
                        .Client(Config.ClientHead)
                        .Client(Config.ClientFileNameSfv)
                        .Client(Config.ClientFoot);
                    break;
                }

                case RaceType.Rar:
                {
                    FileInfo fileInfo = new FileInfo();
                    fileInfo.ParseRaceFile (this);
                    if (fileInfo.GetCrc32ForFile(FileName).Equals (UploadCrc))
                    {
                        //fileInfo.UpdateRaceData (this);
                        Output output = new Output(this);
                        output
                            .Client(Config.ClientHead)
                            .Client(Config.ClientFileNameOk)
                            .Client(Config.ClientFoot);
                        IsValid = true;
                    }
                    else
                    {
                        Output output = new Output(this);
                        output
                            .Client(Config.ClientHead)
                            .Client(Config.ClientFileNameBadCrc)
                            .Client(Config.ClientFoot);
                        IsValid = false;
                    }
                    break;
                }

                default:
                {
                    Output output = new Output(this);
                    output
                        .Client(Config.ClientHead)
                        .Client(Config.ClientFileName)
                        .Client(Config.ClientFoot);
                    IsValid = false;
                    break;
                }
            }
        }

        private bool SfvCheck()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(DirectoryPath);
            System.IO.FileInfo[] fileInfo = directoryInfo.GetFiles("*.sfv");
            if (fileInfo.Length != 1)
            {
                IsValid = false;
                Output output = new Output(this);
                output
                    .Client(Config.ClientHead)
                    .Client(Config.ClientFileNameSfv)
                    .Client(Config.ClientFileNameSfvExists)
                    .Client(Config.ClientFoot);
            }
            return false;
        }

        private void SelectRaceType()
        {
            if (string.IsNullOrEmpty(FileExtension))
            {
                IsValid = false;
                return;
            }
            IsValid = true;
            RaceType = FileExtension.Equals(".sfv", StringComparison.InvariantCultureIgnoreCase)
                           ? RaceType.Sfv
                           : FileExtension.Equals(".mp3", StringComparison.InvariantCultureIgnoreCase)
                                 ? RaceType.Mp3
                                 : FileExtension.Equals(".zip", StringComparison.InvariantCultureIgnoreCase)
                                       ? RaceType.Zip
                                       : RaceType.Rar;
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
        public Dictionary<string, string> SfvData
        {
            get { return sfvData; }
        }

        public bool IsValid { get; set; }

        public int TotalFilesExpected { get; set; }
        public int TotalFilesUploaded { get; set; }

        private readonly string[] args;
        private Dictionary<string, string> sfvData = new Dictionary<string, string>();
    }
}