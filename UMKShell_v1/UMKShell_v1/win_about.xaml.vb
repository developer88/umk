Partial Public Class win_about

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'gb_about.Visibility = Visibility.Hidden
        lbl_version.Content = "Версия: " & My.Application.Info.Version.ToString()
        'lbl_version.Content = "Версия: " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & " Build: " & My.Application.Info.Version.Revision)
    End Sub

    Private Sub lbl_email_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles lbl_email.MouseDown
        open_webdoc("mailto:dsoft88@gmail.com")
    End Sub

    Private Sub lbl_site_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles lbl_site.MouseDown
        open_webdoc("http://www.eremin.me")
    End Sub

    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        about_form_ISshown = False
        Me.Close()
    End Sub

    Private Sub win_about_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
        about_form_ISshown = False
    End Sub

    Private Sub lbl_licence_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles lbl_licence.MouseDown
        open_webdoc(AppDomain.CurrentDomain.BaseDirectory & "help\licence.htm")
    End Sub
End Class
