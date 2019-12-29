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
    class StaffServiceTimeEditViewModel : SubBaseViewModel
    {
        private ObservableCollection<StaffServiceTimeModel> _serviceTimes = null;
        //private ObservableCollection<SalonModel> _salons = null;
        //private ObservableCollection<StaffInfoModel> _staffInfos = null;
        //private SalonModel _salon = null;
        //private StaffInfoModel _staffInfo = null;

        public ObservableCollection<StaffServiceTimeModel> ServiceTimes
        {
            get { return _serviceTimes; }
            set
            {
                _serviceTimes = value;
                RaisePropertyChanged("ServiceTimes");
            }
        }


        //public ObservableCollection<SalonModel> Salons
        //{
        //    get { return _salons; }
        //    set
        //    {
        //        _salons = value;
        //        RaisePropertyChanged("Salons");
        //    }
        //}


        //public ObservableCollection<StaffInfoModel> StaffInfos
        //{
        //    get { return _staffInfos; }
        //    set
        //    {
        //        _staffInfos = value;
        //        RaisePropertyChanged("StaffInfos");
        //    }
        //}

        //public SalonModel Salon
        //{
        //    get { return _salon; }
        //    set
        //     {
        //        _salon = value;
        //        RaisePropertyChanged("Salon");
        //    }
        //}
        //public StaffInfoModel StaffInfo
        //{
        //    get { return _staffInfo; }
        //    set
        //    {
        //        _staffInfo = value;
        //        RaisePropertyChanged("StaffInfo");
        //    }
        //}

        public StaffServiceTimeEditViewModel()
        {
            try
            {
                //Salons = new SalonControl().GetAllSalonInfos();
                //if(Salons.Count > 0)
                //{
                //    Salon = Salons[0];
                //    StaffInfos = new StaffControl().GetStaffInfosBySalon(Salon.Code);
                //    if(StaffInfos.Count > 0)
                //        StaffInfo = StaffInfos[0];
                //}
                _serviceTimes = new StaffServiceTimeControl().GetAllServiceTimes();
            }
            catch (Exception ex)
            {
                AppLog.Error(typeof(StaffServiceTimeEditViewModel), ex.ToString());
            }
        }

        //public void LoadData(SalonModel salon)
        //{
        //    try
        //    {
        //        if (salon != null)
        //        {
        //            StaffInfos = new StaffControl().GetStaffInfosBySalon(salon.Code);
        //            if (StaffInfos.Count > 0)
        //                StaffInfo = StaffInfos[0];
        //        }
        //        else
        //        {
        //            StaffInfos.Clear();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        AppLog.Error(typeof(StaffOrderEditViewModel), ex.ToString());
        //    }

        //}

        override
        public void DoAddCommand()
        {
            ServiceTimes.Add(new StaffServiceTimeModel("Collapsed", "Visible"));
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
            if (new StaffServiceTimeControl().Save(ServiceTimes) != 0)
            {
                ResourceLoader resourceLoader = ResourceLoader.GetForCurrentView("MessageResources");
                string message = resourceLoader.GetString("Success");
                MessagePopup messageopup = new MessagePopup(message);
                messageopup.Show();
                ServiceTimes = new StaffServiceTimeControl().GetAllServiceTimes();
            }
        }

        override
        public void ResetStatus()
        {
            foreach (var item in ServiceTimes)
            {
                item.Show = "Visible";
                item.Edit = "Collapsed";
            }
        }

    }
}
