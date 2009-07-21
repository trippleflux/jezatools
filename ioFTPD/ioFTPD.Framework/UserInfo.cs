using System;
using System.Runtime.InteropServices;

namespace ioFTPD.Framework
{
    public class UserInfo
    {
        //Import the FindWindow API to find our window

// ReSharper disable InconsistentNaming
        private const int WM_USER = 0x0400;
// ReSharper restore InconsistentNaming
// ReSharper disable InconsistentNaming
        private const int WM_SHMEM = (WM_USER + 101);
// ReSharper restore InconsistentNaming
// ReSharper disable InconsistentNaming
        private const int DC_GID_TO_GROUP = 4;
// ReSharper restore InconsistentNaming

        public void Status ()
        {
            //Find the window, using the CORRECT Window Title, for example, Notepad
            int hWnd = IoFtpd.FindWindow ("ioFTPD::MessageWindow", null);
            if (hWnd > 0) //If found
            {
                Console.WriteLine ("Window found...");
                IoFtpd.SendMessage(hWnd, WM_SHMEM, IntPtr.Zero, IntPtr.Zero);
            }
            else
            {
                Console.WriteLine ("Window NOT found...");
            }
        }
    }
}