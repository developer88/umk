Module mdl_dwm
    ' Public back_add As New frm_back
    'Public back_hlp As New frm_back
    'Public back_info As New frm_back
    'Public back_about As New frm_back
    'Public back_options As New frm_back

    Public Sub set_glass(ByVal form_name As String)
        Select Case form_name
            Case "add"
                cur_form = "add"
                frm_add.BackColor = Color.Black
                DwmExtendFrameIntoClientArea(frm_add.Handle, New Margins(0, 0, 97, 39))
                'back_add.Show()
                frm_add.Hide()
                frm_add.Show()
                frm_add.pb_back.Image = frm_res.pb_back.Image
                frm_add.pb_back.Left = 0
                frm_add.pb_back.Top = 97
                frm_add.pb_back.Width = frm_add.Width
                frm_add.pb_back.Height = 238
            Case "about"
                cur_form = "about"
                AboutBox1.BackColor = Color.Black
                DwmExtendFrameIntoClientArea(AboutBox1.Handle, New Margins(405, 100, 237, 100))
                'back_about.Show()
                AboutBox1.Hide()
                AboutBox1.Show()
            Case "help"
                cur_form = "help"
                frm_hlp.BackColor = Color.Black
                DwmExtendFrameIntoClientArea(frm_hlp.Handle, New Margins(0, 0, 0, 29))
                'back_hlp.Show()
                frm_hlp.pb_back.Image = frm_res.pb_back.Image
                frm_hlp.Hide()
                frm_hlp.Show()
            Case "info"
                cur_form = "info"
                frm_info.BackColor = Color.Black
                DwmExtendFrameIntoClientArea(frm_info.Handle, New Margins(0, 0, 0, 120))
                'back_info.Show()
                frm_info.Hide()
                frm_info.Show()
                With frm_info
                    .pb_back.Image = frm_res.pb_back.Image
                    .pb_back.Visible = True
                    .pb_back.Top = 0
                    .pb_back.Left = 0
                    .pb_back.Width = .Width
                    .pb_back.Height = .Height - 145
                    .Label9.Visible = False
                End With
            Case "options"
                cur_form = "options"
                load_stat_styles_list()
                frm_options.BackColor = Color.Black
                DwmExtendFrameIntoClientArea(frm_options.Handle, New Margins(frm_options.tc1.Left + 2, frm_options.Width - 4 - frm_options.tc1.Left - frm_options.tc1.Width, frm_options.pb_back.Top, frm_options.Height - frm_options.tc1.Top - frm_options.tc1.Height - 10))
                'back_options.Show()
                ' frm_options.pb_back.Visible = True
                'frm_options.pb_back.Image = frm_res.pb_back.Image
                ' load_settings()
                'apply_settings()
                frm_options.Hide()
                frm_options.Show()
            Case "manager"
                cur_form = "manager"
                Form1.BackColor = Color.Black
                Form1.txt_info_1.BackColor = Color.Black
                Form1.txt_info_2.BackColor = Color.Black
                Form1.txt_info_3.BackColor = Color.Black
                Form1.txt_info_4.BackColor = Color.Black
                DwmExtendFrameIntoClientArea(Form1.Handle, New Margins(0, 0, 0, 94))
                Form1.Refresh()
                Form1.Show()
        End Select


    End Sub

End Module
