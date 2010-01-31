using System;

namespace jeza.ioFTPD.Framework
{
    public class RaceStats
    {
        public RaceStats AddFileName(string fileName)
        {
            FileName = fileName;
            return this;
        }

        public RaceStats AddCrc32(string crc32)
        {
            Crc32 = crc32;
            return this;
        }

        public RaceStats AddFileUploaded(bool fileUploaded)
        {
            FileUploaded = fileUploaded;
            return this;
        }

        public RaceStats AddFileSize(UInt64 fileSize)
        {
            FileSize = fileSize;
            return this;
        }

        public RaceStats AddFileSpeed(int fileSpeed)
        {
            FileSpeed = fileSpeed;
            return this;
        }

        public RaceStats AddUserName(string userName)
        {
            UserName = userName;
            return this;
        }

        public RaceStats AddGroupName(string groupName)
        {
            GroupName = groupName;
            return this;
        }

        public string FileName { get; set; }
        public string Crc32 { get; set; }
        public bool FileUploaded { get; set; }
        public UInt64 FileSize { get; set; }
        public int FileSpeed { get; set; }
        public string UserName { get; set; }
        public string GroupName { get; set; }
    }
}