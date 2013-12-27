using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace jeza.ioFTPD.Framework.ioFTPD
{
    public class SharedMemoryManager
    {
        private readonly string m_ioFtpdMessageWindow;
        private Process m_currentProcess;
        private bool m_isWindowThere;

        public SharedMemoryManager()
        {
            m_ioFtpdMessageWindow = "ioFTPD::MessageWindow";
            Initialize();
        }

        public SharedMemoryManager(string ioftpdMessagewindow)
        {
            m_ioFtpdMessageWindow = ioftpdMessagewindow;
            m_isWindowThere = false;
            FindWindow();
        }

        public bool IsWindowThere
        {
            get { return m_isWindowThere; }
        }

        [DllImport("User32.Dll")]
        private static extern IntPtr FindWindow(string lpClassName,
                                                string lpWindowName);

        private void Initialize()
        {
            m_isWindowThere = false;
            m_currentProcess = Process.GetCurrentProcess();
        }

        // Find window by Caption, and wait 1/2 a second and then try again.
        private void FindWindow(int waitTime = 500)
        {
            const int maxRetryCount = 2;
            int retryCount = 0;
            IntPtr hWnd = FindWindow(m_ioFtpdMessageWindow, null);
            while (retryCount <= maxRetryCount && hWnd == IntPtr.Zero)
            {
                Thread.Sleep(waitTime);
                hWnd = FindWindow(m_ioFtpdMessageWindow, null);
                retryCount++;
            }
            m_isWindowThere = hWnd != IntPtr.Zero;
        }
    }
}