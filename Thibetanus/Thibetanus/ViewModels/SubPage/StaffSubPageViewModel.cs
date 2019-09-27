using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Common.BaseModel;
using Thibetanus.Common.Helper;
using Thibetanus.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Thibetanus.ViewModels.SubPage
{
    class StaffSubPageViewModel : ObservableObject
    {
        public ObservableCollection<MenuModel> Menus
        {
            get
            {             
                return new ObservableCollection<MenuModel>(MenuHelper.GetXmlHelper().GetMenus(MenuHelper.MenuType.StaffSub));              
            }
        }

        public void NavigateTo(object sender, ItemClickEventArgs e)
        {
            var menu = (MenuModel)e.ClickedItem;
            (Application.Current as App).ContentFrame.Navigate(menu.LinkType);
        }
    }
}
