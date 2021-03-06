namespace jeza.ioFTPD.Framework.Archive
{
    /// <summary>
    /// List of posible types for archiving
    /// </summary>
    public enum ArchiveType
    {
        /// <summary>
        /// Moves the folders.
        /// </summary>
        Move,
        /// <summary>
        /// Deletes the folders.
        /// </summary>
        Delete,
        /// <summary>
        /// Copies folders to destination.
        /// </summary>
        Copy,
    }
}