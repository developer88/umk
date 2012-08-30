Public Class frm_info

    Private Sub frm_info_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        clear_info_form()
    End Sub

    Private Sub frm_info_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        clear_info_form()
    End Sub

    Private Sub txt_name_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_name.MouseEnter
        txt_name.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub txt_name_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_name.MouseLeave
        txt_name.BorderStyle = BorderStyle.None
    End Sub

    Private Sub txt_name_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_name.TextChanged
        If txt_name.Text <> info_var(0) Then btn_ok.Visible = True : btn_close.Text = "Отмена" Else btn_ok.Visible = False : btn_close.Text = "Закрыть"
    End Sub

    Private Sub txt1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt1.MouseEnter
        txt1.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub txt1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt1.MouseLeave
        txt1.BorderStyle = BorderStyle.None
    End Sub

    Private Sub txt1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt1.TextChanged
        If cur_infopanel_type <> 4 Then
            If txt1.Text <> info_var(1) Then btn_ok.Visible = True : btn_close.Text = "Отмена" Else btn_ok.Visible = False : btn_close.Text = "Закрыть"
        End If
        If cur_infopanel_type = 4 Then
            If txt1.Text <> info_var(3) Then btn_ok.Visible = True : btn_close.Text = "Отмена" Else btn_ok.Visible = False : btn_close.Text = "Закрыть"
        End If
    End Sub

    Private Sub txt2_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt2.MouseEnter
        txt2.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub txt2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt2.MouseLeave
        txt2.BorderStyle = BorderStyle.None
    End Sub

    Private Sub txt2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt2.TextChanged
        If txt2.Text <> info_var(2) Then btn_ok.Visible = True : btn_close.Text = "Отмена" Else btn_ok.Visible = False : btn_close.Text = "Закрыть"
    End Sub

    Private Sub txt3_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt3.MouseEnter
        txt3.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub txt3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt3.MouseLeave
        txt3.BorderStyle = BorderStyle.None
    End Sub

    Private Sub txt3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt3.TextChanged
        If txt3.Text <> info_var(3) Then btn_ok.Visible = True : btn_close.Text = "Отмена" Else btn_ok.Visible = False : btn_close.Text = "Закрыть"
    End Sub

    Private Sub txt4_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt4.MouseEnter
        txt4.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub txt4_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt4.MouseLeave
        txt4.BorderStyle = BorderStyle.None
    End Sub

    Private Sub txt4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt4.TextChanged
        If txt4.Text <> info_var(4) Then btn_ok.Visible = True : btn_close.Text = "Отмена" Else btn_ok.Visible = False : btn_close.Text = "Закрыть"
    End Sub

    Private Sub lst_type_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lst_type.SelectedIndexChanged
        If lst_type.Text <> info_var(1) Then btn_ok.Visible = True : btn_close.Text = "Отмена" Else btn_ok.Visible = False : btn_close.Text = "Закрыть"
    End Sub

    Private Sub chk_info1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_info1.CheckedChanged
        Dim g As String
        If chk_info1.Checked = True Then g = "1" Else g = "0"
        If g = info_var(5) Then btn_ok.Visible = False : btn_close.Text = "Закрыть" Else btn_ok.Visible = True : btn_close.Text = "Отмена"
        'If chk_info1.Checked = True Then info_var(4) = "1" Else info_var(4) = "0"
    End Sub

    Private Sub chk_info2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_info2.CheckedChanged
        Dim g As String
        If chk_info2.Checked = True Then g = "1" Else g = "0"
        If g = info_var(6) Then btn_ok.Visible = False : btn_close.Text = "Закрыть" Else btn_ok.Visible = True : btn_close.Text = "Отмена"
        'If chk_info2.Checked = True Then info_var(5) = "1" Else info_var(5) = "0"
    End Sub

    Private Sub chk_info3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_info3.CheckedChanged
        Dim g As String
        If chk_info3.Checked = True Then g = "1" Else g = "0"
        If g = info_var(7) Then btn_ok.Visible = False : btn_close.Text = "Закрыть" Else btn_ok.Visible = True : btn_close.Text = "Отмена"
        'If chk_info3.Checked = True Then info_var(6) = "1" Else info_var(6) = "0"
    End Sub

    Private Sub chk_info4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_info4.CheckedChanged
        Dim g As String
        If chk_info4.Checked = True Then g = "1" Else g = "0"
        If g = info_var(8) Then btn_ok.Visible = False : btn_close.Text = "Закрыть" Else btn_ok.Visible = True : btn_close.Text = "Отмена"
        'If chk_info4.Checked = True Then info_var(7) = "1" Else info_var(7) = "0"
    End Sub

    Private Sub btn_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close.Click
        clear_info_form()
        Me.Close()
    End Sub

    Private Sub btn_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ok.Click
        update_info_var(2)
        update_info(cur_infopanel_type)
        'exit
        clear_info_form()
        Me.Close()
    End Sub

    Private Sub pic_update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pic_update.Click
        Dim fullpath As String = ""
        Dim t_path As String = create_path(cur_infopanel_type)
        FolderBrowserDialog1.ShowNewFolderButton = False
        FolderBrowserDialog1.SelectedPath = ""
        Select Case cur_infopanel_type
            Case 1 'unit
                FolderBrowserDialog1.ShowDialog()
                If Len(FolderBrowserDialog1.SelectedPath) > 0 Then
                    My.Computer.FileSystem.CopyDirectory(FolderBrowserDialog1.SelectedPath, UMK_dir & "\" & t_path & "\" & txt_name.Text, True)
                End If
            Case 2 'caf
                FolderBrowserDialog1.ShowDialog()
                If Len(FolderBrowserDialog1.SelectedPath) > 0 Then
                    My.Computer.FileSystem.CopyDirectory(FolderBrowserDialog1.SelectedPath, UMK_dir & "\" & t_path & "\" & txt_name.Text, True)
                End If
            Case 3 'umk
                FolderBrowserDialog1.ShowDialog()
                If Len(FolderBrowserDialog1.SelectedPath) > 0 Then
                    My.Computer.FileSystem.CopyDirectory(FolderBrowserDialog1.SelectedPath, UMK_dir & "\" & t_path & "\" & txt_name.Text, True)
                End If
            Case 4 'file
                OpenFileDialog1.Title = "Укажите новый файл"
                OpenFileDialog1.DefaultExt = "*." & get_extention(txt_name.Text)
                OpenFileDialog1.Filter = "Файл " & UCase(get_extention(txt_name.Text)) & " (*." & get_extention(txt_name.Text) & ")|*." & get_extention(txt_name.Text)
                OpenFileDialog1.FileName = ""
                OpenFileDialog1.ShowDialog()
                If Len(OpenFileDialog1.FileName) > 0 Then
                    My.Computer.FileSystem.CopyFile(OpenFileDialog1.FileName, UMK_dir & "\" & t_path & "\" & txt_name.Text, True)
                End If
        End Select
    End Sub

    Private Sub pic_update_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_update.MouseEnter
        pic_update.Image = My.Resources.update_m
    End Sub

    Private Sub pic_update_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_update.MouseLeave
        pic_update.Image = My.Resources.update_n
    End Sub

    Private Sub txt5_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt5.MouseEnter
        txt5.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub txt5_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt5.MouseLeave
        txt5.BorderStyle = BorderStyle.None
    End Sub

    Private Sub txt5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt5.TextChanged
        If txt5.Text <> info_var(9) Then btn_ok.Visible = True : btn_close.Text = "Отмена" Else btn_ok.Visible = False : btn_close.Text = "Закрыть"
    End Sub
End Class