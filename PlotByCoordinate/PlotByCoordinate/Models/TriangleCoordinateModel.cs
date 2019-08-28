using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Documents;
using GalaSoft.MvvmLight;

namespace PlotByCoordinate.Models
{
    public class TriangleCoordinateModel : ObservableObject
    {
        private string hiddenOrVisibleOfTriangleImage;

        public ObservableCollection<CanvasPoint> Points { get; }

        public string HiddenOrVisibleOfTriangleImage
        {
            get => hiddenOrVisibleOfTriangleImage;
            set { hiddenOrVisibleOfTriangleImage = value; RaisePropertyChanged(() => HiddenOrVisibleOfTriangleImage); }
        }

        public CanvasPoint FirstPoint { get; set; }

        public CanvasPoint SecondPoint { get; set; }

        public CanvasPoint ThirdPoint { get; set; }

        public double TriangleXPos { get; set; }

        public double TriangleYPos { get; set; }

        public TriangleCoordinateModel()
        {
            HiddenOrVisibleOfTriangleImage = "Hidden";
            FirstPoint = new CanvasPoint();
            SecondPoint = new CanvasPoint();
            ThirdPoint = new CanvasPoint();
            Points = new ObservableCollection<CanvasPoint>()
            {
                FirstPoint, SecondPoint, ThirdPoint
            };
        }

        public void Move(Point deltaPosition)
        {
            foreach (var point in Points)
            {
                point.X += deltaPosition.X;
                point.Y += deltaPosition.Y;
            }
        }
    }
}
