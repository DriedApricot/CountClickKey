﻿#pragma checksum "..\..\StatsWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CFB11E085D50737A67AC2990DA2F8D1502083BC97AEF43E0A5A79BBF852FC189"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace CountClickKey {
    
    
    /// <summary>
    /// StatsWindow
    /// </summary>
    public partial class StatsWindow : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\StatsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border borderActionTool;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\StatsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bActionTool;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\StatsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel spHome;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\StatsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonHome;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\StatsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonHomeText;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\StatsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel spStats;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\StatsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonStats;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\StatsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonStatsText;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\StatsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel spSupport;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\StatsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonSupport;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\StatsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonSupportText;
        
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
            System.Uri resourceLocater = new System.Uri("/CountClickKey;component/statswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\StatsWindow.xaml"
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
            this.borderActionTool = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.bActionTool = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\StatsWindow.xaml"
            this.bActionTool.Click += new System.Windows.RoutedEventHandler(this.ButtonActionTool_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.spHome = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            this.buttonHome = ((System.Windows.Controls.Button)(target));
            
            #line 65 "..\..\StatsWindow.xaml"
            this.buttonHome.Click += new System.Windows.RoutedEventHandler(this.ButtonHome_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.buttonHomeText = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\StatsWindow.xaml"
            this.buttonHomeText.Click += new System.Windows.RoutedEventHandler(this.ButtonHome_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.spStats = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.buttonStats = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.buttonStatsText = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            this.spSupport = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 10:
            this.buttonSupport = ((System.Windows.Controls.Button)(target));
            return;
            case 11:
            this.buttonSupportText = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

