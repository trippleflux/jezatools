Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Module mdlMain
	
	
	Public hStdOut As Integer ' handle of Standard Output
	
	Declare Function GetStdHandle Lib "kernel32" (ByVal nStdHandle As Integer) As Integer
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	Declare Function WriteFile Lib "kernel32" (ByVal hFile As Integer, ByVal lpBuffer As String, ByVal nNumberOfBytesToWrite As Integer, ByRef lpNumberOfBytesWritten As Integer, ByRef lpOverlapped As Object) As Integer
	Public Const STD_OUTPUT_HANDLE As Short = -11
	
	
	Public Const SEPARATOR As String = " | "
	Public Const INIT_FAILED As String = "could not find ioFTPD window"
	Private Sub cmdOnlineUsers()
		
		
		On Error GoTo errhandler
		
		Dim mem As clsMemMap
		mem = New clsMemMap
		
		Dim SMemUser As String
		Dim SMemGroup As String
		
		
		'exit if initialization failed (ioFTPD window handle not found)
		If mem.LOCAL_ERROR = True Then
			send("ERROR: " & INIT_FAILED)
			'UPGRADE_NOTE: Object mem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			mem = Nothing
			Exit Sub
		End If
		
		'exit if there are 0 users online
		If (mem.GetFirstOnlineUser = False) Then
			send("No users online")
			'UPGRADE_NOTE: Object mem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			mem = Nothing
			Exit Sub
		End If
		
		
		'loop through all users
		send("BEGIN:who")
		Do 
			
			If Not (LastOnlineUser.iUID = -1) Then
				
				'load the userfile for more info ... TODO: should check return value
				mem.GetUserFile(LastOnlineUser.iUID)
				SMemUser = mem.UserIdToName(LastUserfile.iUID)
				SMemGroup = mem.GroupIdToName(LastUserfile.iGID)
				
				send("cid" & SEPARATOR & SMemUser & SEPARATOR & SMemGroup & SEPARATOR & LastOnlineUser.iCID & SEPARATOR & LastOnlineUser.sServiceName & SEPARATOR & LastOnlineUser.sIdent & SEPARATOR & LastOnlineUser.sClientIP & SEPARATOR & LastOnlineUser.sHostname & SEPARATOR & LastOnlineUser.sDataIP & SEPARATOR & LastOnlineUser.sLastCmd & SEPARATOR & LastOnlineUser.sFilename & SEPARATOR & LastOnlineUser.sRealPath & SEPARATOR & LastOnlineUser.sVirtualPath & SEPARATOR & LastOnlineUser.lngIdleTime & SEPARATOR & LastOnlineUser.lngLoginTime & SEPARATOR & LastOnlineUser.iTransferState & SEPARATOR & LastOnlineUser.iTransferbytes & SEPARATOR & LastOnlineUser.dblSpeed)
				
			End If ' If Not(iUID = -1) ...
			
		Loop While (mem.GetNextOnlineUser = True)
		send("END:who")
		
		
		'clear class object
		'UPGRADE_NOTE: Object mem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		mem = Nothing
		
		
		Exit Sub
		
errhandler: 
		send("ERROR: Error in cmdListAllUsers() at line " & Erl() & " : " & Err.Description & " (" & Err.Number & ")")
		'UPGRADE_NOTE: Object mem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		mem = Nothing
		
	End Sub
	
	Private Sub cmdUserIdTable()
		
		
		On Error GoTo errhandler
		
		Dim buffer As String
		Dim n As Short
		Dim mem As clsMemMap
		mem = New clsMemMap
		
		Dim SMemGroup As String
		
		'exit if initialization failed (ioFTPD window handle not found)
		If mem.LOCAL_ERROR = True Then
			send("ERROR: " & INIT_FAILED)
			'UPGRADE_NOTE: Object mem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			mem = Nothing
			Exit Sub
		End If
		
		
		mem.GetUserIdTable()
		
		send("BEGIN:usertable")
		For n = LBound(UserIdTable) To UBound(UserIdTable)
			mem.GetUserFile(UserIdTable(n).iID)
			SMemGroup = mem.GroupIdToName(LastUserfile.iGID)
			send("uid" & SEPARATOR & UserIdTable(n).iID & SEPARATOR & UserIdTable(n).sName & SEPARATOR & SMemGroup & SEPARATOR & LastUserfile.sFlags)
		Next n
		send("END:usertable")
		
		
		'clear class object
		'UPGRADE_NOTE: Object mem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		mem = Nothing
		
		
		Exit Sub
		
