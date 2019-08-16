using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlotByCoordinate.Model;
using GalaSoft.MvvmLight.Command;
using System.Windows.Media.Animation;
using System.Windows;
using System.Windows.Media;

namespace PlotByCoordinate.ViewModel
{
    public class CoordinateValueViewModel:ViewModelBase 
    {

        public CoordinateValueViewModel()
        {
            CoordinateValue = new CoordinateValueModel() {TriangleX1=200,TriangleY1=200,TriangleX2=200,TriangleY2=400,TriangleX3=400,TriangleY3=200 ,LineX1=100,LineY1=100,LineX2=500,LineY2=100};           
        }

        private CoordinateValueModel _coordinateValue;

        public CoordinateValueModel CoordinateValue
        {
            get { return _coordinateValue; }
            set { _coordinateValue = value; RaisePropertyChanged(() => CoordinateValue); }
        }

        private RelayCommand beginPaint;

        public RelayCommand BeginPaint
        {
            get
            {
                if (beginPaint == null) return new RelayCommand(() => ExecuteToPaint(), CanExcute);
                return beginPaint;
            }
            set { beginPaint = value; }
        }
        private void ExecuteToPaint()
        {

            
        }
        public bool CanExcute()
        {
            return true;
        }
    }
}
