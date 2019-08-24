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
    class MyPointToPoint : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Point point = new Point();
            MyPointModel myPoint = (MyPointModel)value;
            point.X = myPoint.X;
            point.Y = myPoint.Y;
            Console.WriteLine("x: {0} y:{1}", point.X, point.Y);
            return point;
          
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
