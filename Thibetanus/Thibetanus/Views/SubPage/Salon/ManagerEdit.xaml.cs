﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Thibetanus.Common.Models;
using Thibetanus.DBmanager.PostgreSQL;
using Thibetanus.Models.SubPage.Salon;
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

namespace Thibetanus.Views.SubPage.Salon
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class ManagerEdit : Page
    {
        public ManagerEdit()
        {
            this.InitializeComponent();
        }

        private void SalonList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = (ManagerModel)e.ClickedItem;

            if (item.Show == "Collapsed")
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

        private void SalonList_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            ResetStatus();
        }

        private void SalonList_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key.Equals(VirtualKey.Enter))
            {
                ResetStatus();
            }
        }
              
        private void ResetStatus()
        {
            foreach (var item1 in salonList.Items)
            {
                ((ManagerModel)item1).Show = "Visible";
                ((ManagerModel)item1).Edit = "Collapsed";
            }
        }

      
    }
}
