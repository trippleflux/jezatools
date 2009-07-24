using System;
using System.Runtime.InteropServices;

namespace ioFTPD.Framework
{
    public class Native
    {
        [DllImport ("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenFileMapping
            (uint dwDesiredAccess,
             bool bInheritHandle,
             string lpName);

        [DllImport ("kernel32.dll", SetLastError = true)]
        public static extern IntPtr MapViewOfFile
            (
            IntPtr hFileMappingObject,
            FileMapAccess dwDesiredAccess,
            uint dwFileOffsetHigh,
            uint dwFileOffsetLow,
            uint dwNumberOfBytesToMap);

        // For Windows Mobile, replace user32.dll with coredll.dll
        [DllImport ("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow
            (string lpClassName,
             string lpWindowName);

        [DllImport ("kernel32.dll", SetLastError = true)]
        public static extern bool UnmapViewOfFile (IntPtr lpBaseAddress);

        [DllImport ("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage
            (IntPtr hWnd,
             UInt32 msg,
             IntPtr wParam,
             IntPtr lParam);

        [return: MarshalAs (UnmanagedType.Bool)]
        [DllImport ("user32.dll", SetLastError = true)]
        public static extern bool PostMessage
            (IntPtr hWnd,
             uint msg,
             IntPtr wParam,
             IntPtr lParam);

        [DllImport ("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr CreateFileMapping
            (
            IntPtr hFile,
            IntPtr lpFileMappingAttributes,
            FileMapProtection flProtect,
            uint dwMaximumSizeHigh,
            uint dwMaximumSizeLow,
            [MarshalAs (UnmanagedType.LPTStr)] string lpName);

        [DllImport ("kernel32.dll", SetLastError = true)]
        [return: MarshalAs (UnmanagedType.Bool)]
        public static extern bool CloseHandle (IntPtr hObject);

        [DllImport ("kernel32.dll")]
        public static extern IntPtr CreateEvent
            (IntPtr lpEventAttributes,
             bool bManualReset,
             bool bInitialState,
             string lpName);

        [DllImport ("Kernel32.dll", EntryPoint = "RtlMoveMemory", SetLastError = false)]
        public static extern void MoveMemory
            (Object dest,
             IntPtr src,
             int size);
    }
}