using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Common.BaseModel;
using Thibetanus.Controls.Staff;

namespace Thibetanus.Models.SubPage.Staff
{
    class SkillModel : ObservableObject
    {
        private string _code;
        private string _group;
        private string _name;

        public string Code
        {
            get { return _code; }

            set
            {
                _code = value;
                RaisePropertyChanged("Code");
            }
        }

        public string Group
        {
            get { return _group; }
            set
            {
                _group = value;
                RaisePropertyChanged("Group");
            }
        }
        public string Name
        {
            get { return _name; }

            set{
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

    }
}
