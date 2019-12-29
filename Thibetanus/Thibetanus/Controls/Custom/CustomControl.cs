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
using Thibetanus.Models.SubPage.Custom;
using Thibetanus.Models.SubPage.Salon;
using Thibetanus.Models.SubPage.Service;
using Thibetanus.Models.SubPage.Staff;

namespace Thibetanus.Controls.Custom
{
    class CustomControl : BaseControl
    {
        public CustomControl()
        {
           
        }
        public int Save(ObservableCollection<CustomModel> models)
        {
            if (models.Count < 0) return 0;
            using (DBConnect connect = new DBFactory().GetPostgreSQLDBConnect().BeginTransaction())
            {
                try
                {
                    int res = 0;
                    foreach (CustomModel model in models)
                    {
                        DBModels.PostgreSQL.Custom custom = new DBModels.PostgreSQL.Custom();
                        ModelHelper.CopyModel(custom, model);
                        custom.UpdateTime = DateTime.Now.ToLongDateString();
                        res += connect.Modify(custom);
                    }
                    connect.Commite();
                    return res;
                }
                catch (Exception ex)
                {
                    connect.Rollback();
                    AppLog.Error(typeof(CustomControl), ex.ToString());
                    throw new AppException("DBException");
                }
            }
        }
        public ObservableCollection<CustomModel> GetCustoms(string salonCode)
        {
            var models = new ObservableCollection<CustomModel>();
            using (DBConnect connect = new DBFactory().GetPostgreSQLDBConnect().StartConnect())
            {         
                var list = connect.GetWhere<DBModels.PostgreSQL.Custom>(m => m.SalonCode == salonCode);
                foreach (var item in list)
                {
                    CustomModel model = new CustomModel();
                    ModelHelper.CopyModel(model, item);
                  
                    models.Add(model);
                }
            }
            return models;
        }
    }
}
