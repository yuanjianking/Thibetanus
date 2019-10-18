using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Common.BaseModel;

namespace Thibetanus.Models.SubPage
{
    class ManagerModel : ObservableObject
    {
        private string _code;
        private string _name;
        private string _role;

        public int Id { get; set; }

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

        public string Role
        {
            get { return _role; }
            set
            {
                _role = value;
                RaisePropertyChanged("Role");
            }
        }
    }
}
