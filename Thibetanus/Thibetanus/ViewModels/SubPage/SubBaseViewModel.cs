using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Common.BaseModel;
using Thibetanus.Models;

namespace Thibetanus.ViewModels.SubPage
{
    class SubBaseViewModel : ObservableObject
    {
        private DelegateCommand _addCommand;
        private DelegateCommand _delCommand;
        private DelegateCommand _saveCommand;

        public virtual void DoAddCommand() { }

        public virtual bool CanAddCommand() { return true; }

        public DelegateCommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new DelegateCommand
                  ((obj) =>
                  {
                      ResetStatus();
                      DoAddCommand();
                      if(_addCommand != null) _addCommand.RaiseCanExecuteChanged();
                      if (_delCommand != null) _delCommand.RaiseCanExecuteChanged();
                      if (_saveCommand != null) _saveCommand.RaiseCanExecuteChanged();
                  },
                  (obj) => CanAddCommand()));
            }
        }

        public virtual void DoDelCommand(int index) { }

        public virtual bool CanDelCommand() { return true; }

        public DelegateCommand DelCommand
        {
            get
            {
                return _delCommand ?? (_delCommand =
                  new DelegateCommand((obj) =>
                  {
                      ResetStatus();
                      DoDelCommand((int)obj);
                      if (_addCommand != null) _addCommand.RaiseCanExecuteChanged();
                      if (_delCommand != null) _delCommand.RaiseCanExecuteChanged();
                      if (_saveCommand != null) _saveCommand.RaiseCanExecuteChanged();
                  },
                   (obj) => CanDelCommand()));
            }
        }


        public virtual void DoSaveCommand() { }

        public DelegateCommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand =
                  new DelegateCommand((obj) =>
                  {
                      ResetStatus();
                      DoSaveCommand();
                      if (_addCommand != null) _addCommand.RaiseCanExecuteChanged();
                      if (_delCommand != null) _delCommand.RaiseCanExecuteChanged();
                      if (_saveCommand != null) _saveCommand.RaiseCanExecuteChanged();
                  },
                   (obj) => true));
            }
        }
        public virtual void ResetStatus() { }
    }
}
