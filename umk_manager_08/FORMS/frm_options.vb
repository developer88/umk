Imports System
Imports Microsoft.Win32
Imports System.IO


Public Class frm_options
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        apply_settings()
        save_settings()
        'back_options.Hide()
        Me.Hide()
    End Sub

    Private Sub chk_tray_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_tray.CheckedChanged
        use_tray = chk_tray.Checked
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        select_dir.ShowDialog()
        Dim temp_str As String
        If Len(select_dir.SelectedPath) > 2 Then
            temp_str = Application.StartupPath
            If Microsoft.VisualBasic.Left(select_dir.SelectedPath, Len(temp_str)) = temp_str Then
                TextBox5.Text = "APPDIR" & Microsoft.VisualBasic.Right(select_dir.SelectedPath, Len(select_dir.SelectedPath) - Len(temp_str))
            Else
                TextBox5.Text = select_dir.SelectedPath
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        openfile.DefaultExt = "exe"
        openfile.Title = "Укажите путь"
        openfile.FileName = "*.exe"
        openfile.Multiselect = False
        openfile.ShowDialog()
        ' If Len(openfile.FileName) > 2 Then TextBox1.Text = openfile.FileName
    End Sub

    Private Sub CheckBox5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox5.CheckedChanged
        APP_autostart = CheckBox5.Checked
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        openfile.DefaultExt = "exe"
        openfile.Title = "Укажите путь"
        openfile.FileName = "*.exe"
        openfile.Multiselect = False
        openfile.ShowDialog()
        ' If Len(openfile.FileName) > 2 Then TextBox2.Text = openfile.FileName
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        openfile.DefaultExt = "exe"
        openfile.Title = "Укажите путь"
        openfile.FileName = "*.exe"
        openfile.Multiselect = False
        openfile.ShowDialog()
        'If Len(openfile.FileName) > 2 Then TextBox3.Text = openfile.FileName
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        openfile.DefaultExt = "exe"
        openfile.Title = "Укажите путь"
        openfile.FileName = "*.exe"
        openfile.Multiselect = False
        openfile.ShowDialog()
        ' If Len(openfile.FileName) > 2 Then TextBox4.Text = openfile.FileName
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then search_type = 1 Else search_type = 2
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        search_opt_find_files = CheckBox1.Checked
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        search_opt_find_folders = CheckBox2.Checked
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        search_opt_find_text = CheckBox3.Checked
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        search_for_words = RadioButton4.Checked
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then search_type = 2 Else search_type = 1
    End Sub

    Private Sub lst_stat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lst_stat.Click
        If Len(lst_stat.Text) < 0 Then Exit Sub
        load_stat_style_info(lst_stat.Text)
        stat_style = lst_stat.Text
        For i1 = 0 To lst_stat.Items.Count - 1
            If lst_stat.Items.Item(i1) = stat_style Then
                lst_stat.SelectedIndex = i1
                lst_stat.SelectedValue = stat_style
                load_stat_style_info(stat_style)
            End If
        Next
    End Sub

    Private Sub frm_options_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' Dim c_temp As MsgBoxResult
        'save_settings()
        'back_options.Hide()
        apply_settings()
        'If need_restart = True Then
        'MsgBox("Требуется перезагрузка программы!", MsgBoxStyle.OkOnly, "Требуется перезагрузка программы.")
        'If c_temp = MsgBoxResult.Yes Then
        'apply_settings()
        save_settings()
        'Shell(Application.ExecutablePath, AppWinStyle.NormalFocus)
        'End
        'End If
        'End If
        e.Cancel = True
        Me.Hide()
    End Sub

    Private Sub frm_options_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        'If Environment.OSVersion.Version.Major > 5 And use_transparency = True Then back_options.Location = Me.Location
    End Sub

    Private Sub CheckBox7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CheckBox7_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CheckBox7_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

    End Sub

    Private Sub chk_trans_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click

    End Sub

    Private Sub CheckBox6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox6.CheckedChanged
        use_check = CheckBox6.Checked
    End Sub

    Private Sub CheckBox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckedChanged
        Info_pan_show = CheckBox4.Checked
        show_infopan(Info_pan_show)
    End Sub
End Class