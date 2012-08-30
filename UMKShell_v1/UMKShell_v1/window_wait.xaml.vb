
Partial Public Class window_wait
    Dim File_name As String
    Dim resultat As Boolean = False
    Public close_form As Boolean = False

    Private Sub window_wait_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
        If close_form = False Then e.Cancel = True
    End Sub

    Public Sub change_labels(ByVal text_big As String, ByVal text_small As String)
        lbl_big_caption.Content = text_big
        lbl_small_caption.Content = text_small
    End Sub


End Class
