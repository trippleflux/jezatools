VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "clsMemMap"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Option Explicit

' +-----------------------+
' |  Win32 API functions  |
' +-----------------------+

Private Declare Sub CopyMem1 Lib "kernel32" Alias "RtlMoveMemory" (ByRef xxxDest As Any, ByVal lngSrc As Long, ByVal lngLen As Long)
Private Declare Sub CopyMem2 Lib "kernel32" Alias "RtlMoveMemory" (ByVal lngDest As Long, ByRef xxxSrc As Any, ByVal lngLen As Long)
Private Declare Sub CopyMem3 Lib "kernel32" Alias "RtlMoveMemory" (ByVal lngDest As Long, ByRef xxxSrc As Any, ByVal lngLen As Long)

Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, lpWindowName As Long) As Long

'*********************************************************************

' +-------------+
' |  CONSTANTS  |
' +-------------+

'win32 constants (all of them?)
Private Const PAGE_READWRITE       As Long = 4
Private Const SEC_COMMIT           As Long = &H8000000
Private Const FILE_MAP_READ        As Long = 2
Private Const FILE_MAP_WRITE       As Long = 4
Private Const WAIT_TIMEOUT         As Long = 258
Private Const INVALID_HANDLE_VALUE As Long = -1
'winmessages.h
Private Const WM_KICK              As Long = (WM_USER + 6)
Private Const WM_KILL              As Long = (WM_USER + 15)
Private Const iFILEMAP             As Long = (WM_USER + 21)
Private Const WM_SHMEM             As Long = (WM_USER + 101)
Private Const WM_DATACOPY_FILEMAP  As Long = (WM_USER + 21)
Private Const WM_DATACOPY_FREE     As Long = (WM_USER + 20)
'serverlimits.h
Private Const MAX_SECTIONS         As Long = 10
Private Const MAX_GROUPS           As Long = 128
Private Const MAX_IPS              As Long = 25
Private Const IP_LINE_LENGTH       As Long = 96
Private Const IP_LINE_LENGTH_1     As Long = IP_LINE_LENGTH + 1
Private Const MAX_NAME             As Long = 64
Private Const MAX_NAME_1           As Long = MAX_NAME + 1
Private Const MAX_PATH             As Long = 260
Private Const MAX_PATH_1           As Long = MAX_PATH + 1
'datacopy.h
Private Const DC_USER_TO_UID       As Long = 1     '//  Context = DC_NAMEID
Private Const DC_UID_TO_USER       As Long = 2     '//  Context = DC_NAMEID
Private Const DC_GROUP_TO_GID      As Long = 3     '//  Context = DC_NAMEID
Private Const DC_GID_TO_GROUP      As Long = 4     '//  Context = DC_NAMEID
Private Const DC_USERFILE_OPEN     As Long = 5     '//  Context = USERFILE
Private Const DC_USERFILE_LOCK     As Long = 6     '//  Context = USERFILE
Private Const DC_USERFILE_UNLOCK   As Long = 7     '//  Context = USERFILE
Private Const DC_USERFILE_CLOSE    As Long = 8     '//  Context = USERFILE
Private Const DC_GROUPFILE_OPEN    As Long = 9     '//  Context = GROUPFILE
Private Const DC_GROUPFILE_CLOSE   As Long = 10    '//  Context = GROUPFILE
Private Const DC_VFS_READ          As Long = 11    '//  Context = DC_VFS
Private Const DC_GET_ONLINEDATA    As Long = 13    '//  Context = DC_ONLINEDATA


' +--------------------------------------+
' | GENERAL SHARED MEMORY IOFTPD STRUCTS |
' +--------------------------------------+

Private Type myLocalData
    dwProcessId As Long
    dwType      As Long
    hDaemon     As Long
End Type

'size = 6 * 4b = 24b
Private Type LPDC_MESSAGE
    hEvent           As Long
    hDuplicateEvent  As Long
    dwIdentifier     As Long
    dwReturn         As Long
    lpMemoryBase     As Long
    lpContext        As Long
End Type

'size = 6 * 4b  = 24b
Private Type mylpAllocation
    lpMessage  As Long     'lpMessage  As LPDC_MESSAGE
    lpMemory   As Long
    hDaemon    As Long
    hObject    As Long
    hEvent     As Long
    dwBytes    As Long
End Type


' +--------------------+
' | ONLINEDATA STRUCTS |
' +--------------------+

