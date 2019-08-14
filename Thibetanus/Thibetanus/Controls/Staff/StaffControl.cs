using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Common.BaseControl;
using Thibetanus.Common.Helper;
using Thibetanus.DBmanager;
using Thibetanus.DBModels.MongDB;
using Thibetanus.Models;
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
            DBConnect connect = new DBFactory().GetDBConnect(DBFactory.DBServerType.NoSQL);
          
            var list = connect.SelectAll<StaffTable>(StaffTable.TBName);
            foreach (var staff in list)
            {
                StaffInfoModel staffEdit = new StaffInfoModel();
                CopyModel(staffEdit, staff);
                staffEdit.Skills = new ObservableCollection<SkillModel>();
                foreach (var skill in staff.Skill)
                {
                    SkillModel skillModel = new SkillModel();
                    CopyModel(skillModel, skill);
                    staffEdit.Skills.Add(skillModel);
                }
                Staffs.Add(staffEdit);
            }
            return Staffs;
        }

        public ObservableCollection<SkillModel> GetAllSkills()
        {
            var Skills = new ObservableCollection<SkillModel>();
            DBConnect connect = new DBFactory().GetDBConnect(DBFactory.DBServerType.NoSQL);
            var list = connect.SelectAll<SkillTable>(SkillTable.TBName);
            foreach (var skill in list)
            {
                SkillModel skillModel = new SkillModel();
                CopyModel(skillModel, skill);
                Skills.Add(skillModel);
            }
            return Skills;
        }
    }
}
