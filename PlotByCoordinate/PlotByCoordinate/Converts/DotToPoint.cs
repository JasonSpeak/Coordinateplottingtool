using PlotByCoordinate.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace PlotByCoordinate.Converts
{
    public class DotToPoint : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            double myValue;
            double.TryParse((string)value, out myValue);
            Console.WriteLine("{0}", myValue);
            return myValue;
        }
    }
}
