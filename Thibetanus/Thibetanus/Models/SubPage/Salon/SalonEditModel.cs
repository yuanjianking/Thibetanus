using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Common.BaseModel;

namespace Thibetanus.Models.SubPage.Salon
{
    class SalonEditModel : ObservableObject
    {
        private string _code;
        private string _name;
        private string _location;
        private string _manager;
        private string _show = "Visible";
        private string _edit = "Collapsed";

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

            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        public string Location
        {
            get { return _location; }

            set
            {
                _location = value;
                RaisePropertyChanged("Location");
            }
        }
        public string Manager
        {
            get { return _manager; }

            set
            {
                _manager = value;
                RaisePropertyChanged("Manager");
            }
        }

        public string Show
        {
            get { return _show; }

            set
            {
                _show = value;
                RaisePropertyChanged("Show");
            }
        }

        public string Edit
        {
            get { return _edit; }

            set
            {
                _edit = value;
                RaisePropertyChanged("Edit");
            }
        }

        public SalonEditModel()
        {
        }
        public SalonEditModel(string code, string name, string location,string manager)
        {
            this.Code = code;
            this.Name = name;
            this.Location = location;
            this.Manager = manager;

        }
    }
}
