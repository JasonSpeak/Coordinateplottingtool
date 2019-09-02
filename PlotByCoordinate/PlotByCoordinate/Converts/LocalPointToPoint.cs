using PlotByCoordinate.Models;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace PlotByCoordinate.Converts
{
    public class LocalPointToPoint : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        { 
            //var point = new Point();
            //var localPoint = (LocalPoint)value;
            //if (localPoint?.X == null || localPoint.Y==null) return point;
            //point.X = (double) localPoint.X;
            //point.Y = (double) localPoint.Y;
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
