using GalaSoft.MvvmLight;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace PlotByCoordinate.Models
{
    public class TriangleCoordinateModel : ObservableObject
    {
        private Point _firstPoint;
        private Point _secondPoint;
        private Point _thirdPoint;
        private PointCollection _pointCollection;
        private string _triangleFirstPointX;
        private string _triangleFirstPointY;
        private string _triangleSecondPointX;
        private string _triangleSecondPointY;
        private string _triangleThirdPointX;
        private string _triangleThirdPointY;

        public double TriangleXPos { get; set; }

        public double TriangleYPos { get; set; }

        public PointCollection TempPointCollection { get; set; }

        public PointCollection PointsOfTriangle
        {
            get=>_pointCollection;
            set
            {
                _pointCollection = value;
                RaisePropertyChanged(()=>PointsOfTriangle);
            }
        }

        public string TriangleFirstPointX
        {
            get => _triangleFirstPointX;
            set
            {
                _triangleFirstPointX = value;
                RaisePropertyChanged(()=> TriangleFirstPointX);
                if (double.TryParse(_triangleFirstPointX, out var pointX))
                {
                    FirstPoint = new Point(pointX,FirstPoint.Y);
                }
            }
        }

        public string TriangleFirstPointY
        {
            get => _triangleFirstPointY;
            set
            {
                _triangleFirstPointY = value;
                RaisePropertyChanged(() => TriangleFirstPointY);
                if (double.TryParse(_triangleFirstPointY, out var pointY))
                {
                    FirstPoint = new Point(FirstPoint.X,pointY);
                }
            }
        }

        public string TriangleSecondPointX
        {
            get => _triangleSecondPointX;
            set
            {
                _triangleSecondPointX = value;
                RaisePropertyChanged(() => TriangleSecondPointX);
                if (double.TryParse(_triangleSecondPointX, out var pointX))
                {
                    SecondPoint = new Point(pointX, SecondPoint.Y);
                }
            }
        }

        public string TriangleSecondPointY
        {
            get => _triangleSecondPointY;
            set
            {
                _triangleSecondPointY = value;
                RaisePropertyChanged(() => TriangleSecondPointY);
                if (double.TryParse(_triangleSecondPointY, out var pointY))
                {
                   SecondPoint = new Point(SecondPoint.X, pointY);
                }
            }
        }

        public string TriangleThirdPointX
        {
            get => _triangleThirdPointX;
            set
            {
                _triangleThirdPointX = value;
                RaisePropertyChanged(() => TriangleThirdPointX);
                if (double.TryParse(_triangleThirdPointX, out var pointX))
                {
                    ThirdPoint = new Point(pointX, ThirdPoint.Y);
                }
            }
        }

        public string TriangleThirdPointY
        {
            get => _triangleThirdPointY;
            set
            {
                _triangleThirdPointY = value;
                RaisePropertyChanged(() => TriangleThirdPointY);
                if (double.TryParse(_triangleThirdPointY, out var pointY))
                {
                    ThirdPoint = new Point(ThirdPoint.X, pointY);
                }
            }
        }

        public Point FirstPoint
        {
            get => _firstPoint;
            set
            {
                _firstPoint = value;
                RaisePropertyChanged(() => FirstPoint);
            }
        }

        public Point SecondPoint
        {
            get => _secondPoint;
            set
            {
                _secondPoint = value;
                RaisePropertyChanged(() => SecondPoint);
            }
        }

        public Point ThirdPoint
        {
            get => _thirdPoint;
            set
            {
                _thirdPoint = value;
                RaisePropertyChanged(() => ThirdPoint);
            }
        }

        public TriangleCoordinateModel()
        {
            PointsOfTriangle = new PointCollection();
        }

        public void TriangleMove(Point positionOfControl ,Point mouseDownPosition)
        {
            var offsetDistanceOfX = positionOfControl.X - mouseDownPosition.X;
            var offsetDistanceOfY = positionOfControl.Y - mouseDownPosition.Y;
            var triangleX1 = FirstPoint.X;
            triangleX1 += (offsetDistanceOfX);
            TriangleFirstPointX = triangleX1.ToString(CultureInfo.InvariantCulture);
            var triangleY1 = FirstPoint.Y;
            triangleY1 += (offsetDistanceOfY);
            TriangleFirstPointY = triangleY1.ToString(CultureInfo.InvariantCulture);
            var triangleX2 = SecondPoint.X;
            triangleX2 += (offsetDistanceOfX);
            TriangleSecondPointX = triangleX2.ToString(CultureInfo.InvariantCulture);
            var triangleY2 = SecondPoint.Y;
            triangleY2 += (offsetDistanceOfY);
            TriangleSecondPointY = triangleY2.ToString(CultureInfo.InvariantCulture);
            var triangleX3 = ThirdPoint.X;
            triangleX3 += (offsetDistanceOfX);
            TriangleThirdPointX = triangleX3.ToString(CultureInfo.InvariantCulture);
            var triangleY3 = ThirdPoint.Y;
            triangleY3 += (offsetDistanceOfY);
            TriangleThirdPointY = triangleY3.ToString(CultureInfo.InvariantCulture);
            AddPointToCollection();
        }
      
        public void AddPointToCollection()
        {
            TempPointCollection=new PointCollection();
            TempPointCollection.Clear();
            TempPointCollection.Add(FirstPoint);
            TempPointCollection.Add(SecondPoint);
            TempPointCollection.Add(ThirdPoint);
            PointsOfTriangle = TempPointCollection;
        }

        public void RestorationTriangle()
        {
            TriangleXPos = 0;
            TriangleYPos = 0;
        }
    }
}
