using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Common.BaseModel;
using Thibetanus.Common.Enum;
using Thibetanus.Common.Helper;
using Thibetanus.Common.UserControls;
using Thibetanus.Models;
using Thibetanus.Views;
using Windows.ApplicationModel.Resources;
using Windows.ApplicationModel.Resources.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Thibetanus.ViewModels
{
    class MainMenuViewModel : ObservableObject
    {
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

        public MainMenuViewModel()
        {
            //ResourceContext resourceContext = ResourceContext.GetForViewIndependentUse();
            //ResourceMap resourceMap = ResourceManager.Current.MainResourceMap.GetSubtree("ManagerMenuResources");
            //if(UserPermission == Permission.Master)
            //    resourceMap = ResourceManager.Current.MainResourceMap.GetSubtree("MasterMenuResources");
            //foreach (var map in resourceMap)
            //{
            //    String name = map.Key;
            //    string val = map.Value.Candidates.First().ValueAsString;
            //    this.MenuModels.Add(new MenuModel(name, Type.GetType(val)));
            //}
        }

    }
}
