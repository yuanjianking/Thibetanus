using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Thibetanus.Models.SubPage.Assets;
using Thibetanus.Models.SubPage.Salon;
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

namespace Thibetanus.Views.SubPage.Assets
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class AssetsEdit : Page
    {
        public AssetsEdit()
        {
            this.InitializeComponent();
        }


        private void AssetsList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = (AssetsModel)e.ClickedItem;

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

        private void AssetsList_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            ResetStatus();
        }

        private void AssetsList_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key.Equals(VirtualKey.Enter))
            {
                ResetStatus();
            }
        }

        private void ResetStatus()
        {
            foreach (var item1 in assetsList.Items)
            {
                ((AssetsModel)item1).Show = "Visible";
                ((AssetsModel)item1).Edit = "Collapsed";
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = ((ComboBox)sender).SelectedItem as SalonModel;
            manager.Text = "责任人: " + item.Manager.Name;
            viewModel.LoadData(item);           
        }

        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var item = btn.DataContext as AssetsModel;
            viewModel.Assets.Remove(item);
        }
    }
}
