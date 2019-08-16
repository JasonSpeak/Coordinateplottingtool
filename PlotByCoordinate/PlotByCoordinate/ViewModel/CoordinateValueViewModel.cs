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
            CoordinateValue = new CoordinateValueModel();           
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
