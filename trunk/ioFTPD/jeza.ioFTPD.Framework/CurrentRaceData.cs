namespace jeza.ioFTPD.Framework
{
    public class CurrentRaceData
    {
        public string FileExtension { get; set; }
        public string FileName { get; set; }
        public string FileNameWithoutExtension { get; set; }
        public long FileSize { get; set; }
        /// <summary>
        /// Release name
        /// </summary>
        public string DirectoryName { get; set; }
        /// <summary>
        /// Full path to race directory.
        /// </summary>
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
        public int Uid { get; set; }
        public int Gid { get; set; }
        public string LinkImdb { get; set; }

        public override string ToString()
        {
            return string.Format("FileExtension: {0}, FileName: {1}, FileNameWithoutExtension: {2}, FileSize: {3}, DirectoryName: {4}, DirectoryPath: {5}, RaceType: {6}, UploadCrc: {7}, UploadFile: {8}, UploadVirtualFile: {9}, UserName: {10}, GroupName: {11}, Speed: {12}, DirectoryParent: {13}, UploadVirtualPath: {14}, Uid: {15}, Gid: {16}, LinkImdb: {17}", FileExtension, FileName, FileNameWithoutExtension, FileSize, DirectoryName, DirectoryPath, RaceType, UploadCrc, UploadFile, UploadVirtualFile, UserName, GroupName, Speed, DirectoryParent, UploadVirtualPath, Uid, Gid, LinkImdb);
        }
    }
}