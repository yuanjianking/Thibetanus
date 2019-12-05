using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Thibetanus.Common.BaseModel;
using Thibetanus.Common.Exceptions;
using Thibetanus.Common.UserControls;
using Thibetanus.Controls.Salon;
using Thibetanus.Models.SubPage.Salon;
using Thibetanus.Models.SubPage.Service;
using Thibetanus.ViewModels.SubPage;
using Windows.ApplicationModel.Resources;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace Thibetanus.Views.SubPage.Salon
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class SalonDetailEdit : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<ServiceModel> _serivces = null;

        public ObservableCollection<ServiceModel> Serivces
        {
            get { return _serivces; }
            set
            {
                _serivces = value;
             //   PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Serivces"));
            }
        }
        public SalonDetailEdit()
        {
            this.InitializeComponent();
        }

        public string Code        {
            get;
            set;
        }

        public string SalonName
        {
            get;
            set;
        }

        public string Location
        {
            get;
            set;
        }

        public string Manager
        {
            get;
            set;
        }
        

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var parameter = e.Parameter;

            Type type = e.Parameter?.GetType();
            if (type != null)
            {
                SalonModel model = (SalonModel)type.GetProperty("SalonModel").GetValue(parameter);
                Code = model.Code;
                SalonName = model.Name;
                Location = model.Location.Name;
                Manager = model.Manager.Name;

                Serivces = new SalonControl().GetAllSalonServiceInfos(Code);
               
            }
        }

        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var item = btn.DataContext as ServiceModel;
            Serivces.Remove(item);
        }
        
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Action<object, ObservableCollection<ServiceModel>> action = (o, m) =>
            {
                foreach (var m1 in m)
                {
                    if (Serivces.Where(s => s.Code == m1.Code).Count() > 0)
                    {
                        //skip
                    }
                    else
                    {
                        int index = 0;
                        foreach (var s in Serivces)
                        {
                            if (s.Code.CompareTo(m1.Code) > 0)
                            {
                                break;
                            }
                            else
                            {
                                index++;
                            }
                        }
                        
                        Serivces.Insert(index,m1);                        
                    }
                }
            };
            ServicePopup p = new ServicePopup(action, Serivces);
            p.Show();           
        }


        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int res = new SalonControl().SaveSalonService(Code, Serivces);
                ResourceLoader resourceLoader = ResourceLoader.GetForCurrentView("MessageResources");
                string message = resourceLoader.GetString("Success");
                MessagePopup messageopup = new MessagePopup(message);
                messageopup.Show();
            }
            catch (AppException appex)
            {
                MessagePopup messageopup = new MessagePopup(appex.ToString());
                messageopup.Show();
            }
        }
        
    }
}