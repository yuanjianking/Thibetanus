using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Common.BaseModel;
using Thibetanus.Models.SubPage.Salon;

namespace Thibetanus.Models.SubPage.Custom
{
    class OrderModel : ObservableObject
    {
        private string _customName;
        private string _salonName;
        private string _staffName;
        private string _serviceName;
        private string _price;
        private string _orderTime;
        private string _serviceTime;
        private string _customComment;
        private string _staffComment;
        private string _status;
        

        public OrderModel()
        {
        }

        public string CustomName { get => _customName; set => _customName = value; }
        public string SalonName { get => _salonName; set => _salonName = value; }
        public string StaffName { get => _staffName; set => _staffName = value; }
        public string ServiceName { get => _serviceName; set => _serviceName = value; }
        public string Price { get => _price; set => _price = value; }
        public string OrderTime { get => _orderTime; set => _orderTime = value; }
        public string ServiceTime { get => _serviceTime; set => _serviceTime = value; }
        public string CustomComment { get => _customComment; set => _customComment = value; }
        public string StaffComment { get => _staffComment; set => _staffComment = value; }
        public string Status { get => _status; set => _status = value; }
    }
}