Private Type ONLINEDATA                  'typedef struct _ONLINEDATA {

    uid As Long                          'INT32       Uid;

    dwFlags As Long                      'DWORD       dwFlags;
    szServiceName As String * MAX_NAME_1 'CHAR        szServiceName[_MAX_NAME + 1];   // Name of service
    szAction As String * 64              'CHAR        szAction[64];                   // User's last action

    ulClientIp As Long                   'ULONG       ulClientIp;
    usClientPort As Integer              'USHORT      usClientPort;

    szHostName As String * 96            'CHAR        szHostName[MAX_HOSTNAME];   // Hostname
    szIdent As String * 64               'CHAR        szIdent[MAX_IDENT];         // Ident

    szVirtualPath As String * 513        'CHAR        szVirtualPath[_MAX_PWD + 1];    // Virtual path
    szRealPath As String                 'LPSTR       szRealPath;                     // Real path
    dwRealPath As Long                   'DWORD       dwRealPath;

    tLoginTime As Long                   'time_t      tLoginTime;             // Login Time
    dwIdleTickCount As Long              'DWORD       dwIdleTickCount;        // Idle Time

    bTransferStatus As Byte              'BYTE        bTransferStatus;        // (0 Inactive, 1 Upload, 2 Download, 3 List)
    ulDataClientIp As Long               'ULONG       ulDataClientIp;
    usDataClientPort As Integer          'USHORT      usDataClientPort;

    szVirtualDataPath As String * 513    'CHAR        szVirtualDataPath[_MAX_PWD + 1];
    szRealDataPath As Long               'LPSTR       szRealDataPath;
    dwRealDataPath As Long               'DWORD       dwRealDataPath;

    dwBytesTransfered       As Long      'DWORD       dwBytesTransfered;        // Bytes transfered during interval
    dwIntervalLength        As Long      'DWORD       dwIntervalLength;         // Milliseconds
    i64TotalBytesTransfered As Currency  'INT64       i64TotalBytesTransfered;  // Total bytes transfered during transfer

End Type                                '} ONLINEDATA, * PONLINEDATA;

Private Const sizeof_DC_ONLINEDATA As Long = 1392
Private Type LPDC_ONLINEDATA            'typedef struct _DC_ONLINEDATA
                                        '{
    xOnlineData        As ONLINEDATA    '  ONLINEDATA  OnlineData;
    iOffset            As Integer       '  INT         iOffset;
    dwSharedMemorySize As Long          '  DWORD       dwSharedMemorySize;
                                        '} DC_ONLINEDATA, * LPDC_ONLINEDATA;
End Type



' +------------------+
' | GROUPFILE STRUCT |
' +------------------+

Private Const sizeof_GROUPFILE As Long = 416
Private Type io_GROUPFILE                      ' typedef struct _GROUPFILE
                                               ' {
    GID         As Long                        '     INT        Gid;                      // Group Id
    slots(1)    As Long                        '     INT        Slots[2];                 // # of slots left for this group
    usercount   As Long                        '     INT        Users;                    // # of users in this group
    description As String * 129                '     CHAR       szDescription[128 + 1];   // Long description
    vfsfile     As String * MAX_PATH_1         '     CHAR       szVfsFile[MAX_PATH + 1];  // Default VFS file
                                               '
    lpInternal  As Long                        '     LPVOID     lpInternal;
    lpParent    As Long                        '     LPVOID     lpParent;
                                               '
End Type                                       ' } GROUPFILE, * LPGROUPFILE;



' +-----------------+
' | USERFILE STRUCT |
' +-----------------+

