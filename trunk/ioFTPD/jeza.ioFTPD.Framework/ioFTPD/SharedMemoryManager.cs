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
        private const int MAX_NAME = 64;
        private const int WM_DATACOPY_FILEMAP = (WM_USER + 21);
        private const int WM_DATACOPY_FREE = (WM_USER + 20);

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

        public LPALLOCATION SharedAllocate(UInt32 dwBytes,
                                           bool createEvent = true)
        {
            try
            {
                if (dwBytes <= 0)
                {
                    throw new Exception("Please specify the size!");
                }
                IntPtr hEvent = IntPtr.Zero;
                if (createEvent)
                {
                    hEvent = CreateEvent(IntPtr.Zero, false, false, string.Empty);
                    if (hEvent == IntPtr.Zero)
                    {
                        throw new Exception("Failed to create event!");
                    }
                }

                LPALLOCATION lpallocation = new LPALLOCATION();
                IntPtr pt_lpallocation = VarPtr(lpallocation);
                if (pt_lpallocation == IntPtr.Zero)
                {
                    CloseEventHandle(hEvent);
                    throw new Exception("Failed to get pointer of LPALLOCATION!");
                }

                LPDC_MESSAGE lpdcMessage = new LPDC_MESSAGE();
                IntPtr pt_lpdcMessage = IntPtr.Zero;
                int sizeOf_LPDC_MESSAGE = Marshal.SizeOf(typeof (LPDC_MESSAGE));

                dwBytes = dwBytes + (UInt32) sizeOf_LPDC_MESSAGE;
                FileMapProtection fileMapProtection = FileMapProtection.PageReadWrite |
                                                      FileMapProtection.SectionCommit;
                IntPtr hObject = CreateFileMapping(INVALID_HANDLE_VALUE, IntPtr.Zero, fileMapProtection, 0, dwBytes, null);
                if (hObject == IntPtr.Zero)
                {
                    throw new Exception("Failed to CreateFileMapping!");
                }
                FileMapAccess dwDesiredAccess = //FileMapAccess.FileMapExecute |
                                                //FileMapAccess.FileMapAllAccess |
                                                FileMapAccess.FileMapCopy |
                                                FileMapAccess.FileMapWrite |
                                                FileMapAccess.FileMapRead;
                pt_lpdcMessage = MapViewOfFile(hObject, dwDesiredAccess, 0, 0, dwBytes);
                if (pt_lpdcMessage == IntPtr.Zero)
                {
                    CloseEventHandle(hEvent);
                    CloseFileMappipngHandle(hObject);
                    throw new Exception("Failed to MapViewOfFile!");
                }
                lpdcMessage.hEvent = hEvent;
                lpdcMessage.lpContext = pt_lpdcMessage + sizeOf_LPDC_MESSAGE;
                lpdcMessage.lpMemoryBase = pt_lpdcMessage;
                lpdcMessage.dwIdentifier = 0;

                IntPtr varPtr = VarPtr(lpdcMessage);

                MoveMemory(pt_lpdcMessage, varPtr, sizeOf_LPDC_MESSAGE);

                IntPtr hDaemon = SendMessage(m_ioFtpdWindow, WM_DATACOPY_FILEMAP, (IntPtr) m_currentProcess.Id, hObject);
                if (hDaemon == IntPtr.Zero)
                {
                    CloseEventHandle(hEvent);
                    CloseFileMappipngHandle(hObject);
                    UnmapViewOfFile(pt_lpdcMessage);
                    throw new Exception("Failed to SendMessage 'WM_DATACOPY_FILEMAP'!");
                }

                lpallocation.hDaemon = hDaemon;
                lpallocation.lpMemory = pt_lpdcMessage + sizeOf_LPDC_MESSAGE;
                lpallocation.hEvent = hEvent;
                lpallocation.hObject = hObject;
                lpallocation.lpMessage = pt_lpdcMessage;
                lpallocation.dwBytes = (dwBytes - (uint) sizeOf_LPDC_MESSAGE);

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
            CloseEventHandle(lpallocation.hEvent);
            CloseFileMappipngHandle(lpallocation.hObject);
            SendMessage(m_ioFtpdWindow, WM_DATACOPY_FREE, (IntPtr) m_currentProcess.Id, lpallocation.hDaemon);
        }

        public string UID2Name(int uid)
        {
            int sizeOf_LPDC_NAMEID = Marshal.SizeOf(typeof (LPDC_NAMEID));
            uint dwBytes = (uint) (sizeOf_LPDC_NAMEID + (MAX_PATH * 2));
            LPALLOCATION lpallocation = SharedAllocate(dwBytes);
            try
            {
                if (lpallocation.hDaemon == IntPtr.Zero)
                {
                    return "error";
                }
                LPDC_NAMEID lpdcNameid = new LPDC_NAMEID();
                lpdcNameid.Id = uid;
                IntPtr varPtr = VarPtr(lpdcNameid);
                MoveMemory(lpallocation.lpMemory, varPtr, (int)dwBytes);
                uint queryDaemon = QueryDaemon(DC_UID_TO_USER, lpallocation, 3000);
                MoveMemory(varPtr, lpallocation.lpMemory, (int)dwBytes);
                return Marshal.PtrToStringAnsi(lpdcNameid.tszName);
            }
            catch (Exception exception)
            {
                Log.Debug(exception.Message);
            }
            finally
            {
                SharedFree(lpallocation);
            }
            return "empty";
        }

        private static void CloseEventHandle(IntPtr hEvent)
        {
            if (hEvent != IntPtr.Zero)
            {
                CloseHandle(hEvent);
            }
        }

        private static void CloseFileMappipngHandle(IntPtr hObject)
        {
            if (hObject != IntPtr.Zero || hObject != INVALID_HANDLE_VALUE)
            {
                CloseHandle(hObject);
            }
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll")]
        private static extern IntPtr CreateEvent(IntPtr lpEventAttributes,
                                                 bool bManualReset,
                                                 bool bInitialState,
                                                 string lpName);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr CreateFileMapping(
            IntPtr hFile,
            IntPtr lpFileMappingAttributes,
            FileMapProtection flProtect,
            uint dwMaximumSizeHigh,
            uint dwMaximumSizeLow,
            [MarshalAs(UnmanagedType.LPTStr)] string lpName);

        [DllImport("User32.Dll")]
        private static extern IntPtr FindWindow(string lpClassName,
                                                string lpWindowName);

        private static IntPtr Get(object e)
        {
            GCHandle handle = GCHandle.Alloc(e, GCHandleType.Pinned);
            try
            {
                IntPtr pointer = GCHandle.ToIntPtr(handle);
                return pointer; // "0x" + pointer.ToString("X");
            }
            finally
            {
                handle.Free();
            }
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr MapViewOfFile(
            IntPtr hFileMappingObject,
            FileMapAccess dwDesiredAccess,
            uint dwFileOffsetHigh,
            uint dwFileOffsetLow,
            uint dwNumberOfBytesToMap);

        [DllImport("Kernel32.dll", EntryPoint = "RtlMoveMemory", SetLastError = false)]
        private static extern void MoveMemory(IntPtr dest,
                                              IntPtr src,
                                              int size);

        [DllImport("Kernel32.dll", EntryPoint = "RtlMoveMemory", SetLastError = false)]
        private static extern void MoveMemory(IntPtr dest,
                                              object src,
                                              int size);

        [DllImport("Kernel32.dll", EntryPoint = "RtlMoveMemory", SetLastError = false)]
        private static extern void MoveMemory(object dest,
                                              IntPtr src,
                                              int size);

        [DllImport("User32.Dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd,
                                                 UInt32 msg,
                                                 IntPtr wParam,
                                                 IntPtr lParam);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool UnmapViewOfFile(IntPtr lpBaseAddress);

        private static IntPtr VarPtr(object e)
        {
            GCHandle GC = GCHandle.Alloc(e, GCHandleType.Pinned);
            IntPtr gc = GC.AddrOfPinnedObject();
            GC.Free();
            return gc;
        }

        [DllImport("kernel32", SetLastError = true, ExactSpelling = true)]
        private static extern Int32 WaitForSingleObject(IntPtr handle,
                                                        Int32 milliseconds);

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

        private UInt32 QueryDaemon(UInt32 dwIdentifier,
                                   LPALLOCATION lpallocation,
                                   int dwTimeOut)
        {
            LPDC_MESSAGE lpdcMessage = new LPDC_MESSAGE();
            int sizeOf_LPDC_MESSAGE = Marshal.SizeOf(typeof (LPDC_MESSAGE));
            IntPtr varPtr_LPDC_MESSAGE = VarPtr(lpdcMessage);
            //IntPtr varPtr_LPALLOCATION_LPDC_MESSAGE = VarPtr(lpallocation.lpMessage);
            IntPtr varPtr_LPALLOCATION_LPDC_MESSAGE = lpallocation.lpMessage;
            MoveMemory(varPtr_LPDC_MESSAGE, varPtr_LPALLOCATION_LPDC_MESSAGE, sizeOf_LPDC_MESSAGE);
            //MoveMemory(varPtr_LPDC_MESSAGE, varPtr_LPALLOCATION_LPDC_MESSAGE, sizeOf_LPDC_MESSAGE);
            lpdcMessage.dwIdentifier = dwIdentifier;
            MoveMemory(varPtr_LPALLOCATION_LPDC_MESSAGE, varPtr_LPDC_MESSAGE, sizeOf_LPDC_MESSAGE);
            //MoveMemory(varPtr_LPALLOCATION_LPDC_MESSAGE, varPtr_LPDC_MESSAGE, sizeOf_LPDC_MESSAGE);

            IntPtr hRemote = SendMessage(m_ioFtpdWindow, WM_SHMEM, IntPtr.Zero, lpallocation.hDaemon);

            WaitForSingleObject(lpallocation.hEvent, dwTimeOut);
            MoveMemory(varPtr_LPDC_MESSAGE, varPtr_LPALLOCATION_LPDC_MESSAGE, sizeOf_LPDC_MESSAGE);
            //MoveMemory(varPtr_LPDC_MESSAGE, varPtr_LPALLOCATION_LPDC_MESSAGE, sizeOf_LPDC_MESSAGE);
            return lpdcMessage.dwReturn;
        }
    }
}