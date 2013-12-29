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
        private const int WM_DATACOPY_SHELLALLOC = WM_USER + 19;
        private const int WM_DATACOPY_FILEMAP = (WM_USER + 21);
        private const int WM_DATACOPY_FREE = (WM_USER + 20);

        private const UInt32 STANDARD_RIGHTS_REQUIRED = 0x000F0000;
        private const UInt32 SECTION_QUERY = 0x0001;
        private const UInt32 SECTION_MAP_WRITE = 0x0002;
        private const UInt32 SECTION_MAP_READ = 0x0004;
        private const UInt32 SECTION_MAP_EXECUTE = 0x0008;
        private const UInt32 SECTION_EXTEND_SIZE = 0x0010;

        private const UInt32 SECTION_ALL_ACCESS = (STANDARD_RIGHTS_REQUIRED | SECTION_QUERY |
                                                   SECTION_MAP_WRITE |
                                                   SECTION_MAP_READ |
                                                   SECTION_MAP_EXECUTE |
                                                   SECTION_EXTEND_SIZE);

        private const UInt32 FILE_MAP_ALL_ACCESS = SECTION_ALL_ACCESS;

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
                FileMapAccess dwDesiredAccess = FileMapAccess.FileMapCopy |
                                                FileMapAccess.FileMapWrite |
                                                FileMapAccess.FileMapRead |
                                                FileMapAccess.FileMapExecute |
                                                FileMapAccess.FileMapExtendSize;
                pt_lpdcMessage = MapViewOfFile(hObject, FILE_MAP_ALL_ACCESS, 0, 0, dwBytes);
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
            string uid2Name = string.Empty;
            try
            {
                if (lpallocation.hDaemon == IntPtr.Zero)
                {
                    return uid2Name;
                }
                LPDC_NAMEID lpdcNameid = new LPDC_NAMEID();
                lpdcNameid.Id = uid;
                IntPtr varPtr_LPDC_NAMEID = VarPtr(lpdcNameid);
                IntPtr varPtr_LPALLOCATION_LPDC_NAMEID = VarPtr(lpallocation.lpMemory);

                MoveMemory(varPtr_LPALLOCATION_LPDC_NAMEID, varPtr_LPDC_NAMEID, sizeOf_LPDC_NAMEID);

                uint queryDaemon = QueryDaemon(DC_UID_TO_USER, lpallocation, 3000);
                if (queryDaemon == 0)
                {
                    MoveMemory(varPtr_LPDC_NAMEID, varPtr_LPALLOCATION_LPDC_NAMEID, sizeOf_LPDC_NAMEID);
                    LPDC_NAMEID ptrToStructure = (LPDC_NAMEID) Marshal.PtrToStructure(varPtr_LPDC_NAMEID, typeof (LPDC_NAMEID));
                    string ptrToStringAnsi = Marshal.PtrToStringAnsi(ptrToStructure.tszName);
                    string ptrToStringAuto = Marshal.PtrToStringAuto(ptrToStructure.tszName);
                    string ptrToStringUni = Marshal.PtrToStringUni(ptrToStructure.tszName);
                    return ptrToStringAnsi;
                }
                return uid2Name;
            }
            catch (Exception exception)
            {
                Log.Debug(exception.Message);
            }
            finally
            {
                SharedFree(lpallocation);
            }
            return uid2Name;
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

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr CreateFileMapping(
            IntPtr hFile,
            IntPtr lpFileMappingAttributes,
            UInt32 flProtect,
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

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr MapViewOfFile(
            IntPtr hFileMappingObject,
            UInt32 dwDesiredAccess,
            UInt32 dwFileOffsetHigh,
            UInt32 dwFileOffsetLow,
            UInt32 dwNumberOfBytesToMap);

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

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool PostMessage(IntPtr hWnd,
                                               uint Msg,
                                               IntPtr wParam,
                                               IntPtr lParam);

        [DllImport("User32.Dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd,
                                                 UInt32 msg,
                                                 IntPtr wParam,
                                                 IntPtr lParam);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool UnmapViewOfFile(IntPtr lpBaseAddress);

        private static IntPtr VarPtr<T>(T e)
        {
            IntPtr gc = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (T)));
            GCHandle GC = GCHandle.Alloc(e, GCHandleType.Pinned);
            gc = GC.AddrOfPinnedObject();
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
            if (lpallocation.hEvent == IntPtr.Zero)
            {
                throw new Exception("QueryDaemon : Event no initialized!");
            }
            LPDC_MESSAGE lpdcMessage = new LPDC_MESSAGE();
            int sizeOf_LPDC_MESSAGE = Marshal.SizeOf(typeof (LPDC_MESSAGE));
            IntPtr varPtr_LPDC_MESSAGE = VarPtr(lpdcMessage);
            IntPtr varPtr_LPALLOCATION_LPDC_MESSAGE = VarPtr(lpallocation.lpMessage);

            MoveMemory(varPtr_LPDC_MESSAGE, varPtr_LPALLOCATION_LPDC_MESSAGE, sizeOf_LPDC_MESSAGE);
            LPDC_MESSAGE ptrToStructure = (LPDC_MESSAGE) Marshal.PtrToStructure(varPtr_LPDC_MESSAGE, typeof (LPDC_MESSAGE));
            ptrToStructure.dwIdentifier = dwIdentifier;
            varPtr_LPDC_MESSAGE = VarPtr(ptrToStructure);

            MoveMemory(varPtr_LPALLOCATION_LPDC_MESSAGE, varPtr_LPDC_MESSAGE, sizeOf_LPDC_MESSAGE);

            bool postMessage = PostMessage(m_ioFtpdWindow, WM_SHMEM, IntPtr.Zero, lpallocation.hDaemon);
            if (postMessage)
            {
                WaitForSingleObject(lpallocation.hEvent, dwTimeOut);
                MoveMemory(varPtr_LPDC_MESSAGE, varPtr_LPALLOCATION_LPDC_MESSAGE, sizeOf_LPDC_MESSAGE);
                ptrToStructure = (LPDC_MESSAGE) Marshal.PtrToStructure(varPtr_LPDC_MESSAGE, typeof (LPDC_MESSAGE));
                return ptrToStructure.dwReturn;
            }
            throw new Exception("QueryDaemon : PostMessage failed! dwIdentifier=" + dwIdentifier);
        }
    }
}