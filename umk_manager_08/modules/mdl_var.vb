Module mdl_var
    'path variables
    Public UNIT_path As String
    Public CAF_path As String
    Public UMK_path As String
    Public UMK_item As String
    Public feed_path As String
    Public test_creator_path As String
    Public disk_creator_path As String
    '
    Public cur_edit_type As Integer
    Public cur_show_list As Integer
    Public cur_MODE As Integer '1-basic; 2- search;

    'file types array
    Public umk_filenames(99) As String
    Public umk_filenames_prefix(99) As String

    'temp_variables for info panels and form
    Public info_var(0 To 20) As String
    Public info_var_type(0 To 20) As String
    Public info_var_captions(0 To 20) As String
    Public info_pan_var(0 To 20) As String
    Public info_name As String
    Public cur_info_type As Integer
    Public info_new_var(0 To 20) As String
    Public cur_infopanel_type As String

    'search
    Public search_type As Integer
    Public search_string As String
    Public search_initialised As Boolean
    Public search_started As Boolean
    Public search_opt_find_files As Boolean
    Public search_opt_find_text As Boolean
    Public search_opt_find_folders As Boolean
    Public search_results_strings As New System.Collections.ObjectModel.Collection(Of String)
    Public search_results_types As New System.Collections.ObjectModel.Collection(Of String)
    Public search_for_words As Boolean
    Public cur_result_row As New System.Collections.ObjectModel.Collection(Of String)

    'frm_add
    Public file_styles_caption As New System.Collections.ObjectModel.Collection(Of String)
    Public file_styles_filename As New System.Collections.ObjectModel.Collection(Of String)
    Public file_styles_description As New System.Collections.ObjectModel.Collection(Of String)
    Public create_file As Boolean
    Public cur_add_type As Integer

    'options
    Public options_array As New System.Collections.ObjectModel.Collection(Of String)
    'Public use_transparency As Boolean
    Public use_tray As Boolean
    Public UMK_dir As String
    Public APP_autostart As Boolean
    Public stat_style As String
    Public Info_pan_show As Boolean
    Public need_restart As Boolean
    Public use_check As Boolean

    'drag_n_drop
    Public add_drag_enabled As Boolean
    Public add_drag_path As String
    Public add_drag_used As Boolean

    'statistic
    Public statistic_mode As Integer
    Public style_text_base As String
    Public style_text_row As String
    Public textfile_final As String
    Public text_default_var As String
    Public stat_style_isumk As Integer
    Public stat_style_iscaf As Integer
    Public stat_style_isunit As Integer
    Public stat_answer_yes As String
    Public stat_answer_no As String

    'DWM
    Public cur_form As String

    'FORM1 nav bar
    'Public actions_type As New System.Collections.ObjectModel.Collection(Of String)
    'Public actions_text As New System.Collections.ObjectModel.Collection(Of String)

    'sessions
    Public session_other As New AutoCompleteStringCollection

End Module
