
Module mdl_form1

    Public Sub change_cur_edit_type(ByVal cur_edit_type_value As Integer)
        cur_edit_type = cur_edit_type_value
        If search_initialised = True Then deinitialize_search()
        Form1.pan_info.Visible = False
        clear_info_panel()
        Select Case cur_edit_type
            Case 0
                Form1.ToolTip1.SetToolTip(Form1.PictureBox6, "Создать подразделение")
                UNIT_path = ""
                CAF_path = ""
                UMK_path = ""
                Form1.PictureBox1.Enabled = False
                Form1.PictureBox1.Image = frm_res.PictureBox23.Image
                Form1.PictureBox1.Refresh()
            Case 1
                Form1.ToolTip1.SetToolTip(Form1.PictureBox6, "Создать кафедру")
                CAF_path = ""
                UMK_path = ""
                Form1.PictureBox1.Enabled = True
                Form1.PictureBox1.Image = frm_res.PictureBox7.Image
                Form1.PictureBox1.Refresh()
            Case 2
                Form1.ToolTip1.SetToolTip(Form1.PictureBox6, "Создать УМК")
                UMK_path = ""
                Form1.PictureBox1.Enabled = True
                Form1.PictureBox1.Image = frm_res.PictureBox7.Image
                Form1.PictureBox1.Refresh()
            Case 3
                Form1.ToolTip1.SetToolTip(Form1.PictureBox6, "Добавить файлы в УМК")
                Form1.PictureBox1.Enabled = True
                Form1.PictureBox1.Image = frm_res.PictureBox7.Image
                Form1.PictureBox1.Refresh()
        End Select
        If use_check = True Then check_for_unexistingfiles()
        check_listbox_status()
    End Sub

    Public Sub show_unit()
        If search_initialised = True Then deinitialize_search()
        If cur_edit_type = 0 Then
            get_dir(UMK_dir)
        Else
            Select Case cur_edit_type
                Case 1
                    get_dir(UMK_dir & "\" & UNIT_path)
                Case 2
                    get_dir(UMK_dir & "\" & UNIT_path & "\" & CAF_path)
                Case 3
                    get_files(UMK_dir & "\" & UNIT_path & "\" & CAF_path & "\" & UMK_path, "*.*")
            End Select
        End If
        disable_controls(False)
        check_listbox_status()
        'If Form1.ListBox1.Items.Count = 0 Then disable_controls(False)
    End Sub

  

    Public Sub show_fast_list()
        Form1.lst_short_list.Items.Clear()
        'If search_initialised = True Then deinitialize_search()
        Select Case cur_show_list
            Case 1 'unit
                If My.Computer.FileSystem.DirectoryExists(UMK_dir) = False Then Exit Sub
                Form1.lst_short_list.Left = Form1.pan_nav.Left
                Form1.lst_short_list.Top = Form1.pan_nav.Top + Form1.lbl_nav_a1.Height
                For Each founddir As String In _
                My.Computer.FileSystem.GetDirectories(UMK_dir)
                    Form1.lst_short_list.Items.Add(get_filename(founddir))
                Next
            Case 2 'caf
                If My.Computer.FileSystem.DirectoryExists(UMK_dir & "\" & UNIT_path) = False Then Exit Sub
                If Form1.lbl_nav_a2.Left + Form1.pan_nav.Left + Form1.lst_short_list.Width > Form1.Width Then
                    Form1.lst_short_list.Left = Form1.pan_nav.Left + Form1.lbl_nav_a2.Left - Form1.lst_short_list.Width + Form1.lbl_nav_a2.Width
                Else
                    Form1.lst_short_list.Left = Form1.pan_nav.Left + Form1.lbl_nav_a2.Left
                End If
                Form1.lst_short_list.Top = Form1.pan_nav.Top + Form1.lbl_nav_a2.Height
                For Each founddir As String In _
                My.Computer.FileSystem.GetDirectories(UMK_dir & "\" & UNIT_path)
                    Form1.lst_short_list.Items.Add(get_filename(founddir))
                Next
            Case 3 'umk
                If My.Computer.FileSystem.DirectoryExists(UMK_dir & "\" & UNIT_path & "\" & CAF_path) = False Then Exit Sub
                If Form1.lbl_nav_a3.Left + Form1.pan_nav.Left + Form1.lst_short_list.Width > Form1.Width Then
                    Form1.lst_short_list.Left = Form1.pan_nav.Left + Form1.lbl_nav_a3.Left - Form1.lst_short_list.Width + Form1.lbl_nav_a3.Width
                Else
                    Form1.lst_short_list.Left = Form1.pan_nav.Left + Form1.lbl_nav_a3.Left
                End If
                Form1.lst_short_list.Top = Form1.pan_nav.Top + Form1.lbl_nav_a3.Height
                For Each founddir As String In _
                My.Computer.FileSystem.GetDirectories(UMK_dir & "\" & UNIT_path & "\" & CAF_path)
                    Form1.lst_short_list.Items.Add(get_filename(founddir))
                Next
        End Select
        Form1.lst_short_list.BringToFront()
        Form1.lst_short_list.Visible = True
    End Sub

    Public Sub check_listbox_status()
        If Len(Form1.ListBox1.Text) = 0 Then disable_controls(False) Else enable_controls(False)
        If search_initialised = True Then deinitialize_search()
        If Len(UNIT_path) > 0 Or Len(Form1.ListBox1.Text) > 0 Or Len(CAF_path) > 0 Or Len(UMK_path) > 0 Or Len(UMK_item) > 0 Then
        Else
            Form1.pan_info.Visible = False
        End If
        update_nav_pan()
    End Sub

    Public Sub add_choise(ByVal newMenu As String, ByVal cur_type As Integer)
        Dim newOption As New ToolStripMenuItem()
        newOption.CheckOnClick = True
        newOption.Text = newMenu
        newOption.Tag = cur_type
        AddHandler newOption.Click, AddressOf Form1.mnu_choise_Click
        Form1.mnu_choise.Items.Add(newOption)
    End Sub

    Public Sub add_info_choise(ByVal newMenu As String, ByVal number_of_item As Integer)
        Dim newOption As New ToolStripMenuItem()
        'newoption.CheckOnClick = True
        newOption.Text = newMenu
        newOption.Tag = number_of_item
        ' AddHandler newOption.Click, AddressOf Form1.mnu_filetypes_Click
        Form1.mnu_filetypes.Items.Add(newOption)
    End Sub

    Public Sub clear_info_choise()
        Form1.mnu_filetypes.Items.Clear()
    End Sub

    Public Sub check_info_choise()
        Select Case cur_edit_type
            Case 0
                show_info_panel(1, UNIT_path)
            Case 1
                If Len(CAF_path) > 0 Then
                    clear_choise()
                    add_choise("Подразделение: " & UNIT_path, 1)
                    add_choise("Кафедра: " & CAF_path, 2)
                    Form1.mnu_choise.Show(Form1.PictureBox7, 0, Form1.PictureBox7.Height)
                Else
                    show_info_panel(1, UNIT_path)
                End If
            Case 2
                If Len(UMK_path) > 0 Then
                    clear_choise()
                    add_choise("Кафедра: " & CAF_path, 2)
                    add_choise("УМК: " & UMK_path, 3)
                    Form1.mnu_choise.Show(Form1.PictureBox7, 0, Form1.PictureBox7.Height)
                Else
                    show_info_panel(2, CAF_path)
                End If
            Case 3
                If Len(UMK_item) > 0 Then
                    clear_choise()
                    add_choise("УМК: " & UMK_path, 3)
                    add_choise("Файл: " & UMK_item, 4)
                    Form1.mnu_choise.Show(Form1.PictureBox7, 0, Form1.PictureBox7.Height)
                Else
                    show_info_panel(3, UMK_path)
                End If
        End Select
    End Sub

    Public Sub disable_controls(ByVal disable_all As Boolean)
        If disable_all = True Then

        End If
        With Form1
            .PictureBox9.Image = frm_res.PictureBox20.Image
            .PictureBox8.Image = frm_res.PictureBox24.Image
            .PictureBox11.Image = frm_res.PictureBox21.Image
            .PictureBox10.Image = frm_res.PictureBox22.Image
            .PictureBox2.Image = frm_res.PictureBox1.Image
            .pct_add_to_cd.Image = frm_res.PictureBox42.Image
            .PictureBox8.Enabled = False
            .PictureBox9.Enabled = False
            .PictureBox10.Enabled = False
            .PictureBox11.Enabled = False
            .PictureBox2.Enabled = False
            .pct_add_to_cd.Enabled = False
        End With
    End Sub

    Public Sub enable_controls(ByVal enable_all As Boolean)
        If enable_all = True Then

        End If
        With Form1
            .PictureBox9.Image = frm_res.PictureBox13.Image
            .PictureBox8.Image = frm_res.PictureBox11.Image
            .PictureBox10.Image = frm_res.PictureBox9.Image
            .PictureBox11.Image = frm_res.PictureBox16.Image
            .pct_add_to_cd.Image = frm_res.PictureBox40.Image
            .PictureBox8.Enabled = True
            .PictureBox9.Enabled = True
            .PictureBox10.Enabled = True
            .PictureBox11.Enabled = True
            .pct_add_to_cd.Enabled = True
            If search_initialised = False Then
                Select Case cur_edit_type
                    Case 0
                        If stat_style_isunit = 1 Then .PictureBox2.Enabled = True : .PictureBox2.Image = frm_res.PictureBox17.Image
                    Case 1
                        If stat_style_iscaf = 1 Then .PictureBox2.Enabled = True : .PictureBox2.Image = frm_res.PictureBox17.Image
                    Case 2
                        If stat_style_isumk = 1 Then .PictureBox2.Enabled = True : .PictureBox2.Image = frm_res.PictureBox17.Image
                End Select
            End If
        End With
    End Sub

    Public Sub update_nav_pan()
        Select Case cur_edit_type
            Case 0
                With Form1
                    '1
                    .lbl_nav_a1.Visible = True
                    .lbl_nav_a1.Left = 0
                    .lbl_nav_a1.Height = .pan_nav.Height - 2
                    .lbl_nav_a1.Top = 0
                    .lbl_nav1.Visible = False
                    '2
                    .lbl_nav2.Visible = False
                    .lbl_nav_a2.Visible = False
                    '3
                    .lbl_nav3.Visible = False
                    .lbl_nav_a3.Visible = False
                End With
            Case 1
                With Form1
                    '1
                    .lbl_nav_a1.Visible = True
                    .lbl_nav_a1.Left = 0
                    .lbl_nav_a1.Height = .pan_nav.Height - 2
                    .lbl_nav_a1.Top = 0
                    .lbl_nav1.Left = .lbl_nav_a1.Width + 2
                    .lbl_nav1.Visible = True
                    .lbl_nav1.AutoSize = True
                    .lbl_nav1.Text = UNIT_path
                    '2
                    .lbl_nav_a2.Visible = True
                    If .lbl_nav1.Width + .lbl_nav_a1.Width > .pan_nav.Width - 60 Then
                        .lbl_nav1.AutoSize = False
                        .lbl_nav1.Width = .pan_nav.Width - .lbl_nav_a1.Width - 4 - .lbl_nav_a2.Width
                        .lbl_nav_a2.Left = .lbl_nav1.Left + 2 + .lbl_nav1.Width
                    Else
                        .lbl_nav_a2.Left = .lbl_nav1.Width + 2 + .lbl_nav_a1.Width
                    End If
                    .lbl_nav_a2.Height = .pan_nav.Height - 2
                    .lbl_nav_a2.Top = 0
                    .lbl_nav2.Visible = False
                    '3
                    .lbl_nav3.Visible = False
                    .lbl_nav_a3.Visible = False
                End With
            Case 2
                With Form1
                    '1
                    .lbl_nav_a1.Visible = True
                    .lbl_nav_a1.Left = 0
                    .lbl_nav_a1.Height = .pan_nav.Height - 2
                    .lbl_nav_a1.Top = 0
                    .lbl_nav1.Left = .lbl_nav_a1.Width + 1
                    .lbl_nav1.Visible = True
                    .lbl_nav1.Text = UNIT_path
                    .lbl_nav1.AutoSize = True
                    '2
                    .lbl_nav_a2.Visible = True
                    .lbl_nav_a2.Left = .lbl_nav1.Width + 2 + .lbl_nav_a1.Width
                    .lbl_nav_a2.Height = .pan_nav.Height - 2
                    .lbl_nav_a2.Top = 0
                    .lbl_nav2.Visible = True
                    .lbl_nav2.Left = .lbl_nav_a2.Left + .lbl_nav_a2.Width + 1
                    .lbl_nav2.Text = CAF_path
                    .lbl_nav2.AutoSize = True
                    '3
                    .lbl_nav_a3.Visible = True
                    .lbl_nav_a3.Height = .pan_nav.Height - 2
                    .lbl_nav_a3.Top = 0
                    .lbl_nav_a3.Left = .lbl_nav2.Width + .lbl_nav2.Left + 1
                    .lbl_nav3.Visible = False


                    If (.lbl_nav2.Width + .lbl_nav_a1.Width + .lbl_nav_a2.Width + .lbl_nav1.Width + 6) > (.pan_nav.Width - 60) Then
                        .lbl_nav1.Visible = False
                        .lbl_nav_a2.Left = .lbl_nav_a1.Width + 2
                        .lbl_nav2.Left = .lbl_nav_a2.Left + .lbl_nav_a2.Width + 2
                        If (.lbl_nav_a2.Width + .lbl_nav2.Width + .lbl_nav_a1.Width + 2) > (.pan_nav.Width - 60) Then
                            .lbl_nav2.AutoSize = False
                            .lbl_nav2.Width = .pan_nav.Width - 6 - .lbl_nav_a1.Width - .lbl_nav_a2.Width - .lbl_nav_a3.Width
                        End If
                        .lbl_nav_a3.Left = .lbl_nav2.Left + 2 + .lbl_nav2.Width
                    End If
                End With
            Case 3
                With Form1
                    '1
                    .lbl_nav_a1.Visible = True
                    .lbl_nav_a1.Left = 0
                    .lbl_nav_a1.Height = .pan_nav.Height - 2
                    .lbl_nav_a1.Top = 0
                    .lbl_nav1.Left = .lbl_nav_a1.Width + 1
                    .lbl_nav1.Visible = True
                    .lbl_nav1.Text = UNIT_path
                    '2
                    .lbl_nav_a2.Visible = True
                    .lbl_nav_a2.Left = .lbl_nav1.Width + 2 + .lbl_nav_a1.Width
                    .lbl_nav_a2.Height = .pan_nav.Height - 2
                    .lbl_nav_a2.Top = 0
                    .lbl_nav2.Visible = True
                    .lbl_nav2.Left = .lbl_nav_a2.Left + .lbl_nav_a2.Width + 1
                    .lbl_nav2.Text = CAF_path
                    '3
                    .lbl_nav_a3.Visible = True
                    .lbl_nav_a3.Left = .lbl_nav2.Width + .lbl_nav2.Left + 1
                    .lbl_nav3.Visible = True
                    .lbl_nav_a3.Top = 0
                    .lbl_nav_a3.Height = .pan_nav.Height - 2
                    .lbl_nav3.Left = .lbl_nav_a3.Left + 1 + .lbl_nav_a3.Width
                    .lbl_nav3.Text = UMK_path
                    If .lbl_nav3.Width + .lbl_nav2.Width + 65 + .lbl_nav1.Width > .pan_nav.Width Then
                        .lbl_nav1.Visible = False
                        .lbl_nav2.Visible = False
                        .lbl_nav_a2.Left = .lbl_nav_a1.Width + 1
                        .lbl_nav_a3.Left = .lbl_nav_a3.Width * 2 + 1
                        .lbl_nav3.Left = .lbl_nav_a1.Width * 3 + 3
                        .lbl_nav3.Width = .pan_nav.Width - .lbl_nav_a1.Width * 3 - 2
                    End If
                End With
        End Select
    End Sub

    Public Sub clear_choise()
        Form1.mnu_choise.Items.Clear()
    End Sub

    Public Sub clear_info_lists()
        For i = 0 To 10
            info_new_var(i) = ""
            info_var(i) = ""
            info_var_captions(i) = ""
            info_var_type(i) = ""
        Next
    End Sub

    Public Sub show_selected_unit(ByVal selected_index As Integer)
        If cur_edit_type = selected_index Then Exit Sub
        Select Case selected_index
            Case 1
                change_cur_edit_type(1)
                CAF_path = ""
                UMK_path = ""
            Case 2
                change_cur_edit_type(2)
                UMK_path = ""
            Case 3
                change_cur_edit_type(3)
        End Select
        show_unit()
        update_nav_pan()
    End Sub

    Public Sub load_sessions_lists()
        Dim temp1() As String
        Dim i1 As Integer
        Dim i As Integer
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\configs\autocomplet_list.inf") = True Then
            read_from_text_file_byline(Application.StartupPath & "\configs\autocomplet_list.inf")
            If frm_res.lst_text_file.Items.Count > 0 Then
                For i = 0 To frm_res.lst_text_file.Items.Count - 1
                    temp1 = Split(ReplaceAll(frm_res.lst_text_file.Items.Item(i), " ", ""), ";")
                    For i1 = 0 To temp1.Count - 1
                        session_other.Add(temp1(i1))
                    Next
                Next
            End If
            update_sessions_obj(0)
        End If
    End Sub

    Public Sub update_sessions_obj(ByVal cur_mode As Integer)
        Select Case cur_mode
            Case 0 'form1
                Form1.TextBox1.AutoCompleteCustomSource = session_other
                Form1.txt_info_1.AutoCompleteCustomSource = session_other
                Form1.txt_info_2.AutoCompleteCustomSource = session_other
                Form1.txt_info_3.AutoCompleteCustomSource = session_other
            Case 1 'frm_add
                frm_add.TextBox1.AutoCompleteCustomSource = session_other
                frm_add.TextBox2.AutoCompleteCustomSource = session_other
                frm_add.TextBox3.AutoCompleteCustomSource = session_other
                '
                frm_add.TextBox4.AutoCompleteCustomSource = session_other
                frm_add.TextBox8.AutoCompleteCustomSource = session_other
                frm_add.TextBox7.AutoCompleteCustomSource = session_other
                '
                frm_add.TextBox9.AutoCompleteCustomSource = session_other
                '
                frm_add.TextBox5.AutoCompleteCustomSource = session_other
                frm_add.TextBox6.AutoCompleteCustomSource = session_other
        End Select
    End Sub

    Public Sub add_to_sessionlist(ByVal str As String)
        If Len(str) < 1 Then Exit Sub
        For i = 0 To session_other.Count - 1
            If str = session_other.Item(i) Then Exit Sub
        Next
        session_other.Add(str)
    End Sub

    Public Function convert_sesioncol_to_string(ByVal cur_coll As AutoCompleteStringCollection) As String
        If cur_coll.Count > 0 Then
            convert_sesioncol_to_string = ""
            For i = 0 To cur_coll.Count - 1
                convert_sesioncol_to_string = convert_sesioncol_to_string & ";" & cur_coll.Item(i)
            Next
            If Left(convert_sesioncol_to_string, 1) = ";" Then convert_sesioncol_to_string = Right(convert_sesioncol_to_string, Len(convert_sesioncol_to_string) - 1)
        Else
            convert_sesioncol_to_string = ""
        End If
    End Function

    Public Sub save_sessions_lists()
        clear_command_list()
        add_to_command_list(convert_sesioncol_to_string(session_other))
        write_to_info_file(Application.StartupPath & "\configs\autocomplet_list.inf")
    End Sub

    Public Sub show_infopan(ByVal status As Boolean)
        If status = True Then
            With Form1
                .Panel_info.Visible = True
                .ListBox1.Height = .Panel_info.Top - .ListBox1.Top
                .dg.Height = .Panel_info.Top - .ListBox1.Top
            End With
        Else
            With Form1
                .Panel_info.Visible = False
                .ListBox1.Height = Form1.Height - .ListBox1.Top - 36
                .dg.Height = Form1.Height - 36 - .dg.Top
            End With
        End If
    End Sub

End Module
