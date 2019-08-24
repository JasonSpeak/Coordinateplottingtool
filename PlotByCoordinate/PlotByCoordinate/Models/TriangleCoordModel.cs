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
        private MyPointModel _firstPoint;
        private MyPointModel _thirdPoint;
        private MyPointModel _secondPoint;
        private double _triangleXPos;
        private double _triangleYPos;


        public TriangleCoordModel()
        {
            FirstPoint = new MyPointModel();
            SecondPoint = new MyPointModel();
            ThirdPoint = new MyPointModel();
        }
    
        public MyPointModel FirstPoint
        {
            get { return _firstPoint; }
            set {  _firstPoint = value;  }
        }

        public MyPointModel SecondPoint
        {
            get { return _secondPoint; }
            set { _secondPoint = value;  }
        }

        public MyPointModel ThirdPoint
        {
            get { return _thirdPoint; }
            set { _thirdPoint = value;}
        }
        
        public double TriangleXPos
        {
            get { return _triangleXPos; }
            set{ _triangleXPos = value;}
        }
        
        public double TriangleYPos
        {
            get { return _triangleYPos; }
            set{_triangleYPos = value;}
        }
      
       
    }
}
