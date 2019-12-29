using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Thibetanus.Common.BaseControl;
using Thibetanus.Common.Exceptions;
using Thibetanus.Common.Helper;
using Thibetanus.Common.Log;
using Thibetanus.Controls.Salon;
using Thibetanus.DBmanager;
using Thibetanus.Models.SubPage.Assets;
using Thibetanus.Models.SubPage.Salon;
using Thibetanus.Models.SubPage.Service;
using Thibetanus.Models.SubPage.Staff;

namespace Thibetanus.Controls.Assets
{
    class AssetsControl : BaseControl
    {
        public AssetsControl()
        {
           
        }
        public int Save(ObservableCollection<AssetsModel> models)
        {
            if (models.Count < 1) return 0;
            using (DBConnect connect = new DBFactory().GetPostgreSQLDBConnect().BeginTransaction())
            {
                try
                {
                    int res = 0;
                    var list = connect.GetWhere<DBModels.PostgreSQL.Assets>(m => m.SalonCode == models[0].SalonCode);
                    var data = list.Where(w => !models.Select(s => s.Id).Contains(w.Id));
                    res += connect.Delete(data);

                    foreach (AssetsModel model in models)
                    {
                        DBModels.PostgreSQL.Assets assets = new DBModels.PostgreSQL.Assets();
                        ModelHelper.CopyModel(assets, model);
                        Func<DBModels.PostgreSQL.Assets, bool> func = m =>
                        {
                            if (m.Id == assets.Id)
                            {
                                if (m.Code == assets.Code && m.Name == assets.Name && m.Price == assets.Price && m.Number == assets.Number && m.SalonCode == assets.SalonCode)
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
                            assets.CreateTime = DateTime.Now.ToLongDateString();
                            res += connect.Add(assets);
                        }
                        else if (list.Where(func).Count() > 0)
                        {
                            assets.UpdateTime = DateTime.Now.ToLongDateString();
                            res += connect.Modify(assets);
                        }
                    }
                    connect.Commite();
                    return res;
                }
                catch (Exception ex)
                {
                    connect.Rollback();
                    AppLog.Error(typeof(AssetsControl), ex.ToString());
                    throw new AppException("DBException");
                }
            }
        }
        public ObservableCollection<AssetsModel> GetAssets(string salonCode)
        {
            var models = new ObservableCollection<AssetsModel>();
            using (DBConnect connect = new DBFactory().GetPostgreSQLDBConnect().StartConnect())
            {         
                var list = connect.GetWhere<DBModels.PostgreSQL.Assets>(m => m.SalonCode == salonCode);
                foreach (var item in list)
                {
                    AssetsModel model = new AssetsModel();
                    ModelHelper.CopyModel(model, item);
                  
                    models.Add(model);
                }
            }
            return models;
        }
    }
}
