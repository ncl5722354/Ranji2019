﻿#pragma checksum "..\..\Map_Set.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4D10C197C3F31DD7AAA4112A2320006EC81D68EA"
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
    /// Map_Set
    /// </summary>
    public partial class Map_Set : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\Map_Set.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid maingrid;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\Map_Set.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Imageborder;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\Map_Set.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer ImageScrollviewer;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\Map_Set.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image myimage;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Map_Set.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button add_dizhuang;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfBrowser_warningsystem;component/map_set.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Map_Set.xaml"
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
            return;
            case 2:
            this.Imageborder = ((System.Windows.Controls.Border)(target));
            
            #line 9 "..\..\Map_Set.xaml"
            this.Imageborder.MouseWheel += new System.Windows.Input.MouseWheelEventHandler(this.Imageborder_MouseWheel);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ImageScrollviewer = ((System.Windows.Controls.ScrollViewer)(target));
            
            #line 10 "..\..\Map_Set.xaml"
            this.ImageScrollviewer.MouseWheel += new System.Windows.Input.MouseWheelEventHandler(this.ImageScrollviewer_MouseWheel);
            
            #line default
            #line hidden
            
            #line 10 "..\..\Map_Set.xaml"
            this.ImageScrollviewer.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ImageScrollviewer_MouseDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.myimage = ((System.Windows.Controls.Image)(target));
            
            #line 11 "..\..\Map_Set.xaml"
            this.myimage.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.myimage_MouseDown);
            
            #line default
            #line hidden
            
            #line 11 "..\..\Map_Set.xaml"
            this.myimage.MouseWheel += new System.Windows.Input.MouseWheelEventHandler(this.myimage_MouseWheel);
            
            #line default
            #line hidden
            
            #line 11 "..\..\Map_Set.xaml"
            this.myimage.MouseMove += new System.Windows.Input.MouseEventHandler(this.myimage_MouseMove);
            
            #line default
            #line hidden
            
            #line 11 "..\..\Map_Set.xaml"
            this.myimage.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.myimage_MouseUp);
            
            #line default
            #line hidden
            return;
            case 5:
            this.add_dizhuang = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\Map_Set.xaml"
            this.add_dizhuang.Click += new System.Windows.RoutedEventHandler(this.add_dizhuang_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
