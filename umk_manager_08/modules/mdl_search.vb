Module mdl_search

    Public Sub press_search_button()
        If Form1.TextBox1.Text = "Поиск..." Or Len(Form1.TextBox1.Text) = 0 Then Form1.TextBox1.Text = "Поиск..." : Exit Sub
        search_string = Form1.TextBox1.Text
        add_to_sessionlist(Form1.TextBox1.Text)
        update_sessions_obj(0)
        If search_text(search_string) = True Then
            Form1.pan_info.Visible = False
            clear_info_panel()
            initialise_search()
            enable_controls(False)
        Else
            'deinitialize_search()
            Form1.pan_info.Visible = False
            clear_info_panel()
            initialise_search()
            disable_controls(False)
        End If
    End Sub

    Public Sub clear_dg()
        Form1.dg.Rows.Clear()
    End Sub

    Public Function search_text(ByVal target_text As String) As Boolean
        Dim search_result As Boolean
        Dim i As Integer
        Dim found_type As String
        Dim temp_type As String = ""
        'Form1.ListBox1.Items.Clear()
        search_results_strings.Clear()
        search_results_types.Clear()
        clear_dg()
        If search_type = 1 Then 'simple search
            search_for_text(UMK_dir, target_text)
            If search_results_strings.Count > 0 Then
                search_result = True
                clear_dg()
                For i = 0 To search_results_strings.Count - 1
                    found_type = "Файл"
                    Select Case search_results_types(i)
                        Case "file"
                            found_type = "Файл"
                            temp_type = "file"
                        Case "text"
                            'found_type = "Текст"
                            found_type = "Файл"
                            temp_type = "file"
                        Case "folder"
                            found_type = "Папка"
                            temp_type = "folder"
                    End Select
                    Form1.dg.Rows.Add(get_filename(search_results_strings(i)), found_type, get_relative_path(search_results_strings(i), temp_type))
                Next
            Else
                search_result = False
            End If
            'Else 'indexing search
        End If
        search_text = search_result
    End Function

    Public Sub initialise_search()
        'Form1.ListBox1.Width = 448
        search_initialised = True
        Form1.btn_close_search.Visible = True
        Form1.ListBox1.Visible = False
        Form1.dg.Visible = True
    End Sub

    Public Sub deinitialize_search()
        Form1.ListBox1.Visible = True
        Form1.btn_close_search.Visible = False
        search_string = ""
        Form1.dg.Visible = False
        Form1.TextBox1.Text = "Поиск..."
        search_initialised = False
        search_started = False
        clear_dg()
        show_unit()
    End Sub

    Public Sub search_for_text(ByVal search_dir As String, ByVal search_text As String)
        'dim variables
        Dim temp_array() As String = Split(search_text, " ")
        Dim i, i1 As Integer
        Dim lst_files As System.Collections.ObjectModel.ReadOnlyCollection(Of String)
        Dim lst_text As System.Collections.ObjectModel.ReadOnlyCollection(Of String)
        Dim lst_folders As System.Collections.ObjectModel.ReadOnlyCollection(Of String)
        'search for BIG letters strconv ("",vbstrconv.propercase)
        If search_opt_find_files = True Then
            'search in filenames
            lst_files = My.Computer.FileSystem.FindInFiles(search_dir, "", True, FileIO.SearchOption.SearchAllSubDirectories)
            '1)FILES
            If lst_files.Count > 0 Then
                For i = 0 To lst_files.Count - 1
                    If search_for_words = True And temp_array.Count > 1 Then
                        For i1 = 0 To temp_array.Count - 1
                            Dim found_files() As String
                            'normal
                            ' found_files = Split(get_filename(lst_files.Item(i)), temp_array(i1))
                            'If found_files.Count > 1 And check_for_system_ex(lst_files.Item(i)) = False Then search_results_strings.Add(lst_files.Item(i)) : search_results_types.Add("file")
                            'lowercase
                            found_files = Split(LCase(get_filename(lst_files.Item(i))), LCase(temp_array(i1)))
                            If found_files.Count > 1 And check_for_system_ex(lst_files.Item(i)) = False Then search_results_strings.Add(lst_files.Item(i)) : search_results_types.Add("file")
                            'uppercase
                            'found_files = Split(get_filename(lst_files.Item(i)), UCase(temp_array(i1)))
                            'If found_files.Count > 1 And check_for_system_ex(lst_files.Item(i)) = False Then search_results_strings.Add(lst_files.Item(i)) : search_results_types.Add("file")
                        Next
                    Else
                        Dim found_files() As String
                        'normal
                        'found_files = Split(get_filename(lst_files.Item(i)), search_text)
                        'If found_files.Count > 1 And check_for_system_ex(lst_files.Item(i)) = False Then search_results_strings.Add(lst_files.Item(i)) : search_results_types.Add("file")
                        'lcase
                        found_files = Split(LCase(get_filename(lst_files.Item(i))), LCase(search_text))
                        If found_files.Count > 1 And check_for_system_ex(lst_files.Item(i)) = False Then search_results_strings.Add(lst_files.Item(i)) : search_results_types.Add("file")
                        'ucase
                        'found_files = Split(get_filename(lst_files.Item(i)), UCase(search_text))
                        'If found_files.Count > 1 And check_for_system_ex(lst_files.Item(i)) = False Then search_results_strings.Add(lst_files.Item(i)) : search_results_types.Add("file")
                    End If
                Next
            End If
        End If
        If search_opt_find_text = True Then
            'search in text
            lst_text = My.Computer.FileSystem.FindInFiles(search_dir, search_text, True, FileIO.SearchOption.SearchAllSubDirectories)
            '2)TEXT
            If lst_text.Count > 0 Then
                For i = 0 To lst_text.Count - 1
                    If search_for_words = True And temp_array.Count > 1 Then
                        For i1 = 0 To temp_array.Count - 1
                            Dim found_text() As String
                            'normal
                            ' found_text = Split(get_filename(lst_text.Item(i)), temp_array(i1))
                            'If found_text.Count > 1 And check_for_system_ex(lst_text.Item(i)) = False Then search_results_strings.Add(lst_text.Item(i)) : search_results_types.Add("text")
                            'lcase
                            found_text = Split(LCase(get_filename(lst_text.Item(i))), LCase(temp_array(i1)))
                            If found_text.Count > 1 And check_for_system_ex(lst_text.Item(i)) = False Then search_results_strings.Add(lst_text.Item(i)) : search_results_types.Add("text")
                            'ucase
                            'found_text = Split(get_filename(lst_text.Item(i)), UCase(temp_array(i1)))
                            'If found_text.Count > 1 And check_for_system_ex(lst_text.Item(i)) = False Then search_results_strings.Add(lst_text.Item(i)) : search_results_types.Add("text")
                        Next
                    Else
                        Dim found_text() As String
                        'normal
                        'found_text = Split(get_filename(lst_text.Item(i)), search_text)
                        'If found_text.Count > 1 And check_for_system_ex(lst_text.Item(i)) = False Then search_results_strings.Add(lst_text.Item(i)) : search_results_types.Add("text")
                        'lcase
                        found_text = Split(LCase(get_filename(lst_text.Item(i))), LCase(search_text))
                        If found_text.Count > 1 And check_for_system_ex(lst_text.Item(i)) = False Then search_results_strings.Add(lst_text.Item(i)) : search_results_types.Add("text")
                        'ucase
                        'found_text = Split(get_filename(lst_text.Item(i)), UCase(search_text))
                        ' If found_text.Count > 1 And check_for_system_ex(lst_text.Item(i)) = False Then search_results_strings.Add(lst_text.Item(i)) : search_results_types.Add("text")
                    End If
                Next
            End If
        End If
        If search_opt_find_folders = True Then
            'search_in folders
            lst_folders = My.Computer.FileSystem.GetDirectories(search_dir, FileIO.SearchOption.SearchAllSubDirectories)
            '2)FOLDERS
            If lst_folders.Count > 0 Then
                For i = 0 To lst_folders.Count - 1
                    If search_for_words = True And temp_array.Count > 1 Then
                        For i1 = 0 To temp_array.Count - 1
                            Dim found_folders() As String
                            'normal
                            'found_folders = Split(get_filename(lst_folders.Item(i)), temp_array(i1))
                            'If found_folders.Count > 1 And check_for_system_ex(lst_folders.Item(i)) = False Then search_results_strings.Add(lst_folders.Item(i)) : search_results_types.Add("folder")
                            'lcase
                            found_folders = Split(LCase(get_filename(lst_folders.Item(i))), LCase(temp_array(i1)))
                            If found_folders.Count > 1 And check_for_system_ex(lst_folders.Item(i)) = False Then search_results_strings.Add(lst_folders.Item(i)) : search_results_types.Add("folder")
                            'ucase
                            'found_folders = Split(get_filename(lst_folders.Item(i)), UCase(temp_array(i1)))
                            ' If found_folders.Count > 1 And check_for_system_ex(lst_folders.Item(i)) = False Then search_results_strings.Add(lst_folders.Item(i)) : search_results_types.Add("folder")
                        Next
                    Else
                        Dim found_folders() As String
                        'normal
                        ' found_folders = Split(get_filename(lst_folders.Item(i)), search_text)
                        'If found_folders.Count > 1 And check_for_system_ex(lst_folders.Item(i)) = False Then search_results_strings.Add(lst_folders.Item(i)) : search_results_types.Add("folder")
                        'lcase
                        found_folders = Split(LCase(get_filename(lst_folders.Item(i))), LCase(search_text))
                        If found_folders.Count > 1 And check_for_system_ex(lst_folders.Item(i)) = False Then search_results_strings.Add(lst_folders.Item(i)) : search_results_types.Add("folder")
                        'ucase
                        'found_folders = Split(get_filename(lst_folders.Item(i)), UCase(search_text))
                        ' If found_folders.Count > 1 And check_for_system_ex(lst_folders.Item(i)) = False Then search_results_strings.Add(lst_folders.Item(i)) : search_results_types.Add("folder")
                    End If
                Next
            End If
        End If
    End Sub

End Module
