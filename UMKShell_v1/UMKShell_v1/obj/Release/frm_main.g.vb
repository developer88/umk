﻿#ExternalChecksum("..\..\frm_main.xaml","{406ea660-64cf-4c82-b6f0-42d48172a799}","176FFC914189D879FEBE1F54D942D567")
'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.237
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports Microsoft.Windows.Controls
Imports Microsoft.Windows.Controls.Primitives
Imports Microsoft.Windows.Themes
Imports System
Imports System.Diagnostics
Imports System.Windows
Imports System.Windows.Automation
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Forms.Integration
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Markup
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Effects
Imports System.Windows.Media.Imaging
Imports System.Windows.Media.Media3D
Imports System.Windows.Media.TextFormatting
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports UIControls


'''<summary>
'''frm_main
'''</summary>
<Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>  _
Partial Public Class frm_main
    Inherits System.Windows.Window
    Implements System.Windows.Markup.IComponentConnector
    
    
    #ExternalSource("..\..\frm_main.xaml",12)
    Friend WithEvents Window As frm_main
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\frm_main.xaml",116)
    Friend WithEvents LayoutRoot As System.Windows.Controls.Grid
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\frm_main.xaml",125)
    Friend WithEvents header_back As System.Windows.Shapes.Rectangle
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\frm_main.xaml",133)
    Friend WithEvents rec As System.Windows.Shapes.Rectangle
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\frm_main.xaml",134)
    Friend WithEvents gb_header As System.Windows.Controls.Canvas
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\frm_main.xaml",135)
    Friend WithEvents img_left As System.Windows.Controls.Image
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\frm_main.xaml",141)
    Friend WithEvents lbl_edu As System.Windows.Controls.Label
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\frm_main.xaml",146)
    Friend WithEvents lbl_control As System.Windows.Controls.Label
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\frm_main.xaml",151)
    Friend WithEvents lbl_inst As System.Windows.Controls.Label
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\frm_main.xaml",156)
    Friend WithEvents lbl_other As System.Windows.Controls.Label
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\frm_main.xaml",163)
    Friend WithEvents txt_search_box As UIControls.SearchTextBox
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\frm_main.xaml",165)
    Friend WithEvents image1 As System.Windows.Controls.Image
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\frm_main.xaml",166)
    Friend WithEvents web_browser As System.Windows.Controls.WebBrowser
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\frm_main.xaml",167)
    Friend WithEvents img_splash As System.Windows.Controls.Image
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\frm_main.xaml",177)
    Friend WithEvents gb_search As System.Windows.Controls.Grid
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\frm_main.xaml",178)
    Friend WithEvents lst As System.Windows.Controls.ListView
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\frm_main.xaml",201)
    Friend WithEvents btn_close_search As System.Windows.Controls.Button
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\frm_main.xaml",213)
    Friend WithEvents gb_footer As System.Windows.Controls.Canvas
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\frm_main.xaml",214)
    Friend WithEvents img_about As System.Windows.Controls.Image
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\frm_main.xaml",219)
    Friend WithEvents lbl_status As System.Windows.Controls.Label
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\frm_main.xaml",222)
    Friend WithEvents pop_up1 As System.Windows.Controls.Primitives.Popup
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\frm_main.xaml",225)
    Friend WithEvents lbl_author As System.Windows.Controls.Label
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\frm_main.xaml",226)
    Friend WithEvents lbl_help As System.Windows.Controls.Label
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\frm_main.xaml",227)
    Friend WithEvents lbl_feedback As System.Windows.Controls.Label
    
    #End ExternalSource
    
    Private _contentLoaded As Boolean
    
    '''<summary>
    '''InitializeComponent
    '''</summary>
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Public Sub InitializeComponent() Implements System.Windows.Markup.IComponentConnector.InitializeComponent
        If _contentLoaded Then
            Return
        End If
        _contentLoaded = true
        Dim resourceLocater As System.Uri = New System.Uri("/umk_shell;component/frm_main.xaml", System.UriKind.Relative)
        
        #ExternalSource("..\..\frm_main.xaml",1)
        System.Windows.Application.LoadComponent(Me, resourceLocater)
        
        #End ExternalSource
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")>  _
    Sub System_Windows_Markup_IComponentConnector_Connect(ByVal connectionId As Integer, ByVal target As Object) Implements System.Windows.Markup.IComponentConnector.Connect
        If (connectionId = 1) Then
            Me.Window = CType(target,frm_main)
            Return
        End If
        If (connectionId = 2) Then
            Me.LayoutRoot = CType(target,System.Windows.Controls.Grid)
            Return
        End If
        If (connectionId = 3) Then
            Me.header_back = CType(target,System.Windows.Shapes.Rectangle)
            Return
        End If
        If (connectionId = 4) Then
            Me.rec = CType(target,System.Windows.Shapes.Rectangle)
            Return
        End If
        If (connectionId = 5) Then
            Me.gb_header = CType(target,System.Windows.Controls.Canvas)
            Return
        End If
        If (connectionId = 6) Then
            Me.img_left = CType(target,System.Windows.Controls.Image)
            Return
        End If
        If (connectionId = 7) Then
            Me.lbl_edu = CType(target,System.Windows.Controls.Label)
            Return
        End If
        If (connectionId = 8) Then
            Me.lbl_control = CType(target,System.Windows.Controls.Label)
            Return
        End If
        If (connectionId = 9) Then
            Me.lbl_inst = CType(target,System.Windows.Controls.Label)
            Return
        End If
        If (connectionId = 10) Then
            Me.lbl_other = CType(target,System.Windows.Controls.Label)
            Return
        End If
        If (connectionId = 11) Then
            Me.txt_search_box = CType(target,UIControls.SearchTextBox)
            Return
        End If
        If (connectionId = 12) Then
            Me.image1 = CType(target,System.Windows.Controls.Image)
            Return
        End If
        If (connectionId = 13) Then
            Me.web_browser = CType(target,System.Windows.Controls.WebBrowser)
            Return
        End If
        If (connectionId = 14) Then
            Me.img_splash = CType(target,System.Windows.Controls.Image)
            Return
        End If
        If (connectionId = 15) Then
            Me.gb_search = CType(target,System.Windows.Controls.Grid)
            Return
        End If
        If (connectionId = 16) Then
            Me.lst = CType(target,System.Windows.Controls.ListView)
            Return
        End If
        If (connectionId = 17) Then
            Me.btn_close_search = CType(target,System.Windows.Controls.Button)
            Return
        End If
        If (connectionId = 18) Then
            Me.gb_footer = CType(target,System.Windows.Controls.Canvas)
            Return
        End If
        If (connectionId = 19) Then
            Me.img_about = CType(target,System.Windows.Controls.Image)
            Return
        End If
        If (connectionId = 20) Then
            Me.lbl_status = CType(target,System.Windows.Controls.Label)
            Return
        End If
        If (connectionId = 21) Then
            Me.pop_up1 = CType(target,System.Windows.Controls.Primitives.Popup)
            Return
        End If
        If (connectionId = 22) Then
            Me.lbl_author = CType(target,System.Windows.Controls.Label)
            Return
        End If
        If (connectionId = 23) Then
            Me.lbl_help = CType(target,System.Windows.Controls.Label)
            
            #ExternalSource("..\..\frm_main.xaml",226)
            AddHandler Me.lbl_help.MouseDown, New System.Windows.Input.MouseButtonEventHandler(AddressOf Me.lbl_help_MouseDown)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 24) Then
            Me.lbl_feedback = CType(target,System.Windows.Controls.Label)
            
            #ExternalSource("..\..\frm_main.xaml",227)
            AddHandler Me.lbl_feedback.MouseDown, New System.Windows.Input.MouseButtonEventHandler(AddressOf Me.lbl_feedback_MouseDown)
            
            #End ExternalSource
            Return
        End If
        Me._contentLoaded = true
    End Sub
End Class

