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
using Thibetanus.Common.Initiate;
using Thibetanus.Common.Log;
using Thibetanus.Common.UserControls;
using Thibetanus.DBmanager;
using Thibetanus.DBmanager.PostgreSQL;
using Thibetanus.Models.SubPage.Salon;
using Thibetanus.Models.SubPage.Service;

namespace Thibetanus.Controls.Service
{
    class ServiceGroupControl : BaseControl
    {
        private static ObservableCollection<ServiceGroupModel> _serviceGroups = null;

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

        public ObservableCollection<ServiceGroupModel> GetAllServiceGroups()
        {
            Load();
            return _serviceGroups;
        }
        
        private void Load()
        {
            if (_serviceGroups == null)
            {
                //数据库检索
                _serviceGroups = new ObservableCollection<ServiceGroupModel>();
                using (DBConnect connect = new DBFactory().GetPostgreSQLDBConnect().StartConnect())
                {
                    var list = connect.FindAll<DBModels.PostgreSQL.ServiceGroup, string>(m => m.ShowIndex);

                    foreach (var item in list)
                    {
                        ServiceGroupModel model = new ServiceGroupModel();
                        ModelHelper.CopyModel(model, item);
                        _serviceGroups.Add(model);
                    }
                }
            }
        }

        public int Save(ObservableCollection<ServiceGroupModel> models)
        {
            using (DBConnect connect = new DBFactory().GetPostgreSQLDBConnect().BeginTransaction())
            {
                try
                {
                    int res = 0;
                    var list = connect.FindAll<DBModels.PostgreSQL.ServiceGroup, int>(m => m.Id);                    
                    var data = list.Where(w => !models.Select(s => s.Id).Contains(w.Id));
                    res += connect.Delete(data);
              
                    foreach (ServiceGroupModel model in models)
                    {
                        DBModels.PostgreSQL.ServiceGroup servicegroup = new DBModels.PostgreSQL.ServiceGroup();
                        ModelHelper.CopyModel(servicegroup, model);

                        Func<DBModels.PostgreSQL.ServiceGroup, bool> func = m =>
                        {
                            if (m.Id == model.Id )
                            {
                                if (m.Code == model.Code && m.GroupName == model.GroupName && m.ShowIndex == model.ShowIndex)
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
                            servicegroup.CreateTime = DateTime.Now.ToLongDateString();
                            res += connect.Add(servicegroup);
                        }
                        else if (list.Where(func).Count() > 0)
                        {
                            servicegroup.UpdateTime = DateTime.Now.ToLongDateString();
                            res += connect.Modify(servicegroup);
                        }
                    }
                    connect.Commite();                
                    return res;
                }
                catch (Exception ex)
                {
                    connect.Rollback();
                    AppLog.Error(typeof(ServiceGroupControl), ex.ToString());
                    throw new AppException("DBException");                  
                }
            }
        }
    }
}
