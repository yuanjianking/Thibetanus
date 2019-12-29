
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Models.SubPage.Service;

namespace Thibetanus.Models.SubPage.Staff
{
    public class StaffInfoModel
    {
        private string _code;
        private string _name;
       
        private Dictionary<string,List<StaffServiceTimeModel>> _serviceTimes = null;

        public int Id { get; set; }
        public string Code { get => _code; set => _code = value; }
        public string Name { get => _name; set => _name = value; }
        public Dictionary<string, List<StaffServiceTimeModel>> ServiceTimes { get => _serviceTimes; set => _serviceTimes = value; }
    }
}
