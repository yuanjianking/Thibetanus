using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Common.BaseModel;

namespace Thibetanus.Models.SubPage.Salon
{
    class ManagerModel : ShowEditModel
    {
        private string _code;
        private string _name;

        public int Id { get; set; }
        public string CreateTime { get; set; }
        public string UpdateTime { get; set; }

        public string Code
        {
            get { return _code; }

            set
            {
                _code = value;
                RaisePropertyChanged("Code");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }
        public ManagerModel()
        {
        }

        public ManagerModel(string show, string edit) : base(show, edit)
        {
            this.Code = "CZM";
        }
    }
}
