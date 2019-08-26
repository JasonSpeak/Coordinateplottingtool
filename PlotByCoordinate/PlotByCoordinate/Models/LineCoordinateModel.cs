using GalaSoft.MvvmLight;

namespace PlotByCoordinate.Models
{
    public class LineCoordinateModel : ObservableObject
    {
        public LineCoordinateModel()
        {
            StartPoint = new MyPointModel();
            EndPoint = new MyPointModel();
        }

        public MyPointModel StartPoint { get; set; }

        public MyPointModel EndPoint { get; set; }

        public double LineXPos { get; set; }

        public double LineYPos { get; set; }
    }   
}
