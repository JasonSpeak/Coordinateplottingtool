using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PlotByCoordinate.Models
{
    public class TriangleCoordModel:ObservableObject
    {
        private Point _firstPoint;
        private Point _thirdPoint;
        private Point _secondPoint;
        private double _triangleX1;
        private double _triangleY1;
        private double _triangleX2;
        private double _triangleY2;
        private double _triangleX3;
        private double _triangleY3;
        private double _triangleXPos;
        private double _triangleYPos;
        public Point FirstPoint
        {
            get { return _firstPoint; }
            set { _firstPoint = value; RaisePropertyChanged(() => FirstPoint); }
        }

        public Point SecondPoint
        {
            get { return _secondPoint; }
            set { _secondPoint = value; RaisePropertyChanged(() => SecondPoint); }
        }

        public Point ThirdPoint
        {
            get { return _thirdPoint; }
            set { _thirdPoint = value; RaisePropertyChanged(() => ThirdPoint); }
        }
        
        public double TriangleXPos
        {
            get { return _triangleXPos; }
            set{ _triangleXPos = value;RaisePropertyChanged(() => TriangleXPos);}
        }
        
        public double TriangleYPos
        {
            get { return _triangleYPos; }
            set{_triangleYPos = value;RaisePropertyChanged(() => TriangleYPos);}
        }
    }
}