errhandler: 
		send("ERROR: Error in cmdUserIdTable() at line " & Erl() & " : " & Err.Description & " (" & Err.Number & ")")
		'UPGRADE_NOTE: Object mem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		mem = Nothing
		
	End Sub
	
	
	Private Sub cmdGroupIdTable()
		
		
		On Error GoTo errhandler
		
		Dim buffer As String
		Dim n As Short
		Dim mem As clsMemMap
		mem = New clsMemMap
		
		
		'exit if initialization failed (ioFTPD window handle not found)
		If mem.LOCAL_ERROR = True Then
			send("ERROR: " & INIT_FAILED)
			'UPGRADE_NOTE: Object mem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			mem = Nothing
			Exit Sub
		End If
		
		mem.GetGroupIdTable()
		
		send("BEGIN:grouptable")
		For n = LBound(GroupIdTable) To UBound(GroupIdTable)
			mem.GetGroupFile(GroupIdTable(n).iID)
			send("gid" & SEPARATOR & GroupIdTable(n).iID & SEPARATOR & GroupIdTable(n).sName & SEPARATOR & LastGroupfile.iUserCount)
		Next n
		send("END:grouptable")
		
		
		'clear class object
		'UPGRADE_NOTE: Object mem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		mem = Nothing
		
		
		Exit Sub
		
errhandler: 
		send("ERROR: Error in cmdGroupIdTable() at line " & Erl() & " : " & Err.Description & " (" & Err.Number & ")")
		'UPGRADE_NOTE: Object mem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		mem = Nothing
		
	End Sub
	
	
	
	Private Sub cmdUserfile(ByRef sUID As Short)
		
		
		On Error GoTo errhandler
		
		Dim n As Short
		Dim mem As clsMemMap
		mem = New clsMemMap
		
		Dim SMemUser As String
		Dim SMemGroup As String
		
		
		'exit if initialization failed (ioFTPD window handle not found)
		If mem.LOCAL_ERROR = True Then
			send("ERROR: " & INIT_FAILED)
			'UPGRADE_NOTE: Object mem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			mem = Nothing
			Exit Sub
		End If
		
		'exit if user does not exist
		SMemUser = mem.UserIdToName(sUID)
		If (Len(SMemUser) = 0 Or SMemUser = "(unknown)") Then
			send("ERROR: userid does not exist")
			'UPGRADE_NOTE: Object mem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			mem = Nothing
			Exit Sub
		End If
		
		
		mem.GetUserFile(sUID)
		
		SMemGroup = mem.GroupIdToName(LastUserfile.iGID)
		
		send("BEGIN:userfile:" & sUID)
		send("username" & SEPARATOR & SMemUser)
		send("groupname" & SEPARATOR & SMemGroup)
		send("flags" & SEPARATOR & LastUserfile.sFlags)
		send("home" & SEPARATOR & LastUserfile.sHomepath)
		send("vfs" & SEPARATOR & LastUserfile.sVFSFile)
		send("tagline" & SEPARATOR & LastUserfile.sTagline)
		send("pwdhash" & SEPARATOR & LastUserfile.sPasswordHash)
		send("limits" & SEPARATOR & JoinEx(LastUserfile.iLimits,  ,  , SEPARATOR))
		send("groups" & SEPARATOR & JoinEx(LastUserfile.iGroups,  ,  , SEPARATOR, "-1"))
		send("admingroups" & SEPARATOR & JoinEx(LastUserfile.iAdminGroups,  ,  , SEPARATOR, "-1"))
		send("credits" & SEPARATOR & JoinEx(LastUserfile.iCredits,  ,  , SEPARATOR))
		send("ratios" & SEPARATOR & JoinEx(LastUserfile.iRatio,  ,  , SEPARATOR))
		send("ips" & SEPARATOR & JoinEx(LastUserfile.ips,  ,  , SEPARATOR, ""))
		send("END:userfile:" & sUID)
		
		'clear class object
		'UPGRADE_NOTE: Object mem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		mem = Nothing
		
		
		Exit Sub
		
errhandler: 
		send("ERROR: Error in cmdUserfile() at line " & Erl() & " : " & Err.Description & " (" & Err.Number & ")")
		'UPGRADE_NOTE: Object mem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		mem = Nothing
		
	End Sub
	
	
	
	
	Private Sub cmdSetFlags(ByRef sUID As Short, ByRef sFlags As String)
		
		
		On Error GoTo errhandler
		
		Dim n As Short
		Dim mem As clsMemMap
		mem = New clsMemMap
		
		Dim SMemUser As String
		Dim SMemGroup As String
		
		
		'exit if initialization failed (ioFTPD window handle not found)
		If mem.LOCAL_ERROR = True Then
			send("ERROR: " & INIT_FAILED)
			'UPGRADE_NOTE: Object mem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			mem = Nothing
			Exit Sub
		End If
		
		'exit if user does not exist
		SMemUser = mem.UserIdToName(sUID)
		If (Len(SMemUser) = 0 Or SMemUser = "(unknown)") Then
			send("ERROR: userid does not exist")
			'UPGRADE_NOTE: Object mem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			mem = Nothing
			Exit Sub
		End If
		
		
		mem.SetUserFlags(sUID, sFlags)
		
		
		'clear class object
		'UPGRADE_NOTE: Object mem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		mem = Nothing
		
		
		Exit Sub
		
