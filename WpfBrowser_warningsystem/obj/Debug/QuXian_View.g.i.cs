<<<<<<< HEAD
﻿#pragma checksum "..\..\QuXian_View.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8547CD93637F77D4735D5DB9FAAD25D8"
=======
﻿#pragma checksum "..\..\QuXian_View.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "915632D6718E178CB75E0AA1E9AC06C7FA71225B"
>>>>>>> faf0363c8b660ee6bed408897fdc14387bfc404c
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
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
using System.Windows.Forms.Integration;
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


namespace WpfBrowser_warningsystem {
    
    
    /// <summary>
    /// QuXian_View
    /// </summary>
    public partial class QuXian_View : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\QuXian_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid maingrid;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\QuXian_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.Integration.WindowsFormsHost chart1_formhost;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\QuXian_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.Integration.WindowsFormsHost chart2_formhost;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\QuXian_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label_select_save;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\QuXian_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combo_select_save;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\QuXian_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label_select_jizhun;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\QuXian_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combo_select_jizhun;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\QuXian_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button show_real;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\QuXian_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button show_shoudong;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\QuXian_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_save;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfBrowser_warningsystem;component/quxian_view.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\QuXian_View.xaml"
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
            this.maingrid = ((System.Windows.Controls.Grid)(target));
            
            #line 8 "..\..\QuXian_View.xaml"
            this.maingrid.SizeChanged += new System.Windows.SizeChangedEventHandler(this.maingrid_SizeChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.chart1_formhost = ((System.Windows.Forms.Integration.WindowsFormsHost)(target));
            return;
            case 3:
            this.chart2_formhost = ((System.Windows.Forms.Integration.WindowsFormsHost)(target));
            return;
            case 4:
            this.label_select_save = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.combo_select_save = ((System.Windows.Controls.ComboBox)(target));
            
            #line 12 "..\..\QuXian_View.xaml"
            this.combo_select_save.Drop += new System.Windows.DragEventHandler(this.combo_select_save_Drop);
            
            #line default
            #line hidden
            
            #line 12 "..\..\QuXian_View.xaml"
            this.combo_select_save.MouseEnter += new System.Windows.Input.MouseEventHandler(this.combo_select_save_MouseEnter);
            
            #line default
            #line hidden
            
            #line 12 "..\..\QuXian_View.xaml"
            this.combo_select_save.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.combo_select_save_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 12 "..\..\QuXian_View.xaml"
            this.combo_select_save.DropDownOpened += new System.EventHandler(this.combo_select_save_DropDownOpened);
            
            #line default
            #line hidden
            return;
            case 6:
            this.label_select_jizhun = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.combo_select_jizhun = ((System.Windows.Controls.ComboBox)(target));
            
            #line 14 "..\..\QuXian_View.xaml"
            this.combo_select_jizhun.Drop += new System.Windows.DragEventHandler(this.combo_select_save_Drop);
            
            #line default
            #line hidden
            
            #line 14 "..\..\QuXian_View.xaml"
            this.combo_select_jizhun.MouseEnter += new System.Windows.Input.MouseEventHandler(this.combo_select_jizhun_MouseEnter);
            
            #line default
            #line hidden
            
            #line 14 "..\..\QuXian_View.xaml"
            this.combo_select_jizhun.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.combo_select_save_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 14 "..\..\QuXian_View.xaml"
            this.combo_select_jizhun.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.combo_select_jizhun_MouseDown);
            
            #line default
            #line hidden
            
            #line 14 "..\..\QuXian_View.xaml"
            this.combo_select_jizhun.DropDownOpened += new System.EventHandler(this.combo_select_jizhun_DropDownOpened);
            
            #line default
            #line hidden
            return;
            case 8:
            this.show_real = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\QuXian_View.xaml"
            this.show_real.Click += new System.Windows.RoutedEventHandler(this.show_real_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.show_shoudong = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\QuXian_View.xaml"
            this.show_shoudong.Click += new System.Windows.RoutedEventHandler(this.show_shoudong_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btn_save = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\QuXian_View.xaml"
            this.btn_save.Click += new System.Windows.RoutedEventHandler(this.btn_save_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

