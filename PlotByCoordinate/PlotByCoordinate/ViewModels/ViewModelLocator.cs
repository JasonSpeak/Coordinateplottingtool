using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace PlotByCoordinate.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {     
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);                  
            SimpleIoc.Default.Register<CoordinateValueViewModel>();
        } 
        public CoordinateValueViewModel Coordinate => ServiceLocator.Current.GetInstance<CoordinateValueViewModel>();

        public static void Cleanup() {}

    }
}