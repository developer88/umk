﻿#pragma checksum "..\..\..\themes\generic.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "825CC4114C2EA4DA98C518E6EF193039"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Kent.Boogaart.Windows.Controls;
using Kent.Boogaart.Windows.Controls.themes;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Kent.Boogaart.Windows.Controls.themes {
    
    
    /// <summary>
    /// generic
    /// </summary>
    public partial class generic : System.Windows.ResourceDictionary, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Kent.Boogaart.Windows.Controls;component/themes/generic.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\themes\generic.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 19 "..\..\..\themes\generic.xaml"
            ((System.Windows.Controls.Primitives.ResizeGrip)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.PART_Grip_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 19 "..\..\..\themes\generic.xaml"
            ((System.Windows.Controls.Primitives.ResizeGrip)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.PART_Grip_MouseLeftButtonUp);
            
            #line default
            #line hidden
            
            #line 19 "..\..\..\themes\generic.xaml"
            ((System.Windows.Controls.Primitives.ResizeGrip)(target)).MouseMove += new System.Windows.Input.MouseEventHandler(this.PART_Grip_MouseMove);
            
            #line default
            #line hidden
            
            #line 19 "..\..\..\themes\generic.xaml"
            ((System.Windows.Controls.Primitives.ResizeGrip)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.PART_Grip_MouseDoubleClick);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}