using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using PlotByCoordinate.Model;
using PlotByCoordinate.ViewModel;

namespace PlotByCoordinate.Converts
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {     
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);                  
            SimpleIoc.Default.Register<CoordinateValueViewModel>();
        } 
        public CoordinateValueViewModel Corrdinate
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CoordinateValueViewModel>();
            }
        }
        public static void Cleanup()
        {
        }
    }
}