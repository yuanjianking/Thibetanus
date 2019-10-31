using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Common.BaseModel;
using Thibetanus.Common.Log;
using Thibetanus.Common.UserControls;
using Thibetanus.Controls.Salon;
using Thibetanus.Controls.Service;
using Thibetanus.MasterData;
using Thibetanus.Models.SubPage;
using Thibetanus.Models.SubPage.Salon;
using Thibetanus.Models.SubPage.Service;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml;

namespace Thibetanus.ViewModels.SubPage.Service
{
    class ServiceEditViewModel : SubBaseViewModel
    {
       private ObservableCollection<ServiceModel> _serivces = null;

       public ObservableCollection<ServiceModel> Serivces
        {
            get { return _serivces; }
            set
            {
                _serivces = value;
                RaisePropertyChanged("Serivces");
            }
        }


        public ServiceEditViewModel()
        {
            try
            {
                Serivces = new ServiceControl().GetAllServices();
            }
            catch (Exception ex)
            {
                AppLog.Error(typeof(ServiceEditViewModel), ex.ToString());
            }
        }

        override
        public void DoAddCommand()
        {
            Serivces.Add(new ServiceModel("Collapsed", "Visible"));
        }

        override
        public bool CanAddCommand()
        {
            return Serivces.Count < 100;
        }

        override
        public void DoDelCommand(int index)
        {
            Serivces.RemoveAt(index);
        }

        override
        public bool CanDelCommand()
        {
            return Serivces.Count > 1;
        }

        override
        public void DoSaveCommand()
        {
            if (new ServiceControl().Save(Serivces) != 0)
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
            foreach (var item in Serivces)
            {
                item.Show = "Visible";
                item.Edit = "Collapsed";
            }
        }
    }
}
