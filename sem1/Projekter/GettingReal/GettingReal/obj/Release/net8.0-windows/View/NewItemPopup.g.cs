﻿#pragma checksum "..\..\..\..\View\NewItemPopup.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C5FB3A8451D79115A02DF670EA59956189A7C155"
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


namespace GettingReal {
    
    
    /// <summary>
    /// NewItemPopup
    /// </summary>
    public partial class NewItemPopup : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\View\NewItemPopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lstSelection;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\View\NewItemPopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTimeEstimat;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\View\NewItemPopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddNewItemOK;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\View\NewItemPopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddNewItemFortryd;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GettingReal;component/view/newitempopup.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\NewItemPopup.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.lstSelection = ((System.Windows.Controls.ListBox)(target));
            
            #line 10 "..\..\..\..\View\NewItemPopup.xaml"
            this.lstSelection.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.LstSelection_DoubleClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtTimeEstimat = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.btnAddNewItemOK = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\View\NewItemPopup.xaml"
            this.btnAddNewItemOK.Click += new System.Windows.RoutedEventHandler(this.btnAddNewItemOK_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnAddNewItemFortryd = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\..\View\NewItemPopup.xaml"
            this.btnAddNewItemFortryd.Click += new System.Windows.RoutedEventHandler(this.btnAddNewItemFortryd_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