Private Const sizeof_USERFILE As Long = 6240
Private Type io_USERFILE                            ' typedef struct _USERFILE
                                                    ' {
    uid As Long                                     '     INT       Uid;                       // User id
    GID As Long                                     '     INT       Gid;                       // User group id
                                                                                                                                                      
    tagline   As String * 129                       '     CHAR      Tagline[128 + 1];          // Info line
    mountfile As String * MAX_PATH_1                '     CHAR      MountFile[_MAX_PATH + 1];  // Root directory
    home      As String * MAX_PATH_1                '     CHAR      Home[_MAX_PATH + 1];       // Home directory
    flags     As String * 33                        '     CHAR      Flags[32 + 1];             // Flags
    limits(4) As Long                               '     INT       Limits[5];                 // Up max speed, dn max speed, ftp logins, telnet, http
                                                                                                                                                      
    password  As String * 20                        '     UCHAR     Password[20];              // Password
                                                                                                                                                
    ratio(MAX_SECTIONS)             As Long         '     INT       Ratio[MAX_SECTIONS];       // Ratio
    credits(MAX_SECTIONS - 1)       As Currency     '     INT64     Credits[MAX_SECTIONS];     // Credits
                                                                                                                                                
    dayup((MAX_SECTIONS * 3) - 1)   As Currency     '     INT64     DayUp[MAX_SECTIONS * 3];   // Daily uploads
    daydn((MAX_SECTIONS * 3) - 1)   As Currency     '     INT64     DayDn[MAX_SECTIONS * 3];   // Daily downloads
    wkup((MAX_SECTIONS * 3) - 1)    As Currency     '     INT64     WkUp[MAX_SECTIONS * 3];    // Weekly uploads
    wkdn((MAX_SECTIONS * 3) - 1)    As Currency     '     INT64     WkDn[MAX_SECTIONS * 3];    // Weekly downloads
    monthup((MAX_SECTIONS * 3) - 1) As Currency     '     INT64     MonthUp[MAX_SECTIONS * 3]; // Monthly uploads
    monthdn((MAX_SECTIONS * 3) - 1) As Currency     '     INT64     MonthDn[MAX_SECTIONS * 3]; // Monthly downloads
    allup((MAX_SECTIONS * 3) - 1)   As Currency     '     INT64     AllUp[MAX_SECTIONS * 3];   // Alltime uploads
    alldn((MAX_SECTIONS * 3) - 1)   As Currency     '     INT64     AllDn[MAX_SECTIONS * 3];   // Alltime downloads
                                                                                                                                                
    admingroups(MAX_GROUPS - 1)     As Long         '     INT       AdminGroups[MAX_GROUPS];   // Admin for these groups
    groups(MAX_GROUPS - 1)          As Long         '     INT       Groups[MAX_GROUPS];        // List of groups
    ip(IP_LINE_LENGTH, MAX_IPS)     As Byte         '     CHAR      Ip[MAX_IPS][_IP_LINE_LENGTH + 1];    // List of ips
                                                                                                                                                      
    lpInternal As Long                              '     LPVOID    lpInternal;
    lpParent   As Long                              '     LPVOID    lpParent;
                                                    '
End Type                                            ' } USERFILE, * PUSERFILE, * LPUSERFILE;



' +---------------+
' | NAMEID STRUCT |
' +---------------+

Private Const sizeof_DC_NAMEID As Long = 72
Private Type DC_NAMEID                    ' typedef struct _DC_NAMEID
                                          ' {
   'sName As String * MAX_NAME_1          '     CHAR    szName[_MAX_NAME + 1];
    sName(MAX_NAME_1) As Byte             '     CHAR    szName[_MAX_NAME + 1];
    id    As Long                         '     INT32   Id;
                                          '
End Type                                  ' } DC_NAMEID, * LPDC_NAMEID;



'*****************************************************************************



' +----------------------+
' |  internal variables  |
' +----------------------+

Private m_ProcessId    As Long
Private m_ioFTPD       As Long
Private m_lpAllocation As mylpAllocation 'only for GetFirstOnlineUser & GetNextOnlineUser
                                         'single-call functions use a local var


' +--------------------------+
' |  public variables/types  |
' +--------------------------+

Public LOCAL_ERROR As Boolean




Private Function BytesToHex(data As String) As String
    
    ' +------------------------------------------+
    ' | used to convert password from bin to hex |
    ' +------------------------------------------+
    
    Dim n      As Integer
    Dim buffer As String


    If Len(data) = 0 Then Exit Function
    
    
    buffer = Space(Len(data) * 2)

    For n = 1 To Len(data)
        Mid(buffer, (n * 2) - 1, 2) = Hex(Asc(Mid(data, n, 1)))
    Next n

    BytesToHex = buffer

End Function


Private Sub CopyUserHelper(ThisAlloc1 As mylpAllocation, ThisAlloc2 As mylpAllocation, lpUserSrc As io_USERFILE, lpUserDest As io_USERFILE, iUID_dest As Integer)

    Dim lRet As Long

    CopyMem1 lpUserSrc, ThisAlloc1.lpMemory, sizeof_USERFILE   'read source userfile
    lRet = QueryDaemon(DC_USERFILE_LOCK, ThisAlloc2, 5000)     'lock dest userfile
    CopyMemory lpUserDest, lpUserSrc, sizeof_USERFILE          'copy source user into destination user
    lpUserDest.uid = iUID_dest                                 'quite essential :)
    CopyMem2 ThisAlloc2.lpMemory, lpUserDest, sizeof_USERFILE  'save changes
    lRet = QueryDaemon(DC_USERFILE_UNLOCK, ThisAlloc2, 5000)   'unlock dest userfile
    lRet = QueryDaemon(DC_USERFILE_CLOSE, ThisAlloc2, 5000)    'close dest userfile
        
End Sub

