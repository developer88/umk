Module mdl_add

    Public Sub open_doc_file(ByVal doc_path As String)
        Dim p As New Process()
        p.StartInfo.FileName = "winword.exe"
        p.StartInfo.Arguments = """" & doc_path & """"
        p.Start()
    End Sub

    Public Sub load_file_styles_list()
        Dim temp() As String
        Dim temp2() As String
        Dim i As Integer
        'Dim c_temp As String
        If read_from_text_file_byline(Application.StartupPath & "\configs\file_presets.ini") = 0 Then
            'show_error_message(0, True)
            Exit Sub
        End If
        If frm_res.lst_text_file.Items.Count = 0 Then
            'show_error_message(0, True)
            Exit Sub
        End If
        file_styles_caption.Clear()
        file_styles_description.Clear()
        file_styles_filename.Clear()
        frm_add.ListBox1.Items.Clear()
        For i = 0 To frm_res.lst_text_file.Items.Count - 1
            temp = Split(frm_res.lst_text_file.Items.Item(i), "=")
            'frm_res.lst_filetypes.Items.Add(temp(1))
            'c_temp = ReplaceAll(temp(1), " ", "")
            temp2 = Split(temp(1), ";")
            'temp2 = Split(c_temp, ";")
            file_styles_caption.Add(temp2(0))
            file_styles_filename.Add(temp2(1))
            file_styles_description.Add(temp2(2))
            frm_add.ListBox1.Items.Add(temp2(0))
        Next
        create_file = False
        frm_add.ComboBox2.Text = "Выберите..."
    End Sub

    Public Sub close_add_form()
        'unit
        frm_add.gb_unit.Visible = False
        frm_add.TextBox1.Text = ""
        frm_add.TextBox2.Text = ""
        frm_add.TextBox3.Text = ""
        'caf
        frm_add.gb_caf.Visible = False
        frm_add.TextBox5.Text = ""
        frm_add.TextBox6.Text = ""
        'umk
        frm_add.gb_umk.Visible = False
        frm_add.TextBox4.Text = ""
        frm_add.TextBox7.Text = ""
        frm_add.TextBox8.Text = ""
        'add files to UMK
        frm_add.gb_add_choise.Visible = False
        frm_add.gb_add.Visible = False
        frm_add.btn_apply.Visible = False
        frm_add.TextBox11.Text = ""
        frm_add.TextBox9.Text = ""
        load_file_types_list(1)
        load_file_types_list(2)
        frm_add.btn_apply.Text = "Создать"
        'create file
        frm_add.ListBox1.Items.Clear()
        frm_add.TextBox12.Text = "Новый_файл"
        load_file_styles_list()
        frm_add.gb_create_file.Visible = False
        frm_add.gb_file_style.Visible = False
        create_file = False
        frm_add.CheckBox1.Checked = False
        frm_add.ComboBox1.Enabled = True
        frm_add.ComboBox2.Enabled = True
        'drag_n_drop
        frm_add.gb_drag_n_drop.Visible = False
        'frm_add.gb_drag_n_drop.Left = 485
        'frm_add.gb_drag_n_drop.Top = 255
        frm_add.Label5.Visible = False
        frm_add.lbl_show.Visible = False
        add_drag_used = False
        'other
        cur_add_type = 0
        frm_add.gb_wait.Visible = False
        frm_add.lbl_umk.Visible = False
        frm_add.lbl_delete_umk_dnd.Visible = False
        frm_add.btn_apply.Visible = False
        add_drag_enabled = False
        add_drag_used = False
        frm_add.Close()
        'back_add.Hide()
    End Sub

    Public Sub show_create_dialog(ByVal type_number As Integer, ByVal drag_show As Boolean, ByVal combo_select_text As String)
        add_drag_enabled = True
        frm_add.gb_drag_n_drop.Visible = True
        frm_add.gb_drag_n_drop.Width = frm_add.gb_unit.Width
        frm_add.gb_drag_n_drop.Height = frm_add.gb_unit.Height
        frm_add.gb_wait.Visible = False
        add_drag_enabled = True
        Select Case type_number
            Case 0 ' unit
                frm_add.Text = "Новое подразделение"
                frm_add.gb_unit.Visible = True
                frm_add.img_add_logo.Image = frm_add.img_unit.Image
                frm_add.lbl_add_text.Text = frm_add.lst_text.Items.Item(0)
                frm_add.Label5.Visible = True
                frm_add.lbl_show.Visible = True
                frm_add.gb_unit.Top = frm_add.gb_drag_n_drop.Top
                frm_add.gb_unit.Left = frm_add.gb_drag_n_drop.Left
            Case 1 ' caf
                frm_add.Text = "Новая Кафедра"
                frm_add.gb_caf.Visible = True
                frm_add.gb_caf.Top = frm_add.gb_drag_n_drop.Top
                frm_add.gb_caf.Left = frm_add.gb_drag_n_drop.Left
                frm_add.img_add_logo.Image = frm_add.img_unit.Image
                frm_add.lbl_add_text.Text = frm_add.lst_text.Items.Item(1)
                frm_add.Label5.Visible = True
                frm_add.lbl_show.Visible = True
            Case 2 'umk
                frm_add.Text = "Новое УМК"
                frm_add.gb_umk.Visible = True
                frm_add.gb_umk.Top = frm_add.gb_drag_n_drop.Top
                frm_add.gb_umk.Left = frm_add.gb_drag_n_drop.Left
                frm_add.img_add_logo.Image = frm_add.img_unit.Image
                frm_add.lbl_add_text.Text = frm_add.lst_text.Items.Item(2)
                frm_add.Label5.Visible = True
                frm_add.lbl_show.Visible = True
            Case 3 'add files to UMK
                frm_add.gb_drag_n_drop.Visible = False
                frm_add.gb_add_choise.Top = frm_add.gb_drag_n_drop.Top
                frm_add.gb_add_choise.Left = frm_add.gb_drag_n_drop.Left
                frm_add.lbl_add_text.Text = frm_add.lst_text.Items.Item(5)
                frm_add.Text = "Добавить файлы в УМК"
                frm_add.gb_add.Visible = True
                frm_add.btn_apply.Visible = False
                frm_add.btn_apply.Text = "Добавить"
                frm_add.Label24.Text = ""
                frm_add.TextBox12.Text = "Новый_файл"
                frm_add.Label5.Visible = False
                frm_add.lbl_show.Visible = False
                If drag_show = False Then
                    frm_add.gb_add_choise.Visible = False
                Else
                    frm_add.gb_add_choise.Visible = True
                End If
        End Select
        frm_add.gb_drag_n_drop.AllowDrop = True
        cur_add_type = type_number
        'add_drag_enabled = False
        'add_drag_used = False
        frm_add.Width = 433
        frm_add.Height = 399
        load_file_styles_list()
        load_file_types_list(2)
        load_file_types_list(1)
        update_sessions_obj(1)
        If drag_show = False Then
            frm_add.gb_drag_n_drop.Visible = False
            'gb_drag_n_drop.Left = 485
            'gb_drag_n_drop.Top = 255
            add_drag_enabled = False
            frm_add.lbl_show.Text = "автоматическому виду"
            frm_add.gb_drag_n_drop.Visible = False
            If type_number = 3 Then
                frm_add.btn_apply.Visible = True
                frm_add.img_add_logo.Image = frm_add.img_add_file.Image
                frm_add.lbl_add_text.Text = frm_add.lst_text.Items.Item(3)
                frm_add.gb_add.Top = 122
                frm_add.gb_add.Left = 11
                frm_add.gb_add.Visible = True
                frm_add.Label5.Visible = True
                frm_add.lbl_show.Visible = True
            End If
        Else
            frm_add.lbl_show.Text = "стандартному виду"
        End If
        If Len(combo_select_text) > 0 Then
            frm_add.ComboBox1.Text = combo_select_text
            frm_add.ComboBox1.SelectedValue = combo_select_text
            frm_add.ComboBox1.SelectedText = combo_select_text
            frm_add.ComboBox1.SelectedItem = combo_select_text
        End If
        frm_add.ShowDialog()
    End Sub

    Public Sub do_drag(ByVal path As String)
        Select Case cur_add_type
            Case 0
                frm_add.TextBox1.Text = get_filename(path)
                frm_add.lbl_umk.Text = "Будет скопировано из папки: " & get_filename(path)
                frm_add.ToolTip1.SetToolTip(frm_add.lbl_umk, get_filename(path))
                frm_add.lbl_umk.Visible = True
                frm_add.lbl_delete_umk_dnd.Visible = True
            Case 1
                frm_add.TextBox6.Text = get_filename(path)
                frm_add.lbl_umk.Text = "Будет скопировано из папки: " & get_filename(path)
                frm_add.ToolTip1.SetToolTip(frm_add.lbl_umk, get_filename(path))
                frm_add.lbl_umk.Visible = True
                frm_add.lbl_delete_umk_dnd.Visible = True
            Case 2
                frm_add.TextBox7.Text = get_filename(path)
                frm_add.lbl_umk.Text = "Будет скопировано УМК из папки: " & get_filename(path)
                frm_add.ToolTip1.SetToolTip(frm_add.lbl_umk, get_filename(path))
                frm_add.lbl_umk.Visible = True
                frm_add.lbl_delete_umk_dnd.Visible = True
            Case 3
                If create_file = False Then frm_add.TextBox11.Text = path
        End Select
        frm_add.gb_drag_n_drop.Visible = False
        add_drag_enabled = False
        add_drag_used = True
    End Sub


End Module
