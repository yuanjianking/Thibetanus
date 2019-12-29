using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Common.BaseModel;
using Thibetanus.Controls.Service;

namespace Thibetanus.Models.SubPage.Service
{
    public class ServiceModel : ShowEditModel
    {
        private string _code;
        private string _name;
        private string _price;
        private ServiceGroupModel _serviceGroup = null;
        private ObservableCollection<ServiceGroupModel> _serviceGroups = null;

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
        public ServiceGroupModel ServiceGroup
        {
            get { return _serviceGroup; }

            set
            {
                _serviceGroup = value;
                RaisePropertyChanged("ServiceGroup");
            }
        }
        public ObservableCollection<ServiceGroupModel> ServiceGroups
        {
            get { return _serviceGroups; }

            set
            {
                _serviceGroups = value;
                RaisePropertyChanged("ServiceGroups");
            }
        }
        public ServiceModel()
        {
        }

        public ServiceModel(string show, string edit) : base(show, edit)
        {
            this.ServiceGroup = (new ServiceGroupControl()).GetAllServiceGroups().First();
            this.ServiceGroups = (new ServiceGroupControl()).GetAllServiceGroups();
        }
    }
}
