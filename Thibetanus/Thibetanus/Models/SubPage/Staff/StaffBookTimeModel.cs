using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Common.BaseModel;
using Thibetanus.Models.SubPage.Salon;

namespace Thibetanus.Models.SubPage.Staff
{
    class StaffBookTimeModel : ShowEditModel
    {
        private string _staffCode;
        private string _date;
        private string _serviceTimeCode;
        private string _customName;
        public int Id { get; set; }
        public string CreateTime { get; set; }
        public string UpdateTime { get; set; }

        public StaffBookTimeModel()
        {
        }

        public string StaffCode
        {
            get { return _staffCode; }
            set
            {
                _staffCode = value;
                RaisePropertyChanged("StaffCode");
            }
        }
        public string Date
        {
            get { return _date; }
            set
            {
                _date = value;
                RaisePropertyChanged("Date");
            }
        }
        public string ServiceTimeCode
        {
            get { return _serviceTimeCode; }
            set
            {
                _serviceTimeCode = value;
                RaisePropertyChanged("ServiceTimeCode");
            }
        }
        public string CustomName
        {
            get { return _customName; }
            set
            {
                _customName = value;
                RaisePropertyChanged("CustomName");
            }
        }
    }
}
