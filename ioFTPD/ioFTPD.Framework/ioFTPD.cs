#region

using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

#endregion

namespace ioFTPD.Framework
{
    public class IoFtpd
    {
        [DllImport("User32.dll")]
        public static extern int FindWindow
            (String className,
             String windowName);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage
            (Int32 window,
             Int32 message,
             IntPtr wParam,
             IntPtr lParam);

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        internal static extern int CloseHandle(IntPtr hObject);

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern SafeWaitHandle CreateEvent
            (SecurityAttributes lpSecurityAttributes,
             bool isManualReset,
             bool initialState,
             string name);

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr CreateFileMapping
            (IntPtr hFile,
             [MarshalAs(UnmanagedType.LPStruct)] NativeTypes.SecurityAttributes lpAttributes,
             int flProtect,
             int dwMaxSizeHi,
             int dwMaxSizeLow,
             string lpName);

        [DllImport("Kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr MapViewOfFile
            (IntPtr hFileMapping,
             int dwDesiredAccess,
             int dwFileOffsetHigh,
             int dwFileOffsetLow,
             int dwNumberOfBytesToMap);

        public bool AllocateSharedMemory()
        {
            return AllocateSharedMemory(4096);
        }

        public bool AllocateSharedMemory(long allocationAsked)
        {
            ioFtpdWindow = FindWindow("ioFTPD::MessageWindow", null);
            if (ioFtpdWindow > 0)
            {
                Console.WriteLine("Window found...");
                safeWaitHandle = CreateEvent(null, false, false, null);
                if (!safeWaitHandle.IsInvalid)
                {
                    Console.WriteLine("Event created...");
                }
                else
                {
                    Console.WriteLine("CreateEvent!!!");
                }
            }
            Console.WriteLine("FindWindow!!!");
            return false;
        }

        private SafeWaitHandle safeWaitHandle;
        private int ioFtpdWindow;
    }

    internal class NativeTypes
    {
        public class SecurityAttributes
        {
        }
    }

    public class SecurityAttributes
    {
    }
}