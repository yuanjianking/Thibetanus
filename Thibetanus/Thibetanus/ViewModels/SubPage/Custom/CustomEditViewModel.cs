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
    class CustomEditViewModel : SubBaseViewModel
    {
        private ObservableCollection<CustomModel> _customs = null;
        private ObservableCollection<SalonModel> _salons = null;
    
        public ObservableCollection<CustomModel> Customs
        {
            get { return _customs; }
            set
            {
                _customs = value;
                RaisePropertyChanged("Customs");
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

        public CustomEditViewModel()
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
                    _customs = new CustomControl().GetCustoms(salon.Code);
                }
                else
                {
                    _customs = new ObservableCollection<CustomModel>();
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
            if (new CustomControl().Save(Customs) != 0)
            {
                ResourceLoader resourceLoader = ResourceLoader.GetForCurrentView("MessageResources");
                string message = resourceLoader.GetString("Success");
                MessagePopup messageopup = new MessagePopup(message);
                messageopup.Show();
            }
        }

        override
        public void ResetStatus()
        {
            foreach (var item in Customs)
            {
                item.Show = "Visible";
                item.Edit = "Collapsed";
            }
        }
    }
}
