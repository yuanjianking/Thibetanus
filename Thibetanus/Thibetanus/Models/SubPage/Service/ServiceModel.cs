using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Common.BaseModel;

namespace Thibetanus.Models.SubPage.Service
{
    class ServiceModel : ShowEditModel
    {
        private string _code;
        private string _group;
        private string _name;
        private string _price;

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

            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }


        public string Price
        {
            get { return _price; }

            set
            {
                _price = value;
                RaisePropertyChanged("Price");
            }
        }
        

        public ServiceModel()
        {
        }

        public ServiceModel(string show, string edit)
        {
            this.Show = show;
            this.Edit = edit;
        }
    }
}
