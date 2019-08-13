using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Common.BaseModel;

namespace Thibetanus.Models
{
    class MenuModel : ObservableObject
    {
        private string _label;
        private Type _linktype;

        public string Label
        {
            get { return _label; }

            set{
                _label = value;
                RaisePropertyChanged("Label");
            }
        }

         public Type LinkType
        {
            get { return _linktype; }
            set {
                _linktype = value;
                RaisePropertyChanged("LinkType");
            }
         }
        public MenuModel(string label, Type linktype)
        {
                this.Label = label;
                this.LinkType = linktype;
        }

        public override String ToString()
        {
            return Label;
        }

    }
}
