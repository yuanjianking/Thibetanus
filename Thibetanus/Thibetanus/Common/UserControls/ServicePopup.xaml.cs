using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Thibetanus.Controls.Service;
using Thibetanus.Models.SubPage.Service;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//https://go.microsoft.com/fwlink/?LinkId=234236 上介绍了“用户控件”项模板

namespace Thibetanus.Common.UserControls
{
    public sealed partial class ServicePopup : UserControl
    {
        private Popup m_Popup;
        private ObservableCollection<ServiceModel> _services;
        public event Action<object, ObservableCollection<ServiceModel>> ActionEvent;

        public ServicePopup(Action<object, ObservableCollection<ServiceModel>> action, ObservableCollection<ServiceModel> services)
        {
            this.InitializeComponent();
            m_Popup = new Popup();
            this.Width = Window.Current.Bounds.Width;
            this.Height = Window.Current.Bounds.Height;
            m_Popup.Child = this;
            this.Loaded += NotifyPopup_Loaded; ;
            this.Unloaded += NotifyPopup_Unloaded;
            this.ActionEvent += action;
            this._services = services;
        }
        
        public void Show()
        {
            this.m_Popup.IsOpen = true;
        }
        
        private void AllButton_Click(object sender, RoutedEventArgs e)
        {
            serviceList.SelectAll();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            serviceList.SelectedItems.Clear();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<ServiceModel> models = new ObservableCollection<ServiceModel>();
            foreach (ServiceModel model in serviceList.SelectedItems)
            {
                models.Add(model);
            }                
            ActionEvent?.Invoke(this, models);
            this.m_Popup.IsOpen = false;
        }


        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.m_Popup.IsOpen = false;
        }

        private void NotifyPopup_Loaded(object sender, RoutedEventArgs e)
        {
            Window.Current.SizeChanged += Current_SizeChanged; ;
        }

        private void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            this.Width = e.Size.Width;
            this.Height = e.Size.Height;
        }

        private void NotifyPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            Window.Current.SizeChanged -= Current_SizeChanged;
        }

        private void ServiceList_ChoosingItemContainer(ListViewBase sender, ChoosingItemContainerEventArgs args)
        {
        }

        private void ServiceList_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
        {
            if (args.ItemContainer != null)
            {              
                if (_services.Where(m => m.Code.Equals(((ServiceModel)args.Item).Code)).Count() > 0)
                    args.ItemContainer.IsSelected = true;
            }
        }
    }
}
