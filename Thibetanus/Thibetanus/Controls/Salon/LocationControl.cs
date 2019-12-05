using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Common.Exceptions;
using Thibetanus.Common.Helper;
using Thibetanus.Common.Initiate;
using Thibetanus.Common.Log;
using Thibetanus.Common.UserControls;
using Thibetanus.DBmanager;
using Thibetanus.DBmanager.PostgreSQL;
using Thibetanus.Models.SubPage.Salon;

namespace Thibetanus.Controls.Salon
{
    class LocationControl
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
                using (DBConnect connect = new DBFactory().GetPostgreSQLDBConnect().StartConnect())
                {
                    var list = connect.FindAll<DBModels.PostgreSQL.Location, int>(m => m.Id);
                    foreach (var item in list)
                    {
                        LocationModel model = new LocationModel();
                        ModelHelper.CopyModel(model, item);
                        _locations.Add(model);
                    }
                }
            }
        }

        public int Save()
        {
            using (DBConnect connect = new DBFactory().GetPostgreSQLDBConnect().BeginTransaction())
            {
                try
                {
                    int res = 0;
                    var list = connect.FindAll<DBModels.PostgreSQL.Location, int>(m => m.Id);
                    var data = list.Where(w => !_locations.Select(s => s.Id).Contains(w.Id));
                    res += connect.Delete(data);

                    foreach (var model in _locations)
                    {
                        DBModels.PostgreSQL.Location location = new DBModels.PostgreSQL.Location();
                        ModelHelper.CopyModel(location, model);

                        Func<DBModels.PostgreSQL.Location, bool> func = m =>
                        {
                            if (m.Id == model.Id )
                            {
                                if (m.Code.Equals(model.Code) && m.City.Equals(model.City) && m.Province.Equals(model.Province))
                                {
                                    return false;
                                }
                                else
                                {
                                    return true;
                                }

                            }
                            return false;
                        };

                        if (model.Id < 1)
                        {
                            res += connect.Add(location);
                        }
                        else if (list.Where(func).Count() > 0)
                        {
                            res += connect.Modify(location);
                        }
                    }
                    connect.Commite();
                    return res;
                }
                catch (Exception ex)
                {
                    connect.Rollback();
                    AppLog.Error(typeof(LocationControl), ex.ToString());
                    throw new AppException("DBException");
                }
            }
        }
    }
}
