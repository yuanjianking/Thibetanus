using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Common.BaseModel;

namespace Thibetanus.Models.SubPage
{
    class LocationModel : ObservableObject
    {
        private string _code;
        private string _province;
        private string _city;

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

        public string Province
        {
            get { return _province; }

            set
            {
                _province = value;
                RaisePropertyChanged("Province");
            }
        }

        public string City
        {
            get { return _city; }

            set
            {
                _city = value;
                RaisePropertyChanged("City");
            }
        }


        public string Name
        {
            get { return _province + ">" + _city; }
            set
            {
                Province = value.Split(">")[0];
                City = value.Split(">")[1];
            }
        }
    }
}
