namespace jeza.ioFTPD.Framework.ioFTPD
{
    internal enum FileMapAccess
    {
        FileMapCopy = 0x0001,
        FileMapWrite = 0x0002,
        FileMapRead = 0x0004,
        FileMapAllAccess = 0x001f,
        fileMapExecute = 0x0020,
    }
}