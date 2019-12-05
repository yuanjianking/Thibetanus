using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Models.SubPage.Salon;

namespace Thibetanus.Models.SubPage.Custom
{
    class CustomModel : ShowEditModel
    {
        private string _code;
        private string _name;
        private string _age;
        private string _sex;
        private string _height;
        private string _weight;
        private string _blood;
        private string _tel;
        private string _weiXin;
        private string _detail;

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
        public string Age
        {
            get { return _age; }

            set
            {
                _age = value;
                RaisePropertyChanged("Age");
            }
        }

        public string Sex
        {
            get { return _sex; }

            set
            {
                _sex = value;
                RaisePropertyChanged("Sex");
            }
        }

        public string Height
        {
            get { return _height; }

            set
            {
                _height = value;
                RaisePropertyChanged("Height");
            }
        }

        public string Weight
        {
            get { return _weight; }

            set
            {
                _weight = value;
                RaisePropertyChanged("Weight");
            }
        }

        public string Blood
        {
            get { return _blood; }

            set
            {
                _blood = value;
                RaisePropertyChanged("Blood");
            }
        }

        public string Tel
        {
            get { return _tel; }

            set
            {
                _tel = value;
                RaisePropertyChanged("Tel");
            }
        }

        public string WeiXin
        {
            get { return _weiXin; }

            set
            {
                _weiXin = value;
                RaisePropertyChanged("WeiXin");
            }
        }

        public string Detail
        {
            get { return _detail; }

            set
            {
                _detail = value;
                RaisePropertyChanged("Detail");
            }
        }
        public string SalonCode
        {
            get { return _name; }

            set
            {
                _name = value;
                RaisePropertyChanged("SalonCode");
            }
        }


        public CustomModel()
        {
        }

    }
}
