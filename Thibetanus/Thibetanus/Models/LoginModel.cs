using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Common.BaseModel;

namespace Thibetanus.Models
{
    class LoginModel : ObservableObject
    {
        private string _name;
        private string _password;

        public string Name
        {
            get { return _name; }

            set{
                _name = value;
                RaisePropertyChanged("Name");
            }
        }
         public string Password
         {
            get { return _password; }
            set {
                _password = value;
                RaisePropertyChanged("Password");
            }
         }
    }
}
