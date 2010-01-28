Attribute VB_Name = "mdlMemMap"
Option Explicit


'-----------------------------------------------------'
'                   clsMemMap STUFF                   '
'-----------------------------------------------------'

'u might want to read this value from your program's configuration file (like my sitewho.exe)
'it is used in clsMemMap::OnlineDataToLastOnlineUser
Public Const TIME_OFFSET As Long = 3600

Public Enum myTransferState
    stateIdle = 0
    stateDownload = 1
    stateUpload = 2
    stateLIST = 3
End Enum

Public Type myOnlineUser
    iCID            As Integer
    iUID            As Integer
    sIdent          As String
    sClientIP       As String
    sDataIP         As String
    sServiceName    As String
    sLastCmd        As String
    lngLoginTime    As Long
    lngIdleTime     As Long
    iTransferState  As myTransferState
    dblSpeed        As Double            'in kBps
    iTransferbytes  As Currency          'transferred bytes of current file
    sVirtualPath    As String
    sRealPath       As String
    sFilename       As String
    sHostname       As String
End Type

Public Type myIoStats
    files As Long
    bytes As Currency
    times As Long
End Type

Public Type myUserfile
    'MAX_GROUPS   = 128
    'MAX_IPS      =  25
    'MAX_SECTIONS =  10
    iUID              As Integer
    iGID              As Integer
    sTagline          As String
    sFlags            As String
    sVFSFile          As String
    sPasswordHash     As String
    sHomepath         As String
    ips(24)           As String
    iLimits(4)        As Long
    iGroups(127)      As Integer ' -1 by default (no group)
    iAdminGroups(127) As Integer ' same.
    iRatio(9)         As Integer
    iCredits(9)       As Currency
    allup(9)          As myIoStats 'remark: it seems only 0-8 contains valid data.
    alldn(9)          As myIoStats '        index 9 times contain all zeros.
    monthup(9)        As myIoStats '        meaning there are only 9 sections instead of 10?
    monthdn(9)        As myIoStats
    wkup(9)           As myIoStats
    wkdn(9)           As myIoStats
    dayup(9)          As myIoStats
    daydn(9)          As myIoStats
End Type

Public Type myGroupfile
    iGID         As Integer
    iSlots(1)    As Integer ' 0 = groupslots / 1 = leechslots
    iUserCount   As Integer ' not sure if this is always correct
    sDescription As String
    sVFSFile     As String
End Type

Public Type myIdTable
    iID   As Integer
    sName As String
End Type

Public LastOnlineUser As myOnlineUser
Public LastUserfile   As myUserfile
Public LastGroupfile  As myGroupfile
Public UserIdTable()  As myIdTable
Public GroupIdTable() As myIdTable




'-----------------------------------------------------'
'                    WINSOCK STUFF                    '
'-----------------------------------------------------'

Private Const WSA_DESCRIPTIONLEN = 256
Private Const WSA_SYS_STATUS_LEN = 128
Private Const WSA_DescriptionSize = WSA_DESCRIPTIONLEN + 1
Private Const WSA_SysStatusSize = WSA_SYS_STATUS_LEN + 1
Private Type WSADataType
    wVersion       As Integer
    wHighVersion   As Integer
    szDescription  As String * WSA_DescriptionSize
    szSystemStatus As String * WSA_SysStatusSize
    iMaxSockets    As Integer
    iMaxUdpDg      As Integer
    lpVendorInfo   As Long
End Type

'---Windows System Functions
    Private Declare Sub MemCopy Lib "kernel32" Alias "RtlMoveMemory" (Dest As Any, Src As Any, ByVal cb&)
    Private Declare Function inet_ntoa Lib "wsock32.dll" (ByVal inn As Long) As Long
'---WINDOWS EXTENSIONS
    Private Declare Function WSAStartup Lib "wsock32.dll" (ByVal wVR As Long, lpWSAD As WSADataType) As Long
    Private Declare Function WSACleanup Lib "wsock32.dll" () As Long



'--------------------------------------------------'
'                    TIME STUFF                    '
'--------------------------------------------------'

Private Type tm
    tm_sec As Long   ' seconds (0 - 59)
    tm_min As Long   ' minutes (0 - 59)
    tm_hour As Long  ' hours (0 - 23)
    tm_mday As Long  ' day of month (1 - 31)
    tm_mon As Long   ' month of year (0 - 11)
    tm_year As Long  ' year - 1900
    tm_wday As Long  ' day of week (Sunday = 0), Not used
    tm_yday As Long  ' day of year (0 - 365), Not used
    tm_isdst As Long ' Daylight Savings Time (0, 1), Not used
End Type


