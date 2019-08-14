using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlotByCoordinate.Model;
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


    }
}
