﻿#pragma checksum "D:\source\UWP\Thibetanus\Thibetanus\Views\SubPage\Salon\SalonEdit.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C335922BA3AB42791831E3FE37C6FCFA"
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
    partial class SalonEdit : 
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
            case 2: // Views\SubPage\Salon\SalonEdit.xaml line 13
                {
                    this.viewModel = (global::Thibetanus.ViewModels.SubPage.Salon.SalonEditViewModel)(target);
                }
                break;
            case 3: // Views\SubPage\Salon\SalonEdit.xaml line 17
                {
                    this.listTextBlock = (global::Windows.UI.Xaml.Style)(target);
                }
                break;
            case 4: // Views\SubPage\Salon\SalonEdit.xaml line 21
                {
                    this.listTextBox = (global::Windows.UI.Xaml.Style)(target);
                }
                break;
            case 5: // Views\SubPage\Salon\SalonEdit.xaml line 25
                {
                    this.listComboBox = (global::Windows.UI.Xaml.Style)(target);
                }
                break;
            case 6: // Views\SubPage\Salon\SalonEdit.xaml line 29
                {
                    this.listButton = (global::Windows.UI.Xaml.Style)(target);
                }
                break;
            case 8: // Views\SubPage\Salon\SalonEdit.xaml line 86
                {
                    global::Windows.UI.Xaml.Controls.Button element8 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element8).Click += this.Button_Click;
                }
                break;
            case 10: // Views\SubPage\Salon\SalonEdit.xaml line 70
                {
                    global::Windows.UI.Xaml.Controls.Button element10 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element10).Click += this.Button_Click;
                }
                break;
            case 13: // Views\SubPage\Salon\SalonEdit.xaml line 95
                {
                    this.LargeWindow = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 14: // Views\SubPage\Salon\SalonEdit.xaml line 105
                {
                    this.MediumWindow = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 15: // Views\SubPage\Salon\SalonEdit.xaml line 115
                {
                    this.SmallWindow = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 16: // Views\SubPage\Salon\SalonEdit.xaml line 133
                {
                    this.title = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 17: // Views\SubPage\Salon\SalonEdit.xaml line 135
                {
                    this.salonList = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.salonList).RightTapped += this.SalonList_RightTapped;
                    ((global::Windows.UI.Xaml.Controls.ListView)this.salonList).ItemClick += this.SalonList_ItemClick;
                    ((global::Windows.UI.Xaml.Controls.ListView)this.salonList).KeyUp += this.SalonList_KeyUp;
                }
                break;
            case 18: // Views\SubPage\Salon\SalonEdit.xaml line 140
                {
                    this.menuFlyout = (global::Windows.UI.Xaml.Controls.MenuFlyout)(target);
                }
                break;
            case 19: // Views\SubPage\Salon\SalonEdit.xaml line 142
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

