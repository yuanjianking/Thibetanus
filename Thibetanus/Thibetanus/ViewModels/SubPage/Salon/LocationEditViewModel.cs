using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Common.BaseModel;
using Thibetanus.Common.Exceptions;
using Thibetanus.Common.Log;
using Thibetanus.Common.UserControls;
using Thibetanus.Controls.Salon;
using Thibetanus.MasterData;
using Thibetanus.Models;
using Thibetanus.Models.SubPage;
using Thibetanus.Models.SubPage.Salon;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml;

namespace Thibetanus.ViewModels.SubPage.Salon
{
    class LocationEditViewModel : SubBaseViewModel
    {
       private ObservableCollection<LocationModel> _locations = null;

       public ObservableCollection<LocationModel> Locations
        {
            get { return _locations; }
            set
            {
                _locations = value;
                RaisePropertyChanged("Locations");
            }
        }

        public LocationEditViewModel()
        {
            try
            {
                Locations = new LocationMaster().GetCollection();
            }
            catch (Exception ex)
            {
                AppLog.Error(typeof(LocationEditViewModel), ex.ToString());
            }
        }
        
        override
        public void DoAddCommand()
        {
            Locations.Add(new LocationModel("Collapsed", "Visible"));
        }

        override
        public bool CanAddCommand()
        {
            return Locations.Count < 10;
        }

        override
        public void DoDelCommand(int index)
        {
            Locations.RemoveAt(index);
        }

        override
        public bool CanDelCommand()
        {
            return Locations.Count > 1;
        }

        override
        public void DoSaveCommand()
        {
            if (new LocationMaster().Save() != 0)
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
            foreach (var item in Locations)
            {
                item.Show = "Visible";
                item.Edit = "Collapsed";
            }
        }
    }
}
