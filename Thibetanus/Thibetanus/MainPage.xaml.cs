using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Thibetanus.Common.Enum;
using Thibetanus.Common.Helper;
using Thibetanus.Common.UserControls;
using Thibetanus.Views;
using Windows.ApplicationModel.Resources;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace Thibetanus
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static readonly string START_NO = "A1ACA0D2B4130581D9BEDE862F0DF431656EFACC";
        public MainPage()
        {
            this.InitializeComponent();       
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (START_NO.Equals(EncryptHelper.EncryptToSHA1(passwordBox.Password,Encoding.UTF8)))
            {
                Frame.Navigate(typeof(LoginPage));
            }
        }

        private void PasswordBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if(e.Key.Equals(VirtualKey.Enter))
            {
                if (START_NO.Equals(EncryptHelper.EncryptToSHA1(passwordBox.Password, Encoding.UTF8)))
                {
                    Frame.Navigate(typeof(LoginPage));
                }
                else
                {
                    ResourceLoader resourceLoader = ResourceLoader.GetForCurrentView("MessageResources");
                    string message = resourceLoader.GetString("BootError");
                    MessagePopup messageopup = new MessagePopup(message);
                    messageopup.Show();
                    passwordBox.Password = "";
                  
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame root = Window.Current.Content as Frame;//获取当前激活页面
            root.Navigate(typeof(MainMenu), new { Permission = Permission.Manager});
        }
    }
}
