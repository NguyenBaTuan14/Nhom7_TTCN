﻿#pragma checksum "..\..\..\SuaHoKhau.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "30E9D2703762EEA106539F8BEDDE2AD48F175797"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using System.Windows.Shell;
using TTCN_Nhom7;


namespace TTCN_Nhom7 {
    
    
    /// <summary>
    /// SuaHoKhau
    /// </summary>
    public partial class SuaHoKhau : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 44 "..\..\..\SuaHoKhau.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtmahk;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\SuaHoKhau.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtcccd;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\SuaHoKhau.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtdctc;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\SuaHoKhau.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpNgayDK;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\SuaHoKhau.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtmach;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\SuaHoKhau.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txttench;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\SuaHoKhau.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnsua;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TTCN_Nhom7;component/suahokhau.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\SuaHoKhau.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\SuaHoKhau.xaml"
            ((TTCN_Nhom7.SuaHoKhau)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 32 "..\..\..\SuaHoKhau.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtmahk = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtcccd = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtdctc = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.dpNgayDK = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.txtmach = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.txttench = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.btnsua = ((System.Windows.Controls.Button)(target));
            
            #line 84 "..\..\..\SuaHoKhau.xaml"
            this.btnsua.Click += new System.Windows.RoutedEventHandler(this.btnsua_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

