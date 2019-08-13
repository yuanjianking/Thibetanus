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
                    return new ObservableCollection<MenuModel>()
                    {
                        new MenuModel("会所管理", Type.GetType("Thibetanus.Views.SubPage.SalonSubPage")),
                        new MenuModel("员工管理", Type.GetType("Thibetanus.Views.SubPage.StaffSubPage")),
                        new MenuModel("薪资管理", Type.GetType("Thibetanus.Views.SubPage.SalarySubPage")),
                        new MenuModel("资产管理", Type.GetType("Thibetanus.Views.SubPage.AssetsSubPage")),
                        new MenuModel("客户管理", Type.GetType("Thibetanus.Views.SubPage.CustomSubPage")),
                        new MenuModel("服务管理", Type.GetType("Thibetanus.Views.SubPage.ServiceSubPage")),
                        new MenuModel("报    表", Type.GetType("Thibetanus.Views.SubPage.ReportSubPage"))
                    };
                }
                else if (key == Permission.Manager)
                {
                    return new ObservableCollection<MenuModel>()
                    {
                        new MenuModel("员工管理", Type.GetType("Thibetanus.Views.SubPage.StaffSubPage")),
                        new MenuModel("资产管理", Type.GetType("Thibetanus.Views.SubPage.AssetsSubPage")),
                    };
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
