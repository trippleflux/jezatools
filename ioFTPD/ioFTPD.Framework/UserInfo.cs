using System;
using System.Runtime.InteropServices;

namespace ioFTPD.Framework
{
    public class UserInfo
    {
        //Import the FindWindow API to find our window
        [DllImport ("User32.dll")]
        private static extern int FindWindow
            (String className,
             String windowName);

        [DllImport ("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage
            (Int32 hWnd,
             Int32 wMsg,
             IntPtr wParam,
             IntPtr lParam);

// ReSharper disable InconsistentNaming
        private const int WM_USER = 0x0400;
// ReSharper restore InconsistentNaming
// ReSharper disable InconsistentNaming
        private const int WM_SHMEM = (WM_USER + 101);
// ReSharper restore InconsistentNaming
// ReSharper disable InconsistentNaming
        private const int DC_GID_TO_GROUP = 4;
// ReSharper restore InconsistentNaming

        Message message = new Message();

        public void Status ()
        {
            //Find the window, using the CORRECT Window Title, for example, Notepad
            int hWnd = FindWindow (null, "ioFTPD::MessageWindow");
            if (hWnd > 0) //If found
            {
                Console.WriteLine ("Window found...");
                SendMessage (hWnd, WM_SHMEM, IntPtr.Zero, IntPtr.Zero);
            }
            else
            {
                Console.WriteLine ("Window NOT found...");
            }
        }
    }

    internal class Message
    {
        Int32 dwIdentifier;
        Int32 dwReturn;
        String lpContext;
    }
}