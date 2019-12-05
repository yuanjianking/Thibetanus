using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Thibetanus.Common.Converter
{
    class HeadingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null || parameter == null) return value;
            return string.Format("{0}{1}", parameter, value);// strValue.ToString("C");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value == null || parameter == null) return value;
            string strValue = value as string;
            string strParameter = parameter as string;
            return strValue.Replace(strParameter, "");

        }
    }
}
