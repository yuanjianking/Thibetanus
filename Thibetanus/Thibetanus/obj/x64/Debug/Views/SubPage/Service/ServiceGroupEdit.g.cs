﻿#pragma checksum "D:\source\UWP\Thibetanus\Thibetanus\Views\SubPage\Service\ServiceGroupEdit.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "ACBF82144712EDE69D578020375DA29D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Thibetanus.Views.SubPage.Service
{
    partial class ServiceGroupEdit : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Views\SubPage\Service\ServiceGroupEdit.xaml line 13
                {
                    this.viewModel = (global::Thibetanus.ViewModels.SubPage.Service.ServiceGroupEditViewModel)(target);
                }
                break;
            case 3: // Views\SubPage\Service\ServiceGroupEdit.xaml line 18
                {
                    this.listTextBlock = (global::Windows.UI.Xaml.Style)(target);
                }
                break;
            case 4: // Views\SubPage\Service\ServiceGroupEdit.xaml line 22
                {
                    this.listTextBox = (global::Windows.UI.Xaml.Style)(target);
                }
                break;
            case 5: // Views\SubPage\Service\ServiceGroupEdit.xaml line 26
                {
                    this.listComboBox = (global::Windows.UI.Xaml.Style)(target);
                }
                break;
            case 10: // Views\SubPage\Service\ServiceGroupEdit.xaml line 78
                {
                    this.LargeWindow = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 11: // Views\SubPage\Service\ServiceGroupEdit.xaml line 88
                {
                    this.MediumWindow = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 12: // Views\SubPage\Service\ServiceGroupEdit.xaml line 98
                {
                    this.SmallWindow = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 13: // Views\SubPage\Service\ServiceGroupEdit.xaml line 116
                {
                    this.title = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 14: // Views\SubPage\Service\ServiceGroupEdit.xaml line 118
                {
                    this.serviceGroupList = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.serviceGroupList).RightTapped += this.ServiceGroupList_RightTapped;
                    ((global::Windows.UI.Xaml.Controls.ListView)this.serviceGroupList).ItemClick += this.ServiceGroupList_ItemClick;
                    ((global::Windows.UI.Xaml.Controls.ListView)this.serviceGroupList).KeyUp += this.ServiceGroupList_KeyUp;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

