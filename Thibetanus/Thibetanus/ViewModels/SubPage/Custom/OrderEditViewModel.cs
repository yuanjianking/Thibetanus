using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Common.Log;
using Thibetanus.Common.UserControls;
using Thibetanus.Controls.Assets;
using Thibetanus.Controls.Custom;
using Thibetanus.Controls.Salon;
using Thibetanus.Models.SubPage.Assets;
using Thibetanus.Models.SubPage.Custom;
using Thibetanus.Models.SubPage.Salon;
using Windows.ApplicationModel.Resources;

namespace Thibetanus.ViewModels.SubPage.Custom
{
    class OrderEditViewModel : SubBaseViewModel
    {
        private ObservableCollection<OrderModel> _orders = null;
        private ObservableCollection<SalonModel> _salons = null;
    
        public ObservableCollection<OrderModel> Orders
        {
            get { return _orders; }
            set
            {
                _orders = value;
                RaisePropertyChanged("Orders");
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

        public OrderEditViewModel()
        {
            try
            {
                Salons = new SalonControl().GetAllSalonInfos();
            }
            catch (Exception ex)
            {
                AppLog.Error(typeof(CustomEditViewModel), ex.ToString());
            }
        }

        public void LoadData(SalonModel salon)
        {
            try
            {
                if (salon != null)
                {
                    _orders = new OrderControl().GetOrders(salon.Code);
                }
                else
                {
                    _orders = new ObservableCollection<OrderModel>();
                }
                
            }
            catch (Exception ex)
            {
                AppLog.Error(typeof(CustomEditViewModel), ex.ToString());
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
