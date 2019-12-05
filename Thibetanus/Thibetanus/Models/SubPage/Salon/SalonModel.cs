using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Common.BaseModel;
using Thibetanus.Controls.Salon;
using Thibetanus.MasterData;

namespace Thibetanus.Models.SubPage.Salon
{
    class SalonModel : ShowEditModel
    {
        private string _code;
        private string _name;
        private string _locationCode;
        private string _managerCode;
        private LocationModel _location;
        private ManagerModel _manager;
        private ObservableCollection<LocationModel> _locations = null;
        private ObservableCollection<ManagerModel> _managers = null;

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

        public string LocationCode
        {
            get { return _locationCode; }

            set
            {
                _locationCode = value;
                this.Location = (new LocationControl()).GetDataByCode(value);
                this.Locations = (new LocationControl()).GetCollection();
            }
        }

        public string ManagerCode
        {
            get { return _managerCode; }

            set
            {
                _managerCode = value;
                this.Manager = (new ManagerControl()).GetDataByCode(value);
                this.Managers = (new ManagerControl()).GetCollection();
            }
        }

        public LocationModel Location
        {
            get { return _location; }

            set
            {
                _location = value;
                if(_location != null)
                     _locationCode = _location.Code;
                RaisePropertyChanged("Location");
            }
        }
        public ManagerModel Manager
        {
            get { return _manager; }

            set
            {
                _manager = value;
                if (_manager != null)
                    _managerCode = _manager.Code;
                RaisePropertyChanged("Manager");
            }
        }

        public ObservableCollection<LocationModel> Locations
        {
            get { return _locations; }
            set
            {
                _locations = value;
                RaisePropertyChanged("Locations");
            }
        }

        public ObservableCollection<ManagerModel> Managers
        {
            get { return _managers; }
            set
            {
                _managers = value;
                RaisePropertyChanged("Managers");
            }
        }

        public SalonModel()
        {          
        }

        public SalonModel(string show, string edit):base(show, edit)
        {
            this.Code = "MY";
            this.Name = "熊熊的产康会所";
            this.Location = (new LocationControl()).GetCollection().First();
            this.Locations = (new LocationControl()).GetCollection();
            this.Manager = (new ManagerControl()).GetCollection().First();
            this.Managers = (new ManagerControl()).GetCollection();
        }
        
        
    }
}
