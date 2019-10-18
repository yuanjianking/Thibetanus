using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Common.Helper;
using Thibetanus.Common.Initiate;
using Thibetanus.DBmanager;
using Thibetanus.Models.SubPage;

namespace Thibetanus.MasterData
{
    class LocationMaster
    {
        private static ObservableCollection<LocationModel> _locations = null;

        public ObservableCollection<LocationModel> GetCollection()
        {
            Load();
            return _locations;
        }

        public LocationModel GetDataByCode(string code)
        {
            Load();
            var location = _locations.Where(model => model.Code.Equals(code));
            return location.FirstOrDefault();
        }

        public LocationModel GetDataByCity(string province, string city)
        {
            Load();
            var location = _locations.Where(model => model.Province.Equals(province) && model.City.Equals(city));
            return location.FirstOrDefault();
        }

        public LocationModel GetDataByName(string name)
        {
            Load();
            var location = _locations.Where(model=> model.Name.Equals(name));
            return location.FirstOrDefault();
        }

        public void LoadData(object sender, InitiateEventArgs e)
        {
            Load();
        }


        public void Subscribe(MasterDataInitiater evenSource)
        {
            evenSource.InitiateEvent += new InitiateEventHandler(LoadData);
            evenSource.ActionEvent += new Action<object, InitiateEventArgs>(LoadData);
        }

        public void UnSubscribe(MasterDataInitiater evenSource)
        {
            evenSource.InitiateEvent -= new InitiateEventHandler(LoadData);
            evenSource.ActionEvent -= new Action<object, InitiateEventArgs>(LoadData);
        }

        private void Load()
        {
            if(_locations == null)
            {
                _locations = new ObservableCollection<LocationModel>();
                DBConnect connect = new DBFactory().GetPostgreSQLDBConnect();
                var list = connect.FindAll<DBModels.PostgreSQL.Location,int>(m => m.Id);

                foreach (var item in list)
                {
                    LocationModel model = new LocationModel();
                    ModelHelper.CopyModel(model, item);
                    _locations.Add(model);
                }
            }
        }
    }
}
