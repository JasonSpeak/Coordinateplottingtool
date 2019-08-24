using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PlotByCoordinate.Models
{
    public class LineCoordModel : ObservableObject
    {
        private MyPointModel _startPoint;
        private MyPointModel _endPoint;
        private double _linexPos;
        private double _lineyPos;

        public LineCoordModel()
        {
            StartPoint = new MyPointModel();
            EndPoint = new MyPointModel();
        }

        public MyPointModel StartPoint
        {
            get { return _startPoint; }
            set { _startPoint = value;  }
        }

        public MyPointModel EndPoint
        {
            get { return _endPoint; }
            set { _endPoint = value;  }
        }

        public double LineXPos
        {
            get { return _linexPos; }
            set { _linexPos = value; }
        }

        public double LineYPos
        {
            get { return _lineyPos; }
            set { _lineyPos = value;}
        }
    }   
}