Public Function getascip(ByVal inn As Long) As String
    
    On Error Resume Next
    
    Dim lpStr     As Long
    Dim nStr      As Long
    Dim retString As String
    
    retString = String(32, 0)
    
    lpStr = inet_ntoa(inn)
    If lpStr = 0 Then
        getascip = "255.255.255.255"
        Exit Function
    End If
    
    nStr = lstrlen(lpStr)
    If (nStr > 32) Then nStr = 32
    
    MemCopy ByVal retString, ByVal lpStr, nStr
    retString = Left(retString, nStr)
    getascip = retString
    
    If Err Then getascip = "255.255.255.255"
    
End Function


Public Function mktm(pdatetime As tm) As Long
    
    Dim lResult As Long
    Dim nMonth As Long
    
    Dim kcl_mktm As Long
    
    ' Time validation
    If (pdatetime.tm_sec < 0 Or pdatetime.tm_sec > 59 Or _
        pdatetime.tm_min < 0 Or pdatetime.tm_min > 59 Or _
        pdatetime.tm_hour < 0 Or pdatetime.tm_hour > 23) Then
        kcl_mktm = -1
        Exit Function
    End If
    
    ' Date validation. This routine bites it in 2038
    If (pdatetime.tm_year < 70 Or pdatetime.tm_year > 138 Or _
        pdatetime.tm_mon < 1 Or pdatetime.tm_mon > 12 Or _
        pdatetime.tm_mday < 1 Or pdatetime.tm_mday > 31) Then
        kcl_mktm = -1
        Exit Function
    End If
    
    ' Sum seconds in previous whole years
    lResult = 0 ' Initialize
    lResult = lResult + secsInYears(pdatetime.tm_year)
    
    ' Sum seconds in previous whole months for the current year
    For nMonth = 1 To (pdatetime.tm_mon - nMonth) - 1
        lResult = lResult + secsInMonth(pdatetime.tm_year, nMonth)
    Next nMonth
    
    ' Sum seconds in whole days for the current month
    lResult = lResult + ((pdatetime.tm_mday - 1) * 86400)
    ' Sum seconds in whole hours for the current day
    lResult = lResult + CDec((pdatetime.tm_hour * 3600))
    ' Sum seconds in whole minutes for the current hour
    lResult = lResult + (pdatetime.tm_min * 60)
    ' Sum remaining seconds for the current minute
    lResult = lResult + (pdatetime.tm_sec)
    
    mktm = lResult

End Function


Private Function secsInMonth(Year As Long, Month As Long) As Long
    ' Return total number of seconds in the
    '     given month
    ' Private function: assumes valid parame
    '     ters
    Dim lResult As Long
    Dim lSecPerMonth
    lSecPerMonth = Array(2678400, 2419200, 2678400, 2592000, _
    2678400, 2592000, 2678400, 2678400, _
    2592000, 2678400, 2592000, 2678400)
    ' Compute result
    lResult = lSecPerMonth(Month - 1)


    If (isLeapYear(Year) And Month = 2) Then
        lResult = lResult + 86400 ' its February In a leap year
    End If
    secsInMonth = lResult
End Function


Private Function isLeapYear(Year As Long) As Integer
    ' Determine if given ANSI datetime struc
    '     t represents a leap year
    ' Private function: assumes valid parame
    '     ters
    Dim nYear As Integer
    Dim nIsLeap As Integer
    nYear = Year + 1900


    If ((nYear Mod 4 = 0 And Not (nYear Mod 100)) Or nYear Mod 400 = 0) Then
        nIsLeap = 1 ' its a leap year
    Else
        nIsLeap = 0 ' Not a leap year
    End If
    isLeapYear = nIsLeap
End Function



Private Function secsInYears(Year As Long) As Double
    ' Return sum of seconds for years since
    '     Jan 1, 1970 00:00
    ' up to but excluding the given year.
    ' Private function: assumes valid parame
    '     ters
    Dim lResult As Long
    Dim thisYear As Long
    Dim Temp As Long
    lResult = 0
    ' 0 = normal year, 1 = leap year
    Dim lSecPerYear
    lSecPerYear = Array(31536000, 31622400)


    If (Year > 97) Then
        ' shorten summation iterations for typic
        '     al cases
        lResult = 883612800 ' seconds To Jan 1,1998 00:00:00
        thisYear = 98
    Else
        ' sum all years since 1970
        thisYear = 70
    End If
    ' Sum total seconds since Jan 1, 1970 00
    '     :00


    While (thisYear < Year)
        'for ( ; thisYear < year; thisYear++
        '     )
        Temp = isLeapYear(thisYear)
        lResult = lResult + lSecPerYear(Temp)
        thisYear = thisYear + 1
    Wend
    secsInYears = lResult
End Function



Public Function UnixTimeNow(Optional lngOffset As Long = 0) As Long


    Dim myTm As tm
    
    With myTm
        .tm_year = Year(Now) - 1900
        .tm_mon = Month(Now)
        .tm_mday = Day(Now)
        .tm_hour = Hour(Now)
        .tm_min = Minute(Now)
        .tm_sec = Second(Now)
    End With
    
    UnixTimeNow = mktm(myTm) - lngOffset

End Function


