Module mdl_info

    Public Sub update_info_var(ByVal mode_code As Integer)
        If mode_code = 1 Then 'info pan
            If Form1.txt_info_1.Text <> info_var(0) Then info_var(0) = Form1.txt_info_1.Text
            If Form1.txt_info_2.Text <> info_var(1) Then info_var(1) = Form1.txt_info_2.Text
            If Form1.txt_info_3.Text <> info_var(2) Then info_var(2) = Form1.txt_info_3.Text
            'If Form1.txt_info_4.Text <> info_var(3) Then info_var(3) = Form1.txt_info_4.Text
        ElseIf mode_code = 2 Then 'info form
            If frm_info.txt_name.Text <> info_var(0) Then info_var(0) = frm_info.txt_name.Text
            If cur_infopanel_type = 4 Then
                If frm_info.lst_type.Text <> info_var(1) Then info_var(1) = frm_info.lst_type.Text
                If frm_info.txt1.Text <> info_var(3) Then info_var(3) = frm_info.txt1.Text
            ElseIf cur_infopanel_type = 3 Then
                If frm_info.chk_info1.Checked = True Then info_var(5) = "1" Else info_var(5) = "0"
                If frm_info.chk_info2.Checked = True Then info_var(6) = "1" Else info_var(6) = "0"
                If frm_info.chk_info3.Checked = True Then info_var(7) = "1" Else info_var(7) = "0"
                If frm_info.chk_info4.Checked = True Then info_var(8) = "1" Else info_var(8) = "0"
                If frm_info.txt1.Text <> info_var(1) Then info_var(1) = frm_info.txt1.Text
                If frm_info.txt3.Text <> info_var(3) Then info_var(3) = frm_info.txt3.Text
            Else
                If frm_info.txt3.Text <> info_var(3) Then info_var(3) = frm_info.txt3.Text
                If frm_info.txt1.Text <> info_var(1) Then info_var(1) = frm_info.txt1.Text
            End If
            If frm_info.txt5.Text <> info_var(9) Then info_var(9) = frm_info.txt5.Text
            If frm_info.txt4.Text <> info_var(4) Then info_var(4) = frm_info.txt4.Text
            If frm_info.txt2.Text <> info_var(2) Then info_var(2) = frm_info.txt2.Text
        End If
        'MessageBox.Show(info_var(3))
    End Sub

    Public Sub load_info(ByVal path As String, ByVal cur_type As Integer)
        Dim i As Integer
        Dim temp1() As String
        frm_res.lst_text_file.Items.Clear()
        read_from_text_file_byline(path)
        If frm_res.lst_text_file.Items.Count <= 0 Then Exit Sub
        Select Case cur_type
            Case 1 'unit
                info_var_captions(0) = "Подразделение:"
                info_var_type(2) = "text"
                info_var_captions(2) = "Отв. за УМК:"
                info_var_type(1) = "text"
                info_var_captions(1) = "Начальник:"
                For i = 0 To frm_res.lst_text_file.Items.Count - 1
                    temp1 = Split(frm_res.lst_text_file.Items.Item(i), "=")
                    Select Case temp1(0)
                        Case "chief"
                            info_var(1) = temp1(1)
                        Case "sub_chief"
                            info_var(2) = temp1(1)
                    End Select
                Next
            Case 2 'caf
                info_var_captions(0) = "Кафедра:"
                info_var_type(1) = "text"
                info_var_captions(1) = "Заведующий кафедры:"
                For i = 0 To frm_res.lst_text_file.Items.Count - 1
                    temp1 = Split(frm_res.lst_text_file.Items.Item(i), "=")
                    Select Case temp1(0)
                        Case "chief"
                            info_var(1) = temp1(1)
                    End Select
                Next
            Case 3 'umk
                info_var_type(1) = "text"
                info_var_captions(1) = "Автор УМК:"
                info_var_type(2) = "text"
                info_var_captions(2) = "Закреплено за:"
                info_var_type(3) = "text"
                info_var_captions(3) = "Кол-во лекций:"
                info_var_type(4) = "text"
                info_var_captions(4) = "Кол-во часов:"
                info_var_captions(0) = "УМК:"


                info_var_type(5) = "check"
                info_var_captions(5) = "Экзамен"
                info_var_type(6) = "check"
                info_var_captions(6) = "Зачёт"
                info_var_type(7) = "check"
                info_var_captions(7) = "Контрольная работа"
                info_var_type(8) = "check"
                info_var_captions(8) = "Курсовой проект"

                info_var_type(9) = "text"
                info_var_captions(9) = "Шифр:"


                For i = 0 To frm_res.lst_text_file.Items.Count - 1
                    temp1 = Split(frm_res.lst_text_file.Items.Item(i), "=")
                    Select Case temp1(0)
                        Case "author"
                            info_var(1) = temp1(1)
                        Case "chief"
                            info_var(2) = temp1(1)
                        Case "lectures"
                            info_var(3) = temp1(1)
                        Case "hours"
                            info_var(4) = temp1(1)

                        Case "exam"
                            info_var(5) = temp1(1)
                        Case "test"
                            info_var(6) = temp1(1)
                        Case "examination"
                            info_var(7) = temp1(1)
                        Case "prj"
                            info_var(8) = temp1(1)
                        Case "code"
                            info_var(9) = temp1(1)
                    End Select
                Next
            Case 4 'file
                info_var_type(1) = "type"
                info_var_captions(1) = "Тип файла:"
                info_var_type(2) = "text"
                info_var_captions(2) = "Теги:"
                info_var_type(3) = "text"
                info_var_captions(3) = "Для курса(ов):"
                'info_var(1) = ""
                'info_var(2) = ""
                info_var_captions(0) = "Файл:"
                For i = 0 To frm_res.lst_text_file.Items.Count - 1
                    temp1 = Split(frm_res.lst_text_file.Items.Item(i), "=")
                    Select Case temp1(0)
                        Case "file_type"
                            info_var(1) = temp1(1)
                        Case "course"
                            info_var(3) = temp1(1)
                        Case "tags"
                            info_var(2) = temp1(1)
                    End Select
                Next
        End Select
    End Sub

    Public Sub update_info(ByVal cur_type As Integer)
        Dim t_path As String = ""
        If info_name <> info_var(0) Then
            If cur_type = 4 Then
                rename_unit(info_name, info_var(0), create_path(cur_type), False, True)
            Else
                rename_unit(info_name, info_var(0), create_path(cur_type), False, False)
            End If
        End If
        clear_command_list()
        t_path = create_path(cur_type)
        Select Case cur_type
            Case 1 'unit
                add_to_command_list("type=unit")
                add_to_command_list("chief=" & info_var(1))
                add_to_command_list("sub_chief=" & info_var(2))
                write_to_info_file(UMK_dir & "\" & info_var(0) & "\info.dat")
            Case 2 'caf
                add_to_command_list("type=caf")
                add_to_command_list("chief=" & info_var(1))
                ' MessageBox.Show(t_path)
                write_to_info_file(UMK_dir & "\" & t_path & "\" & info_var(0) & "\info.dat")
            Case 3 'umk
                add_to_command_list("type=umk")
                add_to_command_list("author=" & info_var(1))
                add_to_command_list("chief=" & info_var(2))
                add_to_command_list("lectures=" & info_var(3))
                add_to_command_list("hours=" & info_var(4))
                add_to_command_list("exam=" & info_var(5))
                add_to_command_list("test=" & info_var(6))
                add_to_command_list("examination=" & info_var(7))
                add_to_command_list("prj=" & info_var(8))
                add_to_command_list("code=" & info_var(9))
                'MessageBox.Show(t_path)
                write_to_info_file(UMK_dir & "\" & t_path & "\" & info_var(0) & "\info.dat")
            Case 4 'umk file
                'MessageBox.Show(info_var(3))
                add_to_command_list("file_type=" & info_var(1))
                'add_to_command_list("file_type_code=" & ComboBox1.SelectedIndex)
                add_to_command_list("type=umk_file")
                add_to_command_list("course=" & info_var(3))
                add_to_command_list("tags=" & info_var(2))
                write_to_info_file(UMK_dir & "\" & t_path & "\" & info_var(0) & ".info")
        End Select
        If search_initialised = False Then
            show_unit()
        Else
            Form1.dg.CurrentRow.Cells(0).Value = info_var(0)
        End If
    End Sub

    Public Sub clear_info_form()
        clear_info_lists()
        frm_info.Close()
        load_file_types_list(3)
        With frm_info
            .PictureBox6.Image = frm_res.PictureBox45.Image
            .Label1.Visible = False
            .lst_type.Visible = False
            .lst_type.Text = ""
            .Label2.Visible = False
            .lbl1.Visible = False
            .lbl2.Visible = False
            .lbl_type.Text = ""
            .txt_date.Text = ""
            .txt_editdate.Text = ""
            .txt_name.Text = ""
            .txt_size.Text = ""
            .lbl3.Visible = False
            .lbl4.Visible = False
            .lbl5.Visible = False
            .lbl6.Visible = False
            .txt1.Visible = False
            .txt2.Visible = False
            .txt3.Visible = False
            .txt4.Visible = False
            .txt5.Visible = False
            .txt6.Visible = False
            .txt_size.Visible = False
            .Label8.Visible = False
            .Label11.Visible = False
            .chk_info1.Visible = False
            .chk_info2.Visible = False
            .chk_info3.Visible = False
            .chk_info4.Visible = False
        End With
    End Sub

    Public Function get_obj_type(ByVal path As String) As Integer
        read_from_text_file_byline(path)
        If frm_res.lst_text_file.Items.Count <= 0 Then
            get_obj_type = 0
            Exit Function
        End If
        Dim temp1() As String
        Dim temp_int As Integer = 0
        get_obj_type = temp_int
        For i = 0 To frm_res.lst_text_file.Items.Count - 1
            temp1 = Split(frm_res.lst_text_file.Items.Item(i), "=")
            If temp1(0) = "type" Then
                Select Case temp1(1)
                    Case "umk"
                        get_obj_type = 3
                    Case "umk_file"
                        get_obj_type = 4
                    Case "caf"
                        get_obj_type = 2
                    Case "unit"
                        get_obj_type = 1
                End Select
            End If
        Next
    End Function

    Public Sub show_info_form(ByVal cur_type As Integer, ByVal is_file As Boolean, ByVal unit_name As String, ByVal cur_path As String)
        Dim i As Integer
        Dim myIcon As System.Drawing.Icon
        clear_info_form()
        If cur_type = 0 Then
            If is_file = True Then
                cur_type = get_obj_type(UMK_dir & "\" & cur_path & ".info")
            Else
                cur_type = get_obj_type(UMK_dir & "\" & cur_path & "\info.dat")
            End If
        End If
        If cur_type > 0 Then
            Select Case cur_type
                Case 1 'unit
                    load_info(UMK_dir & "\" & cur_path & "\info.dat", 1)
                    info_name = unit_name
                    info_var(0) = unit_name
                    myIcon = get_icon(UMK_dir & "\" & cur_path, "big")
                    With frm_info
                        .Label1.Visible = True
                        .PictureBox6.Image = myIcon.ToBitmap()
                        .lbl_type.Text = ReplaceAll(info_var_captions(0), ":", "")
                        .txt_name.Text = unit_name
                        .lbl1.Visible = True
                        .lbl1.Text = info_var_captions(1)
                        .txt1.Visible = True
                        .txt1.Text = info_var(1)
                        .txt1.Tag = info_var_type(1)
                        .lbl2.Visible = True
                        .txt2.Visible = True
                        .lbl2.Text = info_var_captions(2)
                        .txt2.Tag = info_var_type(2)
                        .txt2.Text = info_var(2)
                        '-----
                        .txt_date.Text = get_dir_info(UMK_dir & "\" & cur_path, False, 1)
                        .txt_editdate.Text = get_dir_info(UMK_dir & "\" & cur_path, False, 3)
                        .txt_size.Visible = False
                        .Label8.Visible = False
                        '-----
                    End With
                Case 2 'caf
                    load_info(UMK_dir & "\" & cur_path & "\info.dat", 2)
                    info_name = unit_name
                    info_var(0) = unit_name
                    myIcon = get_icon(UMK_dir & "\" & cur_path, "big")
                    With frm_info
                        .Label1.Visible = True
                        .PictureBox6.Image = myIcon.ToBitmap()
                        .lbl_type.Text = ReplaceAll(info_var_captions(0), ":", "")
                        .txt_name.Text = unit_name
                        .lbl1.Visible = True
                        .lbl1.Text = "Заведующий:"
                        '.lbl1.Text = info_var_captions(1)
                        .txt1.Visible = True
                        .txt1.Text = info_var(1)
                        .txt1.Tag = info_var_type(1)
                        '-----
                        .txt_date.Text = get_dir_info(UMK_dir & "\" & cur_path, False, 1)
                        .txt_editdate.Text = get_dir_info(UMK_dir & "\" & cur_path, False, 3)
                        .txt_size.Visible = False
                        .Label8.Visible = False
                    End With
                Case 3 'umk
                    load_info(UMK_dir & "\" & cur_path & "\info.dat", 3)
                    info_name = unit_name
                    info_var(0) = unit_name
                    myIcon = get_icon(UMK_dir & "\" & cur_path, "big")
                    With frm_info
                        .Label1.Visible = True
                        .PictureBox6.Image = myIcon.ToBitmap()
                        .lbl_type.Text = ReplaceAll(info_var_captions(0), ":", "")
                        .txt_name.Text = unit_name
                        .lbl1.Visible = True
                        '.lbl1.Text = info_var_captions(1)
                        .lbl1.Text = "Автор УМК:"
                        .txt1.Visible = True
                        .txt1.Text = info_var(1)
                        .txt1.Tag = info_var_type(1)
                        .lbl2.Visible = True
                        .txt2.Visible = True
                        '.lbl2.Text = info_var_captions(2)
                        .lbl2.Text = "Закреплено за:"
                        .txt2.Tag = info_var_type(2)
                        .txt2.Text = info_var(2)
                        .lbl3.Visible = True
                        .txt3.Visible = True
                        '.lbl3.Text = info_var_captions(3)
                        .lbl3.Text = "Кол-во лекций:"
                        .lbl3.Tag = info_var_type(3)
                        .txt3.Text = info_var(3)
                        .lbl4.Visible = True
                        .txt4.Visible = True
                        '.lbl4.Text = info_var_captions(4)
                        .lbl4.Text = "Кол-во часов:"
                        .lbl4.Tag = info_var_type(4)
                        .txt4.Text = info_var(4)
                        .lbl5.Visible = True
                        .txt5.Visible = True
                        .lbl5.Text = "Шифр:"
                        .lbl5.Tag = info_var_type(9)
                        .txt5.Text = info_var(9)
                        .Label11.Visible = True



                        'info_var_captions(0) = "УМК:"



                        .chk_info1.Visible = True
                        .chk_info1.Tag = info_var_type(5)
                        ' .chk_info1.Text = info_var_captions(5)
                        .chk_info1.Text = "Экзамен"
                        If info_var(5) = "1" Then .chk_info1.Checked = True Else .chk_info1.Checked = False
                        .chk_info2.Visible = True
                        .chk_info2.Tag = info_var_type(6)
                        '.chk_info2.Text = info_var_captions(6)
                        .chk_info2.Text = "Зачёт"
                        If info_var(6) = "1" Then .chk_info2.Checked = True Else .chk_info2.Checked = False
                        .chk_info3.Visible = True
                        .chk_info3.Tag = info_var_type(7)
                        '.chk_info3.Text = info_var_captions(7)
                        .chk_info3.Text = "Контрольная работа"
                        If info_var(7) = "1" Then .chk_info3.Checked = True Else .chk_info3.Checked = False
                        .chk_info4.Visible = True
                        ' .chk_info4.Tag = info_var_type(8)
                        .chk_info4.Text = "Курсовой проект"
                        .chk_info4.Text = info_var_captions(8)
                        If info_var(8) = "1" Then .chk_info4.Checked = True Else .chk_info4.Checked = False



                        '-----
                        .txt_date.Text = get_dir_info(UMK_dir & "\" & cur_path, False, 1)
                        .txt_editdate.Text = get_dir_info(UMK_dir & "\" & cur_path, False, 3)
                        .txt_size.Visible = False
                        .Label8.Visible = False
                    End With
                Case 4 'umk file
                    load_info(UMK_dir & "\" & cur_path & ".info", 4)
                    info_name = unit_name
                    info_var(0) = unit_name
                    myIcon = get_icon(UMK_dir & "\" & cur_path, "big")
                    With frm_info
                        .PictureBox6.Image = myIcon.ToBitmap()
                        .lbl_type.Text = ReplaceAll(info_var_captions(0), ":", "")
                        .txt_name.Text = unit_name
                        .lst_type.Visible = True
                        .Label2.Visible = True
                        .lst_type.Text = ""
                        For i = 0 To frm_info.lst_type.Items.Count - 1
                            If frm_info.lst_type.Items.Item(i) = info_var(1) Then frm_info.lst_type.SelectedIndex = i
                        Next
                        .lbl2.Visible = True
                        .txt2.Visible = True
                        .lbl2.Text = info_var_captions(2)
                        .txt2.Tag = info_var_type(2)
                        .txt2.Text = info_var(2)
                        .lbl1.Visible = True
                        .txt1.Visible = True
                        .txt1.Text = info_var(3)
                        .lbl1.Text = info_var_captions(3)
                        .txt1.Tag = info_var_type(3)
                        '-----
                        .txt_date.Text = get_dir_info(UMK_dir & "\" & cur_path, True, 1)
                        .txt_editdate.Text = get_dir_info(UMK_dir & "\" & cur_path, True, 3)
                        .txt_size.Visible = True
                        .Label8.Visible = True
                        .txt_size.Text = get_dir_info(UMK_dir & "\" & cur_path, True, 4) & " Кб"
                    End With
            End Select
        Else
            clear_info_form()
            info_name = unit_name
            info_var(0) = unit_name
            myIcon = get_icon(UMK_dir & "\" & cur_path, "big")
            With frm_info
                .PictureBox6.Image = myIcon.ToBitmap()
                .lbl_type.Text = "Название:"
                .txt_name.Text = unit_name
                .txt_name.Enabled = False
                '-----
                .txt_date.Text = get_dir_info(UMK_dir & "\" & cur_path, False, 1)
                .txt_editdate.Text = get_dir_info(UMK_dir & "\" & cur_path, False, 3)
                .txt_size.Visible = False
                .Label8.Visible = False
                .txt_date.Text = get_dir_info(UMK_dir & "\" & cur_path, True, 1)
                .txt_editdate.Text = get_dir_info(UMK_dir & "\" & cur_path, True, 3)
                .txt_size.Visible = True
                .Label8.Visible = True
                .btn_ok.Enabled = False
                .btn_ok.Visible = False
            End With
        End If
        cur_infopanel_type = cur_type
        frm_info.ShowDialog()
    End Sub

    Public Sub show_info_panel(ByVal cur_type As Integer, ByVal unit_name As String)
        clear_info_panel()
        Dim myIcon As System.Drawing.Icon
        Select Case cur_type
            Case 1
                load_info(UMK_dir & "\" & unit_name & "\info.dat", 1)
                info_name = unit_name
                info_var(0) = unit_name
                myIcon = get_icon(UMK_dir & "\" & unit_name, "small")
                With Form1
                    .PictureBox15.Image = myIcon.ToBitmap()
                    .Label5.Text = "Подразделение"
                    .ToolTip1.SetToolTip(Form1.Label5, "Подразделение")
                    .Label5.Visible = True
                    'name
                    '.lbl_info_1.Visible = True
                    '.lbl_info_1.Text = get_short_string(15, info_var_captions(0))
                    .txt_info_1.Text = unit_name
                    .txt_info_1.Visible = True
                    'chief
                    .lbl_info_2.Visible = True
                    .lbl_info_2.Text = get_short_string(15, info_var_captions(1))
                    .lbl_info_2.Tag = info_var_type(1)
                    .txt_info_2.Text = info_var(1)
                    .txt_info_2.Visible = True
                    'umk_chief
                    .lbl_info_3.Visible = True
                    .lbl_info_3.Text = get_short_string(15, info_var_captions(2))
                    .txt_info_3.Text = info_var(2)
                    .lbl_info_3.Tag = info_var_type(2)
                    .txt_info_3.Visible = True
                    'folder_date
                    .lbl_info_date2.Visible = True
                    .lbl_info_date.Visible = True
                    .lbl_info_date.Text = get_dir_info(UMK_dir & "\" & unit_name, False, 1)
                End With
            Case 2
                load_info(UMK_dir & "\" & UNIT_path & "\" & unit_name & "\info.dat", 2)
                info_name = unit_name
                info_var(0) = unit_name
                myIcon = get_icon(UMK_dir & "\" & UNIT_path & "\" & unit_name, "small")
                With Form1
                    .PictureBox15.Image = myIcon.ToBitmap()
                    .Label5.Text = "Кафедра"
                    .ToolTip1.SetToolTip(Form1.Label5, "Кафедра")
                    .Label5.Visible = True
                    'name
                    '.lbl_info_1.Visible = True
                    '.lbl_info_1.Text = info_var_captions(0)
                    .txt_info_1.Text = unit_name
                    .txt_info_1.Visible = True
                    'chief
                    .lbl_info_2.Visible = True
                    .lbl_info_2.Text = get_short_string(15, info_var_captions(1))
                    .lbl_info_2.Tag = info_var_type(1)
                    .txt_info_2.Text = info_var(1)
                    .txt_info_2.Visible = True
                    'folder_date
                    .lbl_info_date2.Visible = True
                    .lbl_info_date.Visible = True
                    .lbl_info_date.Text = get_dir_info(UMK_dir & "\" & UNIT_path & "\" & unit_name, False, 1)
                End With
            Case 3
                load_info(UMK_dir & "\" & UNIT_path & "\" & CAF_path & "\" & unit_name & "\info.dat", 3)
                info_name = unit_name
                info_var(0) = unit_name
                myIcon = get_icon(UMK_dir & "\" & UNIT_path & "\" & CAF_path & "\" & unit_name, "small")
                With Form1
                    .Label5.Text = "УМК"
                    .PictureBox15.Image = myIcon.ToBitmap()
                    .ToolTip1.SetToolTip(Form1.Label5, "УМК")
                    .Label5.Visible = True
                    'name
                    '.lbl_info_1.Visible = True
                    '.lbl_info_1.Text = get_short_string(15, info_var_captions(0))
                    .txt_info_1.Text = unit_name
                    .txt_info_1.Visible = True
                    'author
                    .lbl_info_2.Visible = True
                    '.lbl_info_2.Text = get_short_string(15, info_var_captions(1))
                    .lbl_info_2.Text = "Автор УМК:"
                    .lbl_info_2.Tag = info_var_type(1)
                    .txt_info_2.Text = info_var(1)
                    .txt_info_2.Visible = True
                    'chief
                    .lbl_info_3.Visible = True
                    ' .lbl_info_3.Text = get_short_string(15, info_var_captions(2))
                    .lbl_info_3.Text = "Закреплено за:"
                    .lbl_info_3.Tag = info_var_type(2)
                    .txt_info_3.Text = info_var(2)
                    .txt_info_3.Visible = True
                    'lectures
                    '.lbl_info_4.Visible = True
                    '.lbl_info_4.Text = get_short_string(15, info_var_captions(3))
                    '.lbl_info_4.Tag = info_var_type(3)
                    '.txt_info_4.Text = info_var(3)
                    '.txt_info_4.Visible = True
                    'hour
                    '.lbl_info_2.Visible = True
                    '.lbl_info_2.Text = get_short_string(15, info_var_captions(4))
                    '.lbl_info_2.Tag = info_var_type(4)
                    '.txt_info_2.Text = info_var(4)
                    '.txt_info_2.Visible = True
                    'folder_date
                    .lbl_info_date2.Visible = True
                    .lbl_info_date.Visible = True
                    .lbl_info_date.Text = get_dir_info(UMK_dir & "\" & UNIT_path & "\" & CAF_path & "\" & unit_name, False, 1)
                End With
            Case 4
                load_info(UMK_dir & "\" & UNIT_path & "\" & CAF_path & "\" & UMK_path & "\" & unit_name & ".info", 4)
                info_name = unit_name
                info_var(0) = unit_name
                myIcon = get_icon(UMK_dir & "\" & UNIT_path & "\" & CAF_path & "\" & UMK_path & "\" & unit_name, "small")
                With Form1
                    .Label5.Text = "Файл"
                    .PictureBox15.Image = myIcon.ToBitmap()
                    .ToolTip1.SetToolTip(Form1.Label5, "Файл")
                    .Label5.Visible = True
                    'name
                    '.lbl_info_1.Visible = True
                    '.lbl_info_1.Text = get_short_string(15, info_var_captions(0))
                    .txt_info_1.Text = unit_name
                    .txt_info_1.Visible = True
                    'type
                    .txt_info_2.Text = ""
                    .lbl_info_2.Visible = True
                    '.lbl_info_2.Text = get_short_string(15, info_var_captions(1))
                    .lbl_info_2.Text = "Тип файла:"
                    .lbl_info_2.Tag = info_var_type(1)
                    .txt_info_2.Text = info_var(1)
                    .txt_info_2.Refresh()
                    .txt_info_2.Enabled = False
                    .txt_info_2.Visible = True
                    'desk
                    .lbl_info_3.Visible = True
                    '.lbl_info_3.Text = get_short_string(15, info_var_captions(2))
                    .lbl_info_3.Text = "Теги:"
                    .lbl_info_3.Tag = info_var_type(2)
                    .txt_info_3.Text = info_var(2)
                    .txt_info_3.Visible = True
                    'file_date
                    .lbl_info_date2.Visible = True
                    .lbl_info_date.Visible = True
                    .lbl_info_date.Text = get_dir_info(UMK_dir & "\" & UNIT_path & "\" & CAF_path & "\" & UMK_path & "\" & unit_name, True, 1)
                End With
                'load_info_file_types()
        End Select
        cur_info_type = cur_type
        'Form1.gb_info.Visible = True
        Form1.pan_info.Visible = True
    End Sub

    Public Sub clear_info_panel()
        clear_info_lists()
        With Form1
            '.lbl1.Visible = False
            .PictureBox15.Image = frm_res.PictureBox44.Image
            '.lbl_info_1.Visible = False
            .lbl_info_2.Visible = False
            .lbl_info_3.Visible = False
            .lbl_info_4.Visible = False
            .lbl_info_date.Visible = False
            .lbl_info_date2.Visible = False
            .txt_info_1.Text = ""
            .txt_info_2.Text = ""
            .txt_info_3.Text = ""
            .txt_info_4.Text = ""
            .txt_info_1.Enabled = True
            .txt_info_2.Enabled = True
            .txt_info_3.Enabled = True
            .txt_info_4.Enabled = True
            .txt_info_1.Visible = False
            .txt_info_2.Visible = False
            .txt_info_3.Visible = False
            .txt_info_4.Visible = False
            '.lbl2.Visible = False
            '.lbl0.Visible = False
            '.lbl3.Visible = False
            '.lbl4.Visible = False
            .Label5.Visible = False
            .btn_close_pan.Visible = False
            .btn_apply_pan.Visible = False
        End With
    End Sub



End Module
