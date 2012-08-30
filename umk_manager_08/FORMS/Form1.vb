
Public Class Form1
    Public irnd As New Random
    Private Const SIZE_RESTORED As Integer = 0
    Private Const SIZE_MINIMIZED As Integer = 1
    Private Const SIZE_MAXIMIZED As Integer = 2

    Private Sub Form1_AutoSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.AutoSizeChanged
        update_nav_pan()
    End Sub

    Private Sub Form1_ChangeUICues(ByVal sender As Object, ByVal e As System.Windows.Forms.UICuesEventArgs) Handles Me.ChangeUICues
        'MessageBox.Show("9")
    End Sub

    Private Sub Form1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        lst_short_list.Visible = False
        cur_show_list = 0
    End Sub

    Private Sub Form1_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        exit_app(False)
    End Sub

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        exit_app(False)
    End Sub

    Private Sub Form1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        'MessageBox.Show("8")
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Hide()
        load_app()
        Me.Show()
    End Sub

    Private Sub PictureBox4_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox4.MouseLeave
        PictureBox4.Image = frm_res.PictureBox3.Image
    End Sub

    Private Sub PictureBox4_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox4.MouseMove
        PictureBox4.Image = frm_res.PictureBox4.Image
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        If cur_edit_type = 3 Then change_cur_edit_type(2) : show_unit() : UMK_path = "" : UMK_item = "" : update_nav_pan() : Exit Sub
        If cur_edit_type = 2 Then change_cur_edit_type(1) : show_unit() : CAF_path = "" : update_nav_pan() : Exit Sub
        If cur_edit_type = 1 Then change_cur_edit_type(0) : PictureBox1.Enabled = False : PictureBox1.Image = frm_res.PictureBox23.Image : UNIT_path = "" : show_unit() : update_nav_pan() : Exit Sub
    End Sub

    Private Sub PictureBox1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave
        If PictureBox1.Enabled = False Then
            PictureBox1.Enabled = False
            PictureBox1.Image = frm_res.PictureBox23.Image
            PictureBox1.Refresh()
        Else
            PictureBox1.Image = frm_res.PictureBox7.Image
        End If
    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        If PictureBox1.Enabled = False Then
            PictureBox1.Enabled = False
            PictureBox1.Image = frm_res.PictureBox23.Image
            PictureBox1.Refresh()
        Else
            PictureBox1.Image = frm_res.PictureBox8.Image
        End If
    End Sub

    Private Sub ListBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.Click
        If ListBox1.Items.Count < 1 Then Exit Sub
        If cur_edit_type = 0 Then UNIT_path = ListBox1.Text
        If cur_edit_type = 1 Then CAF_path = ListBox1.Text
        If cur_edit_type = 2 Then UMK_path = ListBox1.Text
        If cur_edit_type = 3 Then UMK_item = ListBox1.Text
        check_listbox_status()
        If Len(ListBox1.Text) > 0 Then
            Select Case cur_edit_type
                Case 0
                    show_info_panel(1, UNIT_path)
                Case 1
                    show_info_panel(2, CAF_path)
                Case 2
                    show_info_panel(3, UMK_path)
                Case 3
                    show_info_panel(4, UMK_item)
            End Select
        End If
    End Sub

    Sub lstbox1_dbclick()
        If ListBox1.SelectedItem = "" Then Exit Sub
        If ListBox1.Items.Count < 1 Then Exit Sub
        If cur_edit_type = 0 Then change_cur_edit_type(1) : lbl_nav1.Text = UNIT_path : show_unit() : pan_info.Visible = False : clear_info_panel() : Exit Sub
        If cur_edit_type = 1 Then change_cur_edit_type(2) : lbl_nav2.Text = CAF_path : show_unit() : pan_info.Visible = False : clear_info_panel() : Exit Sub
        If cur_edit_type = 2 Then change_cur_edit_type(3) : show_unit() : lbl_nav3.Text = UMK_path : pan_info.Visible = False : clear_info_panel() : Exit Sub
        If cur_edit_type = 3 Then show_file(UMK_dir & "\" & UNIT_path & "\" & CAF_path & "\" & UMK_path & "\" & ListBox1.Text)
    End Sub

    Private Sub ListBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick
        lstbox1_dbclick()
    End Sub

    Private Sub ListBox1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListBox1.DragDrop
        Try
            add_drag_path = CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString
            Select Case cur_edit_type
                Case 0
                    If isFile(add_drag_path) = True Then Exit Sub
                    frm_add.TextBox1.Text = get_filename(add_drag_path)
                    add_drag_enabled = False
                    add_drag_used = True
                    frm_add.lbl_umk.Text = "Будет скопировано из папки: " & get_filename(add_drag_path)
                    frm_add.ToolTip1.SetToolTip(frm_add.lbl_umk, get_filename(add_drag_path))
                    frm_add.lbl_umk.Visible = True
                    frm_add.lbl_delete_umk_dnd.Visible = True
                    show_create_dialog(cur_edit_type, False, "")
                Case 1
                    If isFile(add_drag_path) = True Then Exit Sub
                    frm_add.TextBox6.Text = get_filename(add_drag_path)
                    add_drag_enabled = False
                    add_drag_used = True
                    frm_add.lbl_umk.Text = "Будет скопировано из папки: " & get_filename(add_drag_path)
                    frm_add.ToolTip1.SetToolTip(frm_add.lbl_umk, get_filename(add_drag_path))
                    frm_add.lbl_umk.Visible = True
                    frm_add.lbl_delete_umk_dnd.Visible = True
                    show_create_dialog(cur_edit_type, False, "")
                Case 2
                    If isFile(add_drag_path) = True Then Exit Sub
                    frm_add.TextBox7.Text = get_filename(add_drag_path)
                    frm_add.lbl_umk.Text = "Будет скопировано УМК из папки: " & get_filename(add_drag_path)
                    frm_add.ToolTip1.SetToolTip(frm_add.lbl_umk, get_filename(add_drag_path))
                    frm_add.lbl_umk.Visible = True
                    frm_add.btn_apply.Visible = True
                    frm_add.lbl_delete_umk_dnd.Visible = True
                    add_drag_enabled = False
                    add_drag_used = True
                    show_create_dialog(cur_edit_type, False, "")
                Case 3
                    'If isFile(add_drag_path) = False Then Exit Sub
                    frm_add.TextBox11.Text = add_drag_path
                    frm_add.gb_add_choise.Visible = False
                    frm_add.btn_apply.Visible = True
                    frm_add.img_add_logo.Image = frm_add.img_add_file.Image
                    frm_add.lbl_add_text.Text = frm_add.lst_text.Items.Item(3)
                    frm_add.gb_add.Visible = True
                    frm_add.gb_add.Top = 122
                    frm_add.gb_add.Left = 11
                    'If cur_add_type = 3 Then
                    If isFile(add_drag_path) = False Then
                        'frm_add.ComboBox1.Text = "Тесты (AIST)"
                        'frm_add.ComboBox1.SelectedValue = "Тесты (AIST)"
                        'frm_add.ComboBox1.SelectedText = "Тесты (AIST)"
                        'frm_add.ComboBox1.SelectedItem = "Тесты (AIST)"
                        add_drag_enabled = False
                        add_drag_used = True
                        show_create_dialog(cur_edit_type, False, "Тесты (AIST)")
                    Else
                        add_drag_enabled = False
                        add_drag_used = True
                        show_create_dialog(cur_edit_type, False, "")
                    End If
                    'End If
            End Select
        Catch ex As Exception
            add_drag_used = False
        End Try
    End Sub

    Private Sub ListBox1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListBox1.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub ListBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox1.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                lstbox1_dbclick()
            Case Keys.Delete
                delete()
            Case Keys.D
                delete()
            Case Keys.I
                information()
            Case Keys.O
                explore()
            Case Keys.E
                explore()
            Case Keys.C
                show_create_dialog(cur_edit_type, True, "")
            Case Keys.N
                show_create_dialog(cur_edit_type, True, "")
        End Select
    End Sub

    Private Sub ListBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBox1.MouseMove
        lst_short_list.Visible = False
        cur_show_list = 0
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        check_listbox_status()
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        Me.ContextMenuStrip1.Show(Me.PictureBox4, 0, Me.PictureBox4.Height)
    End Sub


    Private Sub ВыходToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ВыходToolStripMenuItem.Click
        exit_app(False)
    End Sub

    Private Sub ОПрограммеToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ОПрограммеToolStripMenuItem.Click
        Dim about_frm As New developers_components_lib.cls_about_dlg()
        about_frm.show_dlg("УМК Менеджер", "Версия: " + My.Application.Info.Version.ToString, "RTM", "Комплекс программных средств для автоматизированого создания или обработки УМК (учебный методический комплекс)." & vbCrLf & vbCrLf & "С помощью внутренних стилей и профилей возможна работа данной программы в любом высшем учебном заведении." & vbCrLf & vbCrLf & "Все материалы (файлы) созданные или отредатированные в этой программе принадлежат их владельцам. Автор не несёт ответственность за содержание этих файлов.", frm_res.PictureBox46.Image, Application.StartupPath & "\help\licence_umk.html", "", "umk_mngr", My.Application.Info.Version.Revision, False)
    End Sub

    Private Sub ПомощьToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ПомощьToolStripMenuItem.Click
        Process.Start("http://dsoft.studenthost.ru/help_small.aspx?app_code=umk_mngr")
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        show_create_dialog(cur_edit_type, True, "")
    End Sub

    Private Sub PictureBox6_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox6.MouseLeave
        PictureBox6.Image = frm_res.PictureBox5.Image
    End Sub

    Private Sub PictureBox6_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox6.MouseMove
        PictureBox6.Image = frm_res.PictureBox6.Image
    End Sub

    Sub delete()
        Dim temp_st As Integer
        Dim res_del As Boolean
        Dim temp_i As Integer
        If search_initialised = True Then
            If dg.Rows.Count = 0 Then Exit Sub
            If Len(dg.CurrentRow.Cells(0).FormattedValue) = 0 Then Exit Sub
            temp_st = get_type(dg.CurrentRow.Cells(2).FormattedValue)
            temp_i = dg.CurrentCell.RowIndex
            If temp_st = 0 Then
                res_del = delete_found_file(dg.CurrentRow.Cells(0).FormattedValue, get_type(dg.CurrentRow.Cells(2).FormattedValue), dg.CurrentRow.Cells(0).FormattedValue)
            Else
                res_del = delete_found_file(dg.CurrentRow.Cells(2).FormattedValue & "\" & dg.CurrentRow.Cells(0).FormattedValue, get_type(dg.CurrentRow.Cells(2).FormattedValue), dg.CurrentRow.Cells(0).FormattedValue)
            End If
            pan_info.Visible = False
            clear_info_panel()
            'If res_del = True Then dg.CurrentRow.Visible = False
        Else
            If ListBox1.Text = "" Then Exit Sub
            delete_dir_N_files(ListBox1.Text)
            pan_info.Visible = False
            clear_info_panel()
        End If

    End Sub

    Private Sub PictureBox10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox10.Click
        delete()
    End Sub

    Private Sub PictureBox10_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox10.MouseLeave
        PictureBox10.Image = frm_res.PictureBox9.Image
    End Sub

    Private Sub PictureBox10_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox10.MouseMove
        PictureBox10.Image = frm_res.PictureBox10.Image
    End Sub

    Sub information()
        Dim cur_search_result As Integer
        If search_initialised = False Then
            If Len(ListBox1.Text) > 0 Then
                Select Case cur_edit_type
                    Case 0
                        show_info_form(1, False, UNIT_path, UNIT_path)
                    Case 1
                        show_info_form(2, False, CAF_path, UNIT_path & "\" & CAF_path)
                    Case 2
                        show_info_form(3, False, UMK_path, UNIT_path & "\" & CAF_path & "\" & UMK_path)
                    Case 3
                        show_info_form(4, True, UMK_item, UNIT_path & "\" & CAF_path & "\" & UMK_path & "\" & UMK_item)
                End Select
                pan_info.Visible = False
                clear_info_panel()
            End If
        Else
            If dg.Rows.Count = 0 Then Exit Sub
            If Len(dg.CurrentRow.Cells(0).FormattedValue) > 0 Then
                cur_search_result = get_type(dg.CurrentRow.Cells(2).FormattedValue)
                'MsgBox(cur_search_result)
                Select Case cur_search_result
                    Case 0
                        show_info_form(0, False, dg.CurrentRow.Cells(0).FormattedValue, dg.CurrentRow.Cells(0).FormattedValue)
                    Case 1
                        show_info_form(0, False, dg.CurrentRow.Cells(0).FormattedValue, dg.CurrentRow.Cells(2).FormattedValue & "\" & dg.CurrentRow.Cells(0).FormattedValue)
                    Case 2
                        show_info_form(0, False, dg.CurrentRow.Cells(0).FormattedValue, dg.CurrentRow.Cells(2).FormattedValue & "\" & dg.CurrentRow.Cells(0).FormattedValue)
                    Case 3
                        show_info_form(0, True, dg.CurrentRow.Cells(0).FormattedValue, dg.CurrentRow.Cells(2).FormattedValue & "\" & dg.CurrentRow.Cells(0).FormattedValue)
                End Select
                pan_info.Visible = False
                clear_info_panel()
            End If
        End If
    End Sub

    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox8.Click
        information()
    End Sub

    Private Sub PictureBox8_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox8.MouseLeave
        PictureBox8.Image = frm_res.PictureBox11.Image
    End Sub

    Private Sub PictureBox8_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox8.MouseMove
        If PictureBox8.Enabled = False Then PictureBox8.Image = frm_res.PictureBox24.Image : Exit Sub
        PictureBox8.Image = frm_res.PictureBox12.Image
    End Sub

    Sub explore()
        Dim st_temp As Integer
        If search_initialised = False Then
            If Me.ListBox1.Text = "" Then Exit Sub
            If cur_edit_type = 3 Then
                show_file(UMK_dir & "\" & UNIT_path & "\" & CAF_path & "\" & UMK_path & "\" & ListBox1.Text)
            Else
                explore_folder(Me.ListBox1.Text, False)
            End If
        Else
            If dg.Rows.Count = 0 Then Exit Sub
            If Len(dg.CurrentRow.Cells(0).FormattedValue) = 0 Then Exit Sub
            st_temp = get_type(dg.CurrentRow.Cells(2).FormattedValue)
            'MessageBox.Show(st_temp)
            If st_temp = 3 Then
                show_file(UMK_dir & "\" & dg.CurrentRow.Cells(2).FormattedValue & "\" & dg.CurrentRow.Cells(0).FormattedValue)
            ElseIf st_temp = 0 Then
                explore_folder(UMK_dir & "\" & dg.CurrentRow.Cells(0).FormattedValue, True)
            Else
                explore_folder(UMK_dir & "\" & dg.CurrentRow.Cells(2).FormattedValue & "\" & dg.CurrentRow.Cells(0).FormattedValue, True)
            End If
        End If
    End Sub

    Private Sub PictureBox9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox9.Click
        explore()
    End Sub

    Private Sub PictureBox9_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox9.MouseLeave
        PictureBox9.Image = frm_res.PictureBox13.Image
    End Sub

    Private Sub PictureBox9_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox9.MouseMove
        PictureBox9.Image = frm_res.PictureBox14.Image
    End Sub

    Private Sub PictureBox11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox11.Click
        Dim st_temp As Integer
        If search_initialised = False Then
            If Me.ListBox1.Text = "" Then Exit Sub
            Select Case cur_edit_type
                Case 0
                    rename_func(ListBox1.Text, "", True, 0)
                Case 1
                    rename_func(ListBox1.Text, UNIT_path, True, 1)
                Case 2
                    rename_func(ListBox1.Text, UNIT_path & "\" & CAF_path, True, 2)
                Case 3
                    rename_func(ListBox1.Text, UNIT_path & "\" & CAF_path & "\" & UMK_path, True, 3)
            End Select

        Else
            If dg.Rows.Count = 0 Then Exit Sub
            If Len(dg.CurrentRow.Cells(0).FormattedValue) = 0 Then Exit Sub
            st_temp = get_type(dg.CurrentRow.Cells(2).FormattedValue)
            If st_temp = 0 Then
                rename_func(dg.CurrentRow.Cells(0).FormattedValue, "", False, st_temp)
            Else
                rename_func(dg.CurrentRow.Cells(0).FormattedValue, dg.CurrentRow.Cells(2).FormattedValue, False, st_temp)
            End If
            dg.CurrentRow.Visible = False
        End If
    End Sub

    Private Sub PictureBox11_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox11.MouseLeave
        PictureBox11.Image = frm_res.PictureBox16.Image
    End Sub

    Private Sub PictureBox11_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox11.MouseMove
        PictureBox11.Image = frm_res.PictureBox15.Image
    End Sub

    Private Sub СвернутьToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles СвернутьToolStripMenuItem.Click


        hide_to_tray()


    End Sub

    Private Sub ОткрытьПрограммуToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ОткрытьПрограммуToolStripMenuItem.Click
        NotifyIcon1.Visible = False
        Me.Show()
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub ВыходToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ВыходToolStripMenuItem1.Click
        exit_app(False)
    End Sub

    Private Sub НастройкиToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles НастройкиToolStripMenuItem.Click
        ' If use_transparency = True Then
        'If Environment.OSVersion.Version.Major < 6 Then
        load_stat_styles_list()
        'frm_options.Opacity = 0.95
        load_settings()
        apply_settings()
        frm_options.ShowDialog()
        'Else
        ' set_glass("options")
        'End If
        'Else
        'load_stat_styles_list()
        'frm_options.Opacity = 1
        'load_settings()
        'apply_settings()
        'frm_options.Show()
        'End If
        'need_restart = False
    End Sub

    Private Sub lst_short_list_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lst_short_list.Click
        lst_short_list.Visible = False
        If Len(lst_short_list.Text) = 0 Then Exit Sub
        If search_initialised = True Then deinitialize_search()
        clear_info_panel()
        pan_info.Visible = False
        Select Case cur_show_list
            Case 1
                If UNIT_path = lst_short_list.Text And cur_edit_type = 1 Then Exit Sub
                change_cur_edit_type(1)
                UNIT_path = lst_short_list.Text
                CAF_path = ""
                UMK_path = ""
                ' Label2.Text = "Подразделение: " & UNIT_path
                ' Label3.Text = "<Название кафедры>"
                'Label4.Text = "<Название УМК>"
            Case 2
                If CAF_path = lst_short_list.Text And cur_edit_type = 2 Then Exit Sub
                change_cur_edit_type(2)
                UMK_path = ""
                CAF_path = lst_short_list.Text
                'Label3.Text = "Кафедра: " & CAF_path
                'Label4.Text = "<Название УМК>"
            Case 3
                If UMK_path = lst_short_list.Text And cur_edit_type = 3 Then Exit Sub
                change_cur_edit_type(3)
                UMK_path = lst_short_list.Text
                ' Label4.Text = "УМК: " & UMK_path
        End Select
        show_unit()
        update_nav_pan()
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_nav1.Click
        show_selected_unit(1)
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_nav2.Click
        show_selected_unit(2)
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_nav3.Click
        show_selected_unit(3)
    End Sub

    Private Sub ListBox1_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedValueChanged
        If Len(ListBox1.Text) = 0 Then disable_controls(False) Else enable_controls(False)
    End Sub

    Public Sub mnu_choise_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim itemObject As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Select Case cur_edit_type
            Case 1
                If itemObject.Tag = cur_edit_type Then
                    show_info_panel(1, UNIT_path)
                Else
                    show_info_panel(2, CAF_path)
                End If
            Case 2
                If itemObject.Tag = cur_edit_type Then
                    show_info_panel(2, CAF_path)
                Else
                    show_info_panel(3, UMK_path)
                End If
            Case 3
                If itemObject.Tag = cur_edit_type Then
                    show_info_panel(3, UMK_path)
                Else
                    show_info_panel(4, UMK_item)
                End If
        End Select
    End Sub

    Private Sub PictureBox16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox16.Click
        press_search_button()
    End Sub

    Private Sub ЛицензияToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        open_help(1)
        frm_hlp.Show()
    End Sub

    Private Sub ОписаниеToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        open_help(0)
        frm_hlp.Show()
    End Sub

    Private Sub ПомощьToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        open_help(2)
        frm_hlp.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'close panel
        pan_info.Visible = False
        clear_info_panel()

    End Sub

    Private Sub txt_info_1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_info_1.MouseEnter
        txt_info_1.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub txt_info_1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_info_1.MouseLeave
        txt_info_1.BorderStyle = BorderStyle.None
    End Sub

    Private Sub txt_info_2_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_info_2.MouseEnter
        'If lbl_info_2.Text = "type" Then Exit Sub
        txt_info_2.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub txt_info_2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_info_2.MouseLeave
        txt_info_2.BorderStyle = BorderStyle.None
    End Sub

    Private Sub txt_info_3_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_info_3.MouseEnter
        txt_info_3.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub txt_info_3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_info_3.MouseLeave
        txt_info_3.BorderStyle = BorderStyle.None
    End Sub

    Private Sub txt_info_4_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_info_4.MouseEnter
        txt_info_4.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub txt_info_4_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_info_4.MouseLeave
        txt_info_4.BorderStyle = BorderStyle.None
    End Sub

    Private Sub txt_info_1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_info_1.TextChanged
        If pan_info.Visible = False Then Exit Sub
        If txt_info_1.Text <> info_var(0) Then btn_apply_pan.Visible = True : btn_close_pan.Visible = True : btn_close_pan.Text = "Отмена" Else btn_apply_pan.Visible = False : btn_close_pan.Visible = False
    End Sub

    Private Sub txt_info_2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_info_2.TextChanged
        If pan_info.Visible = False Then Exit Sub
        If txt_info_2.Text <> info_var(1) Then btn_apply_pan.Visible = True : btn_close_pan.Visible = True : btn_close_pan.Text = "Отмена" Else btn_apply_pan.Visible = False : btn_close_pan.Visible = False
    End Sub

    Private Sub txt_info_3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_info_3.TextChanged
        If pan_info.Visible = False Then Exit Sub
        If txt_info_3.Text <> info_var(2) Then btn_apply_pan.Visible = True : btn_close_pan.Visible = True : btn_close_pan.Text = "Отмена" Else btn_apply_pan.Visible = False : btn_close_pan.Visible = False
    End Sub

    Private Sub txt_info_4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_info_4.TextChanged
        If pan_info.Visible = False Then Exit Sub
        If txt_info_4.Text <> info_var(3) Then btn_apply_pan.Visible = True : btn_close_pan.Visible = True : btn_close_pan.Text = "Отмена" Else btn_apply_pan.Visible = False : btn_close_pan.Visible = False
    End Sub

    Private Sub lbl_nav_a1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_nav_a1.Click
        cur_show_list = 1
        show_fast_list()
    End Sub

    Private Sub lbl_nav_a1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbl_nav_a1.MouseEnter
        lbl_nav_a1.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub lbl_nav_a1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbl_nav_a1.MouseLeave
        lbl_nav_a1.BorderStyle = BorderStyle.None
    End Sub

    Private Sub lbl_nav_a2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_nav_a2.Click
        If lbl_nav1.Text = "<Название подразделения>" Then Exit Sub
        cur_show_list = 2
        show_fast_list()
    End Sub

    Private Sub lbl_nav_a3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_nav_a3.Click
        If lbl_nav2.Text = "<Название кафедры>" Then Exit Sub
        cur_show_list = 3
        show_fast_list()
    End Sub

    Private Sub lbl_nav_a2_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbl_nav_a2.MouseEnter
        lbl_nav_a2.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub lbl_nav_a2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbl_nav_a2.MouseLeave
        lbl_nav_a2.BorderStyle = BorderStyle.None
    End Sub

    Private Sub lbl_nav_a3_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbl_nav_a3.MouseEnter
        lbl_nav_a3.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub lbl_nav_a3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbl_nav_a3.MouseLeave
        lbl_nav_a3.BorderStyle = BorderStyle.None
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Dim cur_search_result As Integer
        If search_initialised = False Then
            If Len(ListBox1.Text) < 2 Then Exit Sub
            If cur_edit_type = 0 Then generate_statistic(1, UMK_dir & "\" & ListBox1.Text, ListBox1.Text, "", "")
            If cur_edit_type = 1 Then generate_statistic(2, UMK_dir & "\" & UNIT_path & "\" & ListBox1.Text, UNIT_path, ListBox1.Text, "")
            If cur_edit_type = 2 Then generate_statistic(3, UMK_dir & "\" & UNIT_path & "\" & CAF_path & "\" & ListBox1.Text, UNIT_path, CAF_path, ListBox1.Text)
            'If cur_edit_type = 3 Then generate_statistic(3, UMK_dir & "\" & UNIT_path & "\" & CAF_path & "\" & UMK_path)
        Else
            If dg.Rows.Count = 0 Then Exit Sub
            If Len(dg.CurrentRow.Cells(0).FormattedValue) > 0 Then
                cur_search_result = get_type(dg.CurrentRow.Cells(2).FormattedValue)
                Select Case cur_search_result
                    Case 0
                        generate_statistic(1, UMK_dir & "\" & dg.CurrentRow.Cells(0).FormattedValue, get_dir_from_path(UMK_dir & "\" & dg.CurrentRow.Cells(0).FormattedValue, 1), "", "")
                    Case 1
                        generate_statistic(2, UMK_dir & "\" & dg.CurrentRow.Cells(2).FormattedValue & "\" & dg.CurrentRow.Cells(0).FormattedValue, _
                                           get_dir_from_path(UMK_dir & "\" & dg.CurrentRow.Cells(2).FormattedValue & "\" & dg.CurrentRow.Cells(0).FormattedValue, 1), get_dir_from_path(UMK_dir & "\" & dg.CurrentRow.Cells(2).FormattedValue & "\" & dg.CurrentRow.Cells(0).FormattedValue, 2), "")
                    Case 2
                        generate_statistic(3, UMK_dir & "\" & dg.CurrentRow.Cells(2).FormattedValue & "\" & dg.CurrentRow.Cells(0).FormattedValue, _
                                         get_dir_from_path(UMK_dir & "\" & dg.CurrentRow.Cells(2).FormattedValue & "\" & dg.CurrentRow.Cells(0).FormattedValue, 1), get_dir_from_path(UMK_dir & "\" & dg.CurrentRow.Cells(2).FormattedValue & "\" & dg.CurrentRow.Cells(0).FormattedValue, 2), get_dir_from_path(UMK_dir & "\" & dg.CurrentRow.Cells(2).FormattedValue & "\" & dg.CurrentRow.Cells(0).FormattedValue, 3))
                End Select
                pan_info.Visible = False
                clear_info_panel()
            End If
        End If
    End Sub

    Private Sub PictureBox2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseLeave
        PictureBox2.Image = frm_res.PictureBox17.Image
    End Sub

    Private Sub PictureBox2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox2.MouseMove
        If PictureBox2.Enabled = False Then PictureBox2.Image = frm_res.PictureBox1.Image : Exit Sub
        PictureBox2.Image = frm_res.PictureBox2.Image
    End Sub

    Private Sub PictureBox5_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        lst_short_list.Visible = False
        cur_show_list = 0
    End Sub

    Private Sub dg_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg.CellClick
        Dim cur_search_result As Integer
        If dg.Rows.Count = 0 Then Exit Sub
        If Len(dg.CurrentRow.Cells(0).FormattedValue) < 1 Then Exit Sub
        cur_search_result = get_type(dg.CurrentRow.Cells(2).FormattedValue)
        If cur_search_result = 3 Then
            Me.PictureBox2.Image = frm_res.PictureBox1.Image
            Me.PictureBox2.Enabled = False
        Else
            Me.PictureBox2.Enabled = True
            Me.PictureBox2.Image = frm_res.PictureBox17.Image
        End If
        If isFile(UMK_dir & "\" & dg.CurrentRow.Cells(2).FormattedValue & "\" & dg.CurrentRow.Cells(0).FormattedValue) = True Or isFile(UMK_dir & "\" & dg.CurrentRow.Cells(0).FormattedValue) = True Then
            Me.PictureBox2.Image = frm_res.PictureBox1.Image
            Me.PictureBox2.Enabled = False
        End If
    End Sub

    Private Sub send_feedback_item_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles send_feedback_item.Click
        Process.Start("http://dsoft.studenthost.ru/feedback.aspx")
        'If Len(feed_path) > 0 And My.Computer.FileSystem.FileExists(feed_path) = True Then Shell(feed_path, AppWinStyle.NormalFocus)
    End Sub

    Private Sub PictureBox16_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox16.MouseEnter
        PictureBox16.Image = frm_res.PictureBox25.Image
    End Sub

    Private Sub PictureBox16_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox16.MouseLeave
        PictureBox16.Image = frm_res.PictureBox26.Image
    End Sub

    Private Sub pb_back_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
        lst_short_list.Visible = False
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        deinitialize_search()
    End Sub

    Private Sub ЛицензияToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ЛицензияToolStripMenuItem.Click
        Process.Start(Application.StartupPath & "\help\licence.html")
    End Sub

    Private Sub btn_close_pan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close_pan.Click
        pan_info.Visible = False
    End Sub

    Private Sub btn_apply_pan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_apply_pan.Click
        add_to_sessionlist(txt_info_1.Text)
        add_to_sessionlist(txt_info_2.Text)
        add_to_sessionlist(txt_info_3.Text)
        update_sessions_obj(0)
        update_info_var(1)
        update_info(cur_info_type)
        'Close(Panel)
        btn_apply_pan.Visible = False
        btn_close_pan.Visible = False
    End Sub

    Private Sub btn_close_search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close_search.Click
        deinitialize_search()
    End Sub

    Private Sub dg_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dg.CellMouseDoubleClick
        Dim st_temp As Integer
        If dg.Rows.Count = 0 Then Exit Sub
        If Len(dg.CurrentRow.Cells(0).FormattedValue) = 0 Then Exit Sub
        st_temp = get_type(dg.CurrentRow.Cells(2).FormattedValue)
        If st_temp = 3 Then
            show_file(UMK_dir & "\" & dg.CurrentRow.Cells(2).FormattedValue & "\" & dg.CurrentRow.Cells(0).FormattedValue)
        ElseIf st_temp = 0 Then
            explore_folder(UMK_dir & "\" & dg.CurrentRow.Cells(0).FormattedValue, True)
        Else
            explore_folder(UMK_dir & "\" & dg.CurrentRow.Cells(2).FormattedValue & "\" & dg.CurrentRow.Cells(0).FormattedValue, True)
        End If
    End Sub

    Private Sub Form1_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged
        'Me.Location
        'MessageBox.Show(e.
        ' MessageBox.Show("11")
    End Sub

    Private Sub Form1_MaximizedBoundsChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MaximizedBoundsChanged
        update_nav_pan()
    End Sub

    Private Sub Form1_MinimumSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MinimumSizeChanged
        'MessageBox.Show("7")
    End Sub

    Private Sub Form1_PaddingChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PaddingChanged

    End Sub

    Private Sub Form1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        ' MessageBox.Show("3")
    End Sub

    Private Sub Form1_ParentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ParentChanged
        ' MessageBox.Show("10")
    End Sub

    Private Sub Form1_RegionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.RegionChanged
        'MessageBox.Show("6")
    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If FormWindowState.Minimized = Me.WindowState Then
            If use_tray = True Then hide_to_tray()
        End If
    End Sub

    Private Sub Form1_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        update_nav_pan()
    End Sub

    Private Sub Form1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'MessageBox.Show("2")
    End Sub

    Private Sub Form1_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        If Me.Visible = True Then update_nav_pan()
    End Sub

    Private Sub btn_clear_search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear_search.Click
        TextBox1.Text = ""
    End Sub

    Private Sub TextBox1_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Click
        TextBox1.Text = ""
        btn_clear_search.Visible = True
    End Sub

    Private Sub TextBox1_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = 13 Then press_search_button()
    End Sub

    Private Sub TextBox1_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        If Len(TextBox1.Text) = 0 Then TextBox1.Text = "Поиск..." : btn_clear_search.Visible = False
    End Sub

    Private Sub TextBox1_MouseLeave1(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.MouseLeave
        If Len(TextBox1.Text) = 0 Then TextBox1.Text = "Поиск..." : btn_clear_search.Visible = False
    End Sub

    Private Sub pct_add_to_cd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pct_add_to_cd.Click

    End Sub

    Private Sub pct_add_to_cd_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pct_add_to_cd.MouseEnter
        pct_add_to_cd.Image = frm_res.PictureBox41.Image
    End Sub

    Private Sub pct_add_to_cd_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pct_add_to_cd.MouseLeave
        pct_add_to_cd.Image = frm_res.PictureBox40.Image
    End Sub

    Private Sub NotifyIcon1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.Click

    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        NotifyIcon1.Visible = False
        Me.Show()
        Me.WindowState = FormWindowState.Normal
    End Sub

    
    Private Sub lst_short_list_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lst_short_list.SelectedIndexChanged

    End Sub

    Private Sub dg_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg.CellContentClick

    End Sub

    Private Sub СоздатьДискToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles create_disk_item.Click
        Dim app_func As New developers_components_lib.cls_interract()
        If (app_func.is_app_is_running(get_name(get_filename(disk_creator_path))) = False) Then Process.Start(disk_creator_path)
    End Sub

    Private Sub Form1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Validated
        'MessageBox.Show("4")

    End Sub

    Private Sub Form1_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        'MessageBox.Show("1")
    End Sub

    Private Sub СправкаToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles СправкаToolStripMenuItem.Click
        Dim about_frm As New developers_components_lib.cls_about_dlg()
        about_frm.show_dlg("УМК Менеджер", "Версия: " + My.Application.Info.Version.ToString, "RTM", "Комплекс программных средств для автоматизированого создания или обработки УМК (учебный методический комплекс)." & vbCrLf & vbCrLf & "С помощью внутренних стилей и профилей возможна работа данной программы в любом высшем учебном заведении." & vbCrLf & vbCrLf & "Все материалы (файлы) созданные или отредатированные в этой программе принадлежат их владельцам. Автор не несёт ответственность за содержание этих файлов.", frm_res.PictureBox46.Image, Application.StartupPath & "\help\licence.html", "", "umk_mngr", My.Application.Info.Version.Revision, False)
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub
End Class
