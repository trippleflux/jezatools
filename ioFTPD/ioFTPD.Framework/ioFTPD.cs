using System;
using System.Runtime.InteropServices;

namespace ioFTPD.Framework
{
    public class IoFtpd
    {
        [DllImport("User32.dll")]
        public static extern int FindWindow
            (String className,
             String windowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage
            (Int32 hWnd,
             Int32 wMsg,
             IntPtr wParam,
             IntPtr lParam);

    }
}