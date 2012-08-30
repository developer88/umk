Public Class frm_temp

    ' Public Sub txtEdit_LostFocus() Handles txtEdit.LostFocus
    'txtEdit.Visible = False
    'If Len(txtEdit.Tag) <= 0 Then Exit Sub
    ' Select Case txtEdit.Tag
    ' Case 0
    ' info_var(0) = txtEdit.Text
    ' lbl0.Text = info_var_captions(0) & " " & txtEdit.Text
    ''     Case 1
    ' info_var(1) = txtEdit.Text
    ' lbl1.Text = info_var_captions(1) & " " & txtEdit.Text
    '     Case 2
    ' info_var(2) = txtEdit.Text
    ' lbl2.Text = info_var_captions(2) & " " & txtEdit.Text
    '    Case 3
    ' info_var(3) = txtEdit.Text
    ' lbl3.Text = info_var_captions(3) & " " & txtEdit.Text
    '     Case 4
    ' info_var(4) = txtEdit.Text
    'lbl4.Text = info_var_captions(4) & " " & txtEdit.Text
    ' End Select
    ' txtEdit.Text = ""
    ' txtEdit.Tag = ""
    'End Sub

    Private Sub lbl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' txtEdit_LostFocus()
        Dim i As Integer
        Select Case lbl1.Tag
            Case "text"
                With txtEdit
                    .Text = info_var(1)
                    .Top = lbl1.Top
                    .Left = lbl1.Left
                    .Visible = True
                    .Tag = "1"
                End With
            Case "big_text"
                With big_text
                    .Text = info_var(1)
                    .Visible = True
                    .Tag = "1"
                End With
                PictureBox12.Visible = False
                PictureBox13.Visible = True
            Case "type"
                clear_info_choise()
                For i = 0 To frm_res.lst_filetypes.Items.Count - 1
                    add_info_choise(frm_res.lst_filetypes.Items.Item(i), 1)
                Next
                '  mnu_filetypes.Show(lbl1, 0, lbl1.Height)
        End Select
    End Sub

    Private Sub lbl2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' txtEdit_LostFocus()
        Dim i As Integer
        Select Case lbl2.Tag
            Case "text"
                With txtEdit
                    .Text = info_var(2)
                    .Top = lbl2.Top
                    .Left = lbl2.Left
                    .Visible = True
                    .Tag = "2"
                End With
            Case "big_text"
                With big_text
                    .Text = info_var(2)
                    .Visible = True
                    .Tag = "2"
                End With
                PictureBox12.Visible = False
                PictureBox13.Visible = True
            Case "type"
                clear_info_choise()
                For i = 0 To frm_res.lst_filetypes.Items.Count - 1
                    add_info_choise(frm_res.lst_filetypes.Items.Item(i), 2)
                Next
                '  mnu_filetypes.Show(lbl2, 0, lbl2.Height)
        End Select
    End Sub

    Private Sub lbl3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'txtEdit_LostFocus()
        Dim i As Integer
        Select Case lbl3.Tag
            Case "text"
                With txtEdit
                    .Text = info_var(3)
                    .Top = lbl3.Top
                    .Left = lbl3.Left
                    .Visible = True
                    .Tag = "3"
                End With
            Case "big_text"
                With big_text
                    .Text = info_var(3)
                    .Visible = True
                    .Tag = "3"
                End With
                PictureBox12.Visible = False
                PictureBox13.Visible = True
            Case "type"
                clear_info_choise()
                For i = 0 To frm_res.lst_filetypes.Items.Count - 1
                    add_info_choise(frm_res.lst_filetypes.Items.Item(i), 3)
                Next
                ' mnu_filetypes.Show(lbl3, 0, lbl3.Height)
        End Select
    End Sub

    Private Sub lbl4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' txtEdit_LostFocus()
        Dim i As Integer
        Select Case lbl4.Tag
            Case "text"
                With txtEdit
                    .Text = info_var(4)
                    .Top = lbl4.Top
                    .Left = lbl4.Left
                    .Visible = True
                    .Tag = "4"
                End With
            Case "big_text"
                With big_text
                    .Text = info_var(4)
                    .Visible = True
                    .Tag = "4"
                End With
                PictureBox12.Visible = False
                PictureBox13.Visible = True
            Case "type"
                clear_info_choise()
                For i = 0 To frm_res.lst_filetypes.Items.Count - 1
                    add_info_choise(frm_res.lst_filetypes.Items.Item(i), 4)
                Next
                'mnu_filetypes.Show(lbl4, 0, lbl4.Height)
        End Select
    End Sub

    Private Sub lbl0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' txtEdit_LostFocus()
        With txtEdit
            .Text = info_var(0)
            .Top = lbl0.Top
            .Left = lbl0.Left
            .Visible = True
            .Tag = "0"
        End With
    End Sub

    Public Sub mnu_filetypes_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim itemObject As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Select Case itemObject.Tag
            Case 1
                lbl1.Text = info_var_captions(1) & " " & itemObject.Text
                info_var(1) = itemObject.Text
            Case 2
                lbl2.Text = info_var_captions(2) & " " & itemObject.Text
                info_var(2) = itemObject.Text
            Case 3
                lbl3.Text = info_var_captions(3) & " " & itemObject.Text
                info_var(3) = itemObject.Text
            Case 4
                lbl4.Text = info_var_captions(4) & " " & itemObject.Text
                info_var(4) = itemObject.Text
        End Select
        '  mnu_filetypes.Hide()
        ' mnu_filetypes.Items.Clear()
    End Sub

    Private Sub PictureBox13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PictureBox12.Visible = True
        PictureBox13.Visible = False
        big_text.Visible = False
        Select Case big_text.Tag
            Case 1
                lbl1.Text = info_var_captions(1) & " " & big_text.Text
                info_var(1) = big_text.Text
            Case 2
                lbl2.Text = info_var_captions(2) & " " & big_text.Text
                info_var(2) = big_text.Text
            Case 3
                lbl3.Text = info_var_captions(3) & " " & big_text.Text
                info_var(3) = big_text.Text
            Case 4
                lbl4.Text = info_var_captions(4) & " " & big_text.Text
                info_var(4) = big_text.Text
        End Select
        big_text.Text = ""
        big_text.Tag = ""
    End Sub


End Class