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
using Thibetanus.Models.SubPage.Custom;
using Thibetanus.Models.SubPage.Salon;
using Thibetanus.Models.SubPage.Service;
using Thibetanus.Models.SubPage.Staff;

namespace Thibetanus.Controls.Staff
{
    class StaffServiceTimeControl : BaseControl
    {
        public StaffServiceTimeControl()
        {
           
        }

        public int Save(ObservableCollection<StaffServiceTimeModel> models)
        {
            using (DBConnect connect = new DBFactory().GetPostgreSQLDBConnect().BeginTransaction())
            {
                try
                {
                    int res = 0;
                    var list = connect.FindAll<DBModels.PostgreSQL.StaffServiceTime, int>(m => m.Id);
                    var data = list.Where(w => !models.Select(s => s.Id).Contains(w.Id));
                    res += connect.Delete(data);

                    foreach (StaffServiceTimeModel model in models)
                    {
                        DBModels.PostgreSQL.StaffServiceTime staffService = new DBModels.PostgreSQL.StaffServiceTime();
                        ModelHelper.CopyModel(staffService, model);
                    
                        Func<DBModels.PostgreSQL.StaffServiceTime, bool> func = m =>
                        {
                            if (m.Id == staffService.Id)
                            {
                                if (m.Code == staffService.Code && m.StartTime == staffService.StartTime && m.EndTime == staffService.EndTime)
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
                            staffService.CreateTime = DateTime.Now.ToLongDateString();
                            res += connect.Add(staffService);
                        }
                        else if (list.Where(func).Count() > 0)
                        {
                            staffService.UpdateTime = DateTime.Now.ToLongDateString();
                            res += connect.Modify(staffService);
                        }
                    }
                    connect.Commite();
                    return res;
                }
                catch (Exception ex)
                {
                    connect.Rollback();
                    AppLog.Error(typeof(StaffServiceTimeControl), ex.ToString());
                    throw new AppException("DBException");
                }
            }
        }

        public ObservableCollection<StaffServiceTimeModel> GetAllServiceTimes()
        {
            var models = new ObservableCollection<StaffServiceTimeModel>();
            using (DBConnect connect = new DBFactory().GetPostgreSQLDBConnect().StartConnect())
            {
                var list = connect.FindAll<DBModels.PostgreSQL.StaffServiceTime,string>(m => m.Code);
                foreach (var item in list)
                {
                    StaffServiceTimeModel model = new StaffServiceTimeModel();
                    ModelHelper.CopyModel(model, item);

                    models.Add(model);
                }
            }
            return models;
        }
    }
}
