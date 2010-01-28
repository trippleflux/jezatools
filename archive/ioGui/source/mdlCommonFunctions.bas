Attribute VB_Name = "mdlCommon"
Option Explicit

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


Public Sub AppendToFile(sFile As String, sLine As String)

    On Error GoTo errhandler
    
    Dim f As Integer
            
            
    f = FreeFile(0)
    Open sFile For Append As #f
        Print #f, sLine
    Close #f
    
Exit Sub

errhandler:
    send "ERROR in AppendToFile() : " & Err.description & " (" & Err & ")"
    Resume Next
End Sub


Public Function ListFilesInDir(sPath As String, Optional arrExclude As Variant) As Variant

    Dim a()       As String
    Dim sFile     As String
    Dim n         As Integer
    Dim bContinue As Boolean
    
    
    ReDim a(0) As String
    
    'send "DEBUG: isarray(arrExclude) = " & IsArray(arrExclude)
    'send "DEBUG: ubound(arrExclude) = " & UBound(arrExclude)
    
    'find files
    sFile = Dir(sPath, vbNormal Or vbHidden Or vbArchive Or vbReadOnly Or vbSystem)
    Do While Len(sFile) > 0
        
        'assume the file doesn't match any of the exclusions
        bContinue = True
        
        'check exclude list
        If IsArray(arrExclude) Then
        For n = LBound(arrExclude) To UBound(arrExclude)
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
            ReDim Preserve a(UBound(a) + 1) As String
        End If
        End If
        End If
        
        'fetch next file
        sFile = Dir
    Loop
    
    'remove last empty array-item
    If UBound(a) > 0 Then _
    ReDim Preserve a(UBound(a) - 1) As String
    
    'return the array of files
    ListFilesInDir = a

End Function

Public Function ParseTemplateFile(sFilename As String, ByRef arrData As Variant) As String

    Dim buffer As String
    Dim f      As Integer

    'exit if template file doesn't exist
    If Not IsFile(sFilename) Then
        send "ERROR: ParseTemplateFile() -> template file is missing: " & Quote(sFilename)
        Exit Function
    End If
    
    'read file
    f = FreeFile(1)
    Open sFilename For Binary Access Read As #f
        buffer = Space(FileLen(sFilename))
        Get #f, , buffer
    Close #f

    ParseTemplateFile = ParseString(buffer, arrData)

End Function



Public Function ReadFileToArray(sFilename As String) As Variant

    Dim a() As String
    Dim f   As Integer
    Dim buf As String
        
    'avoid array errors
    ReDim a(0) As String
    ReadFileToArray = a
    
    If Not IsFile(sFilename) Then Exit Function

    f = FreeFile(1)
    Open sFilename For Input Access Read As #f
        Do While Not EOF(f)
            Line Input #f, buf
            a(UBound(a)) = buf:  buf = ""
            ReDim Preserve a(UBound(a) + 1) As String
        Loop
    Close #f

    'remove last empty array-item
    If UBound(a) > 0 Then _
    ReDim Preserve a(UBound(a) - 1) As String


    'return array
    ReadFileToArray = a


End Function

Public Sub StripLastCRLF(sBuffer As String)

    If Right(sBuffer, 2) = vbCrLf Then sBuffer = Left(sBuffer, Len(sBuffer) - 2)

End Sub

Public Function StripPath(sPathAndFile As String) As String

    Dim a() As String
    
    If Len(sPathAndFile) = 0 Then Exit Function
    
    a = Split(sPathAndFile, "\")
    StripPath = a(UBound(a))

End Function

Public Function PathFromFilename(sPathAndFile As String) As String

    Dim a() As String
    
    If Len(sPathAndFile) = 0 Then Exit Function
    
    a = Split(sPathAndFile, "\")
    a(UBound(a)) = ""
    PathFromFilename = Join(a, "\")
    
End Function


Public Sub SetFileAttrHidden(strFilename As String)

    On Error Resume Next
    
    SetAttr strFilename, vbHidden

End Sub

Public Function FileLenEx(sFilename As String) As Long

    ' funtion to replace FileLen()
    ' instead of generating an error for non-existing files, return -1

    On Local Error Resume Next
    
    FileLenEx = FileLen(sFilename)
    If Err <> 0 Then FileLenEx = -1

End Function


Public Sub RemoveEmptyItemsFromArray(ByRef a() As String)

    ' - removes all 0-byte items from a string array
    ' - keeps the rest of the array in the same order
    ' - will allways keep at least 1 item in the array, possibly 0-byte

    Dim n As Integer
    Dim i As Integer
    
    Dim c As Integer

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
        ReDim Preserve a(UBound(a) - c) As String
    Else
        ReDim Preserve a(0) As String
    End If

End Sub





Public Function Quote(data As String) As String

    Quote = """" & data & """"

End Function



Public Function UnQuote(data As String) As String

    
    'will remove leading and/or trailing quotes, if any
    
    UnQuote = data
    
    If Left(data, 1) = """" Then UnQuote = Right(UnQuote, Len(UnQuote) - 1)
    If Right(data, 1) = """" Then UnQuote = Left(UnQuote, Len(UnQuote) - 1)
    

End Function




Public Function ParseString(strData As String, ByRef arrData As Variant) As String

    Dim buff     As String
    Dim tempbuff As String
    Dim a()      As String
    Dim c        As String
    Dim posA     As Integer
    Dim posB     As Integer
    Dim FoundIt  As Boolean
    Dim f        As Integer
    Dim n        As Integer
    
       
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
                    If LCase(arrData(n, 0)) = LCase(a(0)) Then
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
                Case 0: c = Fm(a(0), 0, eAlignLeft)
                Case 1: c = Fm(a(0), Abs(Int(Val(a(1)))), eAlignLeft)
                Case 2: c = Fm(a(0), Abs(Int(Val(a(1)))), IIf(a(2) = "C", eAlignCenter, IIf(a(2) = "R", eAlignright, eAlignLeft)))
                Case 3: c = Fm(a(0), Abs(Int(Val(a(1)))), IIf(a(2) = "C", eAlignCenter, IIf(a(2) = "R", eAlignright, eAlignLeft)), IIf(Len(a(3)) = 1, a(3), " "))
                Case 4: c = Fm(a(0), Abs(Int(Val(a(1)))), IIf(a(2) = "C", eAlignCenter, IIf(a(2) = "R", eAlignright, eAlignLeft)), IIf(Len(a(3)) = 1, a(3), " "), IIf(a(4) = "1", True, False))
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

Public Function Fm(strData As Variant, intTotalSize, Optional intAlign As enumAlignment = eAlignLeft, Optional strFillChar As String = " ", Optional blCapIfTooLong As Boolean = False) As String
    
    If strFillChar = "$" Then
        strData = CStr(Round(Val(strData) / 1024, 0))
        strFillChar = " "
    End If
    
    If blCapIfTooLong = True Then
        If Len(strData) > intTotalSize Then strData = Left(strData, intTotalSize)
    End If

    If (intTotalSize > 0) And (intTotalSize > Len(strData)) Then
        Fm = String(intTotalSize, strFillChar)
        If Len(strData) > 0 Then
            Select Case intAlign
            Case enumAlignment.eAlignLeft
                Mid(Fm, 1, Len(strData)) = strData
            Case enumAlignment.eAlignright
                Mid(Fm, Len(Fm) - Len(strData) + 1, Len(strData)) = strData
            Case enumAlignment.eAlignCenter
                Mid(Fm, Int((Len(Fm) - Len(strData)) / 2) + 1, Len(strData)) = strData
            End Select
        End If
    Else
        Fm = strData
    End If

End Function



Public Function InDebug() As Boolean
    
    On Local Error GoTo errhandler
    InDebug = False
    Debug.Print 1 / 0

Exit Function

errhandler:
    InDebug = True
End Function


Public Function JoinEx(a As Variant, Optional iBegin As Integer = 0, Optional ByVal iEnd As Integer = -1, Optional strSeparator As String = " ", Optional StopAtThisItem As String = "*") As String

    Dim n As Integer

    If (iEnd > UBound(a)) Or (iEnd < 0) Then iEnd = UBound(a)

    For n = iBegin To iEnd
        If (a(n) = StopAtThisItem) And Not (StopAtThisItem = "*") Then Exit For
        JoinEx = JoinEx & a(n) & strSeparator
    Next n
    
    'remove last separator
    If Len(JoinEx) >= Len(strSeparator) Then _
    JoinEx = Left(JoinEx, Len(JoinEx) - Len(strSeparator))
    
End Function


Public Function RepeatStr(intCount As Integer, strWhat As String) As String

    Dim n As Integer

    If intCount > 0 And Len(strWhat) > 0 Then
        RepeatStr = Space(Len(strWhat) * intCount)
        For n = 0 To intCount - 1
            Mid(RepeatStr, (n * Len(strWhat)) + 1, Len(strWhat)) = strWhat
        Next n
    End If

End Function


Public Function TimeDate() As String

    TimeDate = _
        Format(Day(Now), "00") & "/" & _
        Format(Month(Now), "00") & "/" & _
        Year(Now) & " " & _
        Format(Hour(Now), "00") & ":" & _
        Format(Minute(Now), "00") & ":" & _
        Format(Second(Now), "00")

End Function






Public Function IsAinB(a As String, b As String) As Boolean

    'simplified Instr(...) function
    '
    'beware: case SENSITIVE ! (binary compare)
    
    If InStr(1, b, a) > 0 Then IsAinB = True Else IsAinB = False

End Function



Public Function IsOneOfAInB(a As String, b As String) As Boolean

    'used to compare 2 sets of flags:
    '    ABCD  XYZ   -> false
    '    KLMO  DLU   -> true (L)

    Dim n As Integer

    For n = 1 To Len(a)
        If IsAinB(Mid(a, n, 1), b) Then
            IsOneOfAInB = True
            Exit For
        End If
    Next n

End Function

Public Function MakeFilename(strFile As String, Optional strPath As String = "*") As String
    
    If strPath = "*" Then strPath = App.Path
    
    If Right(strPath, 1) = "\" Then
        MakeFilename = strPath & strFile
    Else
        MakeFilename = strPath & "\" & strFile
    End If
    
End Function


Public Function IsFile(strFile As String) As Boolean

    On Error GoTo errhandler

    If FileLen(strFile) >= 0 And IsDir(strFile) = False Then IsFile = True

Exit Function

errhandler:
        IsFile = False
End Function


Public Function TryDelete(strFile As String) As Boolean

    On Local Error Resume Next
    
    If IsFile(strFile) Then
        SetAttr strFile, vbNormal
        Err.Clear
        Kill strFile
        If Err = 0 Then TryDelete = True
    End If

End Function

Public Function TryMkDir(strPath As String) As Boolean

    On Local Error Resume Next
    
    Err.Clear
    MkDir strPath
    If Err = 0 Then TryMkDir = True

End Function


Public Function TryRmDir(strPath As String) As Boolean

    On Local Error Resume Next
    
    Err.Clear
    RmDir strPath
    If Err = 0 Then TryRmDir = True

End Function



Public Function TryRename(strOld As String, strNew As String) As Boolean

    On Local Error Resume Next

    Err.Clear
    Name strOld As strNew
    If Err = 0 Then TryRename = False

End Function


Public Function IsDir(strPath As String) As Boolean

    On Error GoTo errhandler

    If GetAttr(strPath) And vbDirectory Then IsDir = True

Exit Function

errhandler:
        IsDir = False
End Function


