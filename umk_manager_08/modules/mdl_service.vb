Imports System
Imports Microsoft.Win32
Imports System.IO
Imports System.Runtime.InteropServices

Module mdl_service

    Private Structure SHFILEINFO
        Public hIcon As IntPtr            ' : icon
        Public iIcon As Integer           ' : icondex
        Public dwAttributes As Integer    ' : SFGAO_ flags
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> _
        Public szDisplayName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> _
        Public szTypeName As String
    End Structure

    Private Declare Auto Function SHGetFileInfo Lib "shell32.dll" _
            (ByVal pszPath As String, _
             ByVal dwFileAttributes As Integer, _
             ByRef psfi As SHFILEINFO, _
             ByVal cbFileInfo As Integer, _
             ByVal uFlags As Integer) As IntPtr

    Private Const SHGFI_ICON = &H100
    Private Const SHGFI_SMALLICON = &H1
    Private Const SHGFI_LARGEICON = &H0    ' Large icon
    Private nIndex

    Public Function get_icon(ByVal path As String, ByVal size As String) As System.Drawing.Icon
        Dim hImgSmall As IntPtr  'The handle to the system image list.
        Dim shinfo As SHFILEINFO
        shinfo = New SHFILEINFO()
        shinfo.szDisplayName = New String(Chr(0), 260)
        shinfo.szTypeName = New String(Chr(0), 80)

        If size = "small" Then
            hImgSmall = SHGetFileInfo(path, 0, shinfo, _
                       Marshal.SizeOf(shinfo), _
                      SHGFI_ICON Or SHGFI_LARGEICON)
        Else
            hImgSmall = SHGetFileInfo(path, 0, shinfo, Marshal.SizeOf(shinfo), SHGFI_ICON Or SHGFI_LARGEICON)
        End If
        'Use this to get the small icon.
        'hImgSmall = SHGetFileInfo(path, 0, shinfo, _
        '           Marshal.SizeOf(shinfo), _
        '           SHGFI_ICON Or SHGFI_SMALLICON)

        'Use this to get the large icon.
        'hImgLarge = SHGetFileInfo(fName, 0, _
        'ref shinfo, (uint)Marshal.SizeOf(shinfo), _
        'SHGFI_ICON | SHGFI_LARGEICON);

        'The icon is returned in the hIcon member of the
        'shinfo struct.
        Dim myIcon As System.Drawing.Icon
        myIcon = System.Drawing.Icon.FromHandle(shinfo.hIcon)
        get_icon = myIcon

    End Function

    Public Sub check_for_unexistingfiles()
        Dim dir_path As String = ""

        Select Case cur_edit_type
            Case 0
                dir_path = UMK_dir
            Case 1
                dir_path = UMK_dir & "\" & UNIT_path
            Case 2
                dir_path = UMK_dir & "\" & UNIT_path & "\" & CAF_path
            Case 3
                dir_path = UMK_dir & "\" & UNIT_path & "\" & CAF_path & "\" & UMK_path
        End Select
        Dim g_temp As String
        Dim g_temp2 As String
        Dim files_pattern As String = "*.*"
        For Each foundfiles As String In _
            My.Computer.FileSystem.GetFiles(dir_path, FileIO.SearchOption.SearchTopLevelOnly, files_pattern)
            g_temp = get_filename(foundfiles)
            g_temp2 = get_extention(g_temp)
            If g_temp2 = "info" Then
                If My.Computer.FileSystem.FileExists(dir_path & "\" & Left(g_temp, Len(g_temp) - 5)) = False Then
                    My.Computer.FileSystem.DeleteFile(dir_path & "\" & g_temp, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                End If
            End If
            If cur_edit_type < 3 And g_temp2 <> "dat" Then
                My.Computer.FileSystem.DeleteFile(dir_path & "\" & g_temp, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            End If
        Next
        If cur_edit_type = 3 Then
            If My.Computer.FileSystem.DirectoryExists(dir_path) = False Then Exit Sub
            For Each founddir As String In _
              My.Computer.FileSystem.GetDirectories(dir_path & "\")
                'My.Computer.FileSystem.DeleteDirectory(dir_path & "\" & get_filename(founddir), FileIO.DeleteDirectoryOption.DeleteAllContents)
            Next
        End If
    End Sub

    Public Function ReplaceAll(ByVal SourceString As String, ByVal ReplaceThis As String, ByVal WithThis As String)
        Dim Temp As Object
        Temp = Split(SourceString, ReplaceThis)
        ReplaceAll = Join(Temp, WithThis)
    End Function

    Public Sub create_registry()
        Const userRoot As String = "HKEY_CURRENT_USER"
        Const subkey As String = "Software\Microsoft\Windows\CurrentVersion\Run\"
        Const keyName As String = userRoot & "\" & subkey
        Microsoft.Win32.Registry.SetValue(keyName, "umk_mngr", """" & Application.ExecutablePath & """", Microsoft.Win32.RegistryValueKind.String)
    End Sub

    Public Sub create_app_registry()
        Const userRoot As String = "HKEY_CURRENT_USER"
        Const subkey As String = "Software\dsoft\UMK\"
        Const keyName As String = userRoot & "\" & subkey
        Microsoft.Win32.Registry.SetValue(keyName, "umk_path", System.Reflection.Assembly.GetExecutingAssembly().Location, Microsoft.Win32.RegistryValueKind.String)
    End Sub

    Public Sub create_other_registry(ByVal registry_name As String, ByVal registry_value As String)
        Const userRoot As String = "HKEY_CURRENT_USER"
        Const subkey As String = "Software\dsoft\UMK\"
        Const keyName As String = userRoot & "\" & subkey
        Microsoft.Win32.Registry.SetValue(keyName, registry_name, registry_value, Microsoft.Win32.RegistryValueKind.String)
    End Sub

    Public Function get_registry(ByVal key_path As String, ByVal key_name As String) As String
        Const userRoot As String = "HKEY_CURRENT_USER"
        'Const subkey As String = "" & key_path
        Dim keyName As String = userRoot & "\" & key_path
        Dim c_temp As String = Microsoft.Win32.Registry.GetValue(keyName, key_name, String.Empty)
        If Len(c_temp) > 0 Then get_registry = c_temp Else get_registry = ""
    End Function

    Public Sub delete_registry()
        Dim myRegistryKey As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", True)
        myRegistryKey.DeleteValue("umk_mngr", False)
    End Sub

    Public Sub rename_func(ByVal old_name As String, ByVal cur_path As String, ByVal update_unit As Boolean, ByVal cur_type As Integer)
        Dim message, title, defaultValue As String
        Dim myValue As Object
        Dim newValue As String
        If Len(old_name) = 0 Then Exit Sub
        message = "Введите новое название:"
        title = "Новое название"
        defaultValue = ""
        myValue = InputBox(message, title, defaultValue)
        If myValue Is "" Then Exit Sub
        newValue = myValue.ToString
        If Len(newValue) = 0 Then Exit Sub
        If Len(get_extention(newValue)) < 2 Then newValue = newValue & "." & get_extention(old_name)
        If cur_type = 3 Then
            rename_unit(old_name, newValue, cur_path, update_unit, True)
        Else
            rename_unit(old_name, newValue, cur_path, update_unit, False)
        End If
    End Sub

    Public Function read_from_text_file_byline(ByVal filename_path As String) As Integer
        Dim result As Integer
        If My.Computer.FileSystem.FileExists(filename_path) = False Then read_from_text_file_byline = 0 : Exit Function Else result = 1
        Dim ioFile As New StreamReader(filename_path)
        Dim ioLine As String ' Going to hold one line at a time
        'If My.Computer.FileSystem.FileExists(filename_path) = False Then read_from_text_file_byline = 0 : ioFile.Close() : Exit Function Else result = 1
        frm_res.lst_text_file.Items.Clear()
        ioLine = "   1"
        While Not ioLine = ""
            ioLine = ioFile.ReadLine
            If Len(ioLine) > 0 Then frm_res.lst_text_file.Items.Add(ioLine)
        End While
        ioFile.Close()
        read_from_text_file_byline = result
    End Function

    Public Sub clear_command_list()
        frm_res.command_list.Items.Clear()
    End Sub

    Public Sub add_to_command_list(ByVal new_item As String)
        frm_res.command_list.Items.Add(new_item)
    End Sub

    Public Function create_path(ByVal edit_type As Integer) As String
        create_path = ""
        If search_initialised = False Then
            Select Case edit_type
                Case 1
                    create_path = ""
                Case 2
                    create_path = UNIT_path
                Case 3
                    create_path = UNIT_path & "\" & CAF_path
                Case 4
                    create_path = UNIT_path & "\" & CAF_path & "\" & UMK_path
            End Select
        Else
            ' MessageBox.Show(edit_type & " " & Form1.dg.CurrentRow.Cells(2).FormattedValue & "\" & Form1.dg.CurrentRow.Cells(0).FormattedValue)
            Select Case edit_type
                Case 1
                    create_path = ""
                Case 2
                    create_path = Form1.dg.CurrentRow.Cells(2).FormattedValue
                Case 3
                    create_path = Form1.dg.CurrentRow.Cells(2).FormattedValue
                Case 4
                    create_path = Form1.dg.CurrentRow.Cells(2).FormattedValue
            End Select
        End If
    End Function

    Public Sub rename_unit(ByVal cur_name As String, ByVal new_name As String, ByVal cur_path As String, ByVal update_unit As Boolean, ByVal is_file As Boolean)
        If is_file = True Then
            If My.Computer.FileSystem.FileExists(UMK_dir & "\" & cur_path & "\" & cur_name & ".info") = True Then
                My.Computer.FileSystem.MoveFile(UMK_dir & "\" & cur_path & "\" & cur_name & ".info", UMK_dir & "\" & cur_path & "\" & new_name & ".info")
            End If
            My.Computer.FileSystem.MoveFile(UMK_dir & "\" & cur_path & "\" & cur_name, UMK_dir & "\" & cur_path & "\" & new_name)
        Else
            'MessageBox.Show(UNIT_path & "\" & CAF_path & "\" & UMK_path)
            If cur_path = "" Or cur_path = "-" Then
                My.Computer.FileSystem.MoveDirectory(UMK_dir & "\" & cur_name, UMK_dir & "\" & new_name)
            Else
                If (LCase(cur_name) <> LCase(new_name)) Then
                    My.Computer.FileSystem.MoveDirectory(UMK_dir & "\" & cur_path & "\" & cur_name, UMK_dir & "\" & cur_path & "\" & new_name)
                End If
            End If
        End If
        If search_initialised = False Then If update_unit = True Then show_unit()
    End Sub

    Public Sub show_error_message(ByVal error_code As Integer, ByVal is_critical As Boolean)
        If is_critical = True Then
            MsgBox(frm_res.lst_error_message.Items.Item(error_code), MsgBoxStyle.Critical)
            exit_app(True)
        Else
            MsgBox(frm_res.lst_error_message.Items.Item(error_code), MsgBoxStyle.Information)
        End If
    End Sub

    Public Function get_extention(ByVal filename As String) As String
        Dim c_temp() As String
        c_temp = Split(filename, ".")
        If c_temp.Count < 2 Then get_extention = "" : Exit Function
        get_extention = c_temp(c_temp.Count - 1)
    End Function

    Public Sub exit_app(ByVal is_terminated As Boolean)
        Try
            If is_terminated = False Then
                save_settings()
            End If
            Form1.NotifyIcon1.Visible = False
            If My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\temp\") = True Then My.Computer.FileSystem.DeleteDirectory(Application.StartupPath & "\temp\", FileIO.DeleteDirectoryOption.DeleteAllContents)
            'session
            save_sessions_lists()
            End
        Catch
            MessageBox.Show("Ошбика при выходе из приложения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub open_webdoc(ByVal web_path As String)
        Dim windir As String  ' получаем путь папки Windows
        windir = Environment.GetEnvironmentVariable("windir")
        Shell(windir & "\explorer.exe " & web_path, vbNormalFocus)
    End Sub

    Public Sub explore_folder(ByVal folder_path As String, ByVal path_is_full As Boolean)
        If cur_edit_type = 3 Then Exit Sub
        Dim windir As String  ' получаем путь папки Windows
        windir = Environment.GetEnvironmentVariable("windir")
        If path_is_full = True Then
            Shell(windir & "\explorer.exe " & folder_path, vbNormalFocus)
        Else
            Select Case cur_edit_type
                Case 0
                    folder_path = UMK_dir & "\" & folder_path
                Case 1
                    folder_path = UMK_dir & "\" & UNIT_path & "\" & folder_path
                Case 2
                    folder_path = UMK_dir & "\" & UNIT_path & "\" & CAF_path & "\" & folder_path
            End Select
            Shell(windir & "\explorer.exe " & folder_path, vbNormalFocus)
        End If
    End Sub

    Public Function get_filename(ByVal cur_path As String)
        Dim path_temp() As String = Split(cur_path, "\")
        get_filename = path_temp(path_temp.GetUpperBound(0))
    End Function

    Public Function get_name(ByVal filename As String)
        Dim temp() As String
        temp = Split(filename, ".")
        get_name = temp(0)
    End Function

    Public Sub get_dir(ByVal dir_path As String)
        Form1.ListBox1.Items.Clear()
        'If My.Computer.FileSystem.DirectoryExists(dir_path) = False Then Exit Sub
        If is_exist(dir_path) = False Then cur_edit_type = cur_edit_type - 1 : show_unit() : Exit Sub
        For Each founddir As String In _
          My.Computer.FileSystem.GetDirectories(dir_path)
            Form1.ListBox1.Items.Add(get_filename(founddir))
        Next
    End Sub

    Public Function get_path(ByVal get_string As String)
        get_path = My.Computer.FileSystem.GetParentPath(get_string)
    End Function

    Public Function get_relative_path(ByVal fullpath_string As String, ByVal cur_type As String)
        Dim str_temp() As String
        Dim st_temp As String = ""
        If cur_type = "file" Then
            str_temp = Split(My.Computer.FileSystem.GetParentPath(fullpath_string), UMK_dir & "\")
            get_relative_path = str_temp(str_temp.Count - 1)
        Else
            str_temp = Split(Right(fullpath_string, Len(fullpath_string) - Len(UMK_dir & "\")), "\")
            For i = 0 To str_temp.Count - 2
                st_temp = st_temp & str_temp(i) & "\"
            Next
            If Right(st_temp, 1) = "\" Then st_temp = Left(st_temp, Len(st_temp) - 1)
            If Len(st_temp) = 0 Then st_temp = "-"
            get_relative_path = st_temp
        End If
    End Function

    Public Function check_for_system_ex(ByVal filename As String) As Boolean
        Dim i As Integer
        Dim g_array() As String
        Dim g_system As Boolean
        g_system = False
        g_array = Split(filename, ".")
        For i = 0 To frm_res.lst_system_ex.Items.Count - 1
            If frm_res.lst_system_ex.Items.Item(i) = g_array(g_array.Count - 1) Then g_system = True : Exit For
        Next
        check_for_system_ex = g_system
    End Function

    Public Sub get_files(ByVal dir_path As String, ByVal files_pattern As String)
        Dim g_temp As String
        Form1.ListBox1.Items.Clear()
        If Len(files_pattern) <= 1 Then files_pattern = "*.*"
        If is_exist(dir_path) = False Then cur_edit_type = cur_edit_type - 1 : show_unit() : Exit Sub
        For Each foundfiles As String In _
            My.Computer.FileSystem.GetFiles(dir_path, FileIO.SearchOption.SearchTopLevelOnly, files_pattern)
            'check for system files
            g_temp = get_filename(foundfiles)
            If check_for_system_ex(g_temp) = False Then Form1.ListBox1.Items.Add(g_temp)
        Next
    End Sub

    Public Function get_upper_level(ByVal path As String) As String
        Dim s_temp() As String
        Dim s_temp2 As String = ""
        s_temp = Split(path, "\")
        If s_temp.Count > 1 Then
            s_temp2 = s_temp(0)
            For i = 1 To s_temp.Count
                s_temp2 = s_temp2 & "\" & s_temp(i)
            Next

            '' MessageBox.Show(s_temp2)
            get_upper_level = s_temp2
        Else
            get_upper_level = ""
        End If
    End Function

    Public Function is_exist(ByVal path As String) As Boolean
        If My.Computer.FileSystem.FileExists(path) = True Or My.Computer.FileSystem.DirectoryExists(path) = True Then
            is_exist = True
        Else
            is_exist = False
        End If
    End Function

    Public Sub app_set_autostart(ByVal current_value As Boolean)
        If current_value = True Then
            create_registry()
        Else
            delete_registry()
        End If
    End Sub

    Public Sub hide_to_tray()
        Form1.NotifyIcon1.Visible = True
        Form1.NotifyIcon1.Text = "УМК Менеджер"
        Form1.Hide()
    End Sub

    Public Sub delete_dir_N_files(ByVal file_name As String)
        Dim c As MsgBoxResult
        c = MsgBox("Вы дейстивтельно хотите удалить " & file_name & "?", MsgBoxStyle.OkCancel, "Подтвержение удаления")
        If c = MsgBoxResult.Cancel Then Exit Sub
        Select Case cur_edit_type
            Case 0
                My.Computer.FileSystem.DeleteDirectory(UMK_dir & "\" & file_name, FileIO.DeleteDirectoryOption.DeleteAllContents)
            Case 1
                My.Computer.FileSystem.DeleteDirectory(UMK_dir & "\" & UNIT_path & "\" & file_name, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            Case 2
                My.Computer.FileSystem.DeleteDirectory(UMK_dir & "\" & UNIT_path & "\" & CAF_path & "\" & file_name, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            Case 3
                My.Computer.FileSystem.DeleteFile(UMK_dir & "\" & UNIT_path & "\" & CAF_path & "\" & UMK_path & "\" & file_name, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        End Select
        show_unit()
    End Sub

    Public Function delete_found_file(ByVal path As String, ByVal found_type As String, ByVal file_name As String) As Boolean
        Dim c As MsgBoxResult
        c = MsgBox("Вы дейстивтельно хотите удалить " & file_name & "?", MsgBoxStyle.OkCancel, "Подтвержение удаления")
        If c = MsgBoxResult.Cancel Then Exit Function
        delete_found_file = True
        Try
            Select Case found_type
                Case 0
                    My.Computer.FileSystem.DeleteDirectory(UMK_dir & "\" & file_name, FileIO.DeleteDirectoryOption.DeleteAllContents)
                Case 1
                    My.Computer.FileSystem.DeleteDirectory(UMK_dir & "\" & path, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                Case 2
                    My.Computer.FileSystem.DeleteDirectory(UMK_dir & "\" & path, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                Case 3
                    My.Computer.FileSystem.DeleteFile(UMK_dir & "\" & path, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            End Select
            Form1.dg.CurrentRow.Visible = False
            'show_unit()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            delete_found_file = False
        End Try
    End Function

    Public Sub show_file(ByVal file_path As String)
        Dim p As New Process()
        'My.Computer.FileSystem.CopyFile(doc_path_original, doc_path_copy_to, True)
        'If open_now = False Then Exit Sub
        p.StartInfo.FileName = file_path
        'p.StartInfo.Arguments = """" & doc_path & """"
        Try
            p.Start()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Critical) : Exit Sub
        End Try
    End Sub

    Public Sub write_to_info_file(ByVal file_path As String)
        Dim cur_info As String = file_path
        Dim temp_str As String
        temp_str = ""

        If My.Computer.FileSystem.FileExists(file_path) = True Then My.Computer.FileSystem.DeleteFile(file_path)
        For i = 0 To frm_res.command_list.Items.Count - 1
            temp_str = temp_str & frm_res.command_list.Items.Item(i) & vbCrLf
        Next
        Try
            My.Computer.FileSystem.WriteAllText(cur_info, temp_str, True)
        Catch exc As Exception
            MsgBox("Произошла ошибка при сохранении информации в файл " & file_path, MsgBoxStyle.Critical) : Exit Sub
        End Try
    End Sub

    Public Function get_short_string(ByVal max_value As Integer, ByVal cur_string As String) As String
        Dim temp_array() As String
        Dim final_string As String
        Dim final_string1 As String
        Dim cur_index As Integer
        final_string = ""
        If Len(cur_string) > max_value Then
            temp_array = Split(cur_string, " ")
            If temp_array.Count <= 1 Then
                final_string = cur_string
            Else
                final_string1 = cur_string
                cur_index = temp_array.Count
                Do While (Len(final_string1) > max_value And cur_index > 0)
                    final_string1 = ""
                    For i = 0 To cur_index - 1
                        final_string1 = final_string1 & " " & temp_array(i)
                    Next
                    cur_index = cur_index - 1
                Loop
                final_string = final_string1 & ":"
            End If
        Else
            final_string = cur_string
        End If
        get_short_string = final_string
    End Function

    Public Function get_dir_info(ByVal cur_dir As String, ByVal is_file As Boolean, ByVal extra_parameter As Integer) As String
        Dim getfldrInfo As System.IO.DirectoryInfo
        Dim getfileInfo As System.IO.FileInfo
        Dim var_result As String
        var_result = ""
        If is_file = False Then
            getfldrInfo = My.Computer.FileSystem.GetDirectoryInfo(cur_dir)
            Select Case extra_parameter
                Case 1 'creation time
                    var_result = getfldrInfo.CreationTime
                Case 2 'last accestime
                    var_result = getfldrInfo.LastAccessTime
                Case 3 'lastwritetime
                    var_result = getfldrInfo.LastWriteTime
            End Select
        Else
            getfileInfo = My.Computer.FileSystem.GetFileInfo(cur_dir)
            Select Case extra_parameter
                Case 1 'creation time
                    var_result = getfileInfo.CreationTime
                Case 2 'last accestime
                    var_result = getfileInfo.LastAccessTime
                Case 3 'lastwritetime
                    var_result = getfileInfo.LastWriteTime
                Case 4 'size
                    var_result = getfileInfo.Length
            End Select
        End If
        get_dir_info = var_result
    End Function

    Public Function get_type(ByVal cur_path As String) As Integer
        ' Dim app_path As String = Application.ExecutablePath & "\Content\"
        'Dim temp_str As String
        Dim temp_array() As String
        'temp_str = Right(cur_path, Len(app_path) - Len(cur_path))
        'MsgBox("right - app_path " & temp_str)
        If cur_path = "-" Then
            get_type = 0
        Else
            temp_array = Split(cur_path, "\")
            get_type = temp_array.Count
        End If
    End Function

    Public Function isFile(ByVal path As String) As Boolean
        If My.Computer.FileSystem.FileExists(path) = True Then
            isFile = True
        Else
            isFile = False
        End If
    End Function

End Module
