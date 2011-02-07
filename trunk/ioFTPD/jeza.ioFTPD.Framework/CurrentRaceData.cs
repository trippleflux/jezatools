#region
#endregion
namespace jeza.ioFTPD.Framework
{
    public class CurrentRaceData
    {
        public string FileExtension { get; set; }
        public string FileName { get; set; }
        public string FileNameWithoutExtension { get; set; }
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
        public string DirectoryParent { get; set; }
        public string UploadVirtualPath { get; set; }
        public string Uid { get; set; }
        public string Gid { get; set; }

        public override string ToString()
        {
            return string.Format("FileExtension: {0}, FileName: {1}, FileNameWithoutExtension: {16}, FileSize: {2}, DirectoryName: {3}, DirectoryPath: {4}, RaceType: {5}, UploadCrc: {6}, UploadFile: {7}, UploadVirtualFile: {8}, UserName: {9}, GroupName: {10}, Speed: {11}, DirectoryParent: {12}, UploadVirtualPath: {13}, Uid: {14}, Gid: {15}", FileExtension, FileName, FileSize, DirectoryName, DirectoryPath, RaceType, UploadCrc, UploadFile, UploadVirtualFile, UserName, GroupName, Speed, DirectoryParent, UploadVirtualPath, Uid, Gid, FileNameWithoutExtension);
        }
    }
}