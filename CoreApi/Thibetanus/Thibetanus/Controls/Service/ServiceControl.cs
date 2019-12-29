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
using Thibetanus.DbManager;
using Thibetanus.Models.SubPage.Service;

namespace Thibetanus.Controls.Service
{
    class ServiceControl : BaseControl
    {
        //private static ServiceListModel _services = null;
     
        //public void LoadData(object sender, InitiateEventArgs e)
        //{
        //    Load();
        //}

        //public void Subscribe(MasterDataInitiater evenSource)
        //{
        //    evenSource.InitiateEvent += new InitiateEventHandler(LoadData);
        //    evenSource.ActionEvent += new Action<object, InitiateEventArgs>(LoadData);
        //}

        //public void UnSubscribe(MasterDataInitiater evenSource)
        //{
        //    evenSource.InitiateEvent -= new InitiateEventHandler(LoadData);
        //    evenSource.ActionEvent -= new Action<object, InitiateEventArgs>(LoadData);
        //}

        public ServiceListModel GetAllServices(string salongCode)
        {
            //数据库检索
            ServiceListModel _services = new ServiceListModel();
            using (var context = new ApplicationDbContext())
            {
                _services.ServiceGroups = new List<ServiceGroupModel>();

                var list1 = context.ServiceGroups.OrderBy(m => m.ShowIndex).ToList();

                foreach (var item in list1)
                {
                    ServiceGroupModel model = new ServiceGroupModel();
                    ModelHelper.CopyModel(model, item);
                    _services.ServiceGroups.Add(model);
                }

                _services.Services = new Dictionary<string, List<ServiceModel>>();
                var list2 = context.SalonServices.Where(s => s.SalonCode == salongCode).Include(s => s.Service).ToList();

                foreach (var item in _services.ServiceGroups)
                {
                    var services = new List<ServiceModel>();
                    var list3 = list2.Select(s => s.Service).Where(m => m.GroupCode == item.Code).ToList();
                    foreach (var item1 in list3)
                    {
                        ServiceModel model = new ServiceModel();
                        ModelHelper.CopyModel(model, item1);
                        services.Add(model);
                    }
                    if (services.Count > 0)
                    {
                        _services.Services.Add(item.Code, services);
                        item.IsShow = true;
                    }
                }
            }
            return _services;
            //Load();
            //return _services;
        }
        
        //private void Load()
        //{
        //    if (_services == null)
        //    {
        //        //数据库检索
        //        _services = new ServiceListModel();
        //        using (var context = new ApplicationDbContext())
        //        {
        //            _services.ServiceGroups = new List<ServiceGroupModel>();
                
        //            var list1 = context.ServiceGroups.OrderBy(m => m.ShowIndex).ToList();

        //            foreach (var item in list1)
        //            {
        //                ServiceGroupModel model = new ServiceGroupModel();
        //                ModelHelper.CopyModel(model, item);
        //                _services.ServiceGroups.Add(model);
        //            }

        //            _services.Services = new Dictionary<string, List<ServiceModel>>();
        //            var list2 = context.SalonServices.Where(s => s.SalonCode == salonCd).Include(s => s.Service).ToList();
                  
        //            foreach (var item in _services.ServiceGroups)
        //            {
        //                var services = new List<ServiceModel>();
        //                var list3 = list2.Select(s => s.Service).Where(m => m.GroupCode == item.Code).ToList();
        //                foreach (var item1 in list3)
        //                {
        //                    ServiceModel model = new ServiceModel();
        //                    ModelHelper.CopyModel(model, item1);
        //                    services.Add(model);
        //                }
        //                if(services.Count > 0)
        //                {
        //                    _services.Services.Add(item.Code, services);
        //                    item.IsShow = true;
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
