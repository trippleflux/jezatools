Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Module mdlCommon
	
	' Module with 'general' functions that can be used in any of my projects.
	' (nothing project-specific should be inhere)
	
	Public Enum enumAlignment
		eAlignLeft = 0
		eAlignright = 1
		eAlignCenter = 2
	End Enum
	
	
	
	
	Public Function StripNulls(ByRef OriginalStr As String) As String
		
		'removes trailing 0x00 bytes from a string
		
		If (InStr(OriginalStr, Chr(0)) > 0) Then
			StripNulls = Left(OriginalStr, InStr(OriginalStr, Chr(0)) - 1)
		End If
		
	End Function
	Public Sub AddToArray(ByRef a() As String, ByRef AddThis As String)
		
		ReDim Preserve a(UBound(a) + 1)
		a(UBound(a)) = AddThis
		
	End Sub
	
	
	Public Sub AppendToFile(ByRef sFile As String, ByRef sLine As String)
		
		On Error GoTo errhandler
		
		Dim f As Short
		
		
		f = FreeFile()
		FileOpen(f, sFile, OpenMode.Append)
		PrintLine(f, sLine)
		FileClose(f)
		
		Exit Sub
		
errhandler: 
		send("ERROR in AppendToFile() : " & Err.Description & " (" & Err.Number & ")")
		Resume Next
	End Sub
	
	
	Public Function ListFilesInDir(ByRef sPath As String, Optional ByRef arrExclude As Object = Nothing) As Object
		
		Dim a() As String
		Dim sFile As String
		Dim n As Short
		Dim bContinue As Boolean
		
		
		ReDim a(0)
		
		'send "DEBUG: isarray(arrExclude) = " & IsArray(arrExclude)
		'send "DEBUG: ubound(arrExclude) = " & UBound(arrExclude)
		
		'find files
		'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
		'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		sFile = Dir(sPath, vbNormal Or FileAttribute.Hidden Or FileAttribute.Archive Or FileAttribute.ReadOnly Or FileAttribute.System)
		Do While Len(sFile) > 0
			
			'assume the file doesn't match any of the exclusions
			bContinue = True
			
			'check exclude list
			If IsArray(arrExclude) Then
				For n = LBound(arrExclude) To UBound(arrExclude)
					'UPGRADE_WARNING: Couldn't resolve default property of object arrExclude(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If LCase(sFile) Like LCase(arrExclude(n)) Then
						bContinue = False
						Exit For
					End If
				Next n
			End If
			
			'add file to array if it's OK
			If bContinue = True Then
				If Not (sFile = "." Or sFile = "..") Then
					If (IsFile(MakeFilename(sFile, sPath))) Then
						a(UBound(a)) = sFile
						ReDim Preserve a(UBound(a) + 1)
					End If
				End If
			End If
			
			'fetch next file
			'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			sFile = Dir()
		Loop 
		
		'remove last empty array-item
		If UBound(a) > 0 Then ReDim Preserve a(UBound(a) - 1)
		
		'return the array of files
		'UPGRADE_WARNING: Couldn't resolve default property of object ListFilesInDir. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ListFilesInDir = VB6.CopyArray(a)
		
	End Function
	
	Public Function ParseTemplateFile(ByRef sFilename As String, ByRef arrData As Object) As String
		
		Dim buffer As String
		Dim f As Short
		
		'exit if template file doesn't exist
		If Not IsFile(sFilename) Then
			send("ERROR: ParseTemplateFile() -> template file is missing: " & Quote(sFilename))
			Exit Function
		End If
		
		'read file
		f = FreeFile()
		FileOpen(f, sFilename, OpenMode.Binary, OpenAccess.Read)
		buffer = Space(FileLen(sFilename))
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(f, buffer)
		FileClose(f)
		
		ParseTemplateFile = ParseString(buffer, arrData)
		
	End Function
	
	
	
	Public Function ReadFileToArray(ByRef sFilename As String) As Object
		
		Dim a() As String
		Dim f As Short
		Dim buf As String
		
		'avoid array errors
		ReDim a(0)
		'UPGRADE_WARNING: Couldn't resolve default property of object ReadFileToArray. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ReadFileToArray = VB6.CopyArray(a)
		
		If Not IsFile(sFilename) Then Exit Function
		
		f = FreeFile()
		FileOpen(f, sFilename, OpenMode.Input, OpenAccess.Read)
		Do While Not EOF(f)
			buf = LineInput(f)
			a(UBound(a)) = buf : buf = ""
			ReDim Preserve a(UBound(a) + 1)
		Loop 
		FileClose(f)
		
		'remove last empty array-item
		If UBound(a) > 0 Then ReDim Preserve a(UBound(a) - 1)
		
		
		'return array
		'UPGRADE_WARNING: Couldn't resolve default property of object ReadFileToArray. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ReadFileToArray = VB6.CopyArray(a)
		
		
	End Function
	
	Public Sub StripLastCRLF(ByRef sBuffer As String)
		
		If Right(sBuffer, 2) = vbCrLf Then sBuffer = Left(sBuffer, Len(sBuffer) - 2)
		
	End Sub
	
	Public Function StripPath(ByRef sPathAndFile As String) As String
		
		Dim a() As String
		
		If Len(sPathAndFile) = 0 Then Exit Function
		
		a = Split(sPathAndFile, "\")
		StripPath = a(UBound(a))
		
	End Function
	
	Public Function PathFromFilename(ByRef sPathAndFile As String) As String
		
		Dim a() As String
		
		If Len(sPathAndFile) = 0 Then Exit Function
		
		a = Split(sPathAndFile, "\")
		a(UBound(a)) = ""
		PathFromFilename = Join(a, "\")
		
	End Function
	
	
	Public Sub SetFileAttrHidden(ByRef strFilename As String)
		
		On Error Resume Next
		
		SetAttr(strFilename, FileAttribute.Hidden)
		
	End Sub
	
	Public Function FileLenEx(ByRef sFilename As String) As Integer
		
		' funtion to replace FileLen()
		' instead of generating an error for non-existing files, return -1
		
		On Error Resume Next
		
		FileLenEx = FileLen(sFilename)
		If Err.Number <> 0 Then FileLenEx = -1
		
	End Function
	
	
	Public Sub RemoveEmptyItemsFromArray(ByRef a() As String)
		
		' - removes all 0-byte items from a string array
		' - keeps the rest of the array in the same order
		' - will allways keep at least 1 item in the array, possibly 0-byte
		
		Dim n As Short
		Dim i As Short
		
		Dim c As Short
		
		'shift all empty items to bottom of array
		For n = LBound(a) To UBound(a) - 1
			If Len(a(n)) = 0 Then
				For i = n + 1 To UBound(a)
					If Len(a(i)) > 0 Then
						a(n) = a(i)
						a(i) = ""
						n = n - 1
						Exit For
					End If
				Next i
			End If
		Next n
		
		'count empty items
		For n = LBound(a) To UBound(a)
			If Len(a(n)) = 0 Then c = c + 1
		Next n
		
		'remove empty items, but leave array with 1 empty item if there are no items
		If UBound(a) >= c Then
			ReDim Preserve a(UBound(a) - c)
		Else
			ReDim Preserve a(0)
		End If
		
	End Sub
	
	
	
	
	
	Public Function Quote(ByRef data As String) As String
		
		Quote = """" & data & """"
		
	End Function
	
	
	
	Public Function UnQuote(ByRef data As String) As String
		
		
		'will remove leading and/or trailing quotes, if any
		
		UnQuote = data
		
		If Left(data, 1) = """" Then UnQuote = Right(UnQuote, Len(UnQuote) - 1)
		If Right(data, 1) = """" Then UnQuote = Left(UnQuote, Len(UnQuote) - 1)
		
		
	End Function
	
	
	
	
	Public Function ParseString(ByRef strData As String, ByRef arrData As Object) As String
		
		Dim buff As String
		Dim tempbuff As String
		Dim a() As String
		Dim c As String
		Dim posA As Short
		Dim posB As Short
		Dim FoundIt As Boolean
		Dim f As Short
		Dim n As Short
		
		
		buff = strData
		
		posA = InStr(1, buff, "%(")
		Do While (posA > 0)
			'seek for end of variable
			posB = InStr(posA, buff, ")")
			If posB > posA Then
				c = Mid(buff, posA + 2, posB - posA - 2)
				If Len(c) > 0 Then
					a = Split(c, ",")
					
					'check if the value the user wants is in our array
					FoundIt = False
					For n = LBound(arrData) To UBound(arrData)
						'UPGRADE_WARNING: Couldn't resolve default property of object arrData(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If LCase(arrData(n, 0)) = LCase(a(0)) Then
							'UPGRADE_WARNING: Couldn't resolve default property of object arrData(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							a(0) = arrData(n, 1)
							FoundIt = True
							Exit For
						End If
					Next n
					If FoundIt = False Then
						'If LCase(a(0)) = "sitename" Then
						'    a(0) = SiTENAME
						'ElseIf LCase(a(0)) = "maxusers" Then
						'    a(0) = MAXiOUSERS
						'Else
						a(0) = ""
						'End If
					End If
					
					'format the string as requested
					Select Case UBound(a)
						Case 0 : c = Fm(a(0), 0, enumAlignment.eAlignLeft)
						Case 1 : c = Fm(a(0), System.Math.Abs(Int(Val(a(1)))), enumAlignment.eAlignLeft)
						Case 2 : c = Fm(a(0), System.Math.Abs(Int(Val(a(1)))), IIf(a(2) = "C", enumAlignment.eAlignCenter, IIf(a(2) = "R", enumAlignment.eAlignright, enumAlignment.eAlignLeft)))
						Case 3 : c = Fm(a(0), System.Math.Abs(Int(Val(a(1)))), IIf(a(2) = "C", enumAlignment.eAlignCenter, IIf(a(2) = "R", enumAlignment.eAlignright, enumAlignment.eAlignLeft)), IIf(Len(a(3)) = 1, a(3), " "))
						Case 4 : c = Fm(a(0), System.Math.Abs(Int(Val(a(1)))), IIf(a(2) = "C", enumAlignment.eAlignCenter, IIf(a(2) = "R", enumAlignment.eAlignright, enumAlignment.eAlignLeft)), IIf(Len(a(3)) = 1, a(3), " "), IIf(a(4) = "1", True, False))
					End Select
					
					'store the entire message file with the replaced text in new buffer
					'(fast way, by filling a fixed-size buffer)
					tempbuff = Space(Len(buff) - (posB - posA + 1) + Len(c))
					If Len(tempbuff) > 0 Then
						Mid(tempbuff, 1, posA - 1) = Left(buff, posA - 1)
						Mid(tempbuff, posA, Len(c)) = c
						If (posA + Len(c)) <= Len(tempbuff) Then
							Mid(tempbuff, posA + Len(c), Len(tempbuff)) = Right(buff, Len(buff) - posB)
						End If
					End If
					
					'put the temp buffer back in the real one
					buff = tempbuff
					
				End If ' If Len(c) > 0 Then...
			End If ' If posB > posA then...
			
			'place cursor at next variable
			posA = InStr(posA + 1, buff, "%(")
		Loop 
		
		ParseString = buff
		
	End Function
	
	Public Function Fm(ByRef strData As Object, ByRef intTotalSize As Object, Optional ByRef intAlign As enumAlignment = enumAlignment.eAlignLeft, Optional ByRef strFillChar As String = " ", Optional ByRef blCapIfTooLong As Boolean = False) As String
		
		If strFillChar = "$" Then
			'UPGRADE_WARNING: Couldn't resolve default property of object strData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			strData = CStr(System.Math.Round(Val(strData) / 1024, 0))
			strFillChar = " "
		End If
		
		If blCapIfTooLong = True Then
			'UPGRADE_WARNING: Couldn't resolve default property of object intTotalSize. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object strData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If Len(strData) > intTotalSize Then strData = Left(strData, intTotalSize)
		End If
		
		'UPGRADE_WARNING: Couldn't resolve default property of object intTotalSize. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If (intTotalSize > 0) And (intTotalSize > Len(strData)) Then
			'UPGRADE_WARNING: Couldn't resolve default property of object intTotalSize. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Fm = New String(strFillChar, intTotalSize)
			If Len(strData) > 0 Then
				Select Case intAlign
					Case enumAlignment.eAlignLeft
						'UPGRADE_WARNING: Couldn't resolve default property of object strData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Mid(Fm, 1, Len(strData)) = strData
					Case enumAlignment.eAlignright
						'UPGRADE_WARNING: Couldn't resolve default property of object strData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Mid(Fm, Len(Fm) - Len(strData) + 1, Len(strData)) = strData
					Case enumAlignment.eAlignCenter
						'UPGRADE_WARNING: Couldn't resolve default property of object strData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Mid(Fm, Int((Len(Fm) - Len(strData)) / 2) + 1, Len(strData)) = strData
				End Select
			End If
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object strData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Fm = strData
		End If
		
	End Function
	
	
	
	Public Function InDebug() As Boolean
		
		On Error GoTo errhandler
		InDebug = False
		Debug.Print(1 / 0)
		
		Exit Function
		
errhandler: 
		InDebug = True
	End Function
	
	
	Public Function JoinEx(ByRef a As Object, Optional ByRef iBegin As Short = 0, Optional ByVal iEnd As Short = -1, Optional ByRef strSeparator As String = " ", Optional ByRef StopAtThisItem As String = "*") As String
		
		Dim n As Short
		
		If (iEnd > UBound(a)) Or (iEnd < 0) Then iEnd = UBound(a)
		
		For n = iBegin To iEnd
			'UPGRADE_WARNING: Couldn't resolve default property of object a(n). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If (a(n) = StopAtThisItem) And Not (StopAtThisItem = "*") Then Exit For
			'UPGRADE_WARNING: Couldn't resolve default property of object a(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			JoinEx = JoinEx & a(n) & strSeparator
		Next n
		
		'remove last separator
		If Len(JoinEx) >= Len(strSeparator) Then JoinEx = Left(JoinEx, Len(JoinEx) - Len(strSeparator))
		
	End Function
	
	
	Public Function RepeatStr(ByRef intCount As Short, ByRef strWhat As String) As String
		
		Dim n As Short
		
		If intCount > 0 And Len(strWhat) > 0 Then
			RepeatStr = Space(Len(strWhat) * intCount)
			For n = 0 To intCount - 1
				Mid(RepeatStr, (n * Len(strWhat)) + 1, Len(strWhat)) = strWhat
			Next n
		End If
		
	End Function
	
	
	Public Function TimeDate() As String
		
		TimeDate = VB6.Format(VB.Day(Now), "00") & "/" & VB6.Format(Month(Now), "00") & "/" & Year(Now) & " " & VB6.Format(Hour(Now), "00") & ":" & VB6.Format(Minute(Now), "00") & ":" & VB6.Format(Second(Now), "00")
		
	End Function
	
	
	
	
	
	
	Public Function IsAinB(ByRef a As String, ByRef b As String) As Boolean
		
		'simplified Instr(...) function
		'
		'beware: case SENSITIVE ! (binary compare)
		
		If InStr(1, b, a) > 0 Then IsAinB = True Else IsAinB = False
		
	End Function
	
	
	
	Public Function IsOneOfAInB(ByRef a As String, ByRef b As String) As Boolean
		
		'used to compare 2 sets of flags:
		'    ABCD  XYZ   -> false
		'    KLMO  DLU   -> true (L)
		
		Dim n As Short
		
		For n = 1 To Len(a)
			If IsAinB(Mid(a, n, 1), b) Then
				IsOneOfAInB = True
				Exit For
			End If
		Next n
		
	End Function
	
	Public Function MakeFilename(ByRef strFile As String, Optional ByRef strPath As String = "*") As String
		
		If strPath = "*" Then strPath = My.Application.Info.DirectoryPath
		
		If Right(strPath, 1) = "\" Then
			MakeFilename = strPath & strFile
		Else
			MakeFilename = strPath & "\" & strFile
		End If
		
	End Function
	
	
	Public Function IsFile(ByRef strFile As String) As Boolean
		
		On Error GoTo errhandler
		
		If FileLen(strFile) >= 0 And IsDir(strFile) = False Then IsFile = True
		
		Exit Function
		
errhandler: 
		IsFile = False
	End Function
	
	
	Public Function TryDelete(ByRef strFile As String) As Boolean
		
		On Error Resume Next
		
		If IsFile(strFile) Then
			SetAttr(strFile, FileAttribute.Normal)
			Err.Clear()
			Kill(strFile)
			If Err.Number = 0 Then TryDelete = True
		End If
		
	End Function
	
	Public Function TryMkDir(ByRef strPath As String) As Boolean
		
		On Error Resume Next
		
		Err.Clear()
		MkDir(strPath)
		If Err.Number = 0 Then TryMkDir = True
		
	End Function
	
	
	Public Function TryRmDir(ByRef strPath As String) As Boolean
		
		On Error Resume Next
		
		Err.Clear()
		RmDir(strPath)
		If Err.Number = 0 Then TryRmDir = True
		
	End Function
	
	
	
	Public Function TryRename(ByRef strOld As String, ByRef strNew As String) As Boolean
		
		On Error Resume Next
		
		Err.Clear()
		Rename(strOld, strNew)
		If Err.Number = 0 Then TryRename = False
		
	End Function
	
	
	Public Function IsDir(ByRef strPath As String) As Boolean
		
		On Error GoTo errhandler
		
		If GetAttr(strPath) And FileAttribute.Directory Then IsDir = True
		
		Exit Function
		
errhandler: 
		IsDir = False
	End Function
End Module