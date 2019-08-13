using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Common.BaseModel;
using Thibetanus.Common.Enum;
using Thibetanus.Common.Helper;
using Thibetanus.Common.UserControls;
using Thibetanus.Controls;
using Thibetanus.Models;
using Thibetanus.Views;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Thibetanus.Models.SubPage.Staff;
using Thibetanus.Controls.Staff;

namespace Thibetanus.ViewModels.SubPage.Staff
{
    class StaffEditViewModel : ObservableObject
    {
        private ObservableCollection<StaffInfoModel> _staffInfos = null;
        private ObservableCollection<SkillModel> _skills = null;

        public ObservableCollection<StaffInfoModel> StaffInfos
        {
            get { return _staffInfos; }
            set
            {
                _staffInfos = value;
                RaisePropertyChanged("StaffInfos");
            }
        }

        public ObservableCollection<SkillModel> Skills
        {
            get { return _skills; }
            set
            {
                _skills = value;
                RaisePropertyChanged("Skills");
            }
        }

        public StaffEditViewModel()
        {
            this.StaffInfos = new StaffControl().GetAllStaffInfos();
            this.Skills = new StaffControl().GetAllSkills();
        }
    }
}
