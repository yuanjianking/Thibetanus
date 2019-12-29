using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Thibetanus.Models.SubPage.Service
{
    public class ServiceGroupModel
    {
        private string _code;
        private string _groupName;
        private string _icon = "../../images/nav_icon_02.png";
        private bool _isShow = false;
        public string Code { get => _code; set => _code = value; }
        public string GroupName { get => _groupName; set => _groupName = value; }
        public string Icon { get => _icon; set => _icon = value; }
        public bool IsShow { get => _isShow; set => _isShow = value; }
    }
}
