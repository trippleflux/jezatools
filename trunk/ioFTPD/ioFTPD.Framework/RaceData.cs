using System;

namespace ioFTPD.Framework
{
    public class RaceData
    {
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

        public bool IsRaceComplete
        {
            get { return TotalFilesExpected == TotalFilesUploaded; }
        }

        public UInt64 TotalMBytesUploaded
        {
            get { return TotalBytesUploaded / 1000; }
        }
    }
}