using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Thibetanus.Common.UserControls;
using Thibetanus.Models.SubPage.Service;
using Thibetanus.Models.SubPage.Staff;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace Thibetanus.Views.SubPage.Staff
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class StaffEdit : Page
    {

        public StaffEdit()
        {
            this.InitializeComponent();
        }

        private void StaffList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = (StaffInfoModel)e.ClickedItem;

            if (item.Show.Equals("Collapsed"))
            {
                item.Show = "Visible";
                item.Edit = "Collapsed";
            }
            else
            {
                ResetStatus();
                item.Show = "Collapsed";
                item.Edit = "Visible";
            }
        }

        private void StaffList_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            ResetStatus();
        }

        private void StaffList_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key.Equals(VirtualKey.Enter))
            {
                ResetStatus();
            }
        }

        private void ResetStatus()
        {          
            foreach (var item1 in staffList.Items)
            {
                ((StaffInfoModel)item1).Show = "Visible";
                ((StaffInfoModel)item1).Edit = "Collapsed";
            }
        }

        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var item = btn.DataContext as StaffInfoModel;
            viewModel.StaffInfos.Remove(item);
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var item = btn.DataContext as StaffInfoModel;

            Action<object, ObservableCollection<ServiceModel>> action = (o, m) =>
            {
                item.Services.Clear();
                foreach (var m1 in m)
                {
                    int index = 0;
                    foreach (var s in item.Services)
                    {
                        if (s.Code.CompareTo(m1.Code) > 0)
                        {
                            break;
                        }
                        else
                        {
                            index++;
                        }
                    }
                    item.Services.Insert(index, m1);
                }
            };
            ServicePopup p = new ServicePopup(action, item.Services);
            p.Show();
        }
    }
}
