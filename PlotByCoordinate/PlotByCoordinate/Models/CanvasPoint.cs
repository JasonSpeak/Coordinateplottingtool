using GalaSoft.MvvmLight;

namespace PlotByCoordinate.Models
{
    public class CanvasPoint:ObservableObject
    {
        private double? x;

        public double? X
        {
            get => x;
            set
            {
                x = value;
                RaisePropertyChanged(()=>X);
            }
        }

        public double? Y { get; set; }
    }
}
