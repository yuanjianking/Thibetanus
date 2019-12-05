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

namespace Thibetanus.Controls.Salon
{
    class SalonControl : BaseControl
    {
        private static ObservableCollection<SalonModel> _salons = null;

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

        public ObservableCollection<SalonModel> GetAllSalonInfos()
        {
            Load();
            return _salons;
        }

        private void Load()
        {
            if (_salons == null)
            {
                //数据库检索
                _salons = new ObservableCollection<SalonModel>();
                using (DBConnect connect = new DBFactory().GetPostgreSQLDBConnect().StartConnect())
                {
                    var list = connect.FindAll<DBModels.PostgreSQL.Salon, int>(m => m.Id);

                    foreach (var item in list)
                    {
                        SalonModel model = new SalonModel();
                        ModelHelper.CopyModel(model, item);
                        _salons.Add(model);
                    }
                }
            }
        }

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
                            if (m.Id == model.Id)
                            {
                                if (m.Code.Equals(model.Code) && m.Name.Equals(model.Name) && m.LocationCode.Equals(model.LocationCode) && m.ManagerCode.Equals(model.ManagerCode))
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
                            salon.CreateTime = DateTime.Now.ToLongDateString();
                            res += connect.Add(salon);
                        }
                        else if (list.Where(func).Count() > 0)
                        {
                            salon.UpdateTime = DateTime.Now.ToLongDateString();
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

       

        public ObservableCollection<ServiceModel> GetAllSalonServiceInfos(string salongCd)
        {
            var models = new ObservableCollection<ServiceModel>();
            using (DBConnect connect = new DBFactory().GetPostgreSQLDBConnect().StartConnect())
            {
                var salonServices = connect.GetWhere<DBModels.PostgreSQL.SalonService>(s => s.SalonCode == salongCd).Include(s => s.Service).ToList();
                salonServices.ForEach(s =>
                {
                    var model = new ServiceModel();
                    ModelHelper.CopyModel(model, s.Service);
                    models.Add(model);
                });
            }
            return models;
        }

        //没有共通化
        public int SaveSalonService(string salonCd, ObservableCollection<ServiceModel> models)
        {
            using (var context = new PostgreSQLContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        int res = 0;
                        var salonServices = context.SalonServices.Where(s => s.SalonCode == salonCd).Include(s => s.Service).ToList();
                        var data = salonServices.Where(w => !models.Select(s => s.Code).Contains(w.Service.Code));
                        context.SalonServices.RemoveRange(data);
                       

                        foreach (ServiceModel model in models)
                        {
                            if (salonServices.Where(w => w.Service.Code == model.Code).Count() < 1)
                            {
                                DBModels.PostgreSQL.SalonService salon = new DBModels.PostgreSQL.SalonService();
                                DBModels.PostgreSQL.Service service = context.Services.Where(s => s.Code == model.Code).First();

                                salon.SalonCode = salonCd;
                                salon.ServiceCode = model.Code;
                                salon.Service = service;
                                context.SalonServices.Add(salon);
                            }
                        }

                        res += context.SaveChanges();

                        transaction.Commit();
                        return res;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        AppLog.Error(typeof(SalonControl), ex.ToString());
                        throw new AppException("DBException");
                    }
                }
            }
        }
    }
}
