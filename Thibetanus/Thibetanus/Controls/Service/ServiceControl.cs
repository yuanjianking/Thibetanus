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
    class ServiceControl : BaseControl
    {
        private static ObservableCollection<ServiceModel> _services = null;

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

        public ObservableCollection<ServiceModel> GetAllServices()
        {
            Load();
            return _services;
        }
        
        private void Load()
        {
            if (_services == null)
            {
                //数据库检索
                _services = new ObservableCollection<ServiceModel>();
                using (DBConnect connect = new DBFactory().GetPostgreSQLDBConnect().StartConnect())
                {
                    var list = connect.FindAll<DBModels.PostgreSQL.Service, string>(m => m.Code);
                    var serviceGroups = new ServiceGroupControl().GetAllServiceGroups();
                    foreach (var item in list)
                    {
                        ServiceModel model = new ServiceModel();
                        ModelHelper.CopyModel(model, item);
                        model.ServiceGroups = serviceGroups;
                        model.ServiceGroup = serviceGroups.Where(m => m.Code == item.GroupCode).FirstOrDefault();
                        _services.Add(model);
                    }
                }
            }
        }

        public int Save(ObservableCollection<ServiceModel> models)
        {
            using (DBConnect connect = new DBFactory().GetPostgreSQLDBConnect().BeginTransaction())
            {
                try
                {
                    int res = 0;
                    var list = connect.FindAll<DBModels.PostgreSQL.Service, int>(m => m.Id);                    
                    var data = list.Where(w => !models.Select(s => s.Id).Contains(w.Id));
                    res += connect.Delete(data);
              
                    foreach (ServiceModel model in models)
                    {
                        DBModels.PostgreSQL.Service service = new DBModels.PostgreSQL.Service();
                        ModelHelper.CopyModel(service, model);
                        service.GroupCode = model.ServiceGroup.Code;
                        Func<DBModels.PostgreSQL.Service, bool> func = m =>
                        {
                            if (m.Id == model.Id )
                            {
                                if (m.Code == model.Code && m.Name == model.Name && m.GroupCode == model.ServiceGroup.Code && m.Price == model.Price)
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
                            service.CreateTime = DateTime.Now.ToLongDateString();
                            res += connect.Add(service);
                        }
                        else if (list.Where(func).Count() > 0)
                        {
                            service.UpdateTime = DateTime.Now.ToLongDateString();
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
    }
}
