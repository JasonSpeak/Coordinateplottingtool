using GalaSoft.MvvmLight;

namespace PlotByCoordinate.Models
{
    public class LineCoordinateModel : ObservableObject
    {
        public LineCoordinateModel()
        {
            StartPoint = new CanvasPoint();
            EndPoint = new CanvasPoint();
        }

        public CanvasPoint StartPoint { get; set; }

        public CanvasPoint EndPoint { get; set; }

        public double LineXPos { get; set; }

        public double LineYPos { get; set; }
    }   
}
