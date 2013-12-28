using System;

namespace jeza.ioFTPD.Framework.ioFTPD
{
    public struct LPLOCALDATA
    {
        /*
typedef struct _LOCALDATA
{
HWND	hDaemon;
DWORD	dwProcessId;
DWORD	dwType;

HMODULE	hShellLibrary;
HANDLE	hHeap;
LPVOID	ShellAlloc;
LPVOID	ShellLock;
LPVOID	ShellUnlock;
LPVOID	ShellFree;
	
} LOCALDATA, * LPLOCALDATA;
 * */
        IntPtr hDaemon;
        UInt32 dwProcessId;
        UInt32 dwType;

        IntPtr hShellLibrary;
        IntPtr hHeap;
        IntPtr ShellAlloc;
        IntPtr ShellLock;
        IntPtr ShellUnlock;
        IntPtr ShellFree;

    }
}