﻿#pragma checksum "..\..\Window1.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F8CC8068D8F3AF1ABB1787FFB4C0E0C0856ABCE4"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Expression.Controls;
using Microsoft.Expression.Media;
using Microsoft.Expression.Shapes;
using Modul_3.Desktop;
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


namespace Modul_3.Desktop {
    
    
    /// <summary>
    /// Window1
    /// </summary>
    public partial class Window1 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 108 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Baza;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox converterCombobox;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button poprzedni;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button nastepny;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Topka;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Calendar OdKal;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Calendar DoKal;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock OdButton;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DoButton;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Pokaz;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Load;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Expression.Shapes.Arc end;
        
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
            System.Uri resourceLocater = new System.Uri("/Modul_3.Desktop;component/window1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Window1.xaml"
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
            this.Baza = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.converterCombobox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 111 "..\..\Window1.xaml"
            this.converterCombobox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.converterCombobox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.poprzedni = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.nastepny = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.Topka = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.OdKal = ((System.Windows.Controls.Calendar)(target));
            
            #line 121 "..\..\Window1.xaml"
            this.OdKal.SelectedDatesChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.OdKal_SelectedDatesChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.DoKal = ((System.Windows.Controls.Calendar)(target));
            
            #line 122 "..\..\Window1.xaml"
            this.DoKal.SelectedDatesChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.DoKal_SelectedDatesChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.OdButton = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.DoButton = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.Pokaz = ((System.Windows.Controls.Button)(target));
            return;
            case 11:
            this.Load = ((System.Windows.Controls.Grid)(target));
            return;
            case 12:
            this.end = ((Microsoft.Expression.Shapes.Arc)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

