using System;

namespace jeza.ioFTPD.Framework.ioFTPD
{
    public struct LPALLOCATION
    {
        /*
typedef struct _ALLOCATION
{
LPDC_MESSAGE	lpMessage;
LPVOID			lpMemory;
LPVOID			hDaemon;
HANDLE			hObject;
HANDLE			hEvent;
DWORD			dwBytes;

} ALLOCATION, * LPALLOCATION;
 */
        //internal LPDC_MESSAGE lpMessage;
        internal IntPtr lpMessage;
        internal IntPtr lpMemory;
        internal IntPtr hDaemon;
        internal IntPtr hObject;
        internal IntPtr hEvent;
        internal UInt32 dwBytes;
    }
}