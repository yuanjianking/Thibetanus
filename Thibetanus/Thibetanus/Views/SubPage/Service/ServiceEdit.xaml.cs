using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Thibetanus.Common.Models;
using Thibetanus.DBmanager.PostgreSQL;
using Thibetanus.Models.SubPage.Salon;
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

namespace Thibetanus.Views.SubPage.Service
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class ServiceEdit : Page
    {
        public ServiceEdit()
        {
            this.InitializeComponent();
        }

        private void ServiceList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = (ServiceModel)e.ClickedItem;

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

        private void ServiceList_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            ResetStatus();
        }

        private void ServiceList_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key.Equals(VirtualKey.Enter))
            {
                ResetStatus();
            }
        }
              
        private void ResetStatus()
        {
            foreach (var item1 in serviceList.Items)
            {
                ((ServiceModel)item1).Show = "Visible";
                ((ServiceModel)item1).Edit = "Collapsed";
            }
        }

      
    }
}