errhandler: 
		send("ERROR: Error in cmdSetFlags() at line " & Erl() & " : " & Err.Description & " (" & Err.Number & ")")
		'UPGRADE_NOTE: Object mem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		mem = Nothing
		
	End Sub
	
	
	
	
	
	Private Sub cmdCopyUser(ByRef sUID_src As Short, ByRef sUID_dest As Short)
		
		
		On Error GoTo errhandler
		
		Dim n As Short
		Dim mem As clsMemMap
		mem = New clsMemMap
		
		Dim SMemUser As String
		Dim SMemGroup As String
		
		
		'exit if initialization failed (ioFTPD window handle not found)
		If mem.LOCAL_ERROR = True Then
			send("ERROR: " & INIT_FAILED)
			'UPGRADE_NOTE: Object mem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			mem = Nothing
			Exit Sub
		End If
		
		'exit if source user does not exist
		SMemUser = mem.UserIdToName(sUID_src)
		If (Len(SMemUser) = 0 Or SMemUser = "(unknown)") Then
			send("ERROR: source userid does not exist")
			'UPGRADE_NOTE: Object mem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			mem = Nothing
			Exit Sub
		End If
		
		'exit if destination user does not exist
		SMemUser = mem.UserIdToName(sUID_dest)
		If (Len(SMemUser) = 0 Or SMemUser = "(unknown)") Then
			send("ERROR: destination userid does not exist")
			'UPGRADE_NOTE: Object mem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			mem = Nothing
			Exit Sub
		End If
		
		
		mem.CopyUser(sUID_src, sUID_dest)
		
		
		'clear class object
		'UPGRADE_NOTE: Object mem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		mem = Nothing
		
		
		Exit Sub
		
errhandler: 
		send("ERROR: Error in cmdCopyUser() at line " & Erl() & " : " & Err.Description & " (" & Err.Number & ")")
		'UPGRADE_NOTE: Object mem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		mem = Nothing
		
	End Sub
	
	
	
	
	
	
	Private Sub cmdGroupfile(ByRef iGID As Short)
		
		
		On Error GoTo errhandler
		
		Dim i As Short
		Dim n As Short
		Dim mem As clsMemMap
		mem = New clsMemMap
		
		Dim iMembersCount As Short
		Dim sMembersBuff As String
		Dim iGAdminsCount As Short
		Dim sGAdminsBuff As String
		
		Dim SMemGroup As String
		
		
		'exit if initialization failed (ioFTPD window handle not found)
		If mem.LOCAL_ERROR = True Then
			send("ERROR: " & INIT_FAILED)
			'UPGRADE_NOTE: Object mem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			mem = Nothing
			Exit Sub
		End If
		
		'exit if group does not exist
		SMemGroup = mem.GroupIdToName(iGID)
		If (Len(SMemGroup) = 0 Or SMemGroup = "(unknown)") Then
			send("ERROR: groupid does not exist")
			'UPGRADE_NOTE: Object mem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			mem = Nothing
			Exit Sub
		End If
		
		'read the groupfile
		mem.GetGroupFile(iGID)
		
		'search all users that are a member of this group
		mem.GetUserIdTable()
		For n = LBound(UserIdTable) To UBound(UserIdTable)
			If mem.GetUserFile(UserIdTable(n).iID) Then
				
				'is user member of this group ?
				For i = LBound(LastUserfile.iGroups) To UBound(LastUserfile.iGroups)
					If LastUserfile.iGroups(i) = iGID Then
						sMembersBuff = sMembersBuff & SEPARATOR & UserIdTable(n).iID
						iMembersCount = iMembersCount + 1
						Exit For
					ElseIf LastUserfile.iGroups(i) = -1 Then 
						Exit For
					End If
				Next i
				
				'is user a gadmin of this group ?
				For i = LBound(LastUserfile.iAdminGroups) To UBound(LastUserfile.iAdminGroups)
					If LastUserfile.iAdminGroups(i) = iGID Then
						sGAdminsBuff = sGAdminsBuff & SEPARATOR & UserIdTable(n).iID
						iGAdminsCount = iGAdminsCount + 1
						Exit For
					ElseIf LastUserfile.iAdminGroups(i) = -1 Then 
						Exit For
					End If
				Next i
				
			End If
		Next n
		If iMembersCount = 0 Then sMembersBuff = SEPARATOR
		If iGAdminsCount = 0 Then sGAdminsBuff = SEPARATOR
		
		'send all collected info
		send("BEGIN:groupfile:" & iGID)
		send("groupname" & SEPARATOR & SMemGroup)
		send("description" & SEPARATOR & LastGroupfile.sDescription)
		send("vfsfile" & SEPARATOR & LastGroupfile.sVFSFile)
		send("groupslots" & SEPARATOR & LastGroupfile.iSlots(0))
		send("leechslots" & SEPARATOR & LastGroupfile.iSlots(1))
		send("membercount" & SEPARATOR & iMembersCount)
		send("members" & sMembersBuff)
		send("gadmincount" & SEPARATOR & iGAdminsCount)
		send("gadmins" & sGAdminsBuff)
		send("END:groupfile:" & iGID)
		
		'clear class object
		'UPGRADE_NOTE: Object mem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		mem = Nothing
		
		
		Exit Sub
		
