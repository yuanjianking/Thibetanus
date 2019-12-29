
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Models.SubPage.Service;

namespace Thibetanus.Models.SubPage.Staff
{
    class StaffBookTimeModel
    {
        private string _staffCode;
        private string _date;
        private string _serviceTimeCode;
        private string _customName;

        public string StaffCode { get => _staffCode; set => _staffCode = value; }
        public string Date { get => _date; set => _date = value; }
        public string ServiceTimeCode { get => _serviceTimeCode; set => _serviceTimeCode = value; }
        public string CustomName { get => _customName; set => _customName = value; }
       
    }       
}
