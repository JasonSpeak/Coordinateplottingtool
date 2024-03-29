﻿using GalaSoft.MvvmLight;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

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

        public PointCollection TemPointCollection { get; set; }

        public double LineXPos { get; set; }

        public double LineYPos { get; set; }

        public PointCollection PointsOfLine
        {
            get => _pointCollection;
            set
            {
                _pointCollection = value;
                RaisePropertyChanged(() => PointsOfLine);
            }
        }

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

        public LineCoordinateModel()
        {
            PointsOfLine = new PointCollection();
        }

        public void LineMove(Point positionOfControl, Point mouseDownPosition)
        {
            var offsetDistanceOfX = positionOfControl.X - mouseDownPosition.X;
            var offsetDistanceOfY = positionOfControl.Y - mouseDownPosition.Y;
            var lineX1 = StartPoint.X;
            lineX1 += (offsetDistanceOfX);
            LineStartPointX = lineX1.ToString(CultureInfo.InvariantCulture);
            var lineY1 = StartPoint.Y;
            lineY1 += (offsetDistanceOfY);
            LineStartPointY = lineY1.ToString(CultureInfo.InvariantCulture);
            var lineX2 = EndPoint.X;
            lineX2 += (offsetDistanceOfX);
            LineEndPointX = lineX2.ToString(CultureInfo.InvariantCulture);
            var lineY2 = EndPoint.Y;
            lineY2 += (offsetDistanceOfY);
            LineEndPointY = lineY2.ToString(CultureInfo.InvariantCulture);
            AddPointToCollection();
        }

        public void AddPointToCollection()
        {
            TemPointCollection = new PointCollection();
            TemPointCollection.Clear();
            TemPointCollection.Add(StartPoint);
            TemPointCollection.Add(EndPoint);
            PointsOfLine = TemPointCollection;
        }

        public void RestorationLine()
        {
            LineXPos = 0;
            LineYPos = 0;
        }
    }   
}
