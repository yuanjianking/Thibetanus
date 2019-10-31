using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Common.BaseModel;
using Thibetanus.Common.Log;
using Thibetanus.Common.UserControls;
using Thibetanus.Controls.Salon;
using Thibetanus.Models.SubPage;
using Thibetanus.Models.SubPage.Salon;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml;

namespace Thibetanus.ViewModels.SubPage.Salon
{
    class SalonEditViewModel : SubBaseViewModel
    {
       private ObservableCollection<SalonModel> _salons = null;

       public ObservableCollection<SalonModel> Salons
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
            try
            {
                Salons = new SalonControl().GetAllSalonInfos();
            }
            catch (Exception ex)
            {
                AppLog.Error(typeof(SalonEditViewModel), ex.ToString());
            }
        }

        override
        public void DoAddCommand()
        {
            //      string code = string.Format("MY{0}", (Salons..Count + 1).ToString("D10"));
            Salons.Add(new SalonModel("Collapsed", "Visible"));
        }

        override
        public bool CanAddCommand()
        {
            return Salons.Count < 10;
        }

        override
        public void DoDelCommand(int index)
        {
            Salons.RemoveAt(index);
        }

        override
        public bool CanDelCommand()
        {
            return Salons.Count > 1;
        }

        override
        public void DoSaveCommand()
        {
            if (new SalonControl().Save(Salons) != 0)
            {
                ResourceLoader resourceLoader = ResourceLoader.GetForCurrentView("MessageResources");
                string message = resourceLoader.GetString("Success");
                MessagePopup messageopup = new MessagePopup(message);
                messageopup.Show();
                Salons = new SalonControl().GetAllSalonInfos();
            }
        }

        override
        public void ResetStatus()
        {
            foreach (var item in Salons)
            {
                item.Show = "Visible";
                item.Edit = "Collapsed";
            }
        }
    }
}
