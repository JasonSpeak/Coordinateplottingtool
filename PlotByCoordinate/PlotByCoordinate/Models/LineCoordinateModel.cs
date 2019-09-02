using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using GalaSoft.MvvmLight;

namespace PlotByCoordinate.Models
{
    public class LineCoordinateModel : ObservableObject
    {

        private string _lineStartPointX;
        private string _lineStartPointY;
        private string _lineEndPointX;
        private string _lineEndPointY;

        private PointCollection _pointCollection;

        public Point StartPoint { get; set; }

        public Point EndPoint { get; set; }

        public double LineXPos { get; set; }

        public double LineYPos { get; set; }

        public PointCollection TemPointCollection { get; set; }

        public string LineStartPointX
        {
            get => _lineStartPointX;
            set
            {
                _lineStartPointX = value;
                RaisePropertyChanged(() => LineStartPointX);
                if (double.TryParse(_lineStartPointX, out var pointX))
                {
                    StartPoint = new Point(pointX, StartPoint.Y);
                }
            }
        }

        public string LineStartPointY
        {
            get => _lineStartPointY;
            set
            {
                _lineStartPointY = value;
                RaisePropertyChanged(() => LineStartPointY);
                if (double.TryParse(_lineStartPointY, out var pointY))
                {
                    StartPoint = new Point(StartPoint.X, pointY);
                }
            }
        }

        public string LineEndPointX
        {
            get => _lineEndPointX;
            set
            {
                _lineEndPointX = value;
                RaisePropertyChanged(() => LineEndPointX);
                if (double.TryParse(_lineEndPointX, out var pointX))
                {
                    EndPoint = new Point(pointX, EndPoint.Y);
                }
            }
        }

        public string LineEndPointY
        {
            get => _lineEndPointY;
            set
            {
                _lineEndPointY = value;
                RaisePropertyChanged(() => LineEndPointY);
                if (double.TryParse(_lineEndPointY, out var pointY))
                {
                    EndPoint = new Point(EndPoint.X, pointY);
                }
            }
        }

        public PointCollection PointsOfLine
        {
            get => _pointCollection;
            set
            {
                _pointCollection = value;
                RaisePropertyChanged(() => PointsOfLine);
            }
        }
        
    
        public LineCoordinateModel()
        {
            PointsOfLine = new PointCollection();
        }

        public void LineMove(Point positionOfControl, Point mouseDownPosition)
        {
            var lineX1 = StartPoint.X;
            lineX1 += ( positionOfControl.X - mouseDownPosition.X);
            LineStartPointX = lineX1.ToString(CultureInfo.InvariantCulture);

            var lineY1 = StartPoint.Y;
            lineY1 += (positionOfControl.Y - mouseDownPosition.Y);
            LineStartPointY = lineY1.ToString(CultureInfo.InvariantCulture);

            var lineX2 = EndPoint.X;
            lineX2 += (positionOfControl.X - mouseDownPosition.X);
            LineEndPointX = lineX2.ToString(CultureInfo.InvariantCulture);

            var lineY2 = EndPoint.Y;
            lineY2 += (positionOfControl.Y - mouseDownPosition.Y);
            LineEndPointY = lineY2.ToString(CultureInfo.InvariantCulture);

            RaiseLinePointChange();
        }

        public void RaiseLinePointChange()
        {
            TemPointCollection = new PointCollection();
            TemPointCollection.Clear();
            TemPointCollection.Add(StartPoint);
            TemPointCollection.Add(EndPoint);
            PointsOfLine = TemPointCollection;
        }

        public void RestorationPathOfLine()
        {
            LineXPos = 0;
            LineYPos = 0;
        }
    }   
}
