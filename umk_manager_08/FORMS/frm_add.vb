Public Class frm_add



    Private Sub Label16_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label16.MouseLeave
        Label17.ForeColor = Color.Black
        Label16.ForeColor = Color.Black
    End Sub

    Private Sub Label16_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label16.MouseMove
        Label17.ForeColor = Color.Gray
        Label16.ForeColor = Color.Gray
    End Sub

    Private Sub Label17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label17.Click
        add_file()
    End Sub

    Sub add_file()
        gb_add_choise.Visible = False
        'btn_apply.Visible = True
        img_add_logo.Image = img_add_file.Image
        lbl_add_text.Text = lst_text.Items.Item(3)
        gb_drag_n_drop.Visible = True
        gb_add.Visible = True
        gb_add.Top = 122
        gb_add.Left = 11
        Label5.Visible = True
        lbl_show.Visible = True
    End Sub

    Private Sub Label17_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label17.MouseLeave
        Label17.ForeColor = Color.Black
        Label16.ForeColor = Color.Black
    End Sub

    Private Sub Label17_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label17.MouseMove
        Label17.ForeColor = Color.Gray
        Label16.ForeColor = Color.Gray
    End Sub

    Private Sub Label16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label16.Click
        add_file()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim c_temp As String
        If ComboBox1.Text = "Тесты (AIST)" Then
            If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                TextBox11.Text = FolderBrowserDialog1.SelectedPath
            End If
        Else
            OpenFileDialog1.CheckFileExists = True
            OpenFileDialog1.CheckPathExists = True
            OpenFileDialog1.DereferenceLinks = True
            OpenFileDialog1.Filter = "Все файлы|*.*"
            OpenFileDialog1.Multiselect = False
            OpenFileDialog1.RestoreDirectory = True
            OpenFileDialog1.ShowHelp = True
            OpenFileDialog1.ShowReadOnly = False
            OpenFileDialog1.ReadOnlyChecked = False
            OpenFileDialog1.Title = "Выберите файл для добавления"
            OpenFileDialog1.ValidateNames = True
            If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                c_temp = OpenFileDialog1.FileName
                If Len(c_temp) > 0 Then
                    If ComboBox1.Text = "Тесты (AIST)" And isFile(c_temp) = True Then
                        MessageBox.Show("Для данного типа можно указать только директорию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        TextBox11.Text = c_temp
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        gb_file_style.Visible = True
        gb_file_style.Left = gb_drag_n_drop.Left
        gb_file_style.Top = gb_drag_n_drop.Top
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If Len(ListBox1.Text) > 0 Then gb_file_style.Visible = False
    End Sub

    Private Sub Label19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label19.Click
        create_new_file()
    End Sub

    Sub create_new_file()
        gb_add.Visible = False
        gb_create_file.Visible = True
        btn_apply.Visible = True
        create_file = True
        btn_apply.Text = "Создать"
        img_add_logo.Image = img_create_file.Image
        lbl_add_text.Text = lst_text.Items.Item(4)
        Label5.Visible = False
        lbl_show.Visible = False
        add_drag_enabled = False
        gb_create_file.Visible = True
        gb_create_file.Top = gb_drag_n_drop.Top
        gb_create_file.Left = gb_drag_n_drop.Left
        gb_add_choise.Visible = False
        gb_file_style.Visible = False
        gb_file_style.Top = img_add_logo.Top
        gb_file_style.Left = img_add_logo.Left
        ComboBox2.Items.Remove("Тесты (AIST)")
    End Sub

    Private Sub Label18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label18.Click
        create_new_file()
    End Sub

    Private Sub Label18_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label18.MouseLeave
        Label19.ForeColor = Color.Black
        Label18.ForeColor = Color.Black
    End Sub

    Private Sub Label18_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label18.MouseMove
        Label19.ForeColor = Color.Gray
        Label18.ForeColor = Color.Gray
    End Sub

    Private Sub Label19_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label19.MouseLeave
        Label19.ForeColor = Color.Black
        Label18.ForeColor = Color.Black
    End Sub

    Private Sub Label19_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label19.MouseMove
        Label19.ForeColor = Color.Gray
        Label18.ForeColor = Color.Gray
    End Sub

    Private Sub ListBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick
        If Len(ListBox1.Text) > 0 Then gb_file_style.Visible = False
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        Label24.Text = file_styles_description(ListBox1.SelectedIndex)
    End Sub

    Private Sub gb_drag_n_drop_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles gb_drag_n_drop.DragDrop
        Try
            add_drag_path = CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString
            If cur_add_type < 3 And isFile(add_drag_path) = True Then Exit Sub
            If cur_add_type = 3 Then
                If isFile(add_drag_path) = False Then
                    ComboBox1.Text = ""
                    ComboBox1.SelectedValue = "Тесты (AIST)"
                    ComboBox1.SelectedText = "Тесты (AIST)"
                    ComboBox1.SelectedItem = "Тесты (AIST)"
                End If
            End If
            do_drag(add_drag_path)
        Catch ex As Exception
            add_drag_used = False
        End Try
    End Sub

    Private Sub gb_drag_n_drop_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles gb_drag_n_drop.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub Label4_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Label4.DragDrop
        Try
            add_drag_path = CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString
            If cur_add_type < 3 And isFile(add_drag_path) = True Then Exit Sub
            If cur_add_type = 3 Then
                If isFile(add_drag_path) = False Then
                    ComboBox1.SelectedValue = "Тесты (AIST)"
                    ComboBox1.SelectedText = "Тесты (AIST)"
                    ComboBox1.SelectedItem = "Тесты (AIST)"
                End If
            End If
            do_drag(add_drag_path)
        Catch ex As Exception
            add_drag_used = False
        End Try
    End Sub

    Private Sub Label4_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Label4.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub btn_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exit.Click
        close_add_form()
    End Sub

    Private Sub btn_apply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_apply.Click
        Dim temp_newfile_path As String
        Dim ex_components As New developers_components_lib.cls_filesystem()
        Select Case cur_add_type
            Case 0 'unit
                If Len(TextBox1.Text) > 25 Then MsgBox("Имя файла слишком длинное!", MsgBoxStyle.Critical, "Ошибка") : Exit Sub
                If Len(TextBox1.Text) = 0 Then show_error_message(4, False) : Exit Sub
                If My.Computer.FileSystem.DirectoryExists(UMK_dir & "\" & TextBox1.Text) = True Then show_error_message(7, False) : Exit Sub
                If add_drag_used = True Then
                    My.Computer.FileSystem.CopyDirectory(add_drag_path, UMK_dir & "\" & TextBox1.Text)
                Else
                    My.Computer.FileSystem.CreateDirectory(UMK_dir & "\" & TextBox1.Text)
                End If
                clear_command_list()
                'add_to_command_list("name=" & TextBox1.Text)
                add_to_command_list("type=unit")
                add_to_command_list("chief=" & TextBox2.Text)
                add_to_command_list("sub_chief=" & TextBox3.Text)
                write_to_info_file(UMK_dir & "\" & TextBox1.Text & "\info.dat")
                get_dir(UMK_dir & "\")
                add_to_sessionlist(TextBox1.Text)
                add_to_sessionlist(TextBox2.Text)
                add_to_sessionlist(TextBox3.Text)
                update_sessions_obj(0)
                close_add_form()
            Case 1 'caf
                If Len(TextBox6.Text) > 25 Then MsgBox("Имя файла слишком длинное!", MsgBoxStyle.Critical, "Ошибка") : Exit Sub
                If Len(TextBox6.Text) = 0 Then show_error_message(5, False) : Exit Sub
                If My.Computer.FileSystem.DirectoryExists(UMK_dir & "\" & UNIT_path & "\" & TextBox6.Text) = True Then show_error_message(8, False) : Exit Sub
                If add_drag_used = True Then
                    My.Computer.FileSystem.CopyDirectory(add_drag_path, UMK_dir & "\" & UNIT_path & "\" & TextBox6.Text)
                Else
                    My.Computer.FileSystem.CreateDirectory(UMK_dir & "\" & UNIT_path & "\" & TextBox6.Text)
                End If
                clear_command_list()
                'add_to_command_list("name=" & TextBox6.Text)
                add_to_command_list("type=caf")
                add_to_command_list("chief=" & TextBox5.Text)
                write_to_info_file(UMK_dir & "\" & UNIT_path & "\" & TextBox6.Text & "\info.dat")
                'CAF_path = TextBox6.Text
                change_cur_edit_type(1)
                show_unit()
                add_to_sessionlist(TextBox5.Text)
                add_to_sessionlist(TextBox6.Text)
                update_sessions_obj(0)
                close_add_form()
            Case 2 'umk
                If Len(TextBox7.Text) > 25 Then MsgBox("Имя файла слишком длинное!", MsgBoxStyle.Critical, "Ошибка") : Exit Sub
                If Len(TextBox7.Text) = 0 Then show_error_message(6, False) : Exit Sub
                If My.Computer.FileSystem.DirectoryExists(UMK_dir & "\" & UNIT_path & "\" & CAF_path & "\" & TextBox7.Text) = True Then show_error_message(9, False) : Exit Sub
                If add_drag_used = True Then
                    My.Computer.FileSystem.CopyDirectory(add_drag_path, UMK_dir & "\" & UNIT_path & "\" & CAF_path & "\" & TextBox7.Text)
                Else
                    My.Computer.FileSystem.CreateDirectory(UMK_dir & "\" & UNIT_path & "\" & CAF_path & "\" & TextBox7.Text)
                End If
                clear_command_list()
                'add_to_command_list("name=" & TextBox7.Text)
                add_to_command_list("type=umk")
                add_to_command_list("author=" & TextBox4.Text)
                add_to_command_list("chief=" & TextBox8.Text)
                write_to_info_file(UMK_dir & "\" & UNIT_path & "\" & CAF_path & "\" & TextBox7.Text & "\info.dat")
                'UMK_path = TextBox7.Text
                change_cur_edit_type(2)
                show_unit()
                add_to_sessionlist(TextBox4.Text)
                add_to_sessionlist(TextBox7.Text)
                add_to_sessionlist(TextBox8.Text)
                update_sessions_obj(0)
                close_add_form()
            Case 3 ' add files to UMK
                If create_file = True Then
                    If Len(ListBox1.Text) <= 1 Then MsgBox("Вы не выбрали стиль для нового файла.", MsgBoxStyle.Critical, "Стиль") : Exit Sub
                    If ComboBox2.Text = "Выберите..." Or Len(ComboBox2.Text) <= 1 Then MsgBox("Вы не выбрали тип для нового файла.", MsgBoxStyle.Critical, "Тип файла") : Exit Sub
                    If check_for_system_ex(TextBox11.Text) = True Then MsgBox("Недопустимое расширение файла", MsgBoxStyle.Critical, "Ошибка") : Exit Sub
                    temp_newfile_path = UMK_dir & "\" & UNIT_path & "\" & CAF_path & "\" & UMK_path & "\" & TextBox12.Text & "." & get_extention(file_styles_filename(ListBox1.SelectedIndex))
                    ' MsgBox(temp_newfile_path)
                    If My.Computer.FileSystem.FileExists(temp_newfile_path) = True Then MsgBox("Данный файл существует!", MsgBoxStyle.Critical, "Файл существует") : Exit Sub
                    My.Computer.FileSystem.CopyFile(Application.StartupPath & "\styles\file_presets\" & file_styles_filename(ListBox1.SelectedIndex), temp_newfile_path, True)
                    clear_command_list()
                    add_to_command_list("file_type=" & ComboBox2.Text)
                    add_to_command_list("file_type_code=" & ComboBox2.SelectedIndex)
                    add_to_command_list("type=umk_file")
                    add_to_command_list("desk=")
                    write_to_info_file(UMK_dir & "\" & UNIT_path & "\" & CAF_path & "\" & UMK_path & "\" & TextBox12.Text & "." & get_extention(file_styles_filename(ListBox1.SelectedIndex)) & ".info")
                    change_cur_edit_type(3)
                    show_unit()
                    If CheckBox1.Checked = True Then show_file(temp_newfile_path)
                Else
                    If Len(TextBox11.Text) = 0 Then show_error_message(1, False) : Exit Sub
                    If My.Computer.FileSystem.FileExists(TextBox11.Text) = False And isFile(TextBox11.Text) = True Then show_error_message(2, False) : Exit Sub
                    If My.Computer.FileSystem.DirectoryExists(TextBox11.Text) = False And isFile(TextBox11.Text) = False Then show_error_message(2, False) : Exit Sub
                    If Len(ComboBox1.Text) = 0 Or Len(ComboBox1.SelectedItem) = 0 Then show_error_message(3, False) : Exit Sub
                    If check_for_system_ex(TextBox11.Text) = True And isFile(TextBox11.Text) = True Then MsgBox("Недопустимое расширение файла", MsgBoxStyle.Critical, "Ошибка") : Exit Sub
                    If ComboBox1.Text = "Тесты (AIST)" And isFile(TextBox11.Text) = True Then MessageBox.Show("Для данного типа можно указать только директорию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                    If ComboBox1.Text <> "Тесты (AIST)" And isFile(TextBox11.Text) = False Then MessageBox.Show("Для данного типа нельзя указывать путь до директорий", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                    If isFile(TextBox11.Text) = True Then
                        If My.Computer.FileSystem.FileExists(UMK_dir & "\" & UNIT_path & "\" & CAF_path & "\" & UMK_path & "\" & get_filename(TextBox11.Text)) = False Then
                            My.Computer.FileSystem.CopyFile(TextBox11.Text, UMK_dir & "\" & UNIT_path & "\" & CAF_path & "\" & UMK_path & "\" & get_filename(TextBox11.Text), True)
                        Else
                            MessageBox.Show("Файл с таким именем уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    Else
                        If My.Computer.FileSystem.FileExists(UMK_dir & "\" & UNIT_path & "\" & CAF_path & "\" & UMK_path & "\" & get_filename(TextBox11.Text) & ".zip") = False Then
                            'gb_wait.Visible = True
                            ex_components.add_fldr_to_zip(TextBox11.Text, UMK_dir & "\" & UNIT_path & "\" & CAF_path & "\" & UMK_path & "\" & get_filename(TextBox11.Text) & ".zip")
                            ' gb_wait.Visible = False
                        Else
                            MessageBox.Show("Файл с таким именем уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    End If
                    clear_command_list()
                    add_to_command_list("file_type=" & ComboBox1.Text)
                    add_to_command_list("file_type_code=" & ComboBox1.SelectedIndex)
                    add_to_command_list("type=umk_file")
                    add_to_command_list("tags=" & TextBox9.Text)
                    If isFile(TextBox11.Text) = True Then
                        write_to_info_file(UMK_dir & "\" & UNIT_path & "\" & CAF_path & "\" & UMK_path & "\" & get_filename(TextBox11.Text) & ".info")
                    Else
                        write_to_info_file(UMK_dir & "\" & UNIT_path & "\" & CAF_path & "\" & UMK_path & "\" & get_filename(TextBox11.Text) & ".zip.info")
                    End If
                    change_cur_edit_type(3)
                    add_to_sessionlist(TextBox9.Text)
                    update_sessions_obj(0)
                    show_unit()
                End If
                close_add_form()
        End Select
    End Sub

    Private Sub gb_drag_n_drop_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gb_drag_n_drop.Enter

    End Sub

    Private Sub lbl_show_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_show.Click
        If add_drag_enabled = True Then
            gb_drag_n_drop.Visible = False
            'gb_drag_n_drop.Left = 485
            'gb_drag_n_drop.Top = 255
            add_drag_enabled = False
            lbl_show.Text = "автоматическому виду"
        Else
            gb_drag_n_drop.Visible = True
            'gb_drag_n_drop.Left = gb_unit.Left
            'gb_drag_n_drop.Top = gb_unit.Top
            gb_drag_n_drop.Width = gb_unit.Width
            gb_drag_n_drop.Height = gb_unit.Height
            add_drag_enabled = True
            lbl_show.Text = "стандартному виду"
            gb_drag_n_drop.BringToFront()
        End If
    End Sub

    Private Sub lbl_show_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbl_show.MouseEnter
        lbl_show.ForeColor = Color.Blue
    End Sub

    Private Sub lbl_show_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbl_show.MouseLeave
        lbl_show.ForeColor = Color.Navy
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged
        If Len(TextBox7.Text) <> 0 Then btn_apply.Visible = True Else btn_apply.Visible = False
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If Len(TextBox1.Text) <> 0 Then btn_apply.Visible = True Else btn_apply.Visible = False
    End Sub

    Private Sub TextBox11_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox11.TextChanged
        If Len(TextBox11.Text) <> 0 Then btn_apply.Visible = True Else btn_apply.Visible = False
    End Sub

    Private Sub TextBox12_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox12.TextChanged
        If Len(TextBox12.Text) <> 0 Then btn_apply.Visible = True Else btn_apply.Visible = False
    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged
        If Len(TextBox6.Text) <> 0 Then btn_apply.Visible = True Else btn_apply.Visible = False
    End Sub

    Private Sub lbl_delete_umk_dnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_delete_umk_dnd.Click
        add_drag_used = False
        lbl_delete_umk_dnd.Visible = False
        lbl_umk.Visible = False
    End Sub

    Private Sub lbl_delete_umk_dnd_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbl_delete_umk_dnd.MouseEnter
        lbl_delete_umk_dnd.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub lbl_delete_umk_dnd_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbl_delete_umk_dnd.MouseLeave
        lbl_delete_umk_dnd.BorderStyle = BorderStyle.None
    End Sub
End Class