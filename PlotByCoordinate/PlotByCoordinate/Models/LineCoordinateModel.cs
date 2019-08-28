using GalaSoft.MvvmLight;

namespace PlotByCoordinate.Models
{
    public class LineCoordinateModel : ObservableObject
    {
        private string hiddenOrVisibleOfLineImage;

        public string HiddenOrVisibleOfLineImage
        {
            get => hiddenOrVisibleOfLineImage;
            set { hiddenOrVisibleOfLineImage = value; RaisePropertyChanged(()=> HiddenOrVisibleOfLineImage); }
        }

        public CanvasPoint StartPoint { get; set; }

        public CanvasPoint EndPoint { get; set; }

        public double LineXPos { get; set; }

        public double LineYPos { get; set; }

        public LineCoordinateModel()
        {
            HiddenOrVisibleOfLineImage = "Hidden";
            StartPoint = new CanvasPoint();
            EndPoint = new CanvasPoint();
        }

   
    }   
}
