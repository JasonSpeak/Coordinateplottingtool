using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PlotByCoordinate.Model
{
    public class InputLimitsModel : ObservableObject
    {
       
        private double maxX;
        private double maxY;

        public double MaxX
        {
            get { return maxX; }
            set { maxX = value; RaisePropertyChanged(() => MaxX); }
        }


        public double MaxY
        {
            get { return maxY; }
            set { maxY = value; RaisePropertyChanged(() => MaxY); }
        }
    }
}
