﻿#pragma checksum "..\..\CharacterCreation.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "AC427210E76B27AE62F11A32BA1DA8B4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Depths;
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


namespace Depths {
    
    
    /// <summary>
    /// CharacterCreation
    /// </summary>
    public partial class CharacterCreation : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\CharacterCreation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button create_Button;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\CharacterCreation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox name_Box;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\CharacterCreation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image portraitImage;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\CharacterCreation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button port_Next;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\CharacterCreation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button port_Back;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\CharacterCreation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox gender_Combo;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\CharacterCreation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox class_Combo;
        
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
            System.Uri resourceLocater = new System.Uri("/Depths;component/charactercreation.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CharacterCreation.xaml"
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
            this.create_Button = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\CharacterCreation.xaml"
            this.create_Button.Click += new System.Windows.RoutedEventHandler(this.create_Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.name_Box = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.portraitImage = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.port_Next = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.port_Back = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.gender_Combo = ((System.Windows.Controls.ComboBox)(target));
            
            #line 19 "..\..\CharacterCreation.xaml"
            this.gender_Combo.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.portrait_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.class_Combo = ((System.Windows.Controls.ComboBox)(target));
            
            #line 20 "..\..\CharacterCreation.xaml"
            this.class_Combo.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.portrait_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
