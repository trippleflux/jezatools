using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace jeza.ioFTPD.Framework.ioFTPD
{
    public class SharedMemoryManager
    {
        private const int WM_USER = 0x0400;
        private const int WM_SHMEM = (WM_USER + 101);
        private const int WM_DATACOPY_FILEMAP = (WM_USER + 21);
        private const int WM_DATACOPY_FREE = (WM_USER + 20);
        private const int MAX_NAME = 64;

        private const int MAX_PATH = 260;

        private const int DC_UID_TO_USER = 2;

        internal static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
        private readonly string m_ioFtpdMessageWindowName;
        private Process m_currentProcess;
        private IntPtr m_ioFtpdWindow;
        private bool m_isWindowThere;

        public SharedMemoryManager()
        {
            m_ioFtpdMessageWindowName = "ioFTPD::MessageWindow";
            Initialize();
        }

        public SharedMemoryManager(string ioftpdMessagewindow)
        {
            m_ioFtpdMessageWindowName = ioftpdMessagewindow;
            Initialize();
        }

        public bool IsWindowThere
        {
            get { return m_isWindowThere; }
        }

        [DllImport("User32.Dll")]
        private static extern IntPtr FindWindow(string lpClassName,
                                                string lpWindowName);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr CreateFileMapping(
            IntPtr hFile,
            IntPtr lpFileMappingAttributes,
            FileMapProtection flProtect,
            uint dwMaximumSizeHigh,
            uint dwMaximumSizeLow,
            [MarshalAs(UnmanagedType.LPTStr)] string lpName);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr MapViewOfFile(
            IntPtr hFileMappingObject,
            FileMapAccess dwDesiredAccess,
            uint dwFileOffsetHigh,
            uint dwFileOffsetLow,
            uint dwNumberOfBytesToMap);

        [DllImport("User32.Dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd,
                                                 UInt32 msg,
                                                 IntPtr wParam,
                                                 IntPtr lParam);

        [DllImport("User32.Dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd,
                                                 UInt32 msg,
                                                 UInt32 wParam,
                                                 IntPtr lParam);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool UnmapViewOfFile(IntPtr lpBaseAddress);

        [DllImport("Kernel32.dll", EntryPoint = "RtlMoveMemory", SetLastError = false)]
        static extern void MoveMemory(IntPtr dest, IntPtr src, int size);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle(IntPtr hObject);

        private void Initialize()
        {
            try
            {
                m_isWindowThere = false;
                m_currentProcess = Process.GetCurrentProcess();
                if (m_currentProcess.Handle == IntPtr.Zero)
                {
                    throw new Exception("Failed to get current Process ID!");
                }
                FindWindow();
                if (!m_isWindowThere)
                {
                    throw new Exception(string.Format("'{0}' was not found!", m_ioFtpdMessageWindowName));
                }
            }
            catch (Exception exception)
            {
                Log.Debug(exception.Message);
                throw;
            }
        }

        private static IntPtr VarPtr(object e)
        {
            GCHandle GC = GCHandle.Alloc(e, GCHandleType.Pinned);
            IntPtr gc = GC.AddrOfPinnedObject();
            GC.Free();
            return gc;
            
        }

        private static IntPtr Get(object e)
        {
            GCHandle handle = GCHandle.Alloc(e, GCHandleType.Pinned);
            try
            {
                IntPtr pointer = GCHandle.ToIntPtr(handle);
                return pointer;// "0x" + pointer.ToString("X");
            }
            finally
            {
                handle.Free();
            }
        }

        public string UID2Name(int uid)
        {
            LPALLOCATION lpallocation = SharedAllocate(72 + MAX_PATH * 2);
            if (lpallocation.hDaemon == IntPtr.Zero)
            {
                return "error";
            }
            LPDC_NAMEID lpdcNameid = new LPDC_NAMEID();
            lpdcNameid.Id = uid;
            //lpdcNameid.tszName = "";
            IntPtr varPtr = VarPtr(lpdcNameid);

            MoveMemory(lpallocation.lpMemory, varPtr, Marshal.SizeOf(typeof(LPDC_NAMEID)));

            QueryDaemon(DC_UID_TO_USER, lpallocation, 3000);

            MoveMemory(varPtr, lpallocation.lpMemory, 72);
            SharedFree(lpallocation);
            return Marshal.PtrToStringAnsi(lpdcNameid.tszName);
        }

        [DllImport("kernel32", SetLastError = true, ExactSpelling = true)]
        private static extern Int32 WaitForSingleObject(IntPtr handle, Int32 milliseconds);

        private UInt32 QueryDaemon(UInt32 dwIdentifier,
                                 LPALLOCATION lpallocation,
                                 int dwTimeOut)
        {
            LPDC_MESSAGE lpdcMessage = new LPDC_MESSAGE();
            int sizeOf = Marshal.SizeOf(typeof (LPDC_MESSAGE));
            MoveMemory(VarPtr(lpdcMessage), VarPtr(lpallocation.lpMessage), sizeOf);
            lpdcMessage.dwIdentifier = dwIdentifier;
            MoveMemory(VarPtr(lpallocation.lpMessage), VarPtr(lpdcMessage), sizeOf);

            IntPtr hRemote = SendMessage(m_ioFtpdWindow, WM_SHMEM, IntPtr.Zero, lpallocation.hDaemon);

            WaitForSingleObject(lpallocation.hEvent, dwTimeOut);
            MoveMemory(VarPtr(lpdcMessage), VarPtr(lpallocation.lpMessage), sizeOf);
            return lpdcMessage.dwReturn;
        }

        public LPALLOCATION SharedAllocate(UInt32 dwBytes, bool createEvent=true)
        {
            try
            {
                LPALLOCATION lpallocation = new LPALLOCATION();
                IntPtr pt_lpallocation = VarPtr(lpallocation);

                LPDC_MESSAGE lpdcMessage = new LPDC_MESSAGE();
                IntPtr pt_lpdcMessage = IntPtr.Zero;
                int sizeOf = Marshal.SizeOf(typeof(LPDC_MESSAGE));

                IntPtr hEvent = IntPtr.Zero;
                const int dwMaximumSizeLow = 1024;
                IntPtr hObject = CreateFileMapping(INVALID_HANDLE_VALUE, IntPtr.Zero, FileMapProtection.PageReadWrite | FileMapProtection.SectionCommit, 0, dwMaximumSizeLow, null);
                if (hObject == IntPtr.Zero)
                {
                    throw new Exception("Failed to CreateFileMapping!");
                }
                pt_lpdcMessage = MapViewOfFile(hObject, FileMapAccess.FileMapAllAccess, 0, 0, dwMaximumSizeLow);
                if (pt_lpdcMessage == IntPtr.Zero)
                {
                    throw new Exception("Failed to MapViewOfFile!");
                }
                lpdcMessage.hEvent = hEvent;
                lpdcMessage.lpContext = pt_lpdcMessage + sizeOf;
                lpdcMessage.lpMemoryBase =pt_lpdcMessage;
                lpdcMessage.dwIdentifier = 0;

                IntPtr varPtr = VarPtr(lpdcMessage);

                MoveMemory(pt_lpdcMessage, varPtr, sizeOf);

                IntPtr hRemote = SendMessage(m_ioFtpdWindow, WM_DATACOPY_FILEMAP, (IntPtr) m_currentProcess.Id, hObject);
                if (hRemote == IntPtr.Zero)
                {
                    throw new Exception("Failed to SendMessage 'WM_DATACOPY_FILEMAP'!");
                }

                lpallocation.hDaemon = hRemote;
                lpallocation.lpMemory = pt_lpdcMessage + sizeOf;
                lpallocation.hEvent = hEvent;
                lpallocation.hObject = hObject;
                lpallocation.lpMessage = lpdcMessage;
                lpallocation.dwBytes = (dwBytes - (uint)sizeOf);

                UnmapViewOfFile(pt_lpdcMessage);

                return lpallocation;
            }
            catch (Exception exception)
            {
                Log.Debug(exception.Message);
                throw;
            }
        }

        public void SharedFree(LPALLOCATION lpallocation)
        {
            IntPtr varPtr = VarPtr(lpallocation.lpMessage);
            UnmapViewOfFile(varPtr);
            IntPtr hRemote = SendMessage(m_ioFtpdWindow, WM_DATACOPY_FREE, (IntPtr)m_currentProcess.Id, lpallocation.hDaemon);
    //        UnmapViewOfFile ByVal lpAlloc.lpMessage
    
    //If Not (lpAlloc.hEvent = 0) Then CloseHandle lpAlloc.hEvent
    //If Not (lpAlloc.hObject = 0) Then CloseHandle lpAlloc.hObject
    //SendMessage ByVal m_ioFTPD, ByVal WM_DATACOPY_FREE, ByVal 0, ByVal lpAlloc.hDaemon
        }

        // Find window by Caption, and wait 1/2 a second and then try again.
        private void FindWindow(int waitTime = 500)
        {
            try
            {
                const int maxRetryCount = 2;
                int retryCount = 0;
                m_ioFtpdWindow = FindWindow(m_ioFtpdMessageWindowName, null);
                while (retryCount <= maxRetryCount && m_ioFtpdWindow == IntPtr.Zero)
                {
                    Thread.Sleep(waitTime);
                    m_ioFtpdWindow = FindWindow(m_ioFtpdMessageWindowName, null);
                    retryCount++;
                }
                m_isWindowThere = m_ioFtpdWindow != IntPtr.Zero;
            }
            catch (Exception exception)
            {
                Log.Debug(exception.Message);
                throw;
            }
        }
    }
}