Option Strict Off
Option Explicit On
Friend Class clsMemMap
	
	' +-----------------------+
	' |  Win32 API functions  |
	' +-----------------------+
	
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	Private Declare Sub CopyMem1 Lib "kernel32" Alias "RtlMoveMemory" (ByRef xxxDest As Object, ByVal lngSrc As Integer, ByVal lngLen As Integer)
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	Private Declare Sub CopyMem2 Lib "kernel32" Alias "RtlMoveMemory" (ByVal lngDest As Integer, ByRef xxxSrc As Object, ByVal lngLen As Integer)
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	Private Declare Sub CopyMem3 Lib "kernel32" Alias "RtlMoveMemory" (ByVal lngDest As Integer, ByRef xxxSrc As Object, ByVal lngLen As Integer)
	
	Private Declare Function FindWindow Lib "user32"  Alias "FindWindowA"(ByVal lpClassName As String, ByRef lpWindowName As Integer) As Integer
	
	'*********************************************************************
	
	' +-------------+
	' |  CONSTANTS  |
	' +-------------+
	
	Public Const WM_USER As Integer = &H400I
	'win32 constants (all of them?)
	Private Const PAGE_READWRITE As Integer = 4
	Private Const SEC_COMMIT As Integer = &H8000000
	Private Const FILE_MAP_READ As Integer = 2
	Private Const FILE_MAP_WRITE As Integer = 4
	Private Const WAIT_TIMEOUT As Integer = 258
	Private Const INVALID_HANDLE_VALUE As Integer = -1
	'winmessages.h
	Private Const WM_KICK As Integer = (WM_USER + 6)
	Private Const WM_KILL As Integer = (WM_USER + 15)
	Private Const iFILEMAP As Integer = (WM_USER + 21)
	Private Const WM_SHMEM As Integer = (WM_USER + 101)
	Private Const WM_DATACOPY_FILEMAP As Integer = (WM_USER + 21)
	Private Const WM_DATACOPY_FREE As Integer = (WM_USER + 20)
	'serverlimits.h
	Private Const MAX_SECTIONS As Integer = 10
	Private Const MAX_GROUPS As Integer = 128
	Private Const MAX_IPS As Integer = 25
	Private Const IP_LINE_LENGTH As Integer = 96
	Private Const IP_LINE_LENGTH_1 As Integer = IP_LINE_LENGTH + 1
	Private Const MAX_NAME As Integer = 64
	Private Const MAX_NAME_1 As Integer = MAX_NAME + 1
	Private Const MAX_PATH As Integer = 260
	Private Const MAX_PATH_1 As Integer = MAX_PATH + 1
	'datacopy.h
	Private Const DC_USER_TO_UID As Integer = 1 '//  Context = DC_NAMEID
	Private Const DC_UID_TO_USER As Integer = 2 '//  Context = DC_NAMEID
	Private Const DC_GROUP_TO_GID As Integer = 3 '//  Context = DC_NAMEID
	Private Const DC_GID_TO_GROUP As Integer = 4 '//  Context = DC_NAMEID
	Private Const DC_USERFILE_OPEN As Integer = 5 '//  Context = USERFILE
	Private Const DC_USERFILE_LOCK As Integer = 6 '//  Context = USERFILE
	Private Const DC_USERFILE_UNLOCK As Integer = 7 '//  Context = USERFILE
	Private Const DC_USERFILE_CLOSE As Integer = 8 '//  Context = USERFILE
	Private Const DC_GROUPFILE_OPEN As Integer = 9 '//  Context = GROUPFILE
	Private Const DC_GROUPFILE_CLOSE As Integer = 10 '//  Context = GROUPFILE
	Private Const DC_VFS_READ As Integer = 11 '//  Context = DC_VFS
	Private Const DC_GET_ONLINEDATA As Integer = 13 '//  Context = DC_ONLINEDATA
	
	
	' +--------------------------------------+
	' | GENERAL SHARED MEMORY IOFTPD STRUCTS |
	' +--------------------------------------+
	
	Private Structure myLocalData
		Dim dwProcessId As Integer
		Dim dwType As Integer
		Dim hDaemon As Integer
	End Structure
	
	'size = 6 * 4b = 24b
	Private Structure LPDC_MESSAGE
		Dim hEvent As Integer
		Dim hDuplicateEvent As Integer
		Dim dwIdentifier As Integer
		Dim dwReturn As Integer
		Dim lpMemoryBase As Integer
		Dim lpContext As Integer
	End Structure
	
	'size = 6 * 4b  = 24b
	Private Structure mylpAllocation
		Dim lpMessage As Integer 'lpMessage  As LPDC_MESSAGE
		Dim lpMemory As Integer
		Dim hDaemon As Integer
		Dim hObject As Integer
		Dim hEvent As Integer
		Dim dwBytes As Integer
	End Structure
	
	
	' +--------------------+
	' | ONLINEDATA STRUCTS |
	' +--------------------+
	
	Private Structure ONLINEDATA 'typedef struct _ONLINEDATA {
		Dim uid As Integer 'INT32       Uid;
		Dim dwFlags As Integer 'DWORD       dwFlags;
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(MAX_NAME_1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=MAX_NAME_1)> Public szServiceName() As Char 'CHAR        szServiceName[_MAX_NAME + 1];   // Name of service
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(64),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=64)> Public szAction() As Char 'CHAR        szAction[64];                   // User's last action
		Dim ulClientIp As Integer 'ULONG       ulClientIp;
		Dim usClientPort As Short 'USHORT      usClientPort;
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(96),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=96)> Public szHostName() As Char 'CHAR        szHostName[MAX_HOSTNAME];   // Hostname
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(64),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=64)> Public szIdent() As Char 'CHAR        szIdent[MAX_IDENT];         // Ident
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(513),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=513)> Public szVirtualPath() As Char 'CHAR        szVirtualPath[_MAX_PWD + 1];    // Virtual path
		Dim szRealPath As String 'LPSTR       szRealPath;                     // Real path
		Dim dwRealPath As Integer 'DWORD       dwRealPath;
		Dim tLoginTime As Integer 'time_t      tLoginTime;             // Login Time
		Dim dwIdleTickCount As Integer 'DWORD       dwIdleTickCount;        // Idle Time
		Dim bTransferStatus As Byte 'BYTE        bTransferStatus;        // (0 Inactive, 1 Upload, 2 Download, 3 List)
		Dim ulDataClientIp As Integer 'ULONG       ulDataClientIp;
		Dim usDataClientPort As Short 'USHORT      usDataClientPort;
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(513),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=513)> Public szVirtualDataPath() As Char 'CHAR        szVirtualDataPath[_MAX_PWD + 1];
		Dim szRealDataPath As Integer 'LPSTR       szRealDataPath;
		Dim dwRealDataPath As Integer 'DWORD       dwRealDataPath;
		Dim dwBytesTransfered As Integer 'DWORD       dwBytesTransfered;        // Bytes transfered during interval
		Dim dwIntervalLength As Integer 'DWORD       dwIntervalLength;         // Milliseconds
		Dim i64TotalBytesTransfered As Decimal 'INT64       i64TotalBytesTransfered;  // Total bytes transfered during transfer
	End Structure '} ONLINEDATA, * PONLINEDATA;
	
	Private Const sizeof_DC_ONLINEDATA As Integer = 1392
	Private Structure LPDC_ONLINEDATA 'typedef struct _DC_ONLINEDATA
		'{
		Dim xOnlineData As ONLINEDATA '  ONLINEDATA  OnlineData;
		Dim iOffset As Short '  INT         iOffset;
		Dim dwSharedMemorySize As Integer '  DWORD       dwSharedMemorySize;
		'} DC_ONLINEDATA, * LPDC_ONLINEDATA;
	End Structure
	
	
	
	' +------------------+
	' | GROUPFILE STRUCT |
	' +------------------+
	
	Private Const sizeof_GROUPFILE As Integer = 416
	Private Structure io_GROUPFILE ' typedef struct _GROUPFILE
		' {
		Dim GID As Integer '     INT        Gid;                      // Group Id
		<VBFixedArray(1)> Dim slots() As Integer '     INT        Slots[2];                 // # of slots left for this group
		Dim usercount As Integer '     INT        Users;                    // # of users in this group
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(129),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=129)> Public description() As Char '     CHAR       szDescription[128 + 1];   // Long description
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(MAX_PATH_1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=MAX_PATH_1)> Public vfsfile() As Char '     CHAR       szVfsFile[MAX_PATH + 1];  // Default VFS file
		'
		Dim lpInternal As Integer '     LPVOID     lpInternal;
		Dim lpParent As Integer '     LPVOID     lpParent;
		'
		
		'UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
		Public Sub Initialize()
			ReDim slots(1)
		End Sub
	End Structure ' } GROUPFILE, * LPGROUPFILE;
	
	
	
	' +-----------------+
	' | USERFILE STRUCT |
	' +-----------------+
	
	Private Const sizeof_USERFILE As Integer = 6240
	Private Structure io_USERFILE ' typedef struct _USERFILE
		' {
		Dim uid As Integer '     INT       Uid;                       // User id
		Dim GID As Integer '     INT       Gid;                       // User group id
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(129),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=129)> Public tagline() As Char '     CHAR      Tagline[128 + 1];          // Info line
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(MAX_PATH_1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=MAX_PATH_1)> Public mountfile() As Char '     CHAR      MountFile[_MAX_PATH + 1];  // Root directory
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(MAX_PATH_1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=MAX_PATH_1)> Public home() As Char '     CHAR      Home[_MAX_PATH + 1];       // Home directory
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(33),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=33)> Public flags() As Char '     CHAR      Flags[32 + 1];             // Flags
		<VBFixedArray(4)> Dim limits() As Integer '     INT       Limits[5];                 // Up max speed, dn max speed, ftp logins, telnet, http
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(20),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=20)> Public password() As Char '     UCHAR     Password[20];              // Password
		<VBFixedArray(MAX_SECTIONS)> Dim ratio() As Integer '     INT       Ratio[MAX_SECTIONS];       // Ratio
		<VBFixedArray(MAX_SECTIONS - 1)> Dim credits() As Decimal '     INT64     Credits[MAX_SECTIONS];     // Credits
		<VBFixedArray((MAX_SECTIONS * 3) - 1)> Dim dayup() As Decimal '     INT64     DayUp[MAX_SECTIONS * 3];   // Daily uploads
		<VBFixedArray((MAX_SECTIONS * 3) - 1)> Dim daydn() As Decimal '     INT64     DayDn[MAX_SECTIONS * 3];   // Daily downloads
		<VBFixedArray((MAX_SECTIONS * 3) - 1)> Dim wkup() As Decimal '     INT64     WkUp[MAX_SECTIONS * 3];    // Weekly uploads
		<VBFixedArray((MAX_SECTIONS * 3) - 1)> Dim wkdn() As Decimal '     INT64     WkDn[MAX_SECTIONS * 3];    // Weekly downloads
		<VBFixedArray((MAX_SECTIONS * 3) - 1)> Dim monthup() As Decimal '     INT64     MonthUp[MAX_SECTIONS * 3]; // Monthly uploads
		<VBFixedArray((MAX_SECTIONS * 3) - 1)> Dim monthdn() As Decimal '     INT64     MonthDn[MAX_SECTIONS * 3]; // Monthly downloads
		<VBFixedArray((MAX_SECTIONS * 3) - 1)> Dim allup() As Decimal '     INT64     AllUp[MAX_SECTIONS * 3];   // Alltime uploads
		<VBFixedArray((MAX_SECTIONS * 3) - 1)> Dim alldn() As Decimal '     INT64     AllDn[MAX_SECTIONS * 3];   // Alltime downloads
		<VBFixedArray(MAX_GROUPS - 1)> Dim admingroups() As Integer '     INT       AdminGroups[MAX_GROUPS];   // Admin for these groups
		<VBFixedArray(MAX_GROUPS - 1)> Dim groups() As Integer '     INT       Groups[MAX_GROUPS];        // List of groups
		<VBFixedArray(IP_LINE_LENGTH, MAX_IPS)> Dim ip(, ) As Byte '     CHAR      Ip[MAX_IPS][_IP_LINE_LENGTH + 1];    // List of ips
		Dim lpInternal As Integer '     LPVOID    lpInternal;
		Dim lpParent As Integer '     LPVOID    lpParent;
		'
		
		'UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
		Public Sub Initialize()
			ReDim limits(4)
			ReDim ratio(MAX_SECTIONS)
			ReDim credits(MAX_SECTIONS - 1)
			ReDim dayup((MAX_SECTIONS * 3) - 1)
			ReDim daydn((MAX_SECTIONS * 3) - 1)
			ReDim wkup((MAX_SECTIONS * 3) - 1)
			ReDim wkdn((MAX_SECTIONS * 3) - 1)
			ReDim monthup((MAX_SECTIONS * 3) - 1)
			ReDim monthdn((MAX_SECTIONS * 3) - 1)
			ReDim allup((MAX_SECTIONS * 3) - 1)
			ReDim alldn((MAX_SECTIONS * 3) - 1)
			ReDim admingroups(MAX_GROUPS - 1)
			ReDim groups(MAX_GROUPS - 1)
			ReDim ip(IP_LINE_LENGTH, MAX_IPS)
		End Sub
	End Structure ' } USERFILE, * PUSERFILE, * LPUSERFILE;
	
	
	
	' +---------------+
	' | NAMEID STRUCT |
	' +---------------+
	
	Private Const sizeof_DC_NAMEID As Integer = 72
	Private Structure DC_NAMEID ' typedef struct _DC_NAMEID
		' {
		'sName As String * MAX_NAME_1          '     CHAR    szName[_MAX_NAME + 1];
		<VBFixedArray(MAX_NAME_1)> Dim sName() As Byte '     CHAR    szName[_MAX_NAME + 1];
		Dim id As Integer '     INT32   Id;
		'
		
		'UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
		Public Sub Initialize()
			ReDim sName(MAX_NAME_1)
		End Sub
	End Structure ' } DC_NAMEID, * LPDC_NAMEID;
	
	
	
	'*****************************************************************************
	
	
	
	' +----------------------+
	' |  internal variables  |
	' +----------------------+
	
	Private m_ProcessId As Integer
	Private m_ioFTPD As Integer
	Private m_lpAllocation As mylpAllocation 'only for GetFirstOnlineUser & GetNextOnlineUser
	'single-call functions use a local var
	
	
	' +--------------------------+
	' |  public variables/types  |
	' +--------------------------+
	
	Public LOCAL_ERROR As Boolean
	Private vbUnicode As VbStrConv
	Private vbFromUnicode As VbStrConv
	Private VarPtr As Object
	Private UnmapViewOfFile As Object


	Private Function BytesToHex(ByRef data As String) As String
		
		' +------------------------------------------+
		' | used to convert password from bin to hex |
		' +------------------------------------------+
		
		Dim n As Short
		Dim buffer As String
		
		
		If Len(data) = 0 Then Exit Function
		
		
		buffer = Space(Len(data) * 2)
		
		For n = 1 To Len(data)
			Mid(buffer, (n * 2) - 1, 2) = Hex(Asc(Mid(data, n, 1)))
		Next n
		
		BytesToHex = buffer
		
	End Function
	
	
	Private Sub CopyUserHelper(ByRef ThisAlloc1 As mylpAllocation, ByRef ThisAlloc2 As mylpAllocation, ByRef lpUserSrc As io_USERFILE, ByRef lpUserDest As io_USERFILE, ByRef iUID_dest As Short)
		Dim CopyMemory As Object
		
		Dim lRet As Integer
		
		'UPGRADE_WARNING: Couldn't resolve default property of object lpUserSrc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		CopyMem1(lpUserSrc, ThisAlloc1.lpMemory, sizeof_USERFILE) 'read source userfile
		lRet = QueryDaemon(DC_USERFILE_LOCK, ThisAlloc2, 5000) 'lock dest userfile
		'CopyMemory(lpUserDest, lpUserSrc, sizeof_USERFILE) 'copy source user into destination user
		lpUserDest.uid = iUID_dest 'quite essential :)
		'UPGRADE_WARNING: Couldn't resolve default property of object lpUserDest. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		CopyMem2(ThisAlloc2.lpMemory, lpUserDest, sizeof_USERFILE) 'save changes
		lRet = QueryDaemon(DC_USERFILE_UNLOCK, ThisAlloc2, 5000) 'unlock dest userfile
		lRet = QueryDaemon(DC_USERFILE_CLOSE, ThisAlloc2, 5000) 'close dest userfile
		
	End Sub
	
	Public Sub GetGroupIdTable()
		
		
		Dim lRet As Integer
		'UPGRADE_WARNING: Arrays in structure lpNameId may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
		Dim lpNameId As DC_NAMEID
		Dim ThisAllocation As mylpAllocation
		
		Dim n As Short
		Dim sName As String
		
		'clear the current array, if any
		ReDim GroupIdTable(0)
		
		'allocate shared memory
		'UPGRADE_WARNING: Couldn't resolve default property of object ThisAllocation. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ThisAllocation = SharedAllocate(True, sizeof_DC_NAMEID + (MAX_PATH * 2))
		If (ThisAllocation.hDaemon = 0) Then
			'GetUserIdTable = "(error)"
			Exit Sub
		End If
		
		'query all possible groupid's
		For n = 0 To 1023
			
			'fill in structure
			lpNameId.id = n
			
			'copy it to shared memory location
			'UPGRADE_WARNING: Couldn't resolve default property of object lpNameId. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			CopyMem2(ThisAllocation.lpMemory, lpNameId, sizeof_DC_NAMEID)
			
			'get the groupname from ioFTPD
			lRet = QueryDaemon(DC_GID_TO_GROUP, ThisAllocation, 1000)
			If (lRet = 0) Then
				'ok !
				
				'copy shared memory into structure
				'UPGRADE_WARNING: Couldn't resolve default property of object lpNameId. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CopyMem1(lpNameId, ThisAllocation.lpMemory, sizeof_DC_NAMEID)
				
				'convert to string
				'UPGRADE_ISSUE: Constant vbUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
				sName = StrConv(System.Text.UnicodeEncoding.Unicode.GetString(lpNameId.sName), vbUnicode) 'bytearray to string
				sName = StripNulls(sName)
				
				'fill in the info in the idtable array
				GroupIdTable(UBound(GroupIdTable)).iID = n
				GroupIdTable(UBound(GroupIdTable)).sName = sName
				
				'add new item to array
				ReDim Preserve GroupIdTable(UBound(GroupIdTable) + 1)
				
			Else
				'groupid doesn´t exist or function failed
			End If
			
		Next n
		
		
		'remove last empty arrayitem, if any
		If UBound(GroupIdTable) > 0 Then ReDim Preserve GroupIdTable(UBound(GroupIdTable) - 1)
		
		
		SharedFree(ThisAllocation)
		
		
	End Sub
	Public Function GetOwnerOfFile() As Object
		
		'void getFileOwner(const char *complete_filename, char *user)
		'{
		'    if (!initSharedMem(1024 + (strlen(complete_filename) + 1) + sizeof(DC_VFS))) {
		'        strcpy(user,"nobody");
		'        return;
		'    }
		'    lpMessage->dwIdentifier = DC_VFS_READ;
		'    LPDC_VFS pFileInformation = (LPDC_VFS)lpMessage->lpContext;
		'    lpContext = (LPVOID)((ULONG)lpMessage->lpContext + sizeof(DC_VFS));
		'    strcpy((LPTSTR)pFileInformation->pBuffer,complete_filename);
		'    dwReturn = SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory);
		'    if (!dwReturn) {
		'        WaitForSingleObject(hEvent,10000);
		'
		'        int uid = pFileInformation->Uid;
		'        if (pFileInformation->dwFileMode==0 || !resolveUidToName(uid,user))
		'            strcpy(user,"nobody");
		'    } else {
		'        strcpy(user,"nobody");
		'    }
		'    closeSharedMem();
		'}
		
	End Function
	
	Public Sub GetUserIdTable()
		
		
		Dim lRet As Integer
		'UPGRADE_WARNING: Arrays in structure lpNameId may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
		Dim lpNameId As DC_NAMEID
		Dim ThisAllocation As mylpAllocation
		
		Dim n As Short
		Dim sName As String
		
		'clear the current array, if any
		ReDim UserIdTable(0)
		
		'allocate shared memory
		'UPGRADE_WARNING: Couldn't resolve default property of object ThisAllocation. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ThisAllocation = SharedAllocate(True, sizeof_DC_NAMEID + (MAX_PATH * 2))
		If (ThisAllocation.hDaemon = 0) Then
			'GetUserIdTable = "(error)"
			Exit Sub
		End If
		
		'query all possible userid's
		For n = 0 To 1023
			
			'fill in structure
			lpNameId.id = n
			
			'copy it to shared memory location
			'UPGRADE_WARNING: Couldn't resolve default property of object lpNameId. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			CopyMem2(ThisAllocation.lpMemory, lpNameId, sizeof_DC_NAMEID)
			
			'get the username from ioFTPD
			lRet = QueryDaemon(DC_UID_TO_USER, ThisAllocation, 1000)
			If (lRet = 0) Then
				'ok !
				
				'copy shared memory into structure
				'UPGRADE_WARNING: Couldn't resolve default property of object lpNameId. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CopyMem1(lpNameId, ThisAllocation.lpMemory, sizeof_DC_NAMEID)
				
				'convert to string
				'UPGRADE_ISSUE: Constant vbUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
				sName = StrConv(System.Text.UnicodeEncoding.Unicode.GetString(lpNameId.sName), vbUnicode) 'bytearray to string
				sName = StripNulls(sName)
				
				'fill in the info in the idtable array
				UserIdTable(UBound(UserIdTable)).iID = n
				UserIdTable(UBound(UserIdTable)).sName = sName
				
				'add new item to array
				ReDim Preserve UserIdTable(UBound(UserIdTable) + 1)
				
			Else
				'userid doesn´t exist or function failed
			End If
			
		Next n
		
		
		'remove last empty arrayitem, if any
		If UBound(UserIdTable) > 0 Then ReDim Preserve UserIdTable(UBound(UserIdTable) - 1)
		
		
		SharedFree(ThisAllocation)
		
		
	End Sub
	
	
	
	
	Private Sub ClearLastOnlineUser()
		
		'clears the global variable 'LastOnlineUser'
		
		With LastOnlineUser
			.iUID = -1
			.sIdent = ""
			.sClientIP = ""
			.sDataIP = ""
			.sServiceName = ""
			.sLastCmd = ""
			.lngLoginTime = 0
			.lngIdleTime = 0
			.iTransferState = 0
			.dblSpeed = 0
			.iTransferbytes = 0
			.sVirtualPath = ""
			.sRealPath = ""
			.sFilename = ""
		End With
		
	End Sub
	
	
	Private Sub ClearLastUserFile()
		
		'clears the global variable 'LastUserfile'
		
		With LastUserfile
			
			.iUID = -1
			.iGID = -1
			.sTagline = ""
			.sFlags = ""
			.sPasswordHash = ""
			.sHomepath = ""
			.sVFSFile = ""
			
			'TODO: all other userfile info
			'...
			
		End With
		
	End Sub
	
	
	Public Function GetFirstOnlineUser() As Boolean
		
		Dim lCiD As Integer
		Dim lRet As Integer
		Dim lpOnlineData As LPDC_ONLINEDATA
		
		
		
		'clear old data (if any)
		ClearLastOnlineUser()
		
		'allocate shared memory
		'UPGRADE_WARNING: Couldn't resolve default property of object m_lpAllocation. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		m_lpAllocation = SharedAllocate(True, sizeof_DC_ONLINEDATA + (MAX_PATH * 2))
		If (m_lpAllocation.hDaemon = 0) Then
			GetFirstOnlineUser = False
			Exit Function
		End If
		
		'fill in structure
		lpOnlineData.iOffset = 0
		lpOnlineData.dwSharedMemorySize = m_lpAllocation.dwBytes
		
		'copy it to shared memory location
		'UPGRADE_WARNING: Couldn't resolve default property of object lpOnlineData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		CopyMem2(m_lpAllocation.lpMemory, lpOnlineData, sizeof_DC_ONLINEDATA)
		
		
		'get first online user (if any)
		lRet = QueryDaemon(DC_GET_ONLINEDATA, m_lpAllocation, 5000)
		If (lRet = 0) Then
			
			GetFirstOnlineUser = True
			
			'copy shared memory into LPDC_ONLINEDATA structure
			'UPGRADE_WARNING: Couldn't resolve default property of object lpOnlineData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			CopyMem1(lpOnlineData, m_lpAllocation.lpMemory, 1392)
			
			lCiD = (lpOnlineData.iOffset - 1)
			
			'continue if both UID and CID > -1
			If (lpOnlineData.xOnlineData.uid > -1) And (lCiD > -1) Then
				OnlineDataToLastOnlineUser(lpOnlineData.xOnlineData, lCiD)
			Else
				'UID = -1   > User is logging in...
				'CID = -1   > Some bad io stuff, ignore...
				LastOnlineUser.iUID = -1 'let calling code know that they should skip this user
			End If
			
		Else
			'nobody online or function failed
			GetFirstOnlineUser = False
			SharedFree(m_lpAllocation)
		End If
		
		
	End Function
	
	
	
	Public Function GetNextOnlineUser() As Boolean
		
		Dim lCiD As Integer
		Dim lRet As Integer
		Dim lpOnlineData As LPDC_ONLINEDATA
		
		
		'clear old data (if any)
		ClearLastOnlineUser()
		
		
		'get next online user (if any)
		lRet = QueryDaemon(DC_GET_ONLINEDATA, m_lpAllocation, 5000)
		If (lRet = 0) Then
			
			GetNextOnlineUser = True
			
			'copy shared memory into LPDC_ONLINEDATA structure
			'UPGRADE_WARNING: Couldn't resolve default property of object lpOnlineData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			CopyMem1(lpOnlineData, m_lpAllocation.lpMemory, sizeof_DC_ONLINEDATA)
			
			'determine connection ID
			lCiD = (lpOnlineData.iOffset - 1)
			
			'continue if both UID and CID > -1
			If (lpOnlineData.xOnlineData.uid > -1) And (lCiD > -1) Then
				OnlineDataToLastOnlineUser(lpOnlineData.xOnlineData, lCiD)
			Else
				'UID = -1   > User is logging in...
				'CID = -1   > Some bad io stuff, ignore...
				LastOnlineUser.iUID = -1 'let calling code know that they should skip this user
			End If
			
		Else
			'nobody online or function failed
			GetNextOnlineUser = False
			SharedFree(m_lpAllocation)
		End If
		
		
	End Function
	Private Function GetStringFromPointer(ByRef lpString As Integer, ByRef dwSize As Integer) As String
		
		'input:  - pointer to memory location of the string
		'        - size of the string (bytecount)
		'conversion:  - copy memory block into byte-array
		'             - convert byte-array to (unicode) string
		
		
		'OBSOLETE ? was used to get filename from szRealDataPath, but
		'           we're getting it from szVirtualDataPath...
		'           (real filename is same as virtual filename i guess)
		
		Dim sRet() As Byte
		
		
		If lpString = 0 Or dwSize <= 0 Then Exit Function
		
		ReDim sRet(dwSize)
		CopyMem1(sRet(0), lpString, dwSize)
		'UPGRADE_ISSUE: Constant vbUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
		GetStringFromPointer = StrConv(System.Text.UnicodeEncoding.Unicode.GetString(sRet), vbUnicode)
		
	End Function
	
	
	
	Public Function GetUserFile(ByRef iUID As Short) As Boolean
		
		
		Dim lRet As Integer
		'UPGRADE_WARNING: Arrays in structure lpUserFile may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
		Dim lpUserFile As io_USERFILE
		Dim ThisAllocation As mylpAllocation
		
		
		'clear old data (if any)
		ClearLastUserFile()
		
		'allocate shared memory
		'UPGRADE_WARNING: Couldn't resolve default property of object ThisAllocation. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ThisAllocation = SharedAllocate(True, sizeof_USERFILE + (MAX_PATH * 2))
		If (ThisAllocation.hDaemon = 0) Then
			GetUserFile = False
			Exit Function
		End If
		
		'fill in structure
		lpUserFile.uid = iUID
		
		'copy it to shared memory location
		'UPGRADE_WARNING: Couldn't resolve default property of object lpUserFile. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		CopyMem2(ThisAllocation.lpMemory, lpUserFile, sizeof_USERFILE)
		
		'get the userfile from ioFTPD
		lRet = QueryDaemon(DC_USERFILE_OPEN, ThisAllocation, 5000)
		If (lRet = 0) Then
			'ok !
			GetUserFile = True
			
			'copy shared memory into structure
			'UPGRADE_WARNING: Couldn't resolve default property of object lpUserFile. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			CopyMem1(lpUserFile, ThisAllocation.lpMemory, sizeof_USERFILE)
			
			'put the userfile into the public variable
			UserfileToLastUserfile(lpUserFile)
			
			'close the userfile
			lRet = QueryDaemon(DC_USERFILE_CLOSE, ThisAllocation, 5000)
		Else
			'user doesn't exist or function failed
			GetUserFile = False
		End If
		
		
		SharedFree(ThisAllocation)
		
		
	End Function
	
	Public Function SetUserFlags(ByRef iUID As Short, ByRef sFlags As String) As Boolean
		
		
		Dim lRet As Integer
		'UPGRADE_WARNING: Arrays in structure lpUserFile may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
		Dim lpUserFile As io_USERFILE
		Dim ThisAllocation As mylpAllocation
		
		
		'allocate shared memory
		'UPGRADE_WARNING: Couldn't resolve default property of object ThisAllocation. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ThisAllocation = SharedAllocate(True, sizeof_USERFILE + (MAX_PATH * 2))
		If (ThisAllocation.hDaemon = 0) Then
			SetUserFlags = False
			Exit Function
		End If
		
		'fill in structure
		lpUserFile.uid = iUID
		
		'copy it to shared memory location
		'UPGRADE_WARNING: Couldn't resolve default property of object lpUserFile. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		CopyMem2(ThisAllocation.lpMemory, lpUserFile, sizeof_USERFILE)
		
		'get the userfile from ioFTPD
		lRet = QueryDaemon(DC_USERFILE_OPEN, ThisAllocation, 5000)
		If (lRet = 0) Then
			'ok !
			SetUserFlags = True
			
			'lock userfile
			lRet = QueryDaemon(DC_USERFILE_LOCK, ThisAllocation, 5000)
			
			'copy shared memory into structure
			'UPGRADE_WARNING: Couldn't resolve default property of object lpUserFile. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			CopyMem1(lpUserFile, ThisAllocation.lpMemory, sizeof_USERFILE)
			
			'add flag M to in the structure
			lpUserFile.flags = sFlags & New String(Chr(0), 33 - Len(sFlags))
			
			'save changes
			'UPGRADE_WARNING: Couldn't resolve default property of object lpUserFile. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			CopyMem2(ThisAllocation.lpMemory, lpUserFile, sizeof_USERFILE)
			
			'unlock userfile
			lRet = QueryDaemon(DC_USERFILE_UNLOCK, ThisAllocation, 5000)
			
			'close userfile
			lRet = QueryDaemon(DC_USERFILE_CLOSE, ThisAllocation, 5000)
			
		Else
			'user doesn't exist or function failed
		End If
		
		
		SharedFree(ThisAllocation)
		
		
	End Function
	
	
	Public Function CopyUser(ByRef iUID_src As Short, ByRef iUID_dest As Short) As Boolean
		
		
		Dim lRet As Integer
		'UPGRADE_WARNING: Arrays in structure lpUserSrc may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
		Dim lpUserSrc As io_USERFILE
		'UPGRADE_WARNING: Arrays in structure lpUserDest may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
		Dim lpUserDest As io_USERFILE
		Dim ThisAlloc1 As mylpAllocation
		Dim ThisAlloc2 As mylpAllocation
		
		'assume success
		CopyUser = True
		
		'allocate shared memory
		'UPGRADE_WARNING: Couldn't resolve default property of object ThisAlloc1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ThisAlloc1 = SharedAllocate(True, sizeof_USERFILE + (MAX_PATH * 2))
		'UPGRADE_WARNING: Couldn't resolve default property of object ThisAlloc2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ThisAlloc2 = SharedAllocate(True, sizeof_USERFILE + (MAX_PATH * 2))
		If (ThisAlloc1.hDaemon = 0 Or ThisAlloc2.hDaemon = 0) Then
			CopyUser = False
			Exit Function
		End If
		
		'fill in structures
		lpUserSrc.uid = iUID_src
		lpUserDest.uid = iUID_dest
		
		'copy it to shared memory location
		'UPGRADE_WARNING: Couldn't resolve default property of object lpUserSrc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		CopyMem2(ThisAlloc1.lpMemory, lpUserSrc, sizeof_USERFILE)
		'UPGRADE_WARNING: Couldn't resolve default property of object lpUserDest. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		CopyMem2(ThisAlloc2.lpMemory, lpUserDest, sizeof_USERFILE)
		
		'open source userfile
		lRet = QueryDaemon(DC_USERFILE_OPEN, ThisAlloc1, 5000)
		If (lRet <> 0) Then
			'user doesn't exist or function failed
			CopyUser = False
		End If
		
		'open destination userfile
		lRet = QueryDaemon(DC_USERFILE_OPEN, ThisAlloc2, 5000)
		If (lRet <> 0) Then
			'user doesn't exist or function failed
			CopyUser = False
		End If
		
		
		If CopyUser = True Then
			
			CopyUserHelper(ThisAlloc1, ThisAlloc2, lpUserSrc, lpUserDest, iUID_dest)
			
		End If
		
		
		SharedFree(ThisAlloc1)
		SharedFree(ThisAlloc2)
		
	End Function
	
	
	
	Public Function GetGroupFile(ByRef iGID As Short) As Boolean
		
		
		Dim lRet As Integer
		'UPGRADE_WARNING: Arrays in structure lpGroupFile may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
		Dim lpGroupFile As io_GROUPFILE
		Dim ThisAllocation As mylpAllocation
		
		
		'clear old data (if any)
		'ClearLastGroupFile
		
		'allocate shared memory
		'UPGRADE_WARNING: Couldn't resolve default property of object ThisAllocation. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ThisAllocation = SharedAllocate(True, sizeof_GROUPFILE + (MAX_PATH * 2))
		If (ThisAllocation.hDaemon = 0) Then
			GetGroupFile = False
			Exit Function
		End If
		
		'fill in structure
		lpGroupFile.GID = iGID
		
		'copy it to shared memory location
		'UPGRADE_WARNING: Couldn't resolve default property of object lpGroupFile. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		CopyMem2(ThisAllocation.lpMemory, lpGroupFile, sizeof_GROUPFILE)
		
		'get the userfile from ioFTPD
		lRet = QueryDaemon(DC_GROUPFILE_OPEN, ThisAllocation, 5000)
		If (lRet = 0) Then
			'ok !
			GetGroupFile = True
			
			'copy shared memory into structure
			'UPGRADE_WARNING: Couldn't resolve default property of object lpGroupFile. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			CopyMem1(lpGroupFile, ThisAllocation.lpMemory, sizeof_GROUPFILE)
			
			'put the userfile into the public variable
			GroupfileToLastGroupfile(lpGroupFile)
			
			'close the userfile
			lRet = QueryDaemon(DC_GROUPFILE_CLOSE, ThisAllocation, 5000)
		Else
			'user doesn't exist or function failed
			GetGroupFile = False
		End If
		
		
		SharedFree(ThisAllocation)
		
		
	End Function
	
	
	Public Sub KickUserByUID(ByRef iUID As Short)
		Dim PostMessage As Object
		
		'http://www.ioftpd.com/board/showthread.php?s=&postid=18326#post18326
		'Use PostMessage() instead of SendMessage(), when possible.
		
		'PostMessage(m_ioFTPD, WM_KICK, iUID, 0)
		
	End Sub
	
	Public Sub KickUserByCID(ByRef iCID As Short)
		Dim PostMessage As Object
		
		'http://www.ioftpd.com/board/showthread.php?s=&postid=18326#post18326
		'Use PostMessage() instead of SendMessage(), when possible.
		
		'PostMessage(m_ioFTPD, WM_KILL, iCID, 0)
		
	End Sub
	
	
	Public Function UserIdToName(ByRef iUID As Short) As String
		
		
		Dim lRet As Integer
		'UPGRADE_WARNING: Arrays in structure lpNameId may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
		Dim lpNameId As DC_NAMEID
		Dim ThisAllocation As mylpAllocation
		
		
		'allocate shared memory
		'UPGRADE_WARNING: Couldn't resolve default property of object ThisAllocation. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ThisAllocation = SharedAllocate(True, sizeof_DC_NAMEID + (MAX_PATH * 2))
		If (ThisAllocation.hDaemon = 0) Then
			UserIdToName = "(error)"
			Exit Function
		End If
		
		'fill in structure
		lpNameId.id = iUID
		
		'copy it to shared memory location
		'UPGRADE_WARNING: Couldn't resolve default property of object lpNameId. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		CopyMem2(ThisAllocation.lpMemory, lpNameId, sizeof_DC_NAMEID)
		
		'get the userfile from ioFTPD
		lRet = QueryDaemon(DC_UID_TO_USER, ThisAllocation, 3000)
		If (lRet = 0) Then
			'ok !
			
			'copy shared memory into structure
			'UPGRADE_WARNING: Couldn't resolve default property of object lpNameId. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			CopyMem1(lpNameId, ThisAllocation.lpMemory, sizeof_DC_NAMEID)
			
			'return username
			'UPGRADE_ISSUE: Constant vbUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
			UserIdToName = StrConv(System.Text.UnicodeEncoding.Unicode.GetString(lpNameId.sName), vbUnicode) 'bytearray to string
			UserIdToName = StripNulls(UserIdToName)
			
		Else
			'userid doesn´t exist or function failed
			UserIdToName = "(unknown)"
		End If
		
		
		SharedFree(ThisAllocation)
		
		
	End Function
	
	
	Public Function UserNameToID(ByRef sUsername As String) As Short
		
		
		Dim lRet As Integer
		'UPGRADE_WARNING: Arrays in structure lpNameId may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
		Dim lpNameId As DC_NAMEID
		Dim ThisAllocation As mylpAllocation
		
		
		'exit with -1 if no username was given
		If Len(sUsername) = 0 Then
			UserNameToID = -1
			Exit Function
		End If
		
		'allocate shared memory
		'UPGRADE_WARNING: Couldn't resolve default property of object ThisAllocation. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ThisAllocation = SharedAllocate(True, sizeof_DC_NAMEID + (MAX_PATH * 2))
		If (ThisAllocation.hDaemon = 0) Then
			UserNameToID = -1
			Exit Function
		End If
		
		'fill in structure
		Dim n As Short
		Dim b() As Byte
		'UPGRADE_ISSUE: Constant vbFromUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
		'UPGRADE_TODO: Code was upgraded to use System.Text.UnicodeEncoding.Unicode.GetBytes() which may not have the same behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"'
		b = System.Text.UnicodeEncoding.Unicode.GetBytes(StrConv(Left(sUsername, 64), vbFromUnicode)) 'limit to 64 chars
		'UPGRADE_ISSUE: VarPtr function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
		CopyMem2(VarPtr(lpNameId.sName(0)), b(0), UBound(b) + 1)
		
		'copy it to shared memory location
		'UPGRADE_WARNING: Couldn't resolve default property of object lpNameId. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		CopyMem2(ThisAllocation.lpMemory, lpNameId, sizeof_DC_NAMEID)
		
		'get the userfile from ioFTPD
		lRet = QueryDaemon(DC_USER_TO_UID, ThisAllocation, 3000)
		
		'return value is userid. bad usernames will result in UID = -1
		UserNameToID = lRet
		
		
		
		SharedFree(ThisAllocation)
		
		
	End Function
	
	
	
	Public Function GroupIdToName(ByRef iGID As Short) As String
		
		
		Dim lRet As Integer
		'UPGRADE_WARNING: Arrays in structure lpNameId may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
		Dim lpNameId As DC_NAMEID
		Dim ThisAllocation As mylpAllocation
		
		
		'allocate shared memory
		'UPGRADE_WARNING: Couldn't resolve default property of object ThisAllocation. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ThisAllocation = SharedAllocate(True, sizeof_DC_NAMEID + (MAX_PATH * 2))
		If (ThisAllocation.hDaemon = 0) Then
			GroupIdToName = "(error)"
			Exit Function
		End If
		
		'fill in structure
		lpNameId.id = iGID
		
		'copy it to shared memory location
		'UPGRADE_WARNING: Couldn't resolve default property of object lpNameId. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		CopyMem2(ThisAllocation.lpMemory, lpNameId, sizeof_DC_NAMEID)
		
		'get the userfile from ioFTPD
		lRet = QueryDaemon(DC_GID_TO_GROUP, ThisAllocation, 3000)
		If (lRet = 0) Then
			'ok !
			
			'copy shared memory into structure
			'UPGRADE_WARNING: Couldn't resolve default property of object lpNameId. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			CopyMem1(lpNameId, ThisAllocation.lpMemory, sizeof_DC_NAMEID)
			
			'return groupname
			'UPGRADE_ISSUE: Constant vbUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
			GroupIdToName = StrConv(System.Text.UnicodeEncoding.Unicode.GetString(lpNameId.sName), vbUnicode) 'bytearray to string
			GroupIdToName = StripNulls(GroupIdToName)
			
			
		Else
			'groupid doesn´t exist or function failed
			GroupIdToName = "(unknown)"
		End If
		
		
		SharedFree(ThisAllocation)
		
		
	End Function
	
	
	
	Private Function LongToIp(ByRef ip_lng As Integer) As String
		
		' +---------------------------------------------------------------+
		' | input:       long value of IP                                 |
		' | conversion:  long value to dotted IP string (xxx.xxx.xxx.xxx) |
		' +---------------------------------------------------------------+
		
		'TODO: does an inet_ntoa() call require WSAStartup / WSACleanup ?
		'      seems to work without them as well...
		
		LongToIp = getascip(ip_lng)
		
		
		' --------------------
		' OLD SELFWRITTEN CRAP
		' --------------------
		'
		'    On Error GoTo errhandler
		'
		'    'default return value incase of error
		'    LongToIp = CStr(ip_lng)
		'
		'    'store input IP in currency
		'    Dim TheIP As Currency
		'    TheIP = ip_lng
		'
		'    'signed -> unsigned
		'    If TheIP < 0 Then TheIP = TheIP + (MAX_LONG + 1)
		'
		'    'split IP into 4 segments
		'    Dim a(3) As Integer
		'    a(0) = TheIP Mod 256:    TheIP = (TheIP - a(0)) / 256
		'    a(1) = TheIP Mod 256:    TheIP = (TheIP - a(1)) / 256
		'    a(2) = TheIP Mod 256:    TheIP = (TheIP - a(2)) / 256
		'    a(3) = TheIP
		'
		'    'output
		'    LongToIp = a(0) & "." & a(1) & "." & a(2) & "." & a(3)
		'
		'Exit Function
		'
		'errhandler:
		
	End Function
	
	Private Sub OnlineDataToLastOnlineUser(ByRef x As ONLINEDATA, ByRef lCiD As Integer)
		Dim GetTickCount As Object
		
		Dim dblSpeed As Double
		
		'calculate speed
		If x.dwIntervalLength > 0 And x.dwBytesTransfered > 0 Then
			dblSpeed = (x.dwBytesTransfered / x.dwIntervalLength)
		End If
		
		Debug.Print("szVirtualDataPath = " & StripNulls(x.szVirtualDataPath))
		Debug.Print("szVirtualPath     = " & StripNulls(x.szVirtualPath))
		'Debug.Print "szRealDataPath    = " & StripNulls(x.szRealDataPath)
		Debug.Print("szRealPath        = " & StripNulls(x.szRealPath))
		
		With LastOnlineUser
			
			.iCID = lCiD
			.iUID = x.uid
			.lngLoginTime = (UnixTimeNow(TIME_OFFSET) - x.tLoginTime)
			'UPGRADE_WARNING: Couldn't resolve default property of object GetTickCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.lngIdleTime = Int((GetTickCount - x.dwIdleTickCount) / 1000)
			.sIdent = StripNulls(x.szIdent)
			.sClientIP = LongToIp(x.ulClientIp)
			.sDataIP = LongToIp(x.ulDataClientIp)
			.sServiceName = StripNulls(x.szServiceName)
			.sLastCmd = StripNulls(x.szAction)
			.iTransferState = x.bTransferStatus
			.dblSpeed = dblSpeed
			.iTransferbytes = x.i64TotalBytesTransfered * 10000 'decimal currency to integer
			.sVirtualPath = StripNulls(x.szVirtualPath)
			If .sVirtualPath = "" Then .sVirtualPath = "/"
			.sFilename = StripPath(Replace(StripNulls(x.szVirtualDataPath), "/", "\"))
			.sRealPath = StripNulls(x.szRealPath)
			.sHostname = StripNulls(x.szHostName)
			
			'hide password
			If LCase(.sLastCmd) Like "pass *" Then .sLastCmd = "PASS *****"
			
		End With
		
	End Sub
	
	Private Sub UserfileToLastUserfile(ByRef x As io_USERFILE)
		Dim CopyMemory As Object
		
		Dim n As Short
		
		Dim t(IP_LINE_LENGTH) As Byte
		Dim s As String
		With LastUserfile
			
			
			' +---------+
			' | general |
			' +---------+
			.iUID = x.uid
			.iGID = x.GID
			
			
			' +---------+
			' | strings |
			' +---------+
			.sTagline = StripNulls(x.tagline)
			.sFlags = StripNulls(x.flags)
			.sHomepath = StripNulls(x.home)
			.sVFSFile = StripNulls(x.mountfile)
			.sPasswordHash = BytesToHex(x.password)
			
			
			' +------------+
			' | userlimits |
			' +------------+
			For n = 0 To 4
				.iLimits(n) = x.limits(n)
			Next n
			
			'Debug.Print Replace(GetStringFromPointer(VarPtr(x) + 4504, sizeof_USERFILE - 4504), Chr(0), ".")
			'Debug.Print VarPtr(x) + 4504
			'Debug.Print VarPtr(x.ip(0, 0))
			'Debug.Print Replace(GetStringFromPointer(VarPtr(x.ip(0, 0)) - 100, 100), Chr(0), ".")
			
			
			' +-----+
			' | ips |
			' +-----+
			For n = 0 To (MAX_IPS - 1)
				'CopyMemory(t(0), x.ip(0, n), IP_LINE_LENGTH)
				'UPGRADE_ISSUE: Constant vbUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
				s = StripNulls(StrConv(System.Text.UnicodeEncoding.Unicode.GetString(t), vbUnicode))
				.ips(n) = s
			Next n
			
			
			' +--------+
			' | groups |
			' +--------+
			
			'+--------------------------------------------+
			'| TODO:  prevent overflow in array indexes   |
			'+--------------------------------------------+
			
			'set all to -1
			For n = 0 To (MAX_GROUPS - 1)
				.iGroups(n) = -1
				.iAdminGroups(n) = -1
			Next n
			
			'fill iGroups()
			n = 0
			While (x.groups(n) > -1)
				.iGroups(n) = x.groups(n)
				n = n + 1
			End While
			
			'fill iAdminGroups()
			n = 0
			While (x.admingroups(n) > -1)
				.iAdminGroups(n) = x.admingroups(n)
				n = n + 1
			End While
			
			
			' +----------+
			' | sections |
			' +----------+
			For n = 0 To (MAX_SECTIONS - 1)
				
				' NOTE:
				' when CopyMem´ing an C++ INT64 to a VB Currency,
				' the Currency´s value hast to be multiplied with
				' 10000 because it uses 5 digits after the comma.
				
				.iRatio(n) = x.ratio(n)
				.iCredits(n) = (x.credits(n) * 10000)
				
				.allup(n).files = x.allup((n * 3) + 0) * 10000
				.allup(n).bytes = x.allup((n * 3) + 1) * 10000
				.allup(n).times = x.allup((n * 3) + 2) * 10000
				
				.alldn(n).files = x.alldn((n * 3) + 0) * 10000
				.alldn(n).bytes = x.alldn((n * 3) + 1) * 10000
				.alldn(n).times = x.alldn((n * 3) + 2) * 10000
				
				.monthup(n).files = x.monthup((n * 3) + 0) * 10000
				.monthup(n).bytes = x.monthup((n * 3) + 1) * 10000
				.monthup(n).times = x.monthup((n * 3) + 2) * 10000
				
				.monthdn(n).files = x.monthdn((n * 3) + 0) * 10000
				.monthdn(n).bytes = x.monthdn((n * 3) + 1) * 10000
				.monthdn(n).times = x.monthdn((n * 3) + 2) * 10000
				
				.wkup(n).files = x.wkup((n * 3) + 0) * 10000
				.wkup(n).bytes = x.wkup((n * 3) + 1) * 10000
				.wkup(n).times = x.wkup((n * 3) + 2) * 10000
				
				.wkdn(n).files = x.wkdn((n * 3) + 0) * 10000
				.wkdn(n).bytes = x.wkdn((n * 3) + 1) * 10000
				.wkdn(n).times = x.wkdn((n * 3) + 2) * 10000
				
				.dayup(n).files = x.dayup((n * 3) + 0) * 10000
				.dayup(n).bytes = x.dayup((n * 3) + 1) * 10000
				.dayup(n).times = x.dayup((n * 3) + 2) * 10000
				
				.daydn(n).files = x.daydn((n * 3) + 0) * 10000
				.daydn(n).bytes = x.daydn((n * 3) + 1) * 10000
				.daydn(n).times = x.daydn((n * 3) + 2) * 10000
				
			Next n
			
			''' DEBUG:
			
			'        Debug.Print Fm("", 10); Fm("allup", 10); Fm("alldn", 10); Fm("monthup", 10); Fm("monthdn", 10); Fm("wkup", 10); Fm("wkdn", 10); Fm("dayup", 10); Fm("daydn", 10); Fm("credits", 10); Fm("ratio", 10)
			'        Debug.Print
			'        For n = 0 To (MAX_SECTIONS - 1)
			'            Debug.Print Fm(n & ".files", 10); Fm(.dayup(n).files, 10); Fm(.daydn(n).files, 10); Fm(.wkup(n).files, 10); Fm(.wkdn(n).files, 10); Fm(.monthup(n).files, 10); Fm(.monthdn(n).files, 10); Fm(.allup(n).files, 10); Fm(.alldn(n).files, 10); Fm(.iCredits(n), 10); Fm(.iRatio(n), 10)
			'            Debug.Print Fm(n & ".bytes", 10); Fm(.dayup(n).bytes, 10); Fm(.daydn(n).bytes, 10); Fm(.wkup(n).bytes, 10); Fm(.wkdn(n).bytes, 10); Fm(.monthup(n).bytes, 10); Fm(.monthdn(n).bytes, 10); Fm(.allup(n).bytes, 10); Fm(.alldn(n).bytes, 10)
			'            Debug.Print Fm(n & ".times", 10); Fm(.dayup(n).times, 10); Fm(.daydn(n).times, 10); Fm(.wkup(n).times, 10); Fm(.wkdn(n).times, 10); Fm(.monthup(n).times, 10); Fm(.monthdn(n).times, 10); Fm(.allup(n).times, 10); Fm(.alldn(n).times, 10)
			'        Next n
			
			'        Debug.Print "------ groups --------------------------"
			'        For n = 0 To (MAX_GROUPS - 1)
			'            If .iGroups(n) > -1 Then Debug.Print .iGroups(n)
			'        Next n
			'        Debug.Print "------ admingroups ---------------------"
			'        For n = 0 To (MAX_GROUPS - 1)
			'            If .iAdminGroups(n) > -1 Then Debug.Print .iAdminGroups(n)
			'        Next n
			
		End With
		
		
	End Sub
	
	
	Private Sub GroupfileToLastGroupfile(ByRef x As io_GROUPFILE)
		
		Dim n As Short
		
		With LastGroupfile
			
			' +---------+
			' | general |
			' +---------+
			.iGID = x.GID
			.iUserCount = x.usercount
			
			' +---------+
			' | strings |
			' +---------+
			.sDescription = StripNulls(x.description)
			.sVFSFile = StripNulls(x.vfsfile)
			
			' +-------+
			' | slots |
			' +-------+
			.iSlots(0) = x.slots(0)
			.iSlots(1) = x.slots(1)
			
		End With
		
		
	End Sub
	
	
	
	Private Function QueryDaemon(ByRef dwQueryType As Integer, ByRef lpAllocation As mylpAllocation, ByRef dwTimeOut As Integer) As Integer
		Dim WaitForSingleObject As Object
		Dim PostMessage As Object
		
		Dim x As LPDC_MESSAGE
		Dim lRet As Integer
		
		'1. copy memory at location lpAllocation.lpMessage into structure x
		'UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		CopyMem1(x, lpAllocation.lpMessage, 24)
		'2. edit structure x
		x.dwIdentifier = dwQueryType
		'3. copy structure x back to memory at location lpAllocation.lpMessage
		'UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		CopyMem2(lpAllocation.lpMessage, x, 24)
		
		
		'PostMessage(m_ioFTPD, WM_SHMEM, 0, lpAllocation.hDaemon)
		If ((Not (dwTimeOut) = 0)) And (Not (lpAllocation.hEvent = 0)) Then
			'UPGRADE_WARNING: Couldn't resolve default property of object WaitForSingleObject(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lRet = WaitForSingleObject(lpAllocation.hEvent, dwTimeOut)
			If (lRet = WAIT_TIMEOUT) Then
				QueryDaemon = -1
			Else
				'UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CopyMem1(x, lpAllocation.lpMessage, 24)
				QueryDaemon = x.dwReturn
			End If
		Else
			'//  No timeout/event, return value can't be checked
			QueryDaemon = -1
		End If
		
	End Function
	Private Sub CloseHandle(ByRef ref As Object)

	End Sub

	Private Sub SharedFree(ByRef lpAlloc As mylpAllocation)
		Dim SendMessage As Object
		Dim CloseHandle As Object

		'UnmapViewOfFile ByVal lpAlloc.lpMessage
		'UPGRADE_ISSUE: The preceding line couldn't be parsed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="82EBB1AE-1FCB-4FEF-9E6C-8736A316F8A7"'

		'If Not (lpAlloc.hEvent = 0) Then CloseHandle(lpAlloc.hEvent)
		'If Not (lpAlloc.hObject = 0) Then CloseHandle(lpAlloc.hObject)
		'SendMessage(m_ioFTPD, WM_DATACOPY_FREE, 0, lpAlloc.hDaemon)

	End Sub
	Private Function SharedAllocate(ByRef bCreateEvent As Boolean, ByRef dwBytes As Integer) As mylpAllocation
		Dim UnmapViewOfFile As Object
		Dim NO_ERROR As Object
		Dim SendMessage As Object
		Dim SetLastError As Object
		Dim MapViewOfFile As Object
		Dim CreateFileMapping As Object
		Dim CloseHandle As Object
		Dim CreateEvent As Object

		Dim lpAllocation As mylpAllocation
		Dim pt_lpAllocation As Integer 'pointer to mylpAllocation structure

		Dim lpMessage As LPDC_MESSAGE
		Dim pt_lpMessage As Integer	'pointer to LPDC_MESSAGE structure

		Dim dwMessage As Integer
		Dim hObject As Integer
		Dim hEvent As Integer
		Dim hRemote As Integer
		Dim bError As Boolean

		'UPGRADE_ISSUE: SECURITY_ATTRIBUTES object was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
		Dim lpDummySA As Object


		bError = True
		hEvent = 0
		hObject = 0
		pt_lpMessage = 0

		If (dwBytes = 0) Then Exit Function
		If (bCreateEvent = True) Then
			'UPGRADE_WARNING: Couldn't resolve default property of object CreateEvent(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			hEvent = CreateEvent(0, False, 0, 0)
			If (hEvent = 0) Then Exit Function
		End If

		'UPGRADE_ISSUE: VarPtr function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
		pt_lpAllocation = VarPtr(lpAllocation)

		If (pt_lpAllocation = 0) Then
			'If Not (hEvent = 0) Then CloseHandle(hEvent)
			Exit Function
		End If

		dwBytes = dwBytes + 24 'sizeof(DC_MESSAGE)=24
		'//  Allocate memory for local process
		'UPGRADE_WARNING: Couldn't resolve default property of object CreateFileMapping(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		hObject = CreateFileMapping(INVALID_HANDLE_VALUE, lpDummySA, PAGE_READWRITE Or SEC_COMMIT, 0, dwBytes, vbNullString)
		If Not (hObject = 0) Then
			'UPGRADE_WARNING: Couldn't resolve default property of object MapViewOfFile(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			pt_lpMessage = MapViewOfFile(hObject, FILE_MAP_WRITE Or FILE_MAP_READ, 0, 0, dwBytes)
		End If
		dwMessage = WM_DATACOPY_FILEMAP

		If Not (pt_lpMessage = 0) Then

			'fill in structure
			lpMessage.hEvent = hEvent
			lpMessage.lpContext = pt_lpMessage + 24
			lpMessage.lpMemoryBase = pt_lpMessage
			lpMessage.dwIdentifier = 0

			'copy it to the memory location
			'UPGRADE_WARNING: Couldn't resolve default property of object lpMessage. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			CopyMem2(pt_lpMessage, lpMessage, 24)

			'//  Query ioftpd
			'SetLastError(0)
			'UPGRADE_WARNING: Couldn't resolve default property of object SendMessage(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			hRemote = SendMessage(m_ioFTPD, dwMessage, m_ProcessId, hObject)

			'UPGRADE_WARNING: Couldn't resolve default property of object NO_ERROR. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If (Not (hRemote) = 0) And (Err.LastDllError = NO_ERROR) Then bError = False
		End If

		If (bError = True) Then
			'//  Free resources
			'If Not (pt_lpMessage = 0) Then UnmapViewOfFile(pt_lpMessage)
			'If (Not (hObject = 0)) Or (hObject <> INVALID_HANDLE_VALUE) Then CloseHandle(hObject)
			'If Not (hEvent = 0) Then CloseHandle(hEvent)
		Else
			'//  Update structure
			lpAllocation.hDaemon = hRemote
			lpAllocation.lpMemory = pt_lpMessage + 24
			lpAllocation.hEvent = hEvent
			lpAllocation.hObject = hObject
			lpAllocation.lpMessage = pt_lpMessage
			lpAllocation.dwBytes = dwBytes - 24
		End If

		'UPGRADE_WARNING: Couldn't resolve default property of object SharedAllocate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		SharedAllocate = lpAllocation

	End Function

	'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Initialize_Renamed()
		Dim GetCurrentProcessId As Object

		'initalize internal variables
		'UPGRADE_WARNING: Couldn't resolve default property of object GetCurrentProcessId(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		m_ProcessId = GetCurrentProcessId()

		'find ioFTPD's message window
		Dim sWindowName As String : sWindowName = "ioFTPD::MessageWindow"
		Dim sIniFilename As String : sIniFilename = MakeFilename("ioGuiExt.ini")
		Dim a() As String
		Dim i As Short
		If IsFile(sIniFilename) Then
			'UPGRADE_WARNING: Couldn't resolve default property of object ReadFileToArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			a = ReadFileToArray(sIniFilename)
			For i = LBound(a) To UBound(a)
				If LCase(a(i)) Like "windowname*=*" Then
					sWindowName = Trim(Split(a(i), "=", 2)(1))
				End If
			Next i
		End If
		m_ioFTPD = FindWindow(sWindowName, 0)

		'don´t use memmap functions if ioFTPD is not running
		If m_ioFTPD = 0 Then LOCAL_ERROR = True


	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
End Class