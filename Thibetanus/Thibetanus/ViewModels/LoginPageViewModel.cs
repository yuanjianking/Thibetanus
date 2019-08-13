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
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Thibetanus.ViewModels
{
    class LoginPageViewModel : ObservableObject
    {
        private LoginModel _loginUser;

        public LoginModel LoginUser
        {
            get { return _loginUser; }
            set
            {
                _loginUser = value;
                RaisePropertyChanged("LoginUser");
            }
        }

        public void Login(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key.Equals(VirtualKey.Enter))
            { 
                if (new LoginControl().Login(LoginUser))
                {
                    Frame root = Window.Current.Content as Frame;//获取当前激活页面
                    root.Navigate(typeof(MainMenu), new { Permission = Permission.Master });
                }
                else
                {
                    ResourceLoader resourceLoader = ResourceLoader.GetForCurrentView("MessageResources");
                    string message = resourceLoader.GetString("BootError");
                    MessagePopup messageopup = new MessagePopup(message);
                    messageopup.Show();
                    LoginUser.Password = "";
                }
            }
        }


        //private DelegateCommand _addCommand;
        //private DelegateCommand _delCommand;

        //public DelegateCommand AddCommand
        //{
        //    get
        //    {
        //        return _addCommand ?? (_addCommand = new DelegateCommand
        //          ((Object obj) =>
        //          {
        //              this.Users.Add(new User("", "111"));
        //              this._addCommand.RaiseCanExecuteChanged();
        //              this._delCommand.RaiseCanExecuteChanged();
        //          },
        //          (Object obj) => this.Users.Count < 5));
        //    }
        //}

        //public DelegateCommand DelCommand
        //{
        //    get
        //    {
        //        return _delCommand ?? (_delCommand =
        //          new DelegateCommand((Object obj) =>
        //          {
        //              this.Users.RemoveAt(0);
        //              this._addCommand.RaiseCanExecuteChanged();
        //              this._delCommand.RaiseCanExecuteChanged();
        //          },
        //          (Object obj) => this.Users.Count > 1));
        //    }
        //}
    }
}
