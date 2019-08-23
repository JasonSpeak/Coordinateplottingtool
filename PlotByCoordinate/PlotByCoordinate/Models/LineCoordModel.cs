using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PlotByCoordinate.Models
{
    public class LineCoordModel:ObservableObject
    {
        private Point _startPoint;
        private Point _endPoint;
        private double _lineX1;
        private double _lineY1;
        private double _lineX2;
        private double _lineY2;
        private double _linexPos;
        private double _lineyPos;

        public Point StartPoint
        {
            get { return _startPoint; }
            set { _startPoint = value; RaisePropertyChanged(() => StartPoint);}
        }
       
        public Point EndPoint
        {
            get { return _endPoint; }
            set { _endPoint = value; RaisePropertyChanged(() => EndPoint);}
        }
        
        public double LineXPos
        {
            get { return _linexPos; }
            set{ _linexPos = value; RaisePropertyChanged(() => LineXPos); }
        }
        
        public double LineYPos
        {
            get { return _lineyPos; }
            set { _lineyPos = value; RaisePropertyChanged(() => LineYPos);}
        }
        public double LineX1
        {
            get { return _lineX1; }
            set { _lineX1 = (double)value;RaisePropertyChanged(() => LineX1); }
        }

        public double LineY1
        {
            get { return _lineY1; }
            set{ _lineY1 = (double)value;RaisePropertyChanged(() => LineY1);}
        }

        public double LineX2
        {
            get { return _lineX2; }
            set { _lineX2 = (double)value; RaisePropertyChanged(() => LineX2);}
        }

        public double LineY2
        {
            get { return _lineY2; }
            set { _lineY2 = (int)value; RaisePropertyChanged(() => LineY2);}
        }
    }
}
