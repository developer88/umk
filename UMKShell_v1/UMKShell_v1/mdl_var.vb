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
Imports System.Xml
Imports System.Windows.Markup.Primitives
Imports System.Text
Imports System.Windows.Markup
Imports System.Collections.Generic
Imports System.Collections
Imports System.Diagnostics
Imports System.Windows.Markup.XamlParseException
Imports System.Data

Module mdl_var
    'strings components
    Public pdf_is_installed As String
    Public vb_is_installed As String

    'strings collections
    Public strings_values As New System.Collections.ObjectModel.Collection(Of String)
    Public strings_names As New System.Collections.ObjectModel.Collection(Of String)
    Public temp_strings As New System.Collections.ObjectModel.Collection(Of String)
    Public web_history_left As New System.Collections.ObjectModel.Collection(Of String)
    Public web_history_right As New System.Collections.ObjectModel.Collection(Of String)


    'buttons
    Public splash_type As String
    Public splash_path As String
    Public help_type As String
    Public help_path As String
    Public test_type As String
    Public test_path As String
    Public umk_path As String
    Public umk_type As String
    Public about_path As String
    Public about_type As String

    'UI
    Public cur_func As Integer

    'Other
    Public web_browser_path As String
    Public pic_viewer_path As String
    Public go_back As Boolean
    Public Glass_Is_Enabled As Boolean
    Public licence_path As String
    Public licence_type As String

    'search
    Public search_isEnabled As Boolean
    Public search_string As String
    Public search_strings_dir As New System.Collections.ObjectModel.Collection(Of String)
    Public search_strings_files As New System.Collections.ObjectModel.Collection(Of String)
    Public search_strings_exept As New System.Collections.ObjectModel.Collection(Of String)
    Public search_isSearch_for_all As Boolean
    Public search_found_objects As New System.Collections.ObjectModel.Collection(Of String)
    Public search_results_strings As New System.Collections.ObjectModel.Collection(Of String)
    Public search_results_types As New System.Collections.ObjectModel.Collection(Of String)
    Public search_isStarted As Boolean
    Public search_table As DataTable = New DataTable("tbl_results")
    Public search_table_row As DataRow
    Public search_table_column As DataColumn
    Public search_fastsearch_is_enabled As Boolean
    Public fastsearch_list As New System.Collections.ObjectModel.Collection(Of String)

    'forms
    Public about_form_ISshown As Boolean
End Module

