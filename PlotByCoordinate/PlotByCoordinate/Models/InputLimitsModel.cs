using GalaSoft.MvvmLight;

namespace PlotByCoordinate.Models
{
    public class InputLimitsModel : ObservableObject
    {
        private double maxX;
        private double maxY;
        
        public double MaxX
        {
            get => maxX;
            set { maxX = value; RaisePropertyChanged(() => MaxX); }
        }

        public double MaxY
        {
            get => maxY;
            set { maxY = value; RaisePropertyChanged(() => MaxY); }
        }
    }
}
