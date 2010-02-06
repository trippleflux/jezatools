#region

#endregion

namespace jeza.ioFTPD.Framework
{
    public class CurrentUploadData
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
        public int Speed { get; set; }
    }
}