namespace jeza.ioFTPD.Framework.Archive
{
    public enum ArchiveActionAttribute
    {
        /// <summary>
        /// Total space used on DISK.
        /// </summary>
        TotalUsedSpace,
        /// <summary>
        /// Total used space in specified folder.
        /// </summary>
        TotalFolderUsedSpace,
        /// <summary>
        /// Total free space on DISK is belov value specified.
        /// </summary>
        TotalFreeSpace,
        /// <summary>
        /// Total folder count in specified fodler.
        /// </summary>
        TotalFolderCount,
        /// <summary>
        /// If folder is older than the number of days specified.
        /// </summary>
        DateOlder,
    }
}