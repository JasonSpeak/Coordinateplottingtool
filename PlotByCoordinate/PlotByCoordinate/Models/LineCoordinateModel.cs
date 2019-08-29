using System.Collections.ObjectModel;
using System.Windows;
using GalaSoft.MvvmLight;

namespace PlotByCoordinate.Models
{
    public class LineCoordinateModel : ObservableObject
    {
        private string hiddenOrVisibleOfLineImage;

        public ObservableCollection<CanvasPoint> PointsOfLine { get; }

        public CanvasPoint StartPoint { get; set; }

        public CanvasPoint EndPoint { get; set; }

        public double LineXPos { get; set; }

        public double LineYPos { get; set; }

        public string HiddenOrVisibleOfLineImage
        {
            get => hiddenOrVisibleOfLineImage;
            set { hiddenOrVisibleOfLineImage = value; RaisePropertyChanged(() => HiddenOrVisibleOfLineImage); }
        }

        public LineCoordinateModel()
        {
            HiddenOrVisibleOfLineImage = "Hidden";
            StartPoint = new CanvasPoint();
            EndPoint = new CanvasPoint();
            PointsOfLine = new ObservableCollection<CanvasPoint>()
            {
                StartPoint,EndPoint
            };
        }

        public void LineMove(Point positionOfControl, Point mouseDownPosition)
        {
            foreach (var point in PointsOfLine)
            {
                point.X += positionOfControl.X - mouseDownPosition.X;
                point.Y += positionOfControl.Y - mouseDownPosition.Y;
            }
        }

        public void RaiseLinePointChange()
        {
            RaisePropertyChanged(() => StartPoint);
            RaisePropertyChanged(() => EndPoint);
        }

        public void RestorationPathOfLine()
        {
            LineXPos = 0;
            LineYPos = 0;
        }


    }   
}
