using System;
using System.Runtime.InteropServices;
using ioFTPD.Framework;
using MbUnit.Framework;

namespace ioFTPD.Tests
{
    [TestFixture]
    public class IoFtpdTests
    {
        [Test]
        public void GetUsers ()
        {
            IntPtr hWnd = Native.FindWindow ("ioFTPD::MessageWindow", null);
            if (hWnd.ToInt32 () != 0)
            {
                const string lpName = "SFSharedMemory_ALM";
                Object sd = null;
                //IntPtr hd = Native.OpenFileMapping ((int) MapAccess.FileMapAllAccess, false, lpName);
                IntPtr hd = Native.CreateFileMapping (IntPtr.Zero, IntPtr.Zero, FileMapProtection.ReadWrite, 0, 32, lpName);
                if (hd.ToInt32 () != 0)
                {
                    IntPtr baseAddr = Native.MapViewOfFile (hd, (FileMapAccess) MapAccess.FileMapAllAccess, 0, 0, 32);
                    if (baseAddr.ToInt32 () != 0)
                    {
                        IntPtr sendMessage = Native.SendMessage (hWnd, 0x0400 + 21, IntPtr.Zero, hd);
                        //lRet = QueryDaemon(DC_UID_TO_USER, ThisAllocation, 1000) /*DC_UID_TO_USER=2*/
                        //PostMessage ByVal m_ioFTPD, ByVal WM_SHMEM, ByVal 0, ByVal lpAllocation.hDaemon
                        bool postMessage = Native.PostMessage (hWnd, 2, IntPtr.Zero, hd);
                        sd = (LpName) Marshal.PtrToStructure (baseAddr, typeof (LpName));
                        Native.UnmapViewOfFile (baseAddr);
                        Native.CloseHandle (hd);
                    }
                    Native.CloseHandle (hd);
                }
                Console.WriteLine (sd);
            }
        }

        private struct LpName
        {
            public int Id;
            public string Name;
        }
    }
}