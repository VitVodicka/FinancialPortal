﻿#pragma checksum "..\..\TitleSetup.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6EF6618658BDC6D97B06458752D7A88FBC2CF6DABD1F0C512C1B7A3529F4E0E6"
//------------------------------------------------------------------------------
// <auto-generated>
//     Tento kód byl generován nástrojem.
//     Verze modulu runtime:4.0.30319.42000
//
//     Změny tohoto souboru mohou způsobit nesprávné chování a budou ztraceny,
//     dojde-li k novému generování kódu.
// </auto-generated>
//------------------------------------------------------------------------------

using FinancialPortal;
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


namespace FinancialPortal {
    
    
    /// <summary>
    /// TitleSetup
    /// </summary>
    public partial class TitleSetup : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\TitleSetup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock usertext;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\TitleSetup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock accounttext;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\TitleSetup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button accountAdd;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\TitleSetup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button userAddButton;
        
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
            System.Uri resourceLocater = new System.Uri("/FinancialPortal;component/titlesetup.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\TitleSetup.xaml"
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
            this.usertext = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.accounttext = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.accountAdd = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\TitleSetup.xaml"
            this.accountAdd.Click += new System.Windows.RoutedEventHandler(this.AccountAdd_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.userAddButton = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\TitleSetup.xaml"
            this.userAddButton.Click += new System.Windows.RoutedEventHandler(this.UserAdd_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 23 "..\..\TitleSetup.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Setup_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