Public Sub GetGroupIdTable()

    
    Dim lRet           As Long
    Dim lpNameId       As DC_NAMEID
    Dim ThisAllocation As mylpAllocation
    
    Dim n              As Integer
    Dim sName          As String
    
    'clear the current array, if any
    ReDim GroupIdTable(0) As myIdTable
    
    'allocate shared memory
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
        CopyMem2 ThisAllocation.lpMemory, lpNameId, sizeof_DC_NAMEID
        
        'get the groupname from ioFTPD
        lRet = QueryDaemon(DC_GID_TO_GROUP, ThisAllocation, 1000)
        If (lRet = 0) Then
            'ok !
            
            'copy shared memory into structure
            CopyMem1 lpNameId, ThisAllocation.lpMemory, sizeof_DC_NAMEID
            
            'convert to string
            sName = StrConv(lpNameId.sName, vbUnicode) 'bytearray to string
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
    If UBound(GroupIdTable) > 0 Then _
    ReDim Preserve GroupIdTable(UBound(GroupIdTable) - 1)
    
    
    SharedFree ThisAllocation


End Sub
Public Function GetOwnerOfFile()

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

    
    Dim lRet           As Long
    Dim lpNameId       As DC_NAMEID
    Dim ThisAllocation As mylpAllocation
    
    Dim n              As Integer
    Dim sName          As String
    
    'clear the current array, if any
    ReDim UserIdTable(0) As myIdTable
    
    'allocate shared memory
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
        CopyMem2 ThisAllocation.lpMemory, lpNameId, sizeof_DC_NAMEID
        
        'get the username from ioFTPD
        lRet = QueryDaemon(DC_UID_TO_USER, ThisAllocation, 1000)
        If (lRet = 0) Then
            'ok !
            
            'copy shared memory into structure
            CopyMem1 lpNameId, ThisAllocation.lpMemory, sizeof_DC_NAMEID
            
            'convert to string
            sName = StrConv(lpNameId.sName, vbUnicode) 'bytearray to string
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
    If UBound(UserIdTable) > 0 Then _
    ReDim Preserve UserIdTable(UBound(UserIdTable) - 1)
    
    
    SharedFree ThisAllocation


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
    
    Dim lCiD         As Long
    Dim lRet         As Long
    Dim lpOnlineData As LPDC_ONLINEDATA
    
    
    
    'clear old data (if any)
    ClearLastOnlineUser
 
    'allocate shared memory
    m_lpAllocation = SharedAllocate(True, sizeof_DC_ONLINEDATA + (MAX_PATH * 2))
    If (m_lpAllocation.hDaemon = 0) Then
        GetFirstOnlineUser = False
        Exit Function
    End If
        
    'fill in structure
    lpOnlineData.iOffset = 0
    lpOnlineData.dwSharedMemorySize = m_lpAllocation.dwBytes
    
    'copy it to shared memory location
    CopyMem2 m_lpAllocation.lpMemory, lpOnlineData, sizeof_DC_ONLINEDATA
    
    
    'get first online user (if any)
    lRet = QueryDaemon(DC_GET_ONLINEDATA, m_lpAllocation, 5000)
    If (lRet = 0) Then
    
        GetFirstOnlineUser = True
    
        'copy shared memory into LPDC_ONLINEDATA structure
        CopyMem1 lpOnlineData, m_lpAllocation.lpMemory, 1392
        
        lCiD = (lpOnlineData.iOffset - 1)
        
        'continue if both UID and CID > -1
        If (lpOnlineData.xOnlineData.uid > -1) And (lCiD > -1) Then
            OnlineDataToLastOnlineUser lpOnlineData.xOnlineData, lCiD
        Else
            'UID = -1   > User is logging in...
            'CID = -1   > Some bad io stuff, ignore...
            LastOnlineUser.iUID = -1  'let calling code know that they should skip this user
        End If
        
    Else
        'nobody online or function failed
        GetFirstOnlineUser = False
        SharedFree m_lpAllocation
    End If
    

End Function



Public Function GetNextOnlineUser() As Boolean
    
    Dim lCiD         As Long
    Dim lRet         As Long
    Dim lpOnlineData As LPDC_ONLINEDATA
    
    
    'clear old data (if any)
    ClearLastOnlineUser
     
    
    'get next online user (if any)
    lRet = QueryDaemon(DC_GET_ONLINEDATA, m_lpAllocation, 5000)
    If (lRet = 0) Then
    
        GetNextOnlineUser = True
    
        'copy shared memory into LPDC_ONLINEDATA structure
        CopyMem1 lpOnlineData, m_lpAllocation.lpMemory, sizeof_DC_ONLINEDATA
        
        'determine connection ID
        lCiD = (lpOnlineData.iOffset - 1)
        
        'continue if both UID and CID > -1
        If (lpOnlineData.xOnlineData.uid > -1) And (lCiD > -1) Then
            OnlineDataToLastOnlineUser lpOnlineData.xOnlineData, lCiD
        Else
            'UID = -1   > User is logging in...
            'CID = -1   > Some bad io stuff, ignore...
            LastOnlineUser.iUID = -1  'let calling code know that they should skip this user
        End If
        
    Else
        'nobody online or function failed
        GetNextOnlineUser = False
        SharedFree m_lpAllocation
    End If
    