errhandler: 
		send("ERROR: Error in cmdGroupfile() at line " & Erl() & " : " & Err.Description & " (" & Err.Number & ")")
		'UPGRADE_NOTE: Object mem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		mem = Nothing
		
	End Sub
	
	
	
	
	
	Public Function DoesUserExist(ByRef sUsername As String) As Boolean
		
		Dim mem As clsMemMap
		mem = New clsMemMap
		
		
		'check init
		If mem.LOCAL_ERROR = True Then
			send("ERROR: " & INIT_FAILED)
			'UPGRADE_NOTE: Object mem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			mem = Nothing
			Exit Function
		End If
		
		'get the user
		If mem.UserNameToID(sUsername) = -1 Then
			DoesUserExist = False
		Else
			DoesUserExist = True
		End If
		
		'clear class object
		'UPGRADE_NOTE: Object mem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		mem = Nothing
		
	End Function
	
	Public Sub Main()
		
		hStdOut = GetStdHandle(STD_OUTPUT_HANDLE)
		
		
		Dim a() As String
		a = Split(VB.Command(), " ", 2)
		
		If UBound(a) = -1 Then
			ProcessCommand("", "")
		ElseIf UBound(a) = 0 Then 
			ProcessCommand(LCase(a(0)), "")
		Else
			ProcessCommand(LCase(a(0)), a(1))
		End If
		
		
	End Sub
	
	
	Public Sub ProcessCommand(ByRef cmd As String, ByRef args As String)
		
		'capture all errors that may occur anywhere
		On Error GoTo errhandler
		
		
		Dim a() As String
		Dim n As Short
		Dim argcnt As Short
		
		
		'split args in a() array
		If Len(args) > 0 Then
			a = Split(args, " ")
			argcnt = UBound(a) + 1
		Else
			argcnt = 0
		End If
		
		
		Select Case LCase(cmd)
			
			Case "who" '====================================================
				cmdOnlineUsers()
				
			Case "usertable" '==============================================
				cmdUserIdTable()
				
			Case "grouptable" '=============================================
				cmdGroupIdTable()
				
			Case "userfile" '===============================================
				If argcnt = 1 Then
					cmdUserfile(Val(a(0)))
				End If
				
			Case "groupfile" '==============================================
				If argcnt = 1 Then
					cmdGroupfile(Val(a(0)))
				End If
				
			Case "setflags" '===============================================
				If argcnt = 2 Then
					cmdSetFlags(Val(a(0)), a(1))
				End If
				
			Case "copyuser" '===============================================
				If argcnt = 2 Then
					cmdCopyUser(Val(a(0)), Val(a(1)))
				End If
				
			Case Else '=====================================================
				send("ERROR: unknown command: " & Quote(cmd))
				
		End Select '====================================================
		
		
		Exit Sub
		
errhandler: 
		send("ERROR: Error in ProcessCommand() at line " & Erl() & " : " & Err.Description & " (" & Err.Number & ")")
	End Sub
	
	Sub send(ByRef s As String)
		
		Dim rc As Integer
		Dim lBytesWritten As Integer
		Dim a() As String
		Dim aTmp As String
		Dim n As Short
		
		'hide debug output at runtime
		If Left(s, 6) Like "DEBUG:" And InDebug = False Then Exit Sub
		
		'print output to debug windows when in dev.ide mode
		Debug.Print(s)
		
		s = s & vbCrLf
		rc = WriteFile(hStdOut, s, Len(s), lBytesWritten, 0)
		
	End Sub
End Module