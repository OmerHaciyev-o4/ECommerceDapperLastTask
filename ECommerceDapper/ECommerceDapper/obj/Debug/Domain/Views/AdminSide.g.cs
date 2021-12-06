﻿#pragma checksum "..\..\..\..\Domain\Views\AdminSide.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "260E133E7E6883611685392BBFDA3B2691C64C443682B515DE1196EDF3D30859"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ECommerceDapper.Domain.ViewModels;
using ECommerceDapper.Domain.Views;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
using System.Windows.Shell;


namespace ECommerceDapper.Domain.Views {
    
    
    /// <summary>
    /// AdminSide
    /// </summary>
    public partial class AdminSide : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\..\Domain\Views\AdminSide.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ProductDG;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\..\Domain\Views\AdminSide.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox box;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\..\Domain\Views\AdminSide.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TCode;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\..\Domain\Views\AdminSide.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TName;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\..\Domain\Views\AdminSide.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TQuantity;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\..\Domain\Views\AdminSide.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TPrice;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ECommerceDapper;component/domain/views/adminside.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Domain\Views\AdminSide.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ProductDG = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.box = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 83 "..\..\..\..\Domain\Views\AdminSide.xaml"
            this.box.PasswordChanged += new System.Windows.RoutedEventHandler(this.box_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TCode = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.TQuantity = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.TPrice = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

