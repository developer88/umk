Imports System.IO
Imports Microsoft
Imports System.Collections.ObjectModel
Imports System.Text
Imports System.Windows.Markup
Imports System.Collections.Generic
Imports System.Collections
Imports System.Diagnostics
Imports System.Xml

Module mdl_main

    Structure PersonalData
        Dim Name As String
        Dim LastName As String
        Dim Mail As String
    End Structure

    Public Sub load_strings()
        Dim temp() As String
        Dim i As Integer
        'strings.inf
        temp_strings.Clear()
        strings_names.Clear()
        strings_values.Clear()
        read_from_text_file_byline(AppDomain.CurrentDomain.BaseDirectory & "strings.inf")
        If temp_strings.Count < 1 Then MessageBox.Show("Ошибка 003: Ошибка при загрузке файлов программы!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error)
        For i = 0 To temp_strings.Count - 1
            temp = Split(temp_strings.Item(i), "=")
            If temp.Count > 1 Then strings_values.Add(temp(1)) Else strings_values.Add("")
            strings_names.Add(temp(0))
        Next
        'fast_search
        If My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "files.db") = True Then
            search_fastsearch_is_enabled = True
            read_from_text_file_byline(AppDomain.CurrentDomain.BaseDirectory & "files.db")
            If temp_strings.Count > 0 Then
                For i = 0 To temp_strings.Count - 1
                    fastsearch_list.Add(temp_strings(i))
                Next
            Else
                search_fastsearch_is_enabled = False
            End If
        Else
            search_fastsearch_is_enabled = False
        End If
    End Sub

    Public Function get_temp_dir() As String
        Dim windir As String  ' получаем путь папки Windows
        windir = Environment.GetEnvironmentVariable("temp")
        get_temp_dir = windir
    End Function


    Public Function get_extention(ByVal filename As String) As String
        Dim c_temp() As String
        c_temp = Split(filename, ".")
        If c_temp.Count < 2 Then get_extention = "" : Exit Function
        get_extention = LCase(c_temp(c_temp.Count - 1))
    End Function

    Public Function is_weburl(ByVal text As String) As Boolean
        If Len(text) < 8 Then is_weburl = False : Exit Function
        If Left(text, 7) = "http://" Then
            is_weburl = True
        Else
            is_weburl = False
        End If
    End Function

    Public Sub read_from_text_file_byline(ByVal filename_path As String)
        If My.Computer.FileSystem.FileExists(filename_path) = False Then Exit Sub
        Dim ioFile As New StreamReader(filename_path)
        Dim ioLine As String ' Going to hold one line at a time
        If temp_strings.Count > 0 Then temp_strings.Clear()
        ioLine = "   1"
        While Not ioLine = ""
            ioLine = ioFile.ReadLine
            If Len(ioLine) > 0 Then temp_strings.Add(ioLine)
        End While
        ioFile.Close()
    End Sub

    Public Sub open_webdoc(ByVal web_path As String)
        Dim windir As String  ' получаем путь папки Windows
        windir = Environment.GetEnvironmentVariable("windir")
        Shell(windir & "\explorer.exe " & web_path, vbNormalFocus)
    End Sub

    Public Function ReplaceAll(ByVal SourceString As String, ByVal ReplaceThis As String, ByVal WithThis As String)
        Dim Temp As Object
        Temp = Split(SourceString, ReplaceThis)
        ReplaceAll = Join(Temp, WithThis)
    End Function

    Public Function get_filename(ByVal cur_path As String)
        Dim path_temp() As String = Split(cur_path, "\")
        get_filename = path_temp(path_temp.GetUpperBound(0))
    End Function

    Public Function get_name(ByVal filename As String)
        Dim temp() As String
        temp = Split(filename, ".")
        get_name = temp(0)
    End Function

    Public Function get_type(ByVal path As String)
        If My.Computer.FileSystem.DirectoryExists(path) = True Then
            get_type = "folder"
        Else
            get_type = "file"
        End If
    End Function

    Public Function get_relative_path(ByVal fullpath_string As String, ByVal cur_type As String)
        Dim str_temp() As String
        Dim st_temp As String = ""
        If cur_type = "file" Then
            str_temp = Split(My.Computer.FileSystem.GetParentPath(fullpath_string), AppDomain.CurrentDomain.BaseDirectory & "\Content\")
            get_relative_path = str_temp(str_temp.Count - 1)
        Else
            str_temp = Split(Right(fullpath_string, Len(fullpath_string) - Len(AppDomain.CurrentDomain.BaseDirectory & "\Content\")), "\")
            For i = 0 To str_temp.Count - 2
                st_temp = st_temp & str_temp(i) & "\"
            Next
            If Right(st_temp, 1) = "\" Then st_temp = Left(st_temp, Len(st_temp) - 1)
            If Len(st_temp) = 0 Then st_temp = "-"
            get_relative_path = st_temp
        End If
    End Function

End Module
