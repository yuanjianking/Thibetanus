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
    class StaffBookTimeEditViewModel : SubBaseViewModel
    {
        private ObservableCollection<StaffBookTimeModel> _bookTimes = null;
        private ObservableCollection<SalonModel> _salons = null;
        private ObservableCollection<StaffInfoModel> _staffInfos = null;
        private SalonModel _salon = null;
        private StaffInfoModel _staffInfo = null;

        public ObservableCollection<StaffBookTimeModel> BookTimes
        {
            get { return _bookTimes; }
            set
            {
                _bookTimes = value;
                RaisePropertyChanged("BookTimes");
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


        public ObservableCollection<StaffInfoModel> StaffInfos
        {
            get { return _staffInfos; }
            set
            {
                _staffInfos = value;
                RaisePropertyChanged("StaffInfos");
            }
        }

        public SalonModel Salon
        {
            get { return _salon; }
            set
            {
                _salon = value;
                RaisePropertyChanged("Salon");
            }
        }
        public StaffInfoModel StaffInfo
        {
            get { return _staffInfo; }
            set
            {
                _staffInfo = value;
                RaisePropertyChanged("StaffInfo");
            }
        }

        public StaffBookTimeEditViewModel()
        {
            try
            {
                Salons = new SalonControl().GetAllSalonInfos();
                if (Salons.Count > 0)
                {
                    Salon = Salons[0];
                    StaffInfos = new StaffControl().GetStaffInfosBySalon(Salon.Code);
                    if (StaffInfos.Count > 0)
                    { 
                        StaffInfo = StaffInfos[0];
                        BookTimes = new StaffBookTimeControl().GetBookTimesByStaff(StaffInfo.Code);
                    }
                }
                
            }
            catch (Exception ex)
            {
                AppLog.Error(typeof(StaffServiceTimeEditViewModel), ex.ToString());
            }
        }

        public void LoadData(SalonModel salon)
        {
            try
            {
                if (salon != null)
                {
                    StaffInfos = new StaffControl().GetStaffInfosBySalon(salon.Code);
                    if (StaffInfos.Count > 0)
                        StaffInfo = StaffInfos[0];
                }
                else
                {
                    StaffInfos.Clear();
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
            if (new StaffBookTimeControl().Upate(BookTimes) != 0)
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
            foreach (var item in BookTimes)
            {
                item.Show = "Visible";
                item.Edit = "Collapsed";
            }
        }

    }
}
