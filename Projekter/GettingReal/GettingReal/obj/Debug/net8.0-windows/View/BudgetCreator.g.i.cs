﻿#pragma checksum "..\..\..\..\View\BudgetCreator.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "105B56EF066D7A3912EF14111B6E41625C248020"
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
    /// BudgetCreator
    /// </summary>
    public partial class BudgetCreator : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 45 "..\..\..\..\View\BudgetCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPriceLevelLow;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\View\BudgetCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPriceLevelMedium;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\View\BudgetCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPriceLevelHigh;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\View\BudgetCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNewBudget;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\View\BudgetCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSaveBudget;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\View\BudgetCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLoadBudget;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\View\BudgetCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCopyToClipboard;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\View\BudgetCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid myDataGrid;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\View\BudgetCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn PriceColumn;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\View\BudgetCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRabat;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\..\View\BudgetCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTotalPris;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GettingReal;component/view/budgetcreator.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\BudgetCreator.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btnPriceLevelLow = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\..\View\BudgetCreator.xaml"
            this.btnPriceLevelLow.Click += new System.Windows.RoutedEventHandler(this.PriceLevel_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnPriceLevelMedium = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\..\View\BudgetCreator.xaml"
            this.btnPriceLevelMedium.Click += new System.Windows.RoutedEventHandler(this.PriceLevel_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnPriceLevelHigh = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\..\View\BudgetCreator.xaml"
            this.btnPriceLevelHigh.Click += new System.Windows.RoutedEventHandler(this.PriceLevel_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 48 "..\..\..\..\View\BudgetCreator.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.CheckBox_Checked);
            
            #line default
            #line hidden
            
            #line 48 "..\..\..\..\View\BudgetCreator.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.CheckBox_Unchecked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnNewBudget = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\..\View\BudgetCreator.xaml"
            this.btnNewBudget.Click += new System.Windows.RoutedEventHandler(this.NewBudget_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnSaveBudget = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\..\View\BudgetCreator.xaml"
            this.btnSaveBudget.Click += new System.Windows.RoutedEventHandler(this.SaveBudget_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnLoadBudget = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\..\View\BudgetCreator.xaml"
            this.btnLoadBudget.Click += new System.Windows.RoutedEventHandler(this.LoadBudget_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnCopyToClipboard = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\..\View\BudgetCreator.xaml"
            this.btnCopyToClipboard.Click += new System.Windows.RoutedEventHandler(this.CopyToClipboard_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.myDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 57 "..\..\..\..\View\BudgetCreator.xaml"
            this.myDataGrid.CellEditEnding += new System.EventHandler<System.Windows.Controls.DataGridCellEditEndingEventArgs>(this.MyDataGrid_CellEditEnding);
            
            #line default
            #line hidden
            
            #line 57 "..\..\..\..\View\BudgetCreator.xaml"
            this.myDataGrid.KeyDown += new System.Windows.Input.KeyEventHandler(this.EnterKeyDown);
            
            #line default
            #line hidden
            return;
            case 10:
            this.PriceColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 12:
            this.txtRabat = ((System.Windows.Controls.TextBox)(target));
            
            #line 75 "..\..\..\..\View\BudgetCreator.xaml"
            this.txtRabat.LostFocus += new System.Windows.RoutedEventHandler(this.TextRabat_LostFocus);
            
            #line default
            #line hidden
            
            #line 75 "..\..\..\..\View\BudgetCreator.xaml"
            this.txtRabat.KeyDown += new System.Windows.Input.KeyEventHandler(this.EnterKeyDown);
            
            #line default
            #line hidden
            return;
            case 13:
            this.lblTotalPris = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 11:
            
            #line 65 "..\..\..\..\View\BudgetCreator.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteButton_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