End Function
Private Function GetStringFromPointer(lpString As Long, dwSize As Long) As String

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
    CopyMem1 sRet(0), lpString, dwSize
    GetStringFromPointer = StrConv(sRet, vbUnicode)

End Function



Public Function GetUserFile(iUID As Integer) As Boolean

    
    Dim lRet           As Long
    Dim lpUserFile     As io_USERFILE
    Dim ThisAllocation As mylpAllocation
    
    
    'clear old data (if any)
    ClearLastUserFile
 
    'allocate shared memory
    ThisAllocation = SharedAllocate(True, sizeof_USERFILE + (MAX_PATH * 2))
    If (ThisAllocation.hDaemon = 0) Then
        GetUserFile = False
        Exit Function
    End If
        
    'fill in structure
    lpUserFile.uid = iUID
    
    'copy it to shared memory location
    CopyMem2 ThisAllocation.lpMemory, lpUserFile, sizeof_USERFILE
    
    'get the userfile from ioFTPD
    lRet = QueryDaemon(DC_USERFILE_OPEN, ThisAllocation, 5000)
    If (lRet = 0) Then
        'ok !
        GetUserFile = True
        
        'copy shared memory into structure
        CopyMem1 lpUserFile, ThisAllocation.lpMemory, sizeof_USERFILE
        
        'put the userfile into the public variable
        UserfileToLastUserfile lpUserFile
        
        'close the userfile
        lRet = QueryDaemon(DC_USERFILE_CLOSE, ThisAllocation, 5000)
    Else
        'user doesn't exist or function failed
        GetUserFile = False
    End If
    
    
    SharedFree ThisAllocation


End Function

Public Function SetUserFlags(iUID As Integer, sFlags As String) As Boolean

    
    Dim lRet           As Long
    Dim lpUserFile     As io_USERFILE
    Dim ThisAllocation As mylpAllocation
    
    
    'allocate shared memory
    ThisAllocation = SharedAllocate(True, sizeof_USERFILE + (MAX_PATH * 2))
    If (ThisAllocation.hDaemon = 0) Then
        SetUserFlags = False
        Exit Function
    End If
        
    'fill in structure
    lpUserFile.uid = iUID
    
    'copy it to shared memory location
    CopyMem2 ThisAllocation.lpMemory, lpUserFile, sizeof_USERFILE
    
    'get the userfile from ioFTPD
    lRet = QueryDaemon(DC_USERFILE_OPEN, ThisAllocation, 5000)
    If (lRet = 0) Then
        'ok !
        SetUserFlags = True
        
        'lock userfile
        lRet = QueryDaemon(DC_USERFILE_LOCK, ThisAllocation, 5000)
        
        'copy shared memory into structure
        CopyMem1 lpUserFile, ThisAllocation.lpMemory, sizeof_USERFILE
        
        'add flag M to in the structure
        lpUserFile.flags = sFlags & String(33 - Len(sFlags), Chr(0))
                
        'save changes
        CopyMem2 ThisAllocation.lpMemory, lpUserFile, sizeof_USERFILE
        
        'unlock userfile
        lRet = QueryDaemon(DC_USERFILE_UNLOCK, ThisAllocation, 5000)
        
        'close userfile
        lRet = QueryDaemon(DC_USERFILE_CLOSE, ThisAllocation, 5000)
        
    Else
        'user doesn't exist or function failed
    End If
    
    
    SharedFree ThisAllocation


End Function


