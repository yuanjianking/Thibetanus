using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Common.BaseModel;
using Thibetanus.Controls.Salon;
using Thibetanus.Models.SubPage;
using Thibetanus.Models.SubPage.Salon;
using Windows.UI.Xaml;

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
            Salons = new SalonControl().GetAllSalonInfos();  
        }
        
        private DelegateCommand _addCommand;
        private DelegateCommand _delCommand;
        private DelegateCommand _saveCommand;

        public DelegateCommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new DelegateCommand
                  ((obj) =>
                  {
                      ResetStatus();
                      string code = string.Format("MY{0}", (Salons.Count + 1).ToString("D10"));
                      Salons.Add(new SalonEditModel(code, "Collapsed", "Visible"));
                      _addCommand.RaiseCanExecuteChanged();
                      _delCommand.RaiseCanExecuteChanged();
                      _saveCommand.RaiseCanExecuteChanged();
                  },
                  (obj) => Salons.Count < 10));
            }
        }

        public DelegateCommand DelCommand
        {
            get
            {
                return _delCommand ?? (_delCommand =
                  new DelegateCommand((obj) =>
                  {
                      ResetStatus();
                      Salons.RemoveAt((int)obj);
                      _addCommand.RaiseCanExecuteChanged();
                      _delCommand.RaiseCanExecuteChanged();
                      _saveCommand.RaiseCanExecuteChanged();
                  },
                   (obj) => Salons.Count > 1));
            }
        }


        public DelegateCommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand =
                  new DelegateCommand((obj) =>
                  {
                      ResetStatus();
                      new SalonControl().Save(Salons);
                      _addCommand.RaiseCanExecuteChanged();
                      _delCommand.RaiseCanExecuteChanged();
                      _saveCommand.RaiseCanExecuteChanged();
                  },
                   (obj) => true));
            }
        }

        private void ResetStatus()
        {
            foreach (var item in Salons)
            {
                item.Show = "Visible";
                item.Edit = "Collapsed";
            }
        }
    }
}
