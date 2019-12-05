using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Thibetanus.Common.Converter
{
    class VisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null) return value;
            bool boolValue = value.Equals("Visible") ? true : false;
            return boolValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value == null) return value;
            if ((bool)value)
            { return "Visible"; }
            else
            { return "Collapsed"; }
        }
    }
}
