﻿#pragma checksum "D:\source\UWP\Thibetanus\Thibetanus\Views\SubPage\Salon\ManagerEdit.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2B5A46B54BA38F5D255C1971BE00D99A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Thibetanus.Views.SubPage.Salon
{
    partial class ManagerEdit : 
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
            case 2: // Views\SubPage\Salon\ManagerEdit.xaml line 13
                {
                    this.viewModel = (global::Thibetanus.ViewModels.SubPage.Salon.ManagerEditViewModel)(target);
                }
                break;
            case 3: // Views\SubPage\Salon\ManagerEdit.xaml line 17
                {
                    this.listTextBlock = (global::Windows.UI.Xaml.Style)(target);
                }
                break;
            case 4: // Views\SubPage\Salon\ManagerEdit.xaml line 21
                {
                    this.listTextBox = (global::Windows.UI.Xaml.Style)(target);
                }
                break;
            case 5: // Views\SubPage\Salon\ManagerEdit.xaml line 25
                {
                    this.listComboBox = (global::Windows.UI.Xaml.Style)(target);
                }
                break;
            case 10: // Views\SubPage\Salon\ManagerEdit.xaml line 70
                {
                    this.LargeWindow = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 11: // Views\SubPage\Salon\ManagerEdit.xaml line 80
                {
                    this.MediumWindow = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 12: // Views\SubPage\Salon\ManagerEdit.xaml line 90
                {
                    this.SmallWindow = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 13: // Views\SubPage\Salon\ManagerEdit.xaml line 108
                {
                    this.title = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 14: // Views\SubPage\Salon\ManagerEdit.xaml line 110
                {
                    this.salonList = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.salonList).RightTapped += this.SalonList_RightTapped;
                    ((global::Windows.UI.Xaml.Controls.ListView)this.salonList).ItemClick += this.SalonList_ItemClick;
                    ((global::Windows.UI.Xaml.Controls.ListView)this.salonList).KeyUp += this.SalonList_KeyUp;
                }
                break;
            case 15: // Views\SubPage\Salon\ManagerEdit.xaml line 115
                {
                    this.menuFlyout = (global::Windows.UI.Xaml.Controls.MenuFlyout)(target);
                }
                break;
            case 16: // Views\SubPage\Salon\ManagerEdit.xaml line 117
                {
                    this.Copy = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
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

