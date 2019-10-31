using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Common.BaseControl;
using Thibetanus.Common.Exceptions;
using Thibetanus.Common.Helper;
using Thibetanus.Common.Log;
using Thibetanus.Common.UserControls;
using Thibetanus.DBmanager;
using Thibetanus.DBmanager.PostgreSQL;
using Thibetanus.Models.SubPage.Salon;

namespace Thibetanus.Controls.Salon
{
    class SalonControl : BaseControl
    {    
        public int Save(ObservableCollection<SalonModel> models)
        {
            using (DBConnect connect = new DBFactory().GetPostgreSQLDBConnect().BeginTransaction())
            {
                try
                {
                    int res = 0;
                    var list = connect.FindAll<DBModels.PostgreSQL.Salon, int>(m => m.Id);                    
                    var data = list.Where(w => !models.Select(s => s.Id).Contains(w.Id));
                    res += connect.Delete(data);
              
                    foreach (SalonModel model in models)
                    {
                        DBModels.PostgreSQL.Salon salon = new DBModels.PostgreSQL.Salon();
                        ModelHelper.CopyModel(salon, model);

                        Func<DBModels.PostgreSQL.Salon, bool> func = m =>
                        {
                            if (m.Id == model.Id && m.Code.Equals(model.Code))
                            {
                                if (m.Name.Equals(model.Name) && m.LocationCode.Equals(model.LocationCode) && m.ManagerCode.Equals(model.ManagerCode))
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
                            res += connect.Add(salon);
                        }
                        else if (list.Where(func).Count() > 0)
                        {
                            res += connect.Modify(salon);
                        }
                    }
                    connect.Commite();                
                    return res;
                }
                catch (Exception ex)
                {
                    connect.Rollback();
                    AppLog.Error(typeof(SalonControl), ex.ToString());
                    throw new AppException("DBException");                  
                }
            }
        }

        public ObservableCollection<SalonModel> GetAllSalonInfos()
        { 
            var models = new ObservableCollection<SalonModel>();
            using (DBConnect connect = new DBFactory().GetPostgreSQLDBConnect().StartConnect())
            {
                var list = connect.FindAll<DBModels.PostgreSQL.Salon, int>(m => m.Id);

                foreach (var item in list)
                {
                    SalonModel model = new SalonModel();
                    ModelHelper.CopyModel(model, item);
                    models.Add(model);
                }
            }

            return models;
        }
    }
}
