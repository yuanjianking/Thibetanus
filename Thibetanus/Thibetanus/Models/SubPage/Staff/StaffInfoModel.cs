using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Common.BaseModel;
using Thibetanus.Controls.Salon;
using Thibetanus.Controls.Staff;
using Thibetanus.Models.SubPage.Salon;
using Thibetanus.Models.SubPage.Service;

namespace Thibetanus.Models.SubPage.Staff
{
    class StaffInfoModel :  ShowEditModel
    {
        private string _code;
        private string _name;
        private SalonModel _salon;
        private ObservableCollection<SalonModel> _salons = null;

        private ObservableCollection<ServiceModel> _services = null;

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

            set{
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        public SalonModel Salon
        {
            get { return _salon; }
            set
            {
                _salon = value;
                RaisePropertyChanged("Salon");
            }
        }

        public ObservableCollection<SalonModel> Salons
        {
            get { return _salons; }
            set
            {
                _salons = value;
                RaisePropertyChanged("Salons");
            }
        }

        public ObservableCollection<ServiceModel> Services
        {
            get { return _services; }
            set
            {
                _services = value;
                RaisePropertyChanged("Services");
            }
        }       

        public StaffInfoModel()
        {
        }

        public StaffInfoModel(string show, string edit) : base(show, edit)
        {
            this.Code = "E";
            this.Name = "地鼠X";
            this.Salon= new SalonControl().GetAllSalonInfos().First();
            this.Salons = new SalonControl().GetAllSalonInfos();
            this.Services = new ObservableCollection<ServiceModel>();
        }
    }
}
