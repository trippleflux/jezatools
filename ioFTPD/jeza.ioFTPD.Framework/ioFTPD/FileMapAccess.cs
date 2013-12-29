﻿using System;

namespace jeza.ioFTPD.Framework.ioFTPD
{
    [Flags]
    internal enum FileMapAccess
    {
        FileMapCopy = 0x0001,
        FileMapWrite = 0x0002,
        FileMapRead = 0x0004,
        FileMapAllAccess = 0x001f,
        FileMapExecute = 0x0020,
    }
}