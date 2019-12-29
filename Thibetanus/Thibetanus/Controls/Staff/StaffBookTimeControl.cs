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
    class StaffBookTimeControl : BaseControl
    {
        public StaffBookTimeControl()
        {           
        }

        public int Upate(ObservableCollection<StaffBookTimeModel> models)
        {
            using (DBConnect connect = new DBFactory().GetPostgreSQLDBConnect().BeginTransaction())
            {
                try
                {
                    int res = 0;
                    var list = connect.FindAll<DBModels.PostgreSQL.StaffBookTime, int>(m => m.Id);
                    foreach (StaffBookTimeModel model in models)
                    {
                        DBModels.PostgreSQL.StaffBookTime staffBook = new DBModels.PostgreSQL.StaffBookTime();
                        ModelHelper.CopyModel(staffBook, model);
                    
                        Func<DBModels.PostgreSQL.StaffBookTime, bool> func = m =>
                        {
                            if (m.Id == staffBook.Id)
                            {
                                if (m.ServiceTimeCode== staffBook.ServiceTimeCode)
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
                    if (list.Where(func).Count() > 0)
                        {
                            staffBook.UpdateTime = DateTime.Now.ToLongDateString();
                            res += connect.Modify(staffBook);
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

        public ObservableCollection<StaffBookTimeModel> GetBookTimesByStaff(string code)
        {
            var models = new ObservableCollection<StaffBookTimeModel>();
            using (DBConnect connect = new DBFactory().GetPostgreSQLDBConnect().StartConnect())
            {
                var list = connect.GetWhere<DBModels.PostgreSQL.StaffBookTime>(m => m.StaffCode == code).OrderBy(m =>m.Id);
                foreach (var item in list)
                {
                    StaffBookTimeModel model = new StaffBookTimeModel();
                    ModelHelper.CopyModel(model, item);
                    models.Add(model);
                }
            }
            return models;
        }
    }
}
