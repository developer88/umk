Public NotInheritable Class AboutBox1

    Private Sub AboutBox1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'back_about.Hide()
    End Sub

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("О программе {0}", ApplicationTitle)
        Label1.Text = My.Application.Info.ProductName
        Label2.Text = String.Format("Версия {0}", My.Application.Info.Version.ToString)
        'Label3.Text = My.Application.Info.Copyright
        Label4.Text = "Ерёмин Андрей"
        ' Label5.Text = My.Application.Info.Description
        'Label11.Text = ".Net ver: " & Environment.Version.Major & "." & Environment.Version.Minor & "." & Environment.Version.Revision
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        open_webdoc("mailto:dsoft88@gmail.com")
    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click
        open_webdoc("http://dsoft88.spaces.live.com")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Label7_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label7.MouseEnter
        Label7.ForeColor = Color.Blue
    End Sub

    Private Sub Label7_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label7.MouseLeave
        Label7.ForeColor = Color.Black
    End Sub

    Private Sub Label8_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label8.MouseEnter
        Label8.ForeColor = Color.Blue
    End Sub

    Private Sub Label8_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label8.MouseLeave
        Label8.ForeColor = Color.Black
    End Sub
End Class
