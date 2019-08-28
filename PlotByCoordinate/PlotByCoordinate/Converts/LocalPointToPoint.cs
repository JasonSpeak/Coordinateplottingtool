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
            var point = new Point();
            var myPoint = (CanvasPoint)value;
            if (myPoint == null) return point;
            if (myPoint.X != null) point.X = (double) myPoint.X;
            if (myPoint.Y != null) point.Y = (double) myPoint.Y;
            return point;
          
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
