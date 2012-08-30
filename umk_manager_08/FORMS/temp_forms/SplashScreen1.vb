Public NotInheritable Class frm_back

    Private Sub frm_back_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Select Case cur_form
            Case "add"
                Me.Location = frm_add.Location
                Me.Size = frm_add.Size
            Case "help"
                Me.Location = frm_hlp.Location
                Me.Size = frm_hlp.Size
            Case "options"
                Me.Location = frm_options.Location
                Me.Size = frm_options.Size
            Case "about"
                Me.Location = AboutBox1.Location
                Me.Size = AboutBox1.Size
            Case "info"
                Me.Location = frm_info.Location
                Me.Size = frm_info.Size
        End Select

    End Sub

End Class
