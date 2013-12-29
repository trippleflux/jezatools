using System;

namespace jeza.ioFTPD.Framework.ioFTPD
{
    /*
     * #define STANDARD_RIGHTS_REQUIRED         (0x000F0000L)
     * 
#define SECTION_QUERY                0x0001
#define SECTION_MAP_WRITE            0x0002
#define SECTION_MAP_READ             0x0004
#define SECTION_MAP_EXECUTE          0x0008
#define SECTION_EXTEND_SIZE          0x0010
#define SECTION_MAP_EXECUTE_EXPLICIT 0x0020 // not included in SECTION_ALL_ACCESS

#define SECTION_ALL_ACCESS (STANDARD_RIGHTS_REQUIRED|SECTION_QUERY|\
                            SECTION_MAP_WRITE |      \
                            SECTION_MAP_READ |       \
                            SECTION_MAP_EXECUTE |    \
                            SECTION_EXTEND_SIZE)
     * */
    [Flags]
    internal enum FileMapAccess
    {
        FileMapCopy = 0x0001,
        FileMapWrite = 0x0002,
        FileMapRead = 0x0004,
        FileMapExecute = 0x0008,
        FileMapExtendSize = 0x0010,
        //FileMapAllAccess = 0x000F0000L,
        //FileMapExecute = 0x0020,
    }
}