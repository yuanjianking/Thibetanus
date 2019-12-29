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
using Thibetanus.Models.SubPage.Salon;
using Thibetanus.Models.SubPage.Service;
using Thibetanus.Models.SubPage.Staff;
using Thibetanus.ViewModels.SubPage.Staff;

namespace Thibetanus.Controls.Staff
{
    class StaffControl : BaseControl
    {
        public StaffControl()
        {
           
        }
        public int Save(ObservableCollection<StaffInfoModel> models)
        {
            using (DBConnect connect = new DBFactory().GetPostgreSQLDBConnect().BeginTransaction())
            {
                try
                {
                    int res = 0;
                    var list = connect.FindAll<DBModels.PostgreSQL.Staff, int>(m => m.Id);
                    var data = list.Where(w => !models.Select(s => s.Id).Contains(w.Id));
                    res += connect.Delete(data);

                    foreach (StaffInfoModel model in models)
                    {
                        DBModels.PostgreSQL.Staff staff = new DBModels.PostgreSQL.Staff();
                        ModelHelper.CopyModel(staff, model);
                        staff.SalonCode = model.Salon.Code;
                        staff.Salon = connect.GetWhere<DBModels.PostgreSQL.Salon>(s => s.Code == model.Salon.Code).FirstOrDefault();
                        staff.Services = JsonConvert.SerializeObject(model.Services);
                        staff.ServiceTimes = JsonConvert.SerializeObject(model.ServiceTimes);
                        Func<DBModels.PostgreSQL.Staff, bool> func = m =>
                        {
                            if (m.Id == staff.Id)
                            {
                                if (m.Code == staff.Code && m.Name == staff.Name &&
                                m.SalonCode == staff.SalonCode && m.Services == staff.Services && m.ServiceTimes == staff.ServiceTimes)
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
                            staff.CreateTime = DateTime.Now.ToLongDateString();
                            res += connect.Add(staff);
                        }
                        else if (list.Where(func).Count() > 0)
                        {
                            staff.UpdateTime = DateTime.Now.ToLongDateString();
                            res += connect.Modify(staff);
                        }
                    }
                    connect.Commite();
                    return res;
                }
                catch (Exception ex)
                {
                    connect.Rollback();
                    AppLog.Error(typeof(StaffControl), ex.ToString());
                    throw new AppException("DBException");
                }
            }
        }
        public ObservableCollection<StaffInfoModel> GetStaffInfosBySalon(string salonCode)
        {
            var models = new ObservableCollection<StaffInfoModel>();
            using (DBConnect connect = new DBFactory().GetPostgreSQLDBConnect().StartConnect())
            {
                var listStaff = connect.GetWhere<DBModels.PostgreSQL.Staff>(w => w.SalonCode == salonCode).OrderBy(m => m.Code);
                foreach (var item in listStaff)
                {
                    StaffInfoModel model = new StaffInfoModel();
                    ModelHelper.CopyModel(model, item);
                    models.Add(model);
                }
            }
            return models;
        }
        public ObservableCollection<StaffInfoModel> GetAllStaffInfos()
        {
            var models = new ObservableCollection<StaffInfoModel>();
            using (DBConnect connect = new DBFactory().GetPostgreSQLDBConnect().StartConnect())
            {
                var salons = new SalonControl().GetAllSalonInfos();
                var listStaff = connect.FindAll<DBModels.PostgreSQL.Staff, string>(m => m.Code);
                foreach (var item in listStaff)
                {
                    StaffInfoModel model = new StaffInfoModel();
                    ModelHelper.CopyModel(model, item);
                    model.Salons = salons;
                    model.Salon = salons.Where(s => s.Code == item.SalonCode).FirstOrDefault();
                    if(!string.IsNullOrEmpty(item.Services))
                        model.Services = JsonConvert.DeserializeObject<ObservableCollection<ServiceModel>>(item.Services);
                    if(!string.IsNullOrEmpty(item.ServiceTimes))
                    model.ServiceTimes = JsonConvert.DeserializeObject<ObservableCollection<StaffServiceTimeModel>>(item.ServiceTimes);
                    models.Add(model);
                }
            }
            return models;
            //var Staffs = new ObservableCollection<StaffInfoModel>();
            //DBConnect connect = new DBFactory().GetMongDBConnect();

            //var list = connect.FindAll<DBModels.MongDB.Staff, ObjectId>(m => m.Id);
            //foreach (var staff in list)
            //{
            //    StaffInfoModel staffEdit = new StaffInfoModel();
            //    ModelHelper.CopyModel(staffEdit, staff);
            //    staffEdit.Skills = new ObservableCollection<SkillModel>();
            //    foreach (var skill in staff.Skill)
            //    {
            //        SkillModel skillModel = new SkillModel();
            //        ModelHelper.CopyModel(skillModel, skill);
            //        staffEdit.Skills.Add(skillModel);
            //    }
            //    Staffs.Add(staffEdit);
            //}
            //return Staffs;
        }

        //public ObservableCollection<ServiceModel> GetAllServices()
        //{
        //    //var Skills = new ObservableCollection<SkillModel>();
        //    //DBConnect connect = new DBFactory().GetMongDBConnect();
        //    //var list = connect.FindAll<DBModels.MongDB.Skill, ObjectId>(m => m.Id);
        //    //foreach (var skill in list)
        //    //{
        //    //    SkillModel skillModel = new SkillModel();
        //    //    ModelHelper.CopyModel(skillModel, skill);
        //    //    Skills.Add(skillModel);
        //    //}
        //    //return Skills;
        //}
    }
}
