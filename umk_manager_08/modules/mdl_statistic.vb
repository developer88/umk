Module mdl_statistic
    Dim row_string As String
    Dim temp1() As String
    Dim temp_str As String
    Dim temp_collection As New System.Collections.ObjectModel.Collection(Of String)
    ' Dim umk_folder As String
    ' Dim unit_folder As String
    ' Dim caf_folder As String

    Public Sub generate_statistic(ByVal stat_mode As Integer, ByVal path As String, ByVal unit_fldr As String, ByVal caf_fldr As String, ByVal umk_fldr As String)
        Dim windir As String  ' получаем путь папки Windows
        windir = Environment.GetEnvironmentVariable("windir")
        Dim i As Integer
        '
        'umk_folder = umk_fldr
        'unit_folder = unit_fldr
        'caf_folder = caf_fldr
        Select Case stat_mode
            Case 1
                style_text_base = System.IO.File.ReadAllText(Application.StartupPath & "\styles\stats\" & stat_style & "\unit.tpl")
                style_text_row = System.IO.File.ReadAllText(Application.StartupPath & "\styles\stats\" & stat_style & "\unit_row.tpl")
            Case 2
                style_text_base = System.IO.File.ReadAllText(Application.StartupPath & "\styles\stats\" & stat_style & "\caf.tpl")
                style_text_row = System.IO.File.ReadAllText(Application.StartupPath & "\styles\stats\" & stat_style & "\caf_row.tpl")
            Case 3
                style_text_base = System.IO.File.ReadAllText(Application.StartupPath & "\styles\stats\" & stat_style & "\umk.tpl")
                style_text_row = System.IO.File.ReadAllText(Application.StartupPath & "\styles\stats\" & stat_style & "\umk_row.tpl")
        End Select
        textfile_final = style_text_base
        'replace general strings
        If Len(unit_fldr) > 0 Then
            read_from_text_file_byline(UMK_dir & "\" & unit_fldr & "\info.dat")
            If frm_res.lst_text_file.Items.Count > 0 Then
                For i = 0 To frm_res.lst_text_file.Items.Count - 1
                    temp1 = Split(frm_res.lst_text_file.Items.Item(i), "=")
                    Select Case temp1(0)
                        Case "chief"
                            textfile_final = ReplaceAll(textfile_final, "{DIRECTOR}", get_empty_string(temp1(1), "text"))
                        Case "sub_chief"
                            textfile_final = ReplaceAll(textfile_final, "{UMK_DIRECTOR}", get_empty_string(temp1(1), "text"))
                    End Select
                Next
                textfile_final = ReplaceAll(textfile_final, "{DIRECTOR}", "-")
                textfile_final = ReplaceAll(textfile_final, "{UMK_DIRECTOR}", "-")
            End If
        End If
        If Len(caf_fldr) > 0 Then
            read_from_text_file_byline(UMK_dir & "\" & unit_fldr & "\" & caf_fldr & "\info.dat")
            If frm_res.lst_text_file.Items.Count > 0 Then
                For i = 0 To frm_res.lst_text_file.Items.Count - 1
                    temp1 = Split(frm_res.lst_text_file.Items.Item(i), "=")
                    Select Case temp1(0)
                        Case "chief"
                            textfile_final = ReplaceAll(textfile_final, "{CAF_DIRECTOR}", get_empty_string(temp1(1), "text"))
                    End Select
                Next
                textfile_final = ReplaceAll(textfile_final, "{CAF_DIRECTOR}", "-")
            End If
        End If
        If Len(umk_fldr) > 0 Then
            read_from_text_file_byline(UMK_dir & "\" & unit_fldr & "\" & caf_fldr & "\" & umk_fldr & "\info.dat")
            If frm_res.lst_text_file.Items.Count > 0 Then
                For i = 0 To frm_res.lst_text_file.Items.Count - 1
                    temp1 = Split(frm_res.lst_text_file.Items.Item(i), "=")
                    Select Case temp1(0)
                        Case "author"
                            textfile_final = ReplaceAll(textfile_final, "{UMK_AUTHOR}", get_empty_string(temp1(1), "text"))
                        Case "chief"
                            textfile_final = ReplaceAll(textfile_final, "{UMK_ATTACHED}", get_empty_string(temp1(1), "text"))
                        Case "lectures"
                            textfile_final = ReplaceAll(textfile_final, "{UMK_LECTURE}", get_empty_string(temp1(1), "text"))
                        Case "hours"
                            textfile_final = ReplaceAll(textfile_final, "{UMK_HOURS}", get_empty_string(temp1(1), "text"))
                        Case "exam"
                            textfile_final = ReplaceAll(textfile_final, "{UMK_EXAM}", get_empty_string(temp1(1), "img"))
                        Case "test"
                            textfile_final = ReplaceAll(textfile_final, "{UMK_TEST}", get_empty_string(temp1(1), "img"))
                        Case "examination"
                            textfile_final = ReplaceAll(textfile_final, "{UMK_EXAMINATION}", get_empty_string(temp1(1), "img"))
                        Case "prj"
                            textfile_final = ReplaceAll(textfile_final, "{UMK_PRJ}", get_empty_string(temp1(1), "img"))
                    End Select
                Next
                textfile_final = ReplaceAll(textfile_final, "{UMK_AUTHOR}", "-")
                textfile_final = ReplaceAll(textfile_final, "{UMK_ATTACHED}", "-")
                textfile_final = ReplaceAll(textfile_final, "{UMK_LECTURE}", "-")
                textfile_final = ReplaceAll(textfile_final, "{UMK_HOURS}", "-")
                textfile_final = ReplaceAll(textfile_final, "{UMK_EXAM}", stat_answer_no)
                textfile_final = ReplaceAll(textfile_final, "{UMK_TEST}", stat_answer_no)
                textfile_final = ReplaceAll(textfile_final, "{UMK_EXAMINATION}", stat_answer_no)
                textfile_final = ReplaceAll(textfile_final, "{UMK_PRJ}", stat_answer_no)
            End If
        End If
        textfile_final = ReplaceAll(textfile_final, "{INST}", get_empty_string(unit_fldr, "text"))
        textfile_final = ReplaceAll(textfile_final, "{UMK_NAME}", get_empty_string(umk_fldr, "text"))
        textfile_final = ReplaceAll(textfile_final, "{CAF_NAME}", get_empty_string(caf_fldr, "text"))
        textfile_final = ReplaceAll(textfile_final, "{DATE}", Date.Now)
        'replace main content
        Select Case stat_mode
            Case 1
                textfile_final = ReplaceAll(textfile_final, "{STAT_TYPE}", "Подразделение")
                textfile_final = ReplaceAll(textfile_final, "{INSERT}", generate_unit_stat(path, unit_fldr))
            Case 2
                textfile_final = ReplaceAll(textfile_final, "{STAT_TYPE}", "Кафедра")
                textfile_final = ReplaceAll(textfile_final, "{INSERT}", generate_caf_stat(path, caf_fldr, unit_fldr))
            Case 3
                textfile_final = ReplaceAll(textfile_final, "{STAT_TYPE}", "УМК")
                textfile_final = ReplaceAll(textfile_final, "{INSERT}", generate_umk_stat(path, umk_fldr, caf_fldr, unit_fldr))
        End Select
        'finalyse generating process
        My.Computer.FileSystem.CreateDirectory(Application.StartupPath & "\temp\stat")
        My.Computer.FileSystem.CopyDirectory(Application.StartupPath & "\styles\stats\" & stat_style & "\stat_files", Application.StartupPath & "\temp\stat\stat_files", True)
        System.IO.File.WriteAllText(Application.StartupPath & "\temp\stat\stat.htm", textfile_final)
        i = 0
        Do While My.Computer.FileSystem.FileExists(Application.StartupPath & "\temp\stat\stat.htm") = False
            If i = 25 Then Exit Do
            i = i + 1
        Loop
        Shell(windir & "\explorer.exe " & Application.StartupPath & "\temp\stat\stat.htm", vbNormalFocus)
    End Sub

    Function generate_umk_stat(ByVal path As String, ByVal umk_name As String, ByVal caf_name As String, ByVal unit_name As String) As String
        Dim i1 As Integer
        Dim i2 As Integer
        Dim i As Integer
        Dim element_count As Integer
        temp_collection.Clear()
        For Each founddir As String In My.Computer.FileSystem.GetFiles(path)
            If get_filename(founddir) <> "info.dat" Then temp_collection.Add(get_filename(founddir))
        Next
        row_string = ""
        element_count = 0
        For i = 0 To temp_collection.Count - 1
            For i1 = 0 To temp_collection.Count - 1
                If temp_collection.Item(i1) = temp_collection.Item(i) & ".info" Then
                    temp_str = style_text_row
                    read_from_text_file_byline(UMK_dir & "\" & unit_name & "\" & caf_name & "\" & umk_name & "\" & temp_collection.Item(i) & ".info")
                    If frm_res.lst_text_file.Items.Count > 0 Then
                        element_count = element_count + 1
                        temp_str = ReplaceAll(temp_str, "{#}", element_count)
                        temp_str = ReplaceAll(temp_str, "{FILE_NAME}", get_name(temp_collection.Item(i)))
                        For i2 = 0 To frm_res.lst_text_file.Items.Count - 1
                            temp1 = Split(frm_res.lst_text_file.Items.Item(i2), "=")
                            Select Case temp1(0)
                                Case "desk"
                                    temp_str = ReplaceAll(temp_str, "{FILE_DESK}", get_empty_string(temp1(1), "text"))
                                Case "file_type"
                                    temp_str = ReplaceAll(temp_str, "{FILE_TYPE}", get_empty_string(temp1(1), "text"))
                            End Select
                        Next
                        temp_str = ReplaceAll(temp_str, "{FILE_DESK}", "-")
                        temp_str = ReplaceAll(temp_str, "{FILE_TYPE}", "-")
                        row_string = row_string & temp_str
                    End If
                End If
            Next
        Next
        generate_umk_stat = row_string
    End Function

    Function generate_caf_stat(ByVal path As String, ByVal caf_name As String, ByVal unit_name As String) As String
        Dim i1 As Integer
        Dim i As Integer
        Dim element_count As Integer
        temp_collection.Clear()
        For Each founddir As String In My.Computer.FileSystem.GetDirectories(path)
            temp_collection.Add(get_filename(founddir))
        Next
        row_string = ""
        element_count = 0
        For i = 0 To temp_collection.Count - 1
            If My.Computer.FileSystem.FileExists(UMK_dir & "\" & unit_name & "\" & caf_name & "\" & temp_collection.Item(i) & "\info.dat") = True Then
                temp_str = style_text_row
                read_from_text_file_byline(UMK_dir & "\" & unit_name & "\" & caf_name & "\" & temp_collection.Item(i) & "\info.dat")
                If frm_res.lst_text_file.Items.Count > 0 Then
                    temp_str = ReplaceAll(temp_str, "{UMK_NAME}", temp_collection.Item(i))
                    element_count = element_count + 1
                    temp_str = ReplaceAll(temp_str, "{#}", element_count)
                    For i1 = 0 To frm_res.lst_text_file.Items.Count - 1
                        temp1 = Split(frm_res.lst_text_file.Items.Item(i1), "=")
                        Select Case temp1(0)
                            Case "author"
                                temp_str = ReplaceAll(temp_str, "{UMK_AUTHOR}", get_empty_string(temp1(1), "text"))
                            Case "chief"
                                temp_str = ReplaceAll(temp_str, "{UMK_ATTACHED}", get_empty_string(temp1(1), "text"))
                            Case "lectures"
                                temp_str = ReplaceAll(temp_str, "{UMK_LECTURE}", get_empty_string(temp1(1), "text"))
                            Case "hours"
                                temp_str = ReplaceAll(temp_str, "{UMK_HOURS}", get_empty_string(temp1(1), "text"))
                            Case "exam"
                                temp_str = ReplaceAll(temp_str, "{UMK_EXAM}", get_empty_string(temp1(1), "img"))
                            Case "test"
                                temp_str = ReplaceAll(temp_str, "{UMK_TEST}", get_empty_string(temp1(1), "img"))
                            Case "examination"
                                temp_str = ReplaceAll(temp_str, "{UMK_EXAMINATION}", get_empty_string(temp1(1), "img"))
                            Case "prj"
                                temp_str = ReplaceAll(temp_str, "{UMK_PRJ}", get_empty_string(temp1(1), "img"))
                        End Select
                    Next
                    temp_str = ReplaceAll(temp_str, "{UMK_AUTHOR}", "-")
                    temp_str = ReplaceAll(temp_str, "{UMK_ATTACHED}", "-")
                    temp_str = ReplaceAll(temp_str, "{UMK_LECTURE}", "-")
                    temp_str = ReplaceAll(temp_str, "{UMK_HOURS}", "-")
                    temp_str = ReplaceAll(temp_str, "{UMK_EXAM}", stat_answer_no)
                    temp_str = ReplaceAll(temp_str, "{UMK_TEST}", stat_answer_no)
                    temp_str = ReplaceAll(temp_str, "{UMK_EXAMINATION}", stat_answer_no)
                    temp_str = ReplaceAll(temp_str, "{UMK_PRJ}", stat_answer_no)
                End If
                row_string = row_string & temp_str
            End If
        Next
        generate_caf_stat = row_string
    End Function

    Function generate_unit_stat(ByVal path As String, ByVal unit_name As String) As String
        Dim i1 As Integer
        Dim i As Integer
        Dim element_count As Integer
        temp_collection.Clear()
        For Each founddir As String In My.Computer.FileSystem.GetDirectories(path)
            temp_collection.Add(get_filename(founddir))
        Next
        row_string = ""
        element_count = 0
        For i = 0 To temp_collection.Count - 1
            If My.Computer.FileSystem.FileExists(UMK_dir & "\" & unit_name & "\" & temp_collection.Item(i) & "\info.dat") = True Then
                temp_str = style_text_row
                read_from_text_file_byline(UMK_dir & "\" & unit_name & "\" & temp_collection.Item(i) & "\info.dat")
                If frm_res.lst_text_file.Items.Count > 0 Then
                    element_count = element_count + 1
                    temp_str = ReplaceAll(temp_str, "{#}", element_count)
                    temp_str = ReplaceAll(temp_str, "{CAF_NAME}", temp_collection.Item(i))
                    For i1 = 0 To frm_res.lst_text_file.Items.Count - 1
                        temp1 = Split(frm_res.lst_text_file.Items.Item(i1), "=")
                        Select Case temp1(0)
                            Case "chief"
                                temp_str = ReplaceAll(temp_str, "{CAF_DIRECTOR}", get_empty_string(temp1(1), "text"))
                        End Select
                    Next
                    temp_str = ReplaceAll(temp_str, "{CAF_DIRECTOR}", "text")
                End If
                row_string = row_string & temp_str
            End If
        Next
        generate_unit_stat = row_string
    End Function

    Public Sub load_stat_styles_list()
        frm_options.lst_stat.Items.Clear()
        For Each founddir As String In _
          My.Computer.FileSystem.GetDirectories(Application.StartupPath & "\styles\stats\")
            frm_options.lst_stat.Items.Add(get_filename(founddir))
        Next
    End Sub

    Public Sub load_stat_style_info(ByVal path As String)
        Dim i As Integer
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\styles\stats\" & path & "\index.inf") = True Then
            read_from_text_file_byline(Application.StartupPath & "\styles\stats\" & path & "\index.inf")
            If frm_res.lst_text_file.Items.Count > 1 Then
                stat_answer_no = "0"
                stat_answer_yes = "1"
                stat_style_iscaf = 0
                stat_style_isumk = 0
                stat_style_isunit = 0
                For i = 0 To frm_res.lst_text_file.Items.Count - 1
                    temp1 = Split(frm_res.lst_text_file.Items.Item(i), "=")
                    Select Case temp1(0)
                        Case "answer_yes"
                            stat_answer_yes = temp1(1)
                        Case "answer_no"
                            stat_answer_no = temp1(1)
                        Case "desc"
                            frm_options.lbl_stat.Text = temp1(1)
                        Case "isunit"
                            If temp1(1) = "1" Then stat_style_isunit = 1 : frm_options.chk_stat_unit.Checked = True Else stat_style_isunit = 0 : frm_options.chk_stat_unit.Checked = False
                        Case "iscaf"
                            If temp1(1) = "1" Then stat_style_iscaf = 1 : frm_options.chk_stat_caf.Checked = True Else stat_style_iscaf = 0 : frm_options.chk_stat_caf.Checked = False
                        Case "isumk"
                            If temp1(1) = "1" Then stat_style_isumk = 1 : frm_options.chk_stat_umk.Checked = True Else stat_style_isumk = 0 : frm_options.chk_stat_umk.Checked = False
                    End Select
                Next
            End If
        Else
            frm_options.lbl_stat.Text = "Нет информации, или стиль повреждён."
        End If
    End Sub

    Public Function get_empty_string(ByVal str As String, ByVal type As String)
        get_empty_string = ""
        str = ReplaceAll(str, " ", "")
        Select Case type
            Case "img"
                If str = "1" Then get_empty_string = stat_answer_yes Else get_empty_string = stat_answer_no
            Case "var"
                If Len(str) > 0 Then get_empty_string = stat_answer_yes Else get_empty_string = stat_answer_no
            Case "text"
                If Len(str) > 0 Then get_empty_string = str Else get_empty_string = "-"
        End Select
    End Function

    Public Function get_dir_from_path(ByVal cur_path As String, ByVal cur_mode As Integer)
        Dim final_string As String
        Dim temp1() As String
        Dim temp_string As String
        final_string = ""
        If Len(cur_path) > 0 Then
            temp_string = cur_path
            temp_string = Right(temp_string, Len(temp_string) - Len(UMK_dir))
            If Right(temp_string, 1) = "\" Then Left(temp_string, Len(temp_string) - 1)
            temp1 = Split(temp_string, "\")
            If temp1.Count > 0 Then
                Select Case cur_mode
                    Case 1
                        final_string = temp1(1)
                    Case 2
                        final_string = temp1(2)
                    Case 3
                        final_string = temp1(3)
                End Select
            End If
        End If
        get_dir_from_path = final_string
    End Function


End Module
