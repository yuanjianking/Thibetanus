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
using Thibetanus.MasterData;
using Thibetanus.Models.SubPage;
using Thibetanus.Models.SubPage.Salon;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml;

namespace Thibetanus.ViewModels.SubPage.Salon
{
    class ManagerEditViewModel : SubBaseViewModel
    {
       private ObservableCollection<ManagerModel> _managers = null;

       public ObservableCollection<ManagerModel> Managers
        {
            get { return _managers; }
            set
            {
                _managers = value;
                RaisePropertyChanged("Managers");
            }
        }

        public ManagerEditViewModel()
        {
            try
            {
                Managers = new ManagerMaster().GetCollection();
            }
            catch (Exception ex)
            {
                AppLog.Error(typeof(ManagerEditViewModel), ex.ToString());
            }
        }

        override
         public void DoAddCommand()
        {
            Managers.Add(new ManagerModel("Collapsed", "Visible"));
        }

        override
        public bool CanAddCommand()
        {
            return Managers.Count < 10;
        }

        override
        public void DoDelCommand(int index)
        {
            Managers.RemoveAt(index);
        }

        override
        public bool CanDelCommand()
        {
            return Managers.Count > 1;
        }

        override
        public void DoSaveCommand()
        {
            if (new ManagerMaster().Save() != 0)
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
            foreach (var item in Managers)
            {
                item.Show = "Visible";
                item.Edit = "Collapsed";
            }
        }
    }
}
