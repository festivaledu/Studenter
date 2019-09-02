using System;
using System.Globalization;
using System.Windows.Data;

namespace Studenter.Presentation.Converters
{
    public class StringToInt32Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            try {
                return int.Parse(value.ToString());
            } catch {
                return 0;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return value.ToString();
        }
    }
}
