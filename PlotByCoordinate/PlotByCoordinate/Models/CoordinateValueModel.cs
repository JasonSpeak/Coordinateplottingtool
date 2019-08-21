using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PlotByCoordinate.Model
{
    public class CoordinateValueModel:ObservableObject
    {
        private double _lineX1;
        private double _lineY1;
        private double _lineX2;
        private double _lineY2;
        private double _triangleX1;
        private double _triangleY1;
        private double _triangleX2;
        private double _triangleY2;
        private double _triangleX3;
        private double _triangleY3;
        private double _triangleXPos;
        private double _triangleYPos;
        private double _linexPos;
        private double _lineyPos;
        private Point[] _points;

        public double LineX1
        {
            get { return _lineX1; }
            set
            {
                if (value>640||value<0)
                {
                    value = 0;
                }
                _lineX1 = (double)value;
                RaisePropertyChanged(() => LineX1);
            }
        }
        public double LineY1
        {
            get { return _lineY1; }
            set
            {
                if (value>550)
                {
                    value = 0;
                }
                _lineY1 = (double)value;
                RaisePropertyChanged(() => LineY1);
            }
        }
        public double LineX2
        {
            get { return _lineX2; }
            set
            {
                if (value>640)
                {
                    value = 0;
                }
                _lineX2 = (double)value;
                RaisePropertyChanged(() => LineX2);
            }
        }
        public double LineY2
        {
            get { return _lineY2; }
            set
            {
                if (value>550)
                {
                    value = 0;
                }
                _lineY2 = (int)value;
                RaisePropertyChanged(() => LineY2);
            }
        }     
        public double TriangleX1
        {
            get { return _triangleX1; }
            set
            {
                if (value > 640)
                {
                    value = 0;
                }
                _triangleX1 = (double)value;
                RaisePropertyChanged(() => TriangleX1);
            }
        }
        public double TriangleY1
        {
            get { return _triangleY1; }
            set
            {
                if (value>550)
                {
                    value = 0;
                }
                _triangleY1 = (double)value;
                RaisePropertyChanged(() => TriangleY1);
            }
        }
        public double TriangleX2
        {
            get { return _triangleX2; }
            set
            {
                if (value>640)
                {
                    value = 0;
                }
                _triangleX2 = (double)value;
                RaisePropertyChanged(() => TriangleX2);
            }
        }     
        public double TriangleY2
        {
            get { return _triangleY2; }
            set
            {
                if (value>550)
                {
                    value = 0;
                }
                _triangleY2 = (double)value;
                RaisePropertyChanged(() => TriangleY2);
            }
        }      
        public double TriangleX3
        {
            get { return _triangleX3; }
            set
            {
                if (value>640)
                {
                    value = 0;
                }
                _triangleX3 = (double)value;
                RaisePropertyChanged(() => TriangleX3);
            }
        }
        public double TriangleY3
        {
            get { return _triangleY3; }
            set
            {
                if (value>550)
                {
                    value = 0;
                }
                _triangleY3 = (double)value;
                RaisePropertyChanged(() => TriangleY3);
            }
        }
        public double TriangleXPos
        {
            get { return _triangleXPos; }
            set
            {
                _triangleXPos = value;
                RaisePropertyChanged(() => TriangleXPos);
            }
        }
        public double TriangleYPos
        {
            get { return _triangleYPos; }
            set
            {
                _triangleYPos = value;
                RaisePropertyChanged(() => TriangleYPos);
            }
        }    
        public double LineXPos
        {
            get { return _linexPos; }
            set
            {
                _linexPos = value;
                RaisePropertyChanged(() => LineXPos);
            }
        }
        public double LineYPos
        {
            get { return _lineyPos; }
            set
            {
                _lineyPos = value;
                RaisePropertyChanged(() => LineYPos);
            }
        }
    

        public Point[] Points
        {
            get { return _points; }
            set { _points = value; RaisePropertyChanged(() => Points); }
        }

    }
}
