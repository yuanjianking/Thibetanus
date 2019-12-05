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

namespace Thibetanus.ViewModels.SubPage.Staff
{
    class StaffEditViewModel : SubBaseViewModel
    {
        private ObservableCollection<StaffInfoModel> _staffInfos = null;

        public ObservableCollection<StaffInfoModel> StaffInfos
        {
            get { return _staffInfos; }
            set
            {
                _staffInfos = value;
                RaisePropertyChanged("StaffInfos");
            }
        }

        public StaffEditViewModel()
        {
           
            try
            {
                this.StaffInfos = new StaffControl().GetAllStaffInfos();
            }
            catch (Exception ex)
            {
                AppLog.Error(typeof(StaffEditViewModel), ex.ToString());
            }
        }

       override
       public void DoAddCommand()
        {

            StaffInfos.Add(new StaffInfoModel("Collapsed", "Visible"));
        }

        override
        public bool CanAddCommand()
        {
            return true;
        }

        override
        public void DoDelCommand(int index)
        {
            StaffInfos.RemoveAt(index);
        }

        override
        public bool CanDelCommand()
        {
            return StaffInfos.Count > 1;
        }

        override
        public void DoSaveCommand()
        {
            if (new StaffControl().Save(StaffInfos) != 0)
            {
                ResourceLoader resourceLoader = ResourceLoader.GetForCurrentView("MessageResources");
                string message = resourceLoader.GetString("Success");
                MessagePopup messageopup = new MessagePopup(message);
                messageopup.Show();
                StaffInfos = new StaffControl().GetAllStaffInfos();
            }
        }

        override
        public void ResetStatus()
        {
            foreach (var item in StaffInfos)
            {
                item.Show = "Visible";
                item.Edit = "Collapsed";
            }
        }

    }
}
