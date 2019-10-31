using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Common.BaseModel;

namespace Thibetanus.Models
{
    class ShowEditModel : ObservableObject
    {
        private string _show;
        private string _edit;

        public ShowEditModel()
        {
            this.Show = "Visible"; 
            this.Edit = "Collapsed"; 
        }

        public ShowEditModel(string show, string edit)
        {
            this.Show = show;
            this.Edit = edit;
         }

        public string Show
        {
            get { return _show; }

            set
            {
                _show = value;
                RaisePropertyChanged("Show");
            }
        }

        public string Edit
        {
            get { return _edit; }

            set
            {
                _edit = value;
                RaisePropertyChanged("Edit");
            }
        }
    }
}
