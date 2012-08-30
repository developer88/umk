Public Class frm_hlp
    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        open_help(1)
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        wb_hlp.GoBack()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        wb_hlp.GoForward()
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        open_help(0)
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        open_help(2)
    End Sub

    Private Sub frm_hlp_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'back_hlp.Hide()
    End Sub

    Private Sub frm_hlp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        open_help(0)
        Label4.Visible = False
        'Label4.Text = "Статус: " & wb_hlp.Url
    End Sub

    Private Sub wb_hlp_Navigated(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserNavigatedEventArgs) Handles wb_hlp.Navigated
        If Label4.Visible = False Then Label4.Visible = True
        Label4.Text = "Статус: страница загружена."
    End Sub

    Private Sub wb_hlp_Navigating(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserNavigatingEventArgs) Handles wb_hlp.Navigating
        If Label4.Visible = False Then Label4.Visible = True
        Label4.Text = "Статус: Загрузка страницы..."
    End Sub

    Private Sub PictureBox16_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox16.MouseEnter
        PictureBox16.Image = frm_res.PictureBox35.Image
    End Sub

    Private Sub PictureBox16_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox16.MouseLeave
        PictureBox16.Image = frm_res.PictureBox36.Image
    End Sub


    Private Sub PictureBox16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox16.Click

    End Sub

End Class