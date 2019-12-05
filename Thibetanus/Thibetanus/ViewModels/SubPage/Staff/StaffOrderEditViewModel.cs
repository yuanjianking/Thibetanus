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
using Thibetanus.Controls;
using Thibetanus.Models;
using Thibetanus.Views;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Thibetanus.Models.SubPage.Staff;
using Thibetanus.Controls.Staff;
using Thibetanus.Common.Log;
using Thibetanus.Models.SubPage.Custom;
using Thibetanus.Models.SubPage.Salon;
using Thibetanus.Controls.Salon;

namespace Thibetanus.ViewModels.SubPage.Staff
{
    class StaffOrderEditViewModel : SubBaseViewModel
    {
        private ObservableCollection<StaffOrderModel> _staffOrders = null;
        private ObservableCollection<SalonModel> _salons = null;

        public ObservableCollection<StaffOrderModel> StaffOrders
        {
            get { return _staffOrders; }
            set
            {
                _staffOrders = value;
                RaisePropertyChanged("StaffOrders");
            }
        }


        public ObservableCollection<SalonModel> Salons
        {
            get { return _salons; }
            set
            {
                _salons = value;
                RaisePropertyChanged("Salons");
            }
        }

        public StaffOrderEditViewModel()
        {
            try
            {
                Salons = new SalonControl().GetAllSalonInfos();
            }
            catch (Exception ex)
            {
                AppLog.Error(typeof(StaffOrderEditViewModel), ex.ToString());
            }
        }

        public void LoadData(SalonModel salon)
        {
            try
            {
                if (salon != null)
                {
                    _staffOrders = new StaffOrderControl().GetOrders(salon.Code);
                }
                else
                {
                    _staffOrders = new ObservableCollection<StaffOrderModel>();
                }

            }
            catch (Exception ex)
            {
                AppLog.Error(typeof(StaffOrderEditViewModel), ex.ToString());
            }

        }

        override
        public void DoAddCommand()
        {

        }

        override
        public bool CanAddCommand()
        {
            return true;
        }

        override
        public void DoDelCommand(int index)
        {

        }

        override
        public bool CanDelCommand()
        {
            return true;
        }

        override
        public void DoSaveCommand()
        {
        }

        override
        public void ResetStatus()
        {
        }

    }
}
