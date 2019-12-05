using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Thibetanus.Common.Enum;
using Thibetanus.Common.Helper;
using Thibetanus.Common.Models;
using Thibetanus.DBmanager.PostgreSQL;
using Thibetanus.MasterData;
using Thibetanus.Models;
using Windows.ApplicationModel.Resources.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace Thibetanus.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainMenu : Page
    {
       
        public MainMenu()
        {
            this.InitializeComponent();
            contentFrame.Navigated += OnNavigated; 
            SystemNavigationManager.GetForCurrentView().BackRequested += PageBackRequested;

        }

        public ObservableCollection<MenuModel> this[Permission key]
        {
            get
            {
                if (key == Permission.Master)
                {
                    return new ObservableCollection<MenuModel>(MenuHelper.GetXmlHelper().GetMenus(MenuHelper.MenuType.MainMaster));
                }
                else if (key == Permission.Manager)
                {
                    return new ObservableCollection<MenuModel>(MenuHelper.GetXmlHelper().GetMenus(MenuHelper.MenuType.MainManager));
                }
                else
                {
                    return new ObservableCollection<MenuModel>();
                }
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var parameter = e.Parameter;
           
            Type type = e.Parameter?.GetType();
            if (type != null)
            {
                Permission permission = (Permission)type.GetProperty("Permission").GetValue(parameter);
                var dataSource = this[permission];
                listView.ItemsSource = dataSource;
            }

            if (e.NavigationMode == NavigationMode.New)
            {
                if (listView.Items.Count > 0)
                {
                    MenuModel link = listView.Items.First() as MenuModel;
                    contentFrame.Navigate(link.LinkType);
                }
            }

            (Application.Current as App).ContentFrame = contentFrame;

            //var t = Task.Run(() => {   });

            //测试用的数据导入
            //using (var context = new PostgreSQLContext())
            //{
            //    PostgreSQLContxtSeeder.Seed(context);
            //}
            ////数据库数据加载，显示慢，转菊花？还是怎么优化？
           //   (new MasterdataManager()).Load();         

            base.OnNavigatedTo(e);
        }

        private void NavLink_Click(object sender, ItemClickEventArgs e)
        {
            MenuModel link = e.ClickedItem as MenuModel;
            if (link != null && link.LinkType != null)
                contentFrame.Navigate(link.LinkType);
            splitView.IsPaneOpen = false;
        }

        private void SplitViewToggle_Click(object sender, RoutedEventArgs e)
        {
            splitView.IsPaneOpen = !splitView.IsPaneOpen;
        }


        private void PageBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (contentFrame == null)
                return;
            if (contentFrame.CanGoBack)
            {
                e.Handled = true;
                contentFrame.GoBack();
            }
        }

        private void OnNavigated(object sender, NavigationEventArgs e)
        {
            // Each time a navigation event occurs, update the Back button's visibility
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
            ((Frame)sender).CanGoBack ?
            AppViewBackButtonVisibility.Visible :
            AppViewBackButtonVisibility.Collapsed;
        }
    }
}
