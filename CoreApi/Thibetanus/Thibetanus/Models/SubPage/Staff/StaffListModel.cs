using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Thibetanus.Models.SubPage.Service;

namespace Thibetanus.Models.SubPage.Staff
{
    public class StaffListModel
    {
        private List<string> _dates = null;
        private List<StaffInfoModel> staffInfos = null;

        public List<string> Dates { get => _dates; set => _dates = value; }
        public List<StaffInfoModel> StaffInfos { get => staffInfos; set => staffInfos = value; }
    }
}
