
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Models.SubPage.Service;

namespace Thibetanus.Models.SubPage.Staff
{
    public class StaffServiceTimeModel
    {
        private string _code;
        private string _startTime;
        private string _endTime;
        private string _areaTime;
        public string StartTime { get => _startTime; set => _startTime = value; }
        public string EndTime { get => _endTime; set => _endTime = value; }
        public string Code { get => _code; set => _code = value; }
        public string AreaTime { get => _areaTime; set => _areaTime = value; }
    }
}
