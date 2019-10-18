using MongoDB.Bson;
using System;
using System.Collections.ObjectModel;
using Thibetanus.Common.BaseControl;
using Thibetanus.Common.Helper;
using Thibetanus.DBmanager;
using Thibetanus.Models.SubPage.Staff;

namespace Thibetanus.Controls.Staff
{
    class StaffControl : BaseControl
    {
        public StaffControl()
        {
           
        }

        public ObservableCollection<StaffInfoModel> GetAllStaffInfos()
        {
            var Staffs = new ObservableCollection<StaffInfoModel>();
            DBConnect connect = new DBFactory().GetMongDBConnect();

            var list = connect.FindAll<DBModels.MongDB.Staff, ObjectId>(m => m.Id);
            foreach (var staff in list)
            {
                StaffInfoModel staffEdit = new StaffInfoModel();
                ModelHelper.CopyModel(staffEdit, staff);
                staffEdit.Skills = new ObservableCollection<SkillModel>();
                foreach (var skill in staff.Skill)
                {
                    SkillModel skillModel = new SkillModel();
                    ModelHelper.CopyModel(skillModel, skill);
                    staffEdit.Skills.Add(skillModel);
                }
                Staffs.Add(staffEdit);
            }
            return Staffs;
        }

        public ObservableCollection<SkillModel> GetAllSkills()
        {
            var Skills = new ObservableCollection<SkillModel>();
            DBConnect connect = new DBFactory().GetMongDBConnect();
            var list = connect.FindAll<DBModels.MongDB.Skill, ObjectId>(m => m.Id);
            foreach (var skill in list)
            {
                SkillModel skillModel = new SkillModel();
                ModelHelper.CopyModel(skillModel, skill);
                Skills.Add(skillModel);
            }
            return Skills;
        }
    }
}
