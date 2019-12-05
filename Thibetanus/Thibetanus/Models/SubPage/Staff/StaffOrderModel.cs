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
    class StaffOrderModel : ObservableObject
    {
        private string _salonName;
        private string _staffName;
        private string _orderTime;
     
        public StaffOrderModel()
        {
        }
        
        public string SalonName { get => _salonName; set => _salonName = value; }
        public string StaffName { get => _staffName; set => _staffName = value; }
        public string OrderTime { get => _orderTime; set => _orderTime = value; }
     
    }
}
