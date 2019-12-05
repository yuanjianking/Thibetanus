using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Models.SubPage.Salon;

namespace Thibetanus.Models.SubPage.Assets
{
    class AssetsModel : ShowEditModel
    {
        private string _code;
        private string _name;
        private string _price;
        private string _number;
        private string _salonCode;
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
        public string Number
        {
            get { return _number; }

            set
            {
                _number = value;
                RaisePropertyChanged("Number");
            }
        }

        public string SalonCode
        {
            get { return _salonCode; }

            set
            {
                _salonCode = value;
                RaisePropertyChanged("SalonCode");
            }
        }
        public AssetsModel()
        {
        }

        public AssetsModel(string show, string edit) : base(show, edit)
        {
            this.Code = "Z";
            this.Name = "XXX"; 
            this.Price = "100";
            this.Number = "1";
          }
    }
}
