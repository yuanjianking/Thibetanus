using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Common.Log;
using Thibetanus.Common.UserControls;
using Thibetanus.Controls.Assets;
using Thibetanus.Controls.Salon;
using Thibetanus.Models.SubPage.Assets;
using Thibetanus.Models.SubPage.Salon;
using Windows.ApplicationModel.Resources;

namespace Thibetanus.ViewModels.SubPage.Assets
{
    class AssetsEditViewModel : SubBaseViewModel
    {
        private ObservableCollection<AssetsModel> _assets = null;
        private ObservableCollection<SalonModel> _salons = null;
    
        public ObservableCollection<AssetsModel> Assets
        {
            get { return _assets; }
            set
            {
                _assets = value;
                RaisePropertyChanged("Assets");
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

        public AssetsEditViewModel()
        {
            try
            {
                Salons = new SalonControl().GetAllSalonInfos();
            }
            catch (Exception ex)
            {
                AppLog.Error(typeof(AssetsEditViewModel), ex.ToString());
            }
        }

        public void LoadData(SalonModel salon)
        {
            try
            {
                if (salon != null)
                {
                    Assets = new AssetsControl().GetAssets(salon.Code);
                }
                else
                {
                    Assets = new ObservableCollection<AssetsModel>();
                }
                
            }
            catch (Exception ex)
            {
                AppLog.Error(typeof(AssetsEditViewModel), ex.ToString());
            }
          
        }

        override
        public void DoAddCommand()
        {
            Assets.Add(new AssetsModel("Collapsed", "Visible"));
        }

        override
        public bool CanAddCommand()
        {
            return true;
        }

        override
        public void DoDelCommand(int index)
        {
            Assets.RemoveAt(index);
        }

        override
        public bool CanDelCommand()
        {
            return true;
        }

        override
        public void DoSaveCommand()
        {
            if (new AssetsControl().Save(Assets) != 0)
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
            foreach (var item in Assets)
            {
                item.Show = "Visible";
                item.Edit = "Collapsed";
            }
        }
    }
}
