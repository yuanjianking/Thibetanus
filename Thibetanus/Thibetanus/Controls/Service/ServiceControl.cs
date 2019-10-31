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
using Thibetanus.Models.SubPage.Service;

namespace Thibetanus.Controls.Service
{
    class ServiceControl : BaseControl
    {    
        public int Save(ObservableCollection<ServiceModel> models)
        {
            using (DBConnect connect = new DBFactory().GetPostgreSQLDBConnect().BeginTransaction())
            {
                try
                {
                    int res = 0;
                    var list = connect.FindAll<DBModels.PostgreSQL.Servcie, int>(m => m.Id);                    
                    var data = list.Where(w => !models.Select(s => s.Id).Contains(w.Id));
                    res += connect.Delete(data);
              
                    foreach (ServiceModel model in models)
                    {
                        DBModels.PostgreSQL.Servcie service = new DBModels.PostgreSQL.Servcie();
                        ModelHelper.CopyModel(service, model);

                        Func<DBModels.PostgreSQL.Servcie, bool> func = m =>
                        {
                            if (m.Id == model.Id && m.Code.Equals(model.Code))
                            {
                                if (m.Name.Equals(model.Name) && m.Group.Equals(model.Group) && m.Price.Equals(model.Price))
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
                            res += connect.Add(service);
                        }
                        else if (list.Where(func).Count() > 0)
                        {
                            res += connect.Modify(service);
                        }
                    }
                    connect.Commite();                
                    return res;
                }
                catch (Exception ex)
                {
                    connect.Rollback();
                    AppLog.Error(typeof(ServiceControl), ex.ToString());
                    throw new AppException("DBException");                  
                }
            }
        }

        public ObservableCollection<ServiceModel> GetAllServices()
        { 
            var models = new ObservableCollection<ServiceModel>();
            using (DBConnect connect = new DBFactory().GetPostgreSQLDBConnect().StartConnect())
            {
                var list = connect.FindAll<DBModels.PostgreSQL.Servcie, int>(m => m.Id);

                foreach (var item in list)
                {
                    ServiceModel model = new ServiceModel();
                    ModelHelper.CopyModel(model, item);
                    models.Add(model);
                }
            }

            return models;
        }
    }
}
