
Module mdl_main


    Public Sub load_app()
        Try
            check_conditions()
            '
            frm_splash.Show()
            '
            load_stat_styles_list()
            load_settings()
            '
            If My.Computer.FileSystem.DirectoryExists(UMK_dir) = False Then
                My.Computer.FileSystem.CreateDirectory(UMK_dir)
            End If
            If My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\temp") = False Then
                My.Computer.FileSystem.CreateDirectory(Application.StartupPath & "\temp")
            End If
            '
            Form1.ListBox1.Items.Clear()
            Form1.NotifyIcon1.Visible = False
            Form1.ListBox1.AllowDrop = True
            get_dir(UMK_dir & "\")
            change_cur_edit_type(0)
            load_file_types_list(0)
            cur_show_list = 0
            disable_controls(False)
            check_listbox_status()
            load_file_styles_list()
            add_drag_enabled = False
            add_drag_used = False
            update_nav_pan()
            search_type = 1
            load_sessions_lists()
            'create_app_registry()
            'create_other_registry("umk_dir", UMK_dir & "\")
            'check for special buttons 
            'disk_creator_path = get_registry("Software\dsoft\UMK\", "disk_writer_path")
            If (My.Computer.FileSystem.FileExists(Application.StartupPath & "\DiscCreator.exe")) Then
                disk_creator_path = Application.StartupPath & "\DiscCreator.exe"
                Form1.create_disk_item.Enabled = True
            Else
                ' If Len(disk_creator_path) > 0 Then
                'Form1.create_disk_item.Enabled = True
                'Else
                Form1.create_disk_item.Enabled = False
                'End If
            End If
        Catch
            MessageBox.Show("Произошла ошибка при загрузке компонентов программы!", "Ошибка при загрузке", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            frm_splash.Close()
        End Try
    End Sub

    Public Sub apply_settings()
        'main
        If Right(frm_options.TextBox5.Text, 1) = "\" Then frm_options.TextBox5.Text = Left(frm_options.TextBox5.Text, Len(frm_options.TextBox5.Text) - 1)
        If Left(frm_options.TextBox5.Text, 6) = "APPDIR" Then
            UMK_dir = Application.StartupPath & Right(frm_options.TextBox5.Text, Len(frm_options.TextBox5.Text) - 6)
        Else
            UMK_dir = frm_options.TextBox5.Text
        End If
        show_unit()
        'Form1.СвернутьToolStripMenuItem.Enabled = False
        'If use_tray = False Then Form1.СвернутьToolStripMenuItem.Enabled = False Else Form1.СвернутьToolStripMenuItem.Enabled = True
        If APP_autostart = False Then app_set_autostart(False) Else app_set_autostart(True)
        For i1 = 0 To frm_options.lst_stat.Items.Count - 1
            If frm_options.lst_stat.Items.Item(i1) = stat_style Then
                frm_options.lst_stat.SelectedIndex = i1
                frm_options.lst_stat.SelectedValue = stat_style
                load_stat_style_info(stat_style)
            End If
        Next
        'If use_tray = False Then Form1.СвернутьToolStripMenuItem.Visible = False Else Form1.СвернутьToolStripMenuItem.Visible = True
    End Sub


    Public Sub update_settings()

    End Sub

    Public Sub save_settings()
        'infopan_show(False)
        Dim temp_str As String

        Try
            clear_command_list()
            'main
            add_to_command_list("[MAIN]")
            add_to_command_list("autostart=" & APP_autostart)
            add_to_command_list("hidetotray=" & use_tray)
            temp_str = Application.StartupPath
            If Microsoft.VisualBasic.Left(UMK_dir, Len(temp_str)) = temp_str Then
                add_to_command_list("umk_folder=" & "APPDIR" & Microsoft.VisualBasic.Right(UMK_dir, Len(UMK_dir) - Len(temp_str)))
            Else
                add_to_command_list("umk_folder=" & UMK_dir)
            End If
            add_to_command_list("infopanshow=" & Info_pan_show)
            add_to_command_list("use_check=" & use_check)
            'search
            add_to_command_list("[SEARCH]")
            add_to_command_list("search_filenames=" & search_opt_find_files)
            add_to_command_list("search_folder=" & search_opt_find_folders)
            add_to_command_list("search_text=" & search_opt_find_text)
            add_to_command_list("search_words=" & search_for_words)
            'stat
            add_to_command_list("[STAT]")
            add_to_command_list("stat_style_name=" & stat_style)
            write_to_info_file(Application.StartupPath & "\configs\settings.ini")
        Catch
            MessageBox.Show("Ошибка при сохранении настроек программы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub load_settings()
        Dim i As Integer
        Dim i1 As Integer
        Dim c_temp() As String
        Dim temp_str As String

        Try

            'options_array.Clear()
            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\configs\settings.ini") = True Then
                read_from_text_file_byline(Application.StartupPath & "\configs\settings.ini")
                If frm_res.lst_text_file.Items.Count > 1 Then
                    For i = 0 To frm_res.lst_text_file.Items.Count - 1
                        'options_array.Add(frm_res.lst_text_file.Items.Item(i))
                        c_temp = Split(frm_res.lst_text_file.Items.Item(i), "=")
                        'analyse setings
                        Select Case c_temp(0)
                            Case "hidetotray"
                                If c_temp(1) = "true" Or c_temp(1) = "True" Then use_tray = True : frm_options.chk_tray.Checked = True Else use_tray = False : frm_options.chk_tray.Checked = False
                            Case "umk_folder"
                                If Right(c_temp(1), 1) = "\" Then c_temp(1) = Left(c_temp(1), Len(c_temp(1)) - 1)
                                If Left(c_temp(1), 6) = "APPDIR" Then
                                    UMK_dir = ReplaceAll(c_temp(1), "APPDIR", Application.StartupPath)
                                    frm_options.TextBox5.Text = c_temp(1)
                                Else
                                    UMK_dir = c_temp(1)
                                    temp_str = Application.StartupPath
                                    If Microsoft.VisualBasic.Left(UMK_dir, Len(temp_str)) = temp_str Then
                                        frm_options.TextBox5.Text = "APPDIR" & Microsoft.VisualBasic.Right(UMK_dir, Len(UMK_dir) - Len(temp_str))
                                    Else
                                        frm_options.TextBox5.Text = UMK_dir
                                    End If
                                End If
                            Case "infopanshow"
                                If c_temp(1) = "true" Or c_temp(1) = "True" Then Info_pan_show = True : frm_options.CheckBox4.Checked = True : show_infopan(True) Else Info_pan_show = False : frm_options.CheckBox4.Checked = False : show_infopan(False)
                            Case "use_check"
                                If c_temp(1) = "true" Or c_temp(1) = "True" Then use_check = True : frm_options.CheckBox6.Checked = True Else use_check = False : frm_options.CheckBox6.Checked = False
                            Case "autostart"
                                If c_temp(1) = "true" Or c_temp(1) = "True" Then APP_autostart = True : frm_options.CheckBox5.Checked = True : app_set_autostart(True) Else APP_autostart = False : frm_options.CheckBox5.Checked = False : app_set_autostart(False)
                                'search
                            Case "search_filenames"
                                If c_temp(1) = "true" Or c_temp(1) = "True" Then search_opt_find_files = True : frm_options.CheckBox1.Checked = True Else search_opt_find_files = False : frm_options.CheckBox1.Checked = False
                            Case "search_folder"
                                If c_temp(1) = "true" Or c_temp(1) = "True" Then search_opt_find_folders = True : frm_options.CheckBox2.Checked = True Else search_opt_find_folders = False : frm_options.CheckBox2.Checked = False
                            Case "search_text"
                                If c_temp(1) = "true" Or c_temp(1) = "True" Then search_opt_find_text = True : frm_options.CheckBox3.Checked = True Else search_opt_find_text = False : frm_options.CheckBox3.Checked = False
                            Case "search_words"
                                If c_temp(1) = "true" Or c_temp(1) = "True" Then search_for_words = True : frm_options.RadioButton4.Checked = True Else search_for_words = False : frm_options.RadioButton3.Checked = True
                            Case "search_type"
                                If c_temp(1) = "1" Then search_type = 1 : frm_options.RadioButton1.Checked = True Else search_type = 2 : frm_options.RadioButton2.Checked = True
                                'stat
                            Case "stat_style_name"
                                stat_style = c_temp(1)
                                For i1 = 0 To frm_options.lst_stat.Items.Count - 1
                                    If frm_options.lst_stat.Items.Item(i1) = stat_style Then
                                        frm_options.lst_stat.SelectedIndex = i1
                                        load_stat_style_info(stat_style)
                                    End If
                                Next
                        End Select
                    Next
                    apply_settings()
                    If Len(UMK_dir) < 1 Then MsgBox("Не указана директория с УМК!", MsgBoxStyle.Critical, "Ошибка") : frm_options.ShowDialog()
                Else
                    MsgBox("Ошибка при загрузке настроек программы!", MsgBoxStyle.Critical)
                    Application.Exit()
                End If
            Else 'if settings isn't exist
                MsgBox("Файл с настройками не обнаружен, настройте программу!", MsgBoxStyle.Information)
                frm_options.ShowDialog()
            End If
        Catch
            MessageBox.Show("Ошибка при загрузке настроек приложения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub load_info_file_types(ByVal newMenu As String, ByVal cur_type As Integer)
        Dim newOption As New ToolStripMenuItem()
        newOption.CheckOnClick = True
        newOption.Text = newMenu
        newOption.Tag = cur_type
        AddHandler newOption.Click, AddressOf Form1.mnu_choise_Click
        Form1.mnu_choise.Items.Add(newOption)
    End Sub

    Public Sub check_conditions()
        If Environment.OSVersion.Version.Major < 5 Then MsgBox("Ваша операционная система не поддерживается," & vbCrLf & " см. сист. требования!", MsgBoxStyle.OkOnly, "Ошибка") : Application.Exit()
        If Environment.OSVersion.Version.Major = 5 Then MsgBox("В данной ОС приложение может работать нестабильно," & vbCrLf & " см. сист. требования!", MsgBoxStyle.OkOnly, "Предупреждение")
        If My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\configs") = False Or My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\styles") = False Then MsgBox("Файлы программы повреждены!" & vbCrLf & "Переустановите УМК Менеджер!", MsgBoxStyle.OkOnly, "Ошибка") : Application.Exit()
        'If frm_hlp.wb_hlp.Version.Major < 6 Then MsgBox("Для работы ропграммы требуется установленный IE 7.0 и выше!", MsgBoxStyle.Critical, "Ошибка")
        'Dim component_checker As New developers_components_lib.cls_component_checker()
        'If component_checker.check_for_components("umk_mngr") = False Then Application.Exit()
    End Sub

    Public Sub load_file_types_list(ByVal list_code As Integer)
        'Dim temp() As String
        'Dim temp2() As String
        'Dim i As Integer
        'Dim c_temp As String
        'frm_res.lst_filetypes.Items.Clear()
        'If read_from_text_file_byline(Application.StartupPath & "\configs\file_types.ini") = 0 Then show_error_message(0, True)
        'If frm_res.lst_text_file.Items.Count = 0 Then show_error_message(0, True)
        Select Case list_code
            Case 0
                frm_add.ComboBox1.Items.Clear()
                frm_add.ComboBox1.Enabled = True
                frm_add.ComboBox2.Items.Clear()
                frm_add.ComboBox2.Enabled = True
                frm_info.lst_type.Items.Clear()
                frm_info.lst_type.Enabled = True
                '
                frm_add.ComboBox1.Items.Add("Метод. указания")
                frm_add.ComboBox2.Items.Add("Метод. указания")
                frm_info.lst_type.Items.Add("Метод. указания")
                '
                frm_add.ComboBox1.Items.Add("Раб.программа")
                frm_add.ComboBox2.Items.Add("Раб.программа")
                frm_info.lst_type.Items.Add("Раб.программа")
                '
                frm_add.ComboBox1.Items.Add("Лекции")
                frm_add.ComboBox2.Items.Add("Лекции")
                frm_info.lst_type.Items.Add("Лекции")
                '
                frm_add.ComboBox1.Items.Add("Билеты")
                frm_add.ComboBox2.Items.Add("Билеты")
                frm_info.lst_type.Items.Add("Билеты")
                '
                frm_add.ComboBox1.Items.Add("Тесты (AIST)")
                frm_add.ComboBox2.Items.Add("Тесты (AIST)")
                frm_info.lst_type.Items.Add("Тесты (AIST)")
                '
                frm_add.ComboBox1.Items.Add("Тесты")
                frm_add.ComboBox2.Items.Add("Тесты")
                frm_info.lst_type.Items.Add("Тесты")
                '
                frm_add.ComboBox1.Text = "Выберите..."
                frm_add.ComboBox2.Text = "Выберите..."
            Case 1
                frm_add.ComboBox1.Items.Clear()
                frm_add.ComboBox1.Enabled = True
                frm_add.ComboBox1.Items.Add("Метод. указания")
                frm_add.ComboBox1.Items.Add("Раб.программа")
                frm_add.ComboBox1.Items.Add("Лекции")
                frm_add.ComboBox1.Items.Add("Билеты")
                frm_add.ComboBox1.Items.Add("Тесты (AIST)")
                frm_add.ComboBox1.Items.Add("Тесты")
                frm_add.ComboBox1.Text = "Выберите..."
            Case 2
                frm_add.ComboBox2.Items.Clear()
                frm_add.ComboBox2.Enabled = True
                frm_add.ComboBox2.Items.Add("Метод. указания")
                frm_add.ComboBox2.Items.Add("Раб.программа")
                frm_add.ComboBox2.Items.Add("Лекции")
                frm_add.ComboBox2.Items.Add("Билеты")
                frm_add.ComboBox2.Items.Add("Тесты (AIST)")
                frm_add.ComboBox2.Items.Add("Тесты")
                frm_add.ComboBox2.Text = "Выберите..."
            Case 3
                frm_info.lst_type.Items.Clear()
                frm_info.lst_type.Enabled = True
                frm_info.lst_type.Items.Add("Метод. указания")
                frm_info.lst_type.Items.Add("Раб.программа")
                frm_info.lst_type.Items.Add("Лекции")
                frm_info.lst_type.Items.Add("Билеты")
                frm_info.lst_type.Items.Add("Тесты (AIST)")
                frm_info.lst_type.Items.Add("Тесты")
        End Select

        'For i = 0 To frm_res.lst_text_file.Items.Count - 1
        'temp = Split(frm_res.lst_text_file.Items.Item(i), "=")
        ' frm_res.lst_filetypes.Items.Add(temp(1))
        ' c_temp = ReplaceAll(temp(1), " ", "")
        ' temp2 = Split(c_temp, ",")
        ' umk_filenames(i) = temp2(0)
        ' umk_filenames_prefix(i) = temp2(1)
        ' Select Case list_code
        'Case 0
        '   frm_add.ComboBox1.Items.Add(temp2(0) & " " & temp2(1))
        '    frm_add.ComboBox2.Items.Add(temp2(0) & " " & temp2(1))
        '     frm_info.lst_type.Items.Add(temp2(0) & " " & temp2(1))
        ' Case 1
        '    frm_add.ComboBox1.Items.Add(temp2(0) & " " & temp2(1))
        'Case 2
        '     frm_add.ComboBox2.Items.Add(temp2(0) & " " & temp2(1))
        ' Case 3
        '       frm_info.lst_type.Items.Add(temp2(0) & " " & temp2(1))
        ' End Select
        'Next
        Select Case list_code
            Case 0
                frm_add.ComboBox1.Text = "Выберите..."
                frm_add.ComboBox2.Text = "Выберите..."
            Case 1
                frm_add.ComboBox1.Text = "Выберите..."
            Case 2
                frm_add.ComboBox2.Text = "Выберите..."
        End Select
    End Sub

End Module
