using System;
using System.Globalization;
using System.Windows.Data;

namespace Studenter.Presentation.Converters
{
    public class StudentCountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return $"Es sind aktuell {(int) value} Studenten immatrikuliert";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return value;
        }
    }
}
