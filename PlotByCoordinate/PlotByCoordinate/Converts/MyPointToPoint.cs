using PlotByCoordinate.Models;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using PlotByCoordinate.ViewModels;

namespace PlotByCoordinate.Converts
{
    public class MyPointToPoint : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        { 
            var point = new Point();
            var myPoint = (MyPointModel)value;
            if (myPoint == null) return point;
            point.X = myPoint.X;
            point.Y = myPoint.Y;
            return point;
          
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
