using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Common.BaseModel;
using Thibetanus.Models.SubPage.Salon;

namespace Thibetanus.ViewModels.SubPage.Salon
{
    class SalonEditViewModel : ObservableObject
    {
        private ObservableCollection<SalonEditModel> _salons = null;
        public ObservableCollection<SalonEditModel> Salons
        {
            get { return _salons; }
            set
            {
                _salons = value;
                RaisePropertyChanged("Salons");
            }
        }

        public SalonEditViewModel()
        {
            this.Salons = new ObservableCollection<SalonEditModel>();

            Salons.Add(new SalonEditModel("MY000000001", "xx母婴工作室", "江苏省>常州市", "大仓鼠"));
            Salons.Add(new SalonEditModel("MY000000002", "xx母婴工作室", "江苏省>南通市", "大仓鼠"));

        }

    }
}
