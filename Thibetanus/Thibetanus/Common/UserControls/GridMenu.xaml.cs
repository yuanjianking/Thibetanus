using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Thibetanus.Common.Helper;
using Thibetanus.Common.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//https://go.microsoft.com/fwlink/?LinkId=234236 上介绍了“用户控件”项模板

namespace Thibetanus.Common.UserControls
{
    public sealed partial class GridMenu : UserControl
    {
        public static readonly DependencyProperty PageTitleProperty =
             DependencyProperty.Register("PageTitle", typeof(string), typeof(GridMenu), new PropertyMetadata(""));

        public static readonly DependencyProperty MenusProperty =
                 DependencyProperty.Register("Menus", typeof(ObservableCollection<MenuModel>), typeof(GridMenu), new PropertyMetadata(""));

        public GridMenu()
        {
            this.InitializeComponent();
        }

        public string PageTitle
        {
            get { return (string)GetValue(PageTitleProperty); }
            set { SetValue(PageTitleProperty, value); }
        }
               
        public ObservableCollection<MenuModel> Menus
        {
            get { return (ObservableCollection<MenuModel>)GetValue(MenusProperty); }
            set { SetValue(MenusProperty, value); }
        }

        public void NavigateTo(object sender, ItemClickEventArgs e)
        {
            var menu = (MenuModel)e.ClickedItem;
            (Application.Current as App).ContentFrame.Navigate(menu.LinkType);
        }
    }
}