Public Function CopyUser(iUID_src As Integer, iUID_dest As Integer) As Boolean

    
    Dim lRet           As Long
    Dim lpUserSrc      As io_USERFILE
    Dim lpUserDest     As io_USERFILE
    Dim ThisAlloc1     As mylpAllocation
    Dim ThisAlloc2     As mylpAllocation
    
    'assume success
    CopyUser = True
    
    'allocate shared memory
    ThisAlloc1 = SharedAllocate(True, sizeof_USERFILE + (MAX_PATH * 2))
    ThisAlloc2 = SharedAllocate(True, sizeof_USERFILE + (MAX_PATH * 2))
    If (ThisAlloc1.hDaemon = 0 Or ThisAlloc2.hDaemon = 0) Then
        CopyUser = False
        Exit Function
    End If
        
    'fill in structures
    lpUserSrc.uid = iUID_src
    lpUserDest.uid = iUID_dest
    
    'copy it to shared memory location
    CopyMem2 ThisAlloc1.lpMemory, lpUserSrc, sizeof_USERFILE
    CopyMem2 ThisAlloc2.lpMemory, lpUserDest, sizeof_USERFILE
    
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
    
        CopyUserHelper ThisAlloc1, ThisAlloc2, lpUserSrc, lpUserDest, iUID_dest
    
    End If
    
    
    SharedFree ThisAlloc1
    SharedFree ThisAlloc2

End Function



Public Function GetGroupFile(iGID As Integer) As Boolean

    
    Dim lRet           As Long
    Dim lpGroupFile    As io_GROUPFILE
    Dim ThisAllocation As mylpAllocation
    
    
    'clear old data (if any)
    'ClearLastGroupFile
 
    'allocate shared memory
    ThisAllocation = SharedAllocate(True, sizeof_GROUPFILE + (MAX_PATH * 2))
    If (ThisAllocation.hDaemon = 0) Then
        GetGroupFile = False
        Exit Function
    End If
        
    'fill in structure
    lpGroupFile.GID = iGID
    
    'copy it to shared memory location
    CopyMem2 ThisAllocation.lpMemory, lpGroupFile, sizeof_GROUPFILE
    
    'get the userfile from ioFTPD
    lRet = QueryDaemon(DC_GROUPFILE_OPEN, ThisAllocation, 5000)
    If (lRet = 0) Then
        'ok !
        GetGroupFile = True
        
        'copy shared memory into structure
        CopyMem1 lpGroupFile, ThisAllocation.lpMemory, sizeof_GROUPFILE
        
        'put the userfile into the public variable
        GroupfileToLastGroupfile lpGroupFile
        
        'close the userfile
        lRet = QueryDaemon(DC_GROUPFILE_CLOSE, ThisAllocation, 5000)
    Else
        'user doesn't exist or function failed
        GetGroupFile = False
    End If
    
    
    SharedFree ThisAllocation


End Function


Public Sub KickUserByUID(iUID As Integer)

    'http://www.ioftpd.com/board/showthread.php?s=&postid=18326#post18326
    'Use PostMessage() instead of SendMessage(), when possible.
    
        PostMessage ByVal m_ioFTPD, _
                    ByVal WM_KICK, _
                    ByVal iUID, _
                    ByVal 0

End Sub

Public Sub KickUserByCID(iCID As Integer)

    'http://www.ioftpd.com/board/showthread.php?s=&postid=18326#post18326
    'Use PostMessage() instead of SendMessage(), when possible.

        PostMessage ByVal m_ioFTPD, _
                    ByVal WM_KILL, _
                    ByVal iCID, _
                    ByVal 0

End Sub


Public Function UserIdToName(iUID As Integer) As String

    
    Dim lRet           As Long
    Dim lpNameId       As DC_NAMEID
    Dim ThisAllocation As mylpAllocation
    
    
    'allocate shared memory
    ThisAllocation = SharedAllocate(True, sizeof_DC_NAMEID + (MAX_PATH * 2))
    If (ThisAllocation.hDaemon = 0) Then
        UserIdToName = "(error)"
        Exit Function
    End If
        
    'fill in structure
    lpNameId.id = iUID
    
    'copy it to shared memory location
    CopyMem2 ThisAllocation.lpMemory, lpNameId, sizeof_DC_NAMEID
    
    'get the userfile from ioFTPD
    lRet = QueryDaemon(DC_UID_TO_USER, ThisAllocation, 3000)
    If (lRet = 0) Then
        'ok !
        
        'copy shared memory into structure
        CopyMem1 lpNameId, ThisAllocation.lpMemory, sizeof_DC_NAMEID
        
        'return username
        UserIdToName = StrConv(lpNameId.sName, vbUnicode) 'bytearray to string
        UserIdToName = StripNulls(UserIdToName)

    Else
        'userid doesn´t exist or function failed
        UserIdToName = "(unknown)"
    End If
    
    
    SharedFree ThisAllocation


End Function


