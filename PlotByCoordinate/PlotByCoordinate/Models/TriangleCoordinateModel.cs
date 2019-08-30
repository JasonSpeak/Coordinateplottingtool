using System.Collections.ObjectModel;
using System.Windows;
using GalaSoft.MvvmLight;

namespace PlotByCoordinate.Models
{
    public class TriangleCoordinateModel : ObservableObject
    {
        private string hiddenOrVisibleOfTriangleImage;

        public ObservableCollection<LocalPoint> PointsOfTriangle { get; }

        public LocalPoint FirstPoint { get; set; }

        public LocalPoint SecondPoint { get; set; }

        public LocalPoint ThirdPoint { get; set; }

        public double TriangleXPos { get; set; }

        public double TriangleYPos { get; set; }

        public string HiddenOrVisibleOfTriangleImage
        {
            get => hiddenOrVisibleOfTriangleImage;
            set
            {
                hiddenOrVisibleOfTriangleImage = value;
                RaisePropertyChanged(() => HiddenOrVisibleOfTriangleImage);
            }
        }

        public TriangleCoordinateModel()
        {
            HiddenOrVisibleOfTriangleImage = "Hidden";
            FirstPoint = new LocalPoint();
            SecondPoint = new LocalPoint();
            ThirdPoint = new LocalPoint();
            PointsOfTriangle = new ObservableCollection<LocalPoint>()
            {
                FirstPoint, SecondPoint, ThirdPoint
            };
        }

        public void TriangleMove(Point positionOfControl ,Point mouseDownPosition)
        {
            foreach (var point in PointsOfTriangle)
            {
                point.X += positionOfControl.X-mouseDownPosition.X;
                point.Y += positionOfControl.Y-mouseDownPosition.Y;
            }
        }

        public void RaiseTrianglePointChange()
        {
            RaisePropertyChanged(() => FirstPoint);
            RaisePropertyChanged(() => SecondPoint);
            RaisePropertyChanged(() => ThirdPoint);
        }

        public void RestorationPathOfTriangle()
        {
            TriangleXPos = 0;
            TriangleYPos = 0;
        }

        public void ShowImageOfTriangle()
        {
            HiddenOrVisibleOfTriangleImage = "Visible";
        }
    }
}
