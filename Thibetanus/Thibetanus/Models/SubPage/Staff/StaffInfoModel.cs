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
    class StaffInfoModel : ObservableObject
    {
        private string _code;
        private string _name;
        private string _role;
        private string _salon;
        private ObservableCollection<SkillModel> _skills = null;

        public string Code
        {
            get { return _code; }

            set
            {
                _code = value;
                RaisePropertyChanged("Code");
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

        public string Role
         {
            get { return _role; }
            set {
                _role = value;
                RaisePropertyChanged("Role");
            }
         }

        public string Salon
        {
            get { return _salon; }
            set
            {
                _salon = value;
                RaisePropertyChanged("Salon");
            }
        }

        public ObservableCollection<SkillModel> Skills
        {
            get { return _skills; }
            set
            {
                _skills = value;
                RaisePropertyChanged("Skills");
            }
        }
    }
}