Public Function UserNameToID(sUsername As String) As Integer

    
    Dim lRet           As Long
    Dim lpNameId       As DC_NAMEID
    Dim ThisAllocation As mylpAllocation
    
    
    'exit with -1 if no username was given
    If Len(sUsername) = 0 Then
        UserNameToID = -1
        Exit Function
    End If
    
    'allocate shared memory
    ThisAllocation = SharedAllocate(True, sizeof_DC_NAMEID + (MAX_PATH * 2))
    If (ThisAllocation.hDaemon = 0) Then
        UserNameToID = -1
        Exit Function
    End If
        
    'fill in structure
    Dim n   As Integer
    Dim b() As Byte
    b = StrConv(Left(sUsername, 64), vbFromUnicode) 'limit to 64 chars
    CopyMem2 VarPtr(lpNameId.sName(0)), b(0), UBound(b) + 1
    
    'copy it to shared memory location
    CopyMem2 ThisAllocation.lpMemory, lpNameId, sizeof_DC_NAMEID
    
    'get the userfile from ioFTPD
    lRet = QueryDaemon(DC_USER_TO_UID, ThisAllocation, 3000)
    
    'return value is userid. bad usernames will result in UID = -1
    UserNameToID = lRet
    
    
    
    SharedFree ThisAllocation


End Function



Public Function GroupIdToName(iGID As Integer) As String

    
    Dim lRet           As Long
    Dim lpNameId       As DC_NAMEID
    Dim ThisAllocation As mylpAllocation
    
    
    'allocate shared memory
    ThisAllocation = SharedAllocate(True, sizeof_DC_NAMEID + (MAX_PATH * 2))
    If (ThisAllocation.hDaemon = 0) Then
        GroupIdToName = "(error)"
        Exit Function
    End If
        
    'fill in structure
    lpNameId.id = iGID
    
    'copy it to shared memory location
    CopyMem2 ThisAllocation.lpMemory, lpNameId, sizeof_DC_NAMEID
    
    'get the userfile from ioFTPD
    lRet = QueryDaemon(DC_GID_TO_GROUP, ThisAllocation, 3000)
    If (lRet = 0) Then
        'ok !
        
        'copy shared memory into structure
        CopyMem1 lpNameId, ThisAllocation.lpMemory, sizeof_DC_NAMEID
        
        'return groupname
        GroupIdToName = StrConv(lpNameId.sName, vbUnicode) 'bytearray to string
        GroupIdToName = StripNulls(GroupIdToName)
        

    Else
        'groupid doesn´t exist or function failed
        GroupIdToName = "(unknown)"
    End If
    
    
    SharedFree ThisAllocation


End Function



Private Function LongToIp(ip_lng As Long) As String
    
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

Private Sub OnlineDataToLastOnlineUser(x As ONLINEDATA, lCiD As Long)

    Dim dblSpeed As Double

    'calculate speed
    If x.dwIntervalLength > 0 And x.dwBytesTransfered > 0 Then
        dblSpeed = (x.dwBytesTransfered / x.dwIntervalLength)
    End If
    
    Debug.Print "szVirtualDataPath = " & StripNulls(x.szVirtualDataPath)
    Debug.Print "szVirtualPath     = " & StripNulls(x.szVirtualPath)
    'Debug.Print "szRealDataPath    = " & StripNulls(x.szRealDataPath)
    Debug.Print "szRealPath        = " & StripNulls(x.szRealPath)
    
    With LastOnlineUser
    
        .iCID = lCiD
        .iUID = x.uid
        .lngLoginTime = (UnixTimeNow(TIME_OFFSET) - x.tLoginTime)
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

Private Sub UserfileToLastUserfile(x As io_USERFILE)

    Dim n As Integer
    
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
        Dim t(IP_LINE_LENGTH) As Byte
        Dim s As String
        For n = 0 To (MAX_IPS - 1)
            CopyMemory t(0), x.ip(0, n), IP_LINE_LENGTH
            s = StripNulls(StrConv(t, vbUnicode))
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
        Wend
        
        'fill iAdminGroups()
        n = 0
        While (x.admingroups(n) > -1)
            .iAdminGroups(n) = x.admingroups(n)
            n = n + 1
        Wend
                
        
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


Private Sub GroupfileToLastGroupfile(x As io_GROUPFILE)

    Dim n As Integer
    
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



Private Function QueryDaemon(dwQueryType As Long, lpAllocation As mylpAllocation, dwTimeOut As Long) As Long

    Dim x    As LPDC_MESSAGE
    Dim lRet As Long

    '1. copy memory at location lpAllocation.lpMessage into structure x
        CopyMem1 x, lpAllocation.lpMessage, 24
    '2. edit structure x
        x.dwIdentifier = dwQueryType
    '3. copy structure x back to memory at location lpAllocation.lpMessage
        CopyMem2 lpAllocation.lpMessage, x, 24

    
    PostMessage ByVal m_ioFTPD, ByVal WM_SHMEM, ByVal 0, ByVal lpAllocation.hDaemon
    If ((Not (dwTimeOut) = 0)) And (Not (lpAllocation.hEvent = 0)) Then
        lRet = WaitForSingleObject(lpAllocation.hEvent, dwTimeOut)
        If (lRet = WAIT_TIMEOUT) Then
            QueryDaemon = -1
        Else
            CopyMem1 x, lpAllocation.lpMessage, 24
            QueryDaemon = x.dwReturn
        End If
    Else
        '//  No timeout/event, return value can't be checked
        QueryDaemon = -1
    End If
    
