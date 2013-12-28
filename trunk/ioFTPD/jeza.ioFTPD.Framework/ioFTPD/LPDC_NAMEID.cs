using System;

namespace jeza.ioFTPD.Framework.ioFTPD
{
    internal struct LPDC_NAMEID
    {
        /*
         typedef struct _DC_NAMEID
{
	TCHAR	tszName[_MAX_NAME + 1];
	INT32		Id;

} DC_NAMEID, * LPDC_NAMEID;
         */
        internal IntPtr tszName;
        internal Int32 Id;

    }
}