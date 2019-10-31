using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Thibetanus.Common.Converter
{
    class PriceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null) return value;
            long strValue = long.Parse(value as string);
            return string.Format("{0:C0}", strValue);// strValue.ToString("C");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value == null) return value;
            string strValue = value as string;
            return strValue.Replace(",","").Replace("￥","");

        }
    }
}
