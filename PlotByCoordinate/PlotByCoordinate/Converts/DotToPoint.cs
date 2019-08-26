using System;
using System.Globalization;
using System.Windows.Data;

namespace PlotByCoordinate.Converts
{
    public class DotToPoint : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double.TryParse((string)value, out var myValue);
            return myValue;
        }
    }
}
