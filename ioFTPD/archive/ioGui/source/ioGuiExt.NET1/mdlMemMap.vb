Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Module mdlMemMap
	
	
	'-----------------------------------------------------'
	'                   clsMemMap STUFF                   '
	'-----------------------------------------------------'
	
	'u might want to read this value from your program's configuration file (like my sitewho.exe)
	'it is used in clsMemMap::OnlineDataToLastOnlineUser
	Public Const TIME_OFFSET As Integer = 3600
	
	Public Enum myTransferState
		stateIdle = 0
		stateDownload = 1
		stateUpload = 2
		stateLIST = 3
	End Enum
	
	Public Structure myOnlineUser
		Dim iCID As Short
		Dim iUID As Short
		Dim sIdent As String
		Dim sClientIP As String
		Dim sDataIP As String
		Dim sServiceName As String
		Dim sLastCmd As String
		Dim lngLoginTime As Integer
		Dim lngIdleTime As Integer
		Dim iTransferState As myTransferState
		Dim dblSpeed As Double 'in kBps
		Dim iTransferbytes As Decimal 'transferred bytes of current file
		Dim sVirtualPath As String
		Dim sRealPath As String
		Dim sFilename As String
		Dim sHostname As String
	End Structure
	
	Public Structure myIoStats
		Dim files As Integer
		Dim bytes As Decimal
		Dim times As Integer
	End Structure
	
	Public Structure myUserfile
		'MAX_GROUPS   = 128
		'MAX_IPS      =  25
		'MAX_SECTIONS =  10
		Dim iUID As Short
		Dim iGID As Short
		Dim sTagline As String
		Dim sFlags As String
		Dim sVFSFile As String
		Dim sPasswordHash As String
		Dim sHomepath As String
		<VBFixedArray(24)> Dim ips() As String
		<VBFixedArray(4)> Dim iLimits() As Integer
		<VBFixedArray(127)> Dim iGroups() As Short ' -1 by default (no group)
		<VBFixedArray(127)> Dim iAdminGroups() As Short ' same.
		<VBFixedArray(9)> Dim iRatio() As Short
		<VBFixedArray(9)> Dim iCredits() As Decimal
		<VBFixedArray(9)> Dim allup() As myIoStats 'remark: it seems only 0-8 contains valid data.
		<VBFixedArray(9)> Dim alldn() As myIoStats '        index 9 times contain all zeros.
		<VBFixedArray(9)> Dim monthup() As myIoStats '        meaning there are only 9 sections instead of 10?
		<VBFixedArray(9)> Dim monthdn() As myIoStats
		<VBFixedArray(9)> Dim wkup() As myIoStats
		<VBFixedArray(9)> Dim wkdn() As myIoStats
		<VBFixedArray(9)> Dim dayup() As myIoStats
		<VBFixedArray(9)> Dim daydn() As myIoStats
		
		'UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
		Public Sub Initialize()
			ReDim ips(24)
			ReDim iLimits(4)
			ReDim iGroups(127)
			ReDim iAdminGroups(127)
			ReDim iRatio(9)
			ReDim iCredits(9)
			ReDim allup(9)
			ReDim alldn(9)
			ReDim monthup(9)
			ReDim monthdn(9)
			ReDim wkup(9)
			ReDim wkdn(9)
			ReDim dayup(9)
			ReDim daydn(9)
		End Sub
	End Structure
	
	Public Structure myGroupfile
		Dim iGID As Short
		<VBFixedArray(1)> Dim iSlots() As Short ' 0 = groupslots / 1 = leechslots
		Dim iUserCount As Short ' not sure if this is always correct
		Dim sDescription As String
		Dim sVFSFile As String
		
		'UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
		Public Sub Initialize()
			ReDim iSlots(1)
		End Sub
	End Structure
	
	Public Structure myIdTable
		Dim iID As Short
		Dim sName As String
	End Structure
	
	Public LastOnlineUser As myOnlineUser
	'UPGRADE_WARNING: Arrays in structure LastUserfile may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
	Public LastUserfile As myUserfile
	'UPGRADE_WARNING: Arrays in structure LastGroupfile may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
	Public LastGroupfile As myGroupfile
	Public UserIdTable() As myIdTable
	Public GroupIdTable() As myIdTable
	
	
	
	
	'-----------------------------------------------------'
	'                    WINSOCK STUFF                    '
	'-----------------------------------------------------'
	
	Private Const WSA_DESCRIPTIONLEN As Short = 256
	Private Const WSA_SYS_STATUS_LEN As Short = 128
	Private Const WSA_DescriptionSize As Integer = WSA_DESCRIPTIONLEN + 1
	Private Const WSA_SysStatusSize As Integer = WSA_SYS_STATUS_LEN + 1
	Private Structure WSADataType
		Dim wVersion As Short
		Dim wHighVersion As Short
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(WSA_DescriptionSize),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=WSA_DescriptionSize)> Public szDescription() As Char
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(WSA_SysStatusSize),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=WSA_SysStatusSize)> Public szSystemStatus() As Char
		Dim iMaxSockets As Short
		Dim iMaxUdpDg As Short
		Dim lpVendorInfo As Integer
	End Structure
	
	'---Windows System Functions
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	Private Declare Sub MemCopy Lib "kernel32" Alias "RtlMoveMemory" (ByRef Dest As Object, ByRef Src As Object, ByVal cb As Integer)
	Private Declare Function inet_ntoa Lib "wsock32.dll" (ByVal inn As Integer) As Integer
	'---WINDOWS EXTENSIONS
	'UPGRADE_WARNING: Structure WSADataType may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Private Declare Function WSAStartup Lib "wsock32.dll" (ByVal wVR As Integer, ByRef lpWSAD As WSADataType) As Integer
	Private Declare Function WSACleanup Lib "wsock32.dll" () As Integer
	
	
	
	'--------------------------------------------------'
	'                    TIME STUFF                    '
	'--------------------------------------------------'
	
	Private Structure tm
		Dim tm_sec As Integer ' seconds (0 - 59)
		Dim tm_min As Integer ' minutes (0 - 59)
		Dim tm_hour As Integer ' hours (0 - 23)
		Dim tm_mday As Integer ' day of month (1 - 31)
		Dim tm_mon As Integer ' month of year (0 - 11)
		Dim tm_year As Integer ' year - 1900
		Dim tm_wday As Integer ' day of week (Sunday = 0), Not used
		Dim tm_yday As Integer ' day of year (0 - 365), Not used
		Dim tm_isdst As Integer ' Daylight Savings Time (0, 1), Not used
	End Structure
	
	
	Public Function getascip(ByVal inn As Integer) As String
		Dim lstrlen As Object
		
		On Error Resume Next
		
		Dim lpStr As Integer
		Dim nStr As Integer
		Dim retString As String
		
		retString = New String(Chr(0), 32)
		
		lpStr = inet_ntoa(inn)
		If lpStr = 0 Then
			getascip = "255.255.255.255"
			Exit Function
		End If
		
		'UPGRADE_WARNING: Couldn't resolve default property of object lstrlen(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		nStr = lstrlen(lpStr)
		If (nStr > 32) Then nStr = 32
		
		MemCopy(retString, lpStr, nStr)
		retString = Left(retString, nStr)
		getascip = retString
		
		If Err.Number Then getascip = "255.255.255.255"
		
	End Function


	Public Function mktm() As Integer
		Dim pdatetime As tm = New tm
		Return mktm(pdatetime)
	End Function

	Public Function mktm(ByRef pdatetime As Object) As Integer

		Dim lResult As Integer
		Dim nMonth As Integer

		Dim kcl_mktm As Integer

		' Time validation
		If (pdatetime.tm_sec < 0 Or pdatetime.tm_sec > 59 Or pdatetime.tm_min < 0 Or pdatetime.tm_min > 59 Or pdatetime.tm_hour < 0 Or pdatetime.tm_hour > 23) Then
			kcl_mktm = -1
			Exit Function
		End If

		' Date validation. This routine bites it in 2038
		If (pdatetime.tm_year < 70 Or pdatetime.tm_year > 138 Or pdatetime.tm_mon < 1 Or pdatetime.tm_mon > 12 Or pdatetime.tm_mday < 1 Or pdatetime.tm_mday > 31) Then
			kcl_mktm = -1
			Exit Function
		End If

		' Sum seconds in previous whole years
		lResult = 0	' Initialize
		lResult = lResult + secsInYears(pdatetime.tm_year)

		' Sum seconds in previous whole months for the current year
		For nMonth = 1 To (pdatetime.tm_mon - nMonth) - 1
			lResult = lResult + secsInMonth(pdatetime.tm_year, nMonth)
		Next nMonth

		' Sum seconds in whole days for the current month
		lResult = lResult + ((pdatetime.tm_mday - 1) * 86400)
		' Sum seconds in whole hours for the current day
		lResult = lResult + CDec(pdatetime.tm_hour * 3600)
		' Sum seconds in whole minutes for the current hour
		lResult = lResult + (pdatetime.tm_min * 60)
		' Sum remaining seconds for the current minute
		lResult = lResult + (pdatetime.tm_sec)

		mktm = lResult

	End Function
	
	
	'UPGRADE_NOTE: Month was upgraded to Month_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	'UPGRADE_NOTE: Year was upgraded to Year_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Function secsInMonth(ByRef Year_Renamed As Integer, ByRef Month_Renamed As Integer) As Integer
		' Return total number of seconds in the
		'     given month
		' Private function: assumes valid parame
		'     ters
		Dim lResult As Integer
		Dim lSecPerMonth As Object
		'UPGRADE_WARNING: Array has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		'UPGRADE_WARNING: Couldn't resolve default property of object lSecPerMonth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		lSecPerMonth = New Object(){2678400, 2419200, 2678400, 2592000, 2678400, 2592000, 2678400, 2678400, 2592000, 2678400, 2592000, 2678400}
		' Compute result
		'UPGRADE_WARNING: Couldn't resolve default property of object lSecPerMonth(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		lResult = lSecPerMonth(Month_Renamed - 1)
		
		
		If (isLeapYear(Year_Renamed) And Month_Renamed = 2) Then
			lResult = lResult + 86400 ' its February In a leap year
		End If
		secsInMonth = lResult
	End Function
	
	
	'UPGRADE_NOTE: Year was upgraded to Year_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Function isLeapYear(ByRef Year_Renamed As Integer) As Short
		' Determine if given ANSI datetime struc
		'     t represents a leap year
		' Private function: assumes valid parame
		'     ters
		Dim nYear As Short
		Dim nIsLeap As Short
		nYear = Year_Renamed + 1900
		
		
		If ((nYear Mod 4 = 0 And Not (nYear Mod 100)) Or nYear Mod 400 = 0) Then
			nIsLeap = 1 ' its a leap year
		Else
			nIsLeap = 0 ' Not a leap year
		End If
		isLeapYear = nIsLeap
	End Function
	
	
	
	'UPGRADE_NOTE: Year was upgraded to Year_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Function secsInYears(ByRef Year_Renamed As Integer) As Double
		' Return sum of seconds for years since
		'     Jan 1, 1970 00:00
		' up to but excluding the given year.
		' Private function: assumes valid parame
		'     ters
		Dim lResult As Integer
		Dim thisYear As Integer
		Dim Temp As Integer
		lResult = 0
		' 0 = normal year, 1 = leap year
		Dim lSecPerYear As Object
		'UPGRADE_WARNING: Array has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		'UPGRADE_WARNING: Couldn't resolve default property of object lSecPerYear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		lSecPerYear = New Object(){31536000, 31622400}
		
		
		If (Year_Renamed > 97) Then
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
		
		
		While (thisYear < Year_Renamed)
			'for ( ; thisYear < year; thisYear++
			'     )
			Temp = isLeapYear(thisYear)
			'UPGRADE_WARNING: Couldn't resolve default property of object lSecPerYear(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lResult = lResult + lSecPerYear(Temp)
			thisYear = thisYear + 1
		End While
		secsInYears = lResult
	End Function
	
	
	
	Public Function UnixTimeNow(Optional ByRef lngOffset As Integer = 0) As Integer
		
		
		Dim myTm As tm
		
		With myTm
			.tm_year = Year(Now) - 1900
			.tm_mon = Month(Now)
			.tm_mday = VB.Day(Now)
			.tm_hour = Hour(Now)
			.tm_min = Minute(Now)
			.tm_sec = Second(Now)
		End With
		
		UnixTimeNow = mktm(myTm) - lngOffset
		
	End Function
End Module