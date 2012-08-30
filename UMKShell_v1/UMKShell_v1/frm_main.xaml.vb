Imports System.ComponentModel
Imports System
Imports System.IO
Imports System.Net
Imports Microsoft
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Navigation
Imports System.Collections.ObjectModel
Imports System.Windows.Markup.XamlParseException
Imports System.Xml
Imports System.Windows.Markup.Primitives
Imports System.Text
Imports System.Windows.Markup
Imports System.Collections.Generic
Imports System.Collections
Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports System.Windows.Interop
Imports System.Data
Imports System.Threading

Partial Public Class frm_main

    Dim arr_left(0 To 10) As String
    Dim arr_right(0 To 10) As String
    Dim last_action As String

#Region "glass"
    Private Structure MARGINS
        Public Sub New(ByVal t As Thickness)
            Left = 0 'CInt(t.Left)
            Right = 0
            Top = 52
            Bottom = 25
        End Sub
        Public Left As Integer
        Public Right As Integer
        Public Top As Integer
        Public Bottom As Integer
    End Structure

    <DllImport("dwmapi.dll", PreserveSig:=False)> _
    Private Shared Sub DwmExtendFrameIntoClientArea(ByVal hwnd As IntPtr, ByRef margins As MARGINS)
    End Sub

    <DllImport("dwmapi.dll", PreserveSig:=False)> _
    Private Shared Function DwmIsCompositionEnabled() As Boolean
    End Function

    Protected Overloads Overrides Sub OnSourceInitialized(ByVal e As EventArgs)
        If Glass_Is_Enabled = True And Environment.OSVersion.Version.Major > 5 Then
            MyBase.OnSourceInitialized(e)
            ' This can't be done any earlier than the SourceInitialized event:
            ExtendGlassFrame(Me, New Thickness(-1))
        Else
            LayoutRoot.Background = New SolidColorBrush(Color.FromRgb(255, 255, 255))
        End If

    End Sub

    Public Shared Function ExtendGlassFrame(ByVal window As Window, ByVal margin As Thickness) As Boolean
        If Not DwmIsCompositionEnabled() Then
            Return False
        End If

        Dim hwnd As IntPtr = New WindowInteropHelper(window).Handle
        If hwnd = IntPtr.Zero Then
            Throw New InvalidOperationException("The Window must be shown before extending glass.")
        End If

        ' Set the background to transparent from both the WPF and Win32 perspectives
        window.Background = Brushes.Transparent
        HwndSource.FromHwnd(hwnd).CompositionTarget.BackgroundColor = Colors.Transparent

        Dim margins As New MARGINS(margin)
        DwmExtendFrameIntoClientArea(hwnd, margins)
        Return True
    End Function
#End Region

    Public Sub New()
        'load
        MyBase.New()
        Me.InitializeComponent()
        If My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "strings.inf") = False Or My.Computer.FileSystem.DirectoryExists(AppDomain.CurrentDomain.BaseDirectory & "Content") = False Then
            MessageBox.Show("Ошибка: Данные программы не найдены!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error)
            Application.Current.Shutdown()
        End If
        If (Environment.OSVersion.Version.Major < 5) Then MessageBox.Show("Данная операционная система не поддерживается!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error) : Application.Current.Shutdown()
        Dim splash_enabled As Boolean = True
        Dim help_enabled As Boolean = True
        Dim edu_enabled As Boolean = True
        Dim control_enabled As Boolean = True
        Dim inst_enabled As Boolean = True
        Dim temp_img As New BitmapImage()
        web_browser.Visibility = Visibility.Visible
        web_browser.Visibility = Visibility.Hidden

        'load files
        load_strings()
        'load default settings
        Window.Title = "<Диск без Названия>"

        'applying
        For i = 0 To strings_values.Count - 1
            Select Case strings_names.Item(i)
                'main
                Case "caption"
                    Window.Title = strings_values.Item(i)
                Case "author"
                    lbl_inst.Content = strings_values.Item(i)
                Case "learn_caption"
                    lbl_edu.Content = strings_values.Item(i)
                Case "control_caption"
                    lbl_control.Content = strings_values.Item(i)
                Case "splash_type"
                    splash_type = strings_values.Item(i)
                Case "splash_path"
                    splash_path = strings_values.Item(i)
                Case "help_type"
                    help_type = strings_values.Item(i)
                Case "help_path"
                    help_path = strings_values.Item(i)
                Case "test_path"
                    test_path = strings_values.Item(i)
                Case "test_type"
                    test_type = strings_values.Item(i)
                Case "umk_path"
                    umk_path = strings_values.Item(i)
                Case "umk_type"
                    umk_type = strings_values.Item(i)
                Case "about_type"
                    about_type = strings_values.Item(i)
                Case "about_path"
                    about_path = strings_values.Item(i)
                Case "pict_viewer_path"
                    pic_viewer_path = strings_values.Item(i)
                Case "web_browser_path"
                    web_browser_path = strings_values.Item(i)
                    'element visibility
                Case "splash_enabled"
                    If LCase(strings_values.Item(i)) = "false" Then splash_enabled = False Else splash_enabled = True
                Case "help_enabled"
                    If LCase(strings_values.Item(i)) = "false" Then help_enabled = False Else help_enabled = True
                Case "umk_enabled"
                    If LCase(strings_values.Item(i)) = "false" Then edu_enabled = False Else edu_enabled = True
                Case "test_enabled"
                    If LCase(strings_values.Item(i)) = "false" Then control_enabled = False Else control_enabled = True
                Case "about_enabled"
                    If LCase(strings_values.Item(i)) = "false" Then inst_enabled = False Else inst_enabled = True
                    'other
                Case "search_enabled"
                    If LCase(strings_values.Item(i)) = "true" Then txt_search_box.Visibility = System.Windows.Visibility.Visible Else txt_search_box.Visibility = System.Windows.Visibility.Hidden
                Case "glass_enabled"
                    If LCase(strings_values.Item(i)) = "true" Then Glass_Is_Enabled = True Else Glass_Is_Enabled = False
                Case "licence_path"
                    licence_path = strings_values.Item(i)
                Case "licence_type"
                    licence_type = strings_values.Item(i)
            End Select
        Next

        'showing licence box
        If (Len(licence_path) > 0 And Len(licence_type) > 0) Then
            Dim licence_window As New window_licence()
            If (licence_type = "page") Then
                If My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "Content\" & licence_path) = False Then
                    MessageBox.Show("Ошибка, при загрузке программы: файл с лицензионным соглашением не найден!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Asterisk)
                    Application.Current.Shutdown()
                Else
                    licence_window.web_browser.Navigate(New Uri(AppDomain.CurrentDomain.BaseDirectory & "Content\" & licence_path))
                End If
            Else
                licence_window.web_browser.Navigate(New Uri(licence_path))
            End If
            licence_window.ShowDialog()
            If licence_window.apply = False Then Application.Current.Shutdown()
        End If

        'checking and applying
        If Len(splash_path) > 3 And Len(splash_type) > 3 And splash_enabled = True Then
            Select Case splash_type
                Case "url"
                    web_browser.Visibility = Visibility.Visible
                    web_browser.Navigate(New Uri(splash_path))
                    last_action = "web"
                Case "page"
                    web_browser.Visibility = Visibility.Visible
                    web_browser.Navigate(New Uri(AppDomain.CurrentDomain.BaseDirectory & "Content\" & splash_path))
                    last_action = "web"
                Case "image"
                    img_splash.Visibility = Visibility.Visible
                    temp_img.BeginInit()
                    temp_img.UriSource = New Uri(AppDomain.CurrentDomain.BaseDirectory & "Content\" & splash_path, UriKind.Absolute)
                    temp_img.EndInit()
                    img_splash.Source = temp_img
                    last_action = "img"
            End Select
        End If
        If Len(help_path) < 3 Or Len(help_type) < 2 Or help_enabled = False Then lbl_help.IsEnabled = False : lbl_help.Visibility = System.Windows.Visibility.Collapsed
        If Len(umk_path) < 3 Or Len(umk_type) < 2 Or edu_enabled = False Then lbl_edu.IsEnabled = False : lbl_edu.Visibility = System.Windows.Visibility.Collapsed
        If Len(test_path) < 3 Or Len(test_type) < 2 Or control_enabled = False Then lbl_control.IsEnabled = False : lbl_control.Visibility = System.Windows.Visibility.Collapsed
        If Len(about_path) < 3 Or Len(about_type) < 2 Or inst_enabled = False Then lbl_inst.IsEnabled = False : lbl_inst.Visibility = System.Windows.Visibility.Collapsed
        If Glass_Is_Enabled = False Then header_back.Visibility = System.Windows.Visibility.Visible Else header_back.Visibility = System.Windows.Visibility.Hidden

        img_left.IsEnabled = False
        Dim temp_img1 As New BitmapImage()
        Dim temp_img2 As New BitmapImage()
        temp_img1.BeginInit()
        temp_img1.UriSource = New Uri("images\btn_left_dis.png", UriKind.Relative)
        temp_img1.EndInit()
        img_left.Source = temp_img1
        temp_img2.BeginInit()
        temp_img2.UriSource = New Uri("images\btn_right_dis.png", UriKind.Relative)
        temp_img2.EndInit()

        'other settings
        cur_func = 0
        web_history_left.Clear()
        search_isEnabled = False
        search_string = ""
        txt_search_box.Text = ""
        lbl_status.Content = "Готово"
        about_form_ISshown = False
        go_back = False
        last_action = ""
        search_isSearch_for_all = True
        search_isStarted = False
    End Sub

    Private Sub img_left_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles img_left.MouseDown
        If web_browser.CanGoBack Then
            web_browser.GoBack()
        Else
            Dim temp_img4 As New BitmapImage()
            img_left.IsEnabled = False
            temp_img4.BeginInit()
            temp_img4.UriSource = New Uri("images\btn_left_dis.png", UriKind.Relative)
            temp_img4.EndInit()
            img_left.Source = temp_img4
        End If
    End Sub

    Private Sub img_left_MouseEnter(ByVal sender As Object, ByVal e As System.Windows.Input.MouseEventArgs) Handles img_left.MouseEnter
        Dim temp_img As New BitmapImage()
        temp_img.BeginInit()
        temp_img.UriSource = New Uri("images\btn_left_up.png", UriKind.Relative)
        temp_img.EndInit()
        img_left.Source = temp_img
    End Sub

    Private Sub img_left_MouseLeave(ByVal sender As Object, ByVal e As System.Windows.Input.MouseEventArgs) Handles img_left.MouseLeave
        If web_browser.CanGoBack = True Then
            Dim temp_img As New BitmapImage()
            temp_img.BeginInit()
            temp_img.UriSource = New Uri("images\btn_left.png", UriKind.Relative)
            temp_img.EndInit()
            img_left.Source = temp_img
        Else
            Dim temp_img4 As New BitmapImage()
            img_left.IsEnabled = False
            temp_img4.BeginInit()
            temp_img4.UriSource = New Uri("images\btn_left_dis.png", UriKind.Relative)
            temp_img4.EndInit()
            img_left.Source = temp_img4
        End If
    End Sub

    Private Sub web_browser_Navigated(ByVal sender As Object, ByVal e As System.Windows.Navigation.NavigationEventArgs) Handles web_browser.Navigated
        lbl_status.Content = "Готово"
        If web_browser.CanGoBack Then
            Dim temp_img4 As New BitmapImage()
            img_left.IsEnabled = True
            temp_img4.BeginInit()
            temp_img4.UriSource = New Uri("images\btn_left.png", UriKind.Relative)
            temp_img4.EndInit()
            img_left.Source = temp_img4
        Else
            Dim temp_img4 As New BitmapImage()
            img_left.IsEnabled = False
            temp_img4.BeginInit()
            temp_img4.UriSource = New Uri("images\btn_left_dis.png", UriKind.Relative)
            temp_img4.EndInit()
            img_left.Source = temp_img4
        End If
    End Sub

    Public Sub Wait(ByVal seconds As Single)
        Dim newDate As Date
        newDate = DateAndTime.Now.AddSeconds(seconds)
        While DateAndTime.Now.Second < newDate.Second
            Thread.Sleep(100)
        End While
    End Sub

    Public Shared Sub ThreadExtract(ByVal g_temp1 As String)
        Dim file_func As New developers_components_lib.cls_filesystem()
        file_func.extract_all_to_fldr(AppDomain.CurrentDomain.BaseDirectory & "Content\" & g_temp1, get_temp_dir() & "\umk_shell\" & get_filename(g_temp1))
        Thread.Sleep(0)
    End Sub


    Private Sub web_browser_Navigating(ByVal sender As Object, ByVal e As System.Windows.Navigation.NavigatingCancelEventArgs) Handles web_browser.Navigating
        Dim g_temp() As String = Split(e.Uri.ToString, "://")
        lbl_status.Content = "Загрузка..."
        If g_temp.Count > 0 Then
            ' Try
            Select Case g_temp(0)
                Case "web"
                    Process.Start(g_temp(1))
                    e.Cancel = True
                    Exit Sub
                Case "ztest"
                    Dim t As New Thread(AddressOf ThreadExtract)
                    If Microsoft.VisualBasic.Right(g_temp(1), 1) = "/" Or Microsoft.VisualBasic.Right(g_temp(1), 1) = "\" Then g_temp(1) = Microsoft.VisualBasic.Left(g_temp(1), Len(g_temp(1)) - 1)
                    g_temp(1) = ReplaceAll(g_temp(1), "/", "\")
                    If My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "Content\" & g_temp(1)) = True Then
                        Dim file_func As New developers_components_lib.cls_filesystem()
                        Dim win_wait As New window_wait
                        win_wait.Show()
                        t.Start(g_temp(1))
                        If Directory.Exists(get_temp_dir() & "\umk_shell\" & get_filename(g_temp(1))) = True Then
                            Try
                                Directory.Delete(get_temp_dir() & "\umk_shell\" & get_filename(g_temp(1)), True)
                            Catch
                            End Try
                        End If
                        t.Join()
                        win_wait.close_form = True
                        win_wait.Close()
                        If File.Exists(get_temp_dir() & "\umk_shell\" & get_filename(g_temp(1)) & "\app_test.exe") Then
                            Process.Start(get_temp_dir() & "\umk_shell\" & get_filename(g_temp(1)) & "\app_test.exe")
                        ElseIf File.Exists(get_temp_dir() & "\umk_shell\" & get_filename(g_temp(1)) & "\Aist-3w.exe") Then
                            Process.Start(get_temp_dir() & "\umk_shell\" & get_filename(g_temp(1)) & "\Aist-3w.exe")
                        End If
                    End If
                    lbl_status.Content = "Готово"
                    e.Cancel = True
                    Exit Sub
                Case "app"
                    If Microsoft.VisualBasic.Right(g_temp(1), 1) = "/" Or Microsoft.VisualBasic.Right(g_temp(1), 1) = "\" Then g_temp(1) = Microsoft.VisualBasic.Left(g_temp(1), Len(g_temp(1)) - 1)
                    g_temp(1) = ReplaceAll(g_temp(1), "/", "\")
                    If My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "Content\" & g_temp(1)) = True Then
                        Process.Start(AppDomain.CurrentDomain.BaseDirectory & "Content\" & g_temp(1))
                    End If
                    lbl_status.Content = "Готово"
                    e.Cancel = True
                    Exit Sub
                Case "fldr"
                    If Microsoft.VisualBasic.Right(g_temp(1), 1) = "/" Or Microsoft.VisualBasic.Right(g_temp(1), 1) = "\" Then g_temp(1) = Microsoft.VisualBasic.Left(g_temp(1), Len(g_temp(1)) - 1)
                    g_temp(1) = ReplaceAll(g_temp(1), "/", "\")
                    If My.Computer.FileSystem.DirectoryExists(AppDomain.CurrentDomain.BaseDirectory & "Content\" & g_temp(1)) = True Then
                        Process.Start(AppDomain.CurrentDomain.BaseDirectory & "Content\" & g_temp(1))
                    End If
                    e.Cancel = True
                    lbl_status.Content = "Готово"
                    Exit Sub
                Case "pic"
                    If Microsoft.VisualBasic.Right(g_temp(1), 1) = "/" Or Microsoft.VisualBasic.Right(g_temp(1), 1) = "\" Then g_temp(1) = Microsoft.VisualBasic.Left(g_temp(1), Len(g_temp(1)) - 1)
                    g_temp(1) = ReplaceAll(g_temp(1), "/", "\")
                    If My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "Content\" & g_temp(1)) = True Then
                        Dim win_img As New win_screen
                        Dim temp_img1 As New BitmapImage()
                        temp_img1.BeginInit()
                        temp_img1.UriSource = New Uri(AppDomain.CurrentDomain.BaseDirectory & "Content\" & g_temp(1), UriKind.RelativeOrAbsolute)
                        temp_img1.EndInit()
                        win_img.img_pic.Source = temp_img1
                        win_img.ShowDialog()
                    End If
                    e.Cancel = True
                    lbl_status.Content = "Готово"
                    Exit Sub
                Case "other"
                    If Microsoft.VisualBasic.Right(g_temp(1), 1) = "/" Or Microsoft.VisualBasic.Right(g_temp(1), 1) = "\" Then g_temp(1) = Microsoft.VisualBasic.Left(g_temp(1), Len(g_temp(1)) - 1)
                    g_temp(1) = ReplaceAll(g_temp(1), "/", "\")
                    If My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "Content\" & g_temp(1)) = True Then
                        Process.Start(AppDomain.CurrentDomain.BaseDirectory & "Content\" & g_temp(1))
                    End If
                    e.Cancel = True
                    lbl_status.Content = "Готово"
                    Exit Sub
            End Select
            ' Catch
            'Exit Sub
            'End Try
        End If
        pop_up1.IsOpen = False
        go_back = False
        last_action = "web"
    End Sub

    Private Sub lbl_edu_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles lbl_edu.MouseDown
        On Error Resume Next
        If cur_func <> 1 Then clear_history()
        cur_func = 1
        img_splash.Visibility = Visibility.Hidden
        Select Case umk_type
            Case "url"
                If Microsoft.VisualBasic.Left(umk_path, 7) <> "http://" Then umk_path = "http://" & umk_path
                web_browser.Visibility = Visibility.Visible
                web_browser.Navigate(New Uri(umk_path))
                add_to_history(umk_path)
            Case "page"
                web_browser.Visibility = Visibility.Visible
                web_browser.Navigate(New Uri(AppDomain.CurrentDomain.BaseDirectory & "Content\" & umk_path))
                add_to_history(AppDomain.CurrentDomain.BaseDirectory & "Content\" & umk_path)
        End Select
        show_search(False)
        If img_splash.Visibility = System.Windows.Visibility.Visible Then img_splash.Visibility = System.Windows.Visibility.Hidden
        pop_up1.IsOpen = False
        clear_history()
    End Sub

    Private Sub lbl_inst_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles lbl_inst.MouseDown
        On Error Resume Next
        If cur_func <> 3 Then clear_history()
        cur_func = 3
        img_splash.Visibility = Visibility.Hidden
        Select Case about_type
            Case "url"
                If Microsoft.VisualBasic.Left(about_path, 7) <> "http://" Then about_path = "http://" & about_path
                web_browser.Visibility = Visibility.Visible
                web_browser.Navigate(New Uri(about_path))
                add_to_history(about_path)
            Case "page"
                web_browser.Visibility = Visibility.Visible
                web_browser.Navigate(New Uri(AppDomain.CurrentDomain.BaseDirectory & "Content\" & about_path))
                add_to_history(AppDomain.CurrentDomain.BaseDirectory & "Content\" & about_path)
        End Select
        show_search(False)
        If img_splash.Visibility = System.Windows.Visibility.Visible Then img_splash.Visibility = System.Windows.Visibility.Hidden
        pop_up1.IsOpen = False
        clear_history()
    End Sub

    Private Sub lbl_control_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles lbl_control.MouseDown
        On Error Resume Next
        If cur_func <> 2 Then clear_history()
        img_splash.Visibility = Visibility.Hidden
        Select Case test_type
            Case "url"
                If Microsoft.VisualBasic.Left(test_path, 7) <> "http://" Then test_path = "http://" & test_path
                web_browser.Visibility = Visibility.Visible
                web_browser.Navigate(New Uri(test_path))
                add_to_history(test_path)
            Case "page"
                web_browser.Visibility = Visibility.Visible
                web_browser.Navigate(New Uri(AppDomain.CurrentDomain.BaseDirectory & "Content\" & test_path))
                add_to_history(AppDomain.CurrentDomain.BaseDirectory & "Content\" & test_path)
            Case "umk_test"
                Shell(AppDomain.CurrentDomain.BaseDirectory & "Content\" & test_path, AppWinStyle.NormalFocus)
        End Select
        show_search(False)
        If img_splash.Visibility = System.Windows.Visibility.Visible Then img_splash.Visibility = System.Windows.Visibility.Hidden
        cur_func = 2
        pop_up1.IsOpen = False
        clear_history()
    End Sub

    Private Sub lbl_other_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles lbl_other.MouseDown
        pop_up1.PlacementTarget = lbl_other
        If pop_up1.IsOpen = True Then pop_up1.IsOpen = False Else pop_up1.IsOpen = True
    End Sub

    Private Sub lbl_help_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Input.MouseButtonEventArgs)
        On Error Resume Next
        If cur_func <> 4 Then clear_history()
        cur_func = 4
        Select Case help_type
            Case "url"
                If Microsoft.VisualBasic.Left(help_path, 7) <> "http://" Then help_path = "http://" & help_path
                web_browser.Visibility = Visibility.Visible
                web_browser.Navigate(New Uri(help_path))
                add_to_history(help_path)
            Case "page"
                web_browser.Visibility = Visibility.Visible
                web_browser.Navigate(New Uri(AppDomain.CurrentDomain.BaseDirectory & "Content\" & help_path))
                add_to_history(AppDomain.CurrentDomain.BaseDirectory & "Content\" & help_path)
        End Select
        web_browser.Visibility = System.Windows.Visibility.Visible
        web_browser.Focus()
        pop_up1.IsOpen = False
        show_search(False)
        If img_splash.Visibility = System.Windows.Visibility.Visible Then img_splash.Visibility = System.Windows.Visibility.Hidden
    End Sub

    Private Sub lbl_author_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles lbl_author.MouseDown
        pop_up1.IsOpen = False
        Dim wind1_about As New win_about
        wind1_about.ShowDialog()
    End Sub

    Private Sub pop_up1_MouseEnter(ByVal sender As Object, ByVal e As System.Windows.Input.MouseEventArgs) Handles pop_up1.MouseEnter
        pop_up1.StaysOpen = False
    End Sub

    Private Sub pop_up1_MouseLeave(ByVal sender As Object, ByVal e As System.Windows.Input.MouseEventArgs) Handles pop_up1.MouseLeave
        If pop_up1.IsOpen = False Then pop_up1.StaysOpen = True
    End Sub

    Public Sub show_search(ByVal isShown As Boolean)
        If search_isEnabled = isShown Then Exit Sub
        If isShown = False Then
            search_isEnabled = False
            lst.Items.Clear()
            gb_search.Visibility = System.Windows.Visibility.Hidden
            If last_action = "web" Then
                web_browser.Visibility = System.Windows.Visibility.Visible
            Else
                img_splash.Visibility = System.Windows.Visibility.Visible
            End If
            Dim temp_img1 As New BitmapImage()
            temp_img1.BeginInit()
            If web_history_left.Count > 0 Then
                img_left.IsEnabled = False
                temp_img1.UriSource = New Uri("images\btn_left.png", UriKind.Relative)
            Else
                img_left.IsEnabled = False
                temp_img1.UriSource = New Uri("images\btn_left_dis.png", UriKind.Relative)
            End If
            temp_img1.EndInit()
            img_left.Source = temp_img1
        Else
            gb_search.Visibility = System.Windows.Visibility.Visible
            search_isEnabled = True
            If img_splash.Visibility = System.Windows.Visibility.Visible Then img_splash.Visibility = System.Windows.Visibility.Hidden
        End If
    End Sub

    Private Sub txt_search_box_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles txt_search_box.KeyDown
        If e.Key = 6 And Len(txt_search_box.Text) > 0 Then
            start_search(txt_search_box.Text)
            cur_func = 0
        End If
    End Sub

    Private Sub btn_close_search_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles btn_close_search.Click
        show_search(False)
    End Sub

    Private Sub clear_history()
        web_history_left.Clear()
        Dim temp_img4 As New BitmapImage()
    End Sub

    Private Sub add_to_history(ByVal url_path As String)

    End Sub

    Private Sub remove_from_history()
        If web_history_left.Count > 0 Then
            web_history_left.Remove(web_history_left.Count)
        End If
        Dim temp_img2 As New BitmapImage()
        If web_history_left.Count <= 1 Then
            img_left.IsEnabled = False
            temp_img2.BeginInit()
            temp_img2.UriSource = New Uri("images\btn_left_dis.png", UriKind.Relative)
            temp_img2.EndInit()
            img_left.Source = temp_img2
        Else
            img_left.IsEnabled = True
            temp_img2.BeginInit()
            temp_img2.UriSource = New Uri("images\btn_left.png", UriKind.Relative)
            temp_img2.EndInit()
            img_left.Source = temp_img2
        End If
    End Sub

    Private Sub start_search(ByVal search_str As String)
        search_string = search_str
        Dim temp_array() As String = Split(search_string, " ")
        Dim i, i1 As Integer
        search_results_strings.Clear()
        search_results_types.Clear()
        pop_up1.IsOpen = False
        lst.Items.Clear()
        search_found_objects.Clear()
        search_isStarted = True
        lbl_status.Content = "Поиск..."

        If search_isSearch_for_all = True Then
            search(AppDomain.CurrentDomain.BaseDirectory & "Content", search_str)
        Else
            'For i = 0 To search_strings_dir.Count - 1
            'search(AppDomain.CurrentDomain.BaseDirectory & "Content\" & search_strings_dir.Item(i))
            'Next
            'For i = 0 To search_strings_files.Count - 1
            ' search(AppDomain.CurrentDomain.BaseDirectory & "Content\" & search_strings_files.Item(i))
            'Next
        End If
        For i = 0 To search_found_objects.Count - 1
            If search_fastsearch_is_enabled = True Then
                search_results_strings.Add(search_found_objects.Item(i))
                search_results_types.Add(get_type(search_found_objects.Item(i)))
            Else
                Dim found_files() As String
                found_files = Split(LCase(get_filename(search_found_objects.Item(i))), LCase(temp_array(i1)))
                ' If found_files.Count > 1 And check_for_system_ex(lst_files.Item(i)) = False Then search_results_strings.Add(lst_files.Item(i)) : search_results_types.Add("file")
                If found_files.Count > 1 Then search_results_strings.Add(search_found_objects.Item(i)) : search_results_types.Add(get_type(search_found_objects.Item(i)))
            End If
        Next
        If search_results_strings.Count = 0 Then
            MessageBox.Show("Поиск результатов не дал!", "Поиск", MessageBoxButton.OK, MessageBoxImage.Information)
        Else
            lst.SelectedIndex = 0
            For i = 0 To search_results_strings.Count - 1
                lst.Items.Add(New search_row(get_filename(search_results_strings.Item(i)), search_results_types.Item(i), get_relative_path(search_results_strings.Item(i), search_results_types.Item(i))))
            Next
            show_search(True)
            web_browser.Visibility = System.Windows.Visibility.Hidden
            search_isStarted = False
            Dim temp_img1 As New BitmapImage()
            temp_img1.BeginInit()
            img_left.IsEnabled = False
            temp_img1.UriSource = New Uri("images\btn_left_dis.png", UriKind.Relative)
            temp_img1.EndInit()
            img_left.Source = temp_img1
        End If
        lbl_status.Content = "Готово"
    End Sub

    Private Sub search(ByVal search_path As String, ByVal search_str As String)
        Dim file_func As New developers_components_lib.cls_filesystem()
        Dim i As Integer
        Dim j As Integer
        Dim item_is_founded As Boolean = False
        Dim lst_files As System.Collections.ObjectModel.ReadOnlyCollection(Of String)
        If search_fastsearch_is_enabled = True Then
            For i = 0 To fastsearch_list.Count - 1
                item_is_founded = False
                Dim str() As String
                Dim str_tags() As String
                Dim str_path() As String
                Dim str_temp() As String
                Dim str_pure_path() As String
                str_pure_path = Split(fastsearch_list.Item(i).ToString(), ";")
                str = Split(LCase(fastsearch_list.Item(i).ToString()), ";")
                str_path = Split(str(0), LCase(search_str))
                If str_path.Count > 1 Then item_is_founded = True
                If str.Count > 1 Then
                    str_tags = Split(str(1), ",")
                    For j = 0 To str_tags.Count - 1
                        str_temp = Split(str_tags(j), LCase(search_str))
                        If str_temp.Count > 1 Then item_is_founded = True
                    Next
                End If
                If item_is_founded = True Then search_found_objects.Add(str(0))
            Next
        Else
            'search in filenames
            lst_files = My.Computer.FileSystem.FindInFiles(search_path, search_str, True, FileIO.SearchOption.SearchAllSubDirectories)
            For i = 0 To lst_files.Count - 1
                search_found_objects.Add(lst_files.Item(i))
            Next
            Dim lst_folders As System.Collections.ObjectModel.ReadOnlyCollection(Of String)
            'search in folders
            lst_folders = My.Computer.FileSystem.GetDirectories(search_path, FileIO.SearchOption.SearchAllSubDirectories)
            Dim str_found As String
            For i = 0 To lst_folders.Count - 1
                str_found = LCase(lst_folders.Item(i))
                If str_found.Contains(LCase(search_str)) Then search_found_objects.Add(lst_folders.Item(i))
            Next
        End If
    End Sub

    Private Sub gb_header_MouseEnter(ByVal sender As Object, ByVal e As System.Windows.Input.MouseEventArgs) Handles gb_header.MouseEnter
        pop_up1.IsOpen = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        gb_search.Visibility = System.Windows.Visibility.Visible
        lst.Items.Clear()
    End Sub

    Private Sub img_about_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles img_about.MouseDown
        Dim wind_about As New win_about
        wind_about.ShowDialog()
    End Sub

    Private Sub frm_main_Unloaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Me.Unloaded
        'Application.Current.Shutdown()
    End Sub

    Private Sub lst_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles lst.MouseDoubleClick
        Dim ext As String
        If search_isStarted = True Then Exit Sub
        If search_results_strings.Count < 1 Or lst.SelectedIndex < 0 Then Exit Sub
        If File.Exists(search_results_strings.Item(lst.SelectedIndex).ToString) = False And Directory.Exists(search_results_strings.Item(lst.SelectedIndex).ToString) = False Then Exit Sub
        ext = get_extention(search_results_strings.Item(lst.SelectedIndex).ToString)
        If ext = "jpg" Or ext = "jpeg" Or ext = "png" Or ext = "gif" Or ext = "bmp" Then
            Dim win_img As New win_screen
            Dim temp_img1 As New BitmapImage()
            temp_img1.BeginInit()
            temp_img1.UriSource = New Uri(search_results_strings.Item(lst.SelectedIndex).ToString, UriKind.RelativeOrAbsolute)
            temp_img1.EndInit()
            win_img.img_pic.Source = temp_img1
            win_img.ShowDialog()
            ' If Len(pic_viewer_path) > 0 Then Process.Start(pic_viewer_path & " " & search_results_strings.Item(lst.SelectedIndex).ToString) Else Process.Start(search_results_strings.Item(lst.SelectedIndex).ToString)
        Else
            Process.Start(search_results_strings.Item(lst.SelectedIndex).ToString)
        End If
    End Sub

    Private Sub lbl_feedback_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs)
        If cur_func <> 4 Then clear_history()
        cur_func = 4
        open_webdoc("http://dsoft.studenthost.ru/feedback.aspx")
        pop_up1.IsOpen = False
        show_search(False)
        If img_splash.Visibility = System.Windows.Visibility.Visible Then img_splash.Visibility = System.Windows.Visibility.Hidden

    End Sub

End Class

#Region "search_vars"
Public Class search_row
    ' Methods
    Public Sub New(ByVal first As String, ByVal second As String, ByVal last As String)
        Me.Found_Name = first
        Me.Found_path = last
        Me.Found_type = second
    End Sub

    Private _name As String
    Public Property Found_Name() As String
        Get
            Return (_name)
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property
    Private _type As String
    Public Property Found_type() As String
        Get
            Return (_type)
        End Get
        Set(ByVal value As String)
            _type = value
        End Set
    End Property
    Private _path As String
    Public Property Found_path() As String
        Get
            Return (_path)
        End Get
        Set(ByVal value As String)
            _path = value
        End Set
    End Property
End Class
#End Region


