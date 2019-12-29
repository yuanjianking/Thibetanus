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
    class ServiceGroupEditViewModel : SubBaseViewModel
    {
        private ObservableCollection<ServiceGroupModel> _serviceGroups = null;

        public ObservableCollection<ServiceGroupModel> SerivceGroups
        {
            get { return _serviceGroups; }
            set
            {
                _serviceGroups = value;
                RaisePropertyChanged("SerivceGroups");
            }
        }


        public ServiceGroupEditViewModel()
        {
            try
            {
                SerivceGroups = new ServiceGroupControl().GetAllServiceGroups();
            }
            catch (Exception ex)
            {
                AppLog.Error(typeof(ServiceEditViewModel), ex.ToString());
            }
        }

        override
        public void DoAddCommand()
        {
            SerivceGroups.Add(new ServiceGroupModel("Collapsed", "Visible"));
        }

        override
        public bool CanAddCommand()
        {
            return SerivceGroups.Count < 100;
        }

        override
        public void DoDelCommand(int index)
        {
            SerivceGroups.RemoveAt(index);
        }

        override
        public bool CanDelCommand()
        {
            return SerivceGroups.Count > 1;
        }

        override
        public void DoSaveCommand()
        {
            if (new ServiceGroupControl().Save(SerivceGroups) != 0)
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
            foreach (var item in SerivceGroups)
            {
                item.Show = "Visible";
                item.Edit = "Collapsed";
            }
        }
    }
}
