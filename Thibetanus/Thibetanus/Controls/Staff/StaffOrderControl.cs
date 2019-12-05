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
    class StaffOrderControl : BaseControl
    {
        public StaffOrderControl()
        {
           
        }
        public ObservableCollection<StaffOrderModel> GetOrders(string salonCode)
        {
            var models = new ObservableCollection<StaffOrderModel>();
            using (DBConnect connect = new DBFactory().GetPostgreSQLDBConnect().StartConnect())
            {
                var list = connect.GetWhere<DBModels.PostgreSQL.StaffOrder>(m => m.SalonCode.Equals(salonCode));
                foreach (var item in list)
                {
                    StaffOrderModel model = new StaffOrderModel();
                    ModelHelper.CopyModel(model, item);

                    models.Add(model);
                }
            }
            return models;
        }
    }
}
