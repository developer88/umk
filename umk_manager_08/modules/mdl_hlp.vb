Module mdl_hlp
    'variables
    Public help_type As Integer

    Public Sub open_help(ByVal type_of_help As Integer)
        help_type = type_of_help
        Select Case type_of_help
            Case 2 'help_online
                frm_hlp.wb_hlp.Navigate("http://dsoft88.spaces.live.com")
        End Select
    End Sub

End Module
