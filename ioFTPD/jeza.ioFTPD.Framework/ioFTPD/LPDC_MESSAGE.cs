using System;

namespace jeza.ioFTPD.Framework.ioFTPD
{
    internal struct LPDC_MESSAGE
    {
        /*
        typedef struct _DC_MESSAGE
        {
            HANDLE		hEvent;
            HANDLE		hObject;
            DWORD		dwIdentifier;
            DWORD		dwReturn;
            LPVOID		lpMemoryBase;
            LPVOID		lpContext;


        } DC_MESSAGE, * LPDC_MESSAGE;
         */
        internal IntPtr hEvent;
        internal IntPtr hObject;
        internal UInt32 dwIdentifier;
        internal UInt32 dwReturn;
        internal IntPtr lpMemoryBase;
        internal IntPtr lpContext;
    }
}