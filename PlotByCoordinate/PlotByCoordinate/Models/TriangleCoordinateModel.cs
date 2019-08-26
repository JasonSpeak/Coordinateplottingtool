using GalaSoft.MvvmLight;

namespace PlotByCoordinate.Models
{
    public class TriangleCoordinateModel:ObservableObject
    {
        public TriangleCoordinateModel()
        {
            FirstPoint = new MyPointModel();
            SecondPoint = new MyPointModel();
            ThirdPoint = new MyPointModel();
        }
    
        public MyPointModel FirstPoint { get; set; }

        public MyPointModel SecondPoint { get; set; }

        public MyPointModel ThirdPoint { get; set; }

        public double TriangleXPos { get; set; }

        public double TriangleYPos { get; set; }
    }
}