End Function

Private Sub SharedFree(ByRef lpAlloc As mylpAllocation)
    
    UnmapViewOfFile ByVal lpAlloc.lpMessage
    
    If Not (lpAlloc.hEvent = 0) Then CloseHandle lpAlloc.hEvent
    If Not (lpAlloc.hObject = 0) Then CloseHandle lpAlloc.hObject
    SendMessage ByVal m_ioFTPD, ByVal WM_DATACOPY_FREE, ByVal 0, ByVal lpAlloc.hDaemon

End Sub
Private Function SharedAllocate(bCreateEvent As Boolean, dwBytes As Long) As mylpAllocation

    Dim lpAllocation    As mylpAllocation
    Dim pt_lpAllocation As Long            'pointer to mylpAllocation structure
    
    Dim lpMessage       As LPDC_MESSAGE
    Dim pt_lpMessage    As Long            'pointer to LPDC_MESSAGE structure
    
    Dim dwMessage       As Long
    Dim hObject         As Long
    Dim hEvent          As Long
    Dim hRemote         As Long
    Dim bError          As Boolean
    
    Dim lpDummySA As SECURITY_ATTRIBUTES


    bError = True
    hEvent = 0
    hObject = 0
    pt_lpMessage = 0

    If (dwBytes = 0) Then Exit Function
    If (bCreateEvent = True) Then
        hEvent = CreateEvent(0, False, 0, 0)
        If (hEvent = 0) Then Exit Function
    End If
    
    pt_lpAllocation = VarPtr(lpAllocation)
    
    If (pt_lpAllocation = 0) Then
        If Not (hEvent = 0) Then CloseHandle hEvent
        Exit Function
    End If

    dwBytes = dwBytes + 24 'sizeof(DC_MESSAGE)=24
    '//  Allocate memory for local process
    hObject = CreateFileMapping(INVALID_HANDLE_VALUE, lpDummySA, PAGE_READWRITE Or SEC_COMMIT, 0, dwBytes, vbNullString)
    If Not (hObject = 0) Then
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
        CopyMem2 pt_lpMessage, lpMessage, 24

        '//  Query ioftpd
        SetLastError 0
        hRemote = SendMessage(ByVal m_ioFTPD, ByVal dwMessage, ByVal m_ProcessId, ByVal hObject)

        If (Not (hRemote) = 0) And (Err.LastDllError = NO_ERROR) Then bError = False
    End If

    If (bError = True) Then
        '//  Free resources
        If Not (pt_lpMessage = 0) Then UnmapViewOfFile pt_lpMessage
        If (Not (hObject = 0)) Or (hObject <> INVALID_HANDLE_VALUE) Then CloseHandle hObject
        If Not (hEvent = 0) Then CloseHandle hEvent
    Else
        '//  Update structure
        lpAllocation.hDaemon = hRemote
        lpAllocation.lpMemory = pt_lpMessage + 24
        lpAllocation.hEvent = hEvent
        lpAllocation.hObject = hObject
        lpAllocation.lpMessage = pt_lpMessage
        lpAllocation.dwBytes = dwBytes - 24
    End If
    
    SharedAllocate = lpAllocation
    
End Function

Private Sub Class_Initialize()

    'initalize internal variables
    m_ProcessId = GetCurrentProcessId()
    
    'find ioFTPD's message window
    Dim sWindowName As String: sWindowName = "ioFTPD::MessageWindow"
    Dim sIniFilename As String: sIniFilename = MakeFilename("ioGuiExt.ini")
    If IsFile(sIniFilename) Then
        Dim a() As String
        Dim i As Integer
        a = ReadFileToArray(sIniFilename)
        For i = LBound(a) To UBound(a)
            If LCase(a(i)) Like "windowname*=*" Then
                sWindowName = Trim(Split(a(i), "=", 2)(1))
            End If
        Next i
    End If
    m_ioFTPD = FindWindow(sWindowName, ByVal 0)
    
    'don´t use memmap functions if ioFTPD is not running
    If m_ioFTPD = 0 Then LOCAL_ERROR = True
   

End Sub


