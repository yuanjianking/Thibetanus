using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Common.BaseModel;

namespace Thibetanus.Models.SubPage.Service
{
    public class ServiceGroupModel : ShowEditModel
    {
        private string _code;
        private string _groupName;
        private string _showIndex;
        public int Id { get; set; }
        public string CreateTime { get; set; }
        public string UpdateTime { get; set; }

        public string Code
        {
            get { return _code; }

            set
            {
                _code = value;
                RaisePropertyChanged("Code");
            }
        }

        public string GroupName
        {
            get { return _groupName; }

            set
            {
                _groupName = value;
                RaisePropertyChanged("GroupName");
            }
        }


        public string ShowIndex
        {
            get { return _showIndex; }

            set
            {
                _showIndex = value;
                RaisePropertyChanged("ShowIndex");
            }
        }


        public ServiceGroupModel()
        {
        }

        public ServiceGroupModel(string show, string edit) : base(show, edit)
        {
        }
    }
}
