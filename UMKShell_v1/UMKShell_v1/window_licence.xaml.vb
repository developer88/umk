Partial Public Class window_licence
    Public apply As Boolean = False

    Private Sub btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btn_cancel.Click
        If MessageBox.Show("Данное действие приведёт к закрытию приложения, продолжить?", "Завершение работы", MessageBoxButton.YesNo, MessageBoxImage.Question) = MessageBoxResult.Yes Then
            apply = False
            Application.Current.Shutdown()
        End If
    End Sub

    Private Sub btn_apply_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btn_apply.Click
        apply = True
        Me.Close()
    End Sub
End Class
