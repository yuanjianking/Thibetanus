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
    public class StaffServiceTimeModel : ShowEditModel
    {
        private string _code;
        private string _startTime;
        private string _endTime;

        public int Id { get; set; }
        public string CreateTime { get; set; }
        public string UpdateTime { get; set; }

        public StaffServiceTimeModel()
        {
        }

        public string Code
        {
            get { return _code; }
            set
            {
                _code = value;
                RaisePropertyChanged("Code");
            }
        }
        public string StartTime
        {
            get { return _startTime; }
            set
            {
                _startTime = value;
                RaisePropertyChanged("StartTime");
            }
        }
        public string EndTime
        {
            get { return _endTime; }
            set
            {
                _endTime = value;
                RaisePropertyChanged("EndTime");
            }
        }

        public StaffServiceTimeModel(string show, string edit) : base(show, edit)
        {
        }
    }
}
