using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using PlotByCoordinate.Model;

namespace PlotByCoordinate.ViewModel
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            #region 默认时所注册的窗体
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
            }
            else
            {
                SimpleIoc.Default.Register<IDataService, DataService>();
            }
            #endregion

            #region 注册窗体
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<CoordinateValueViewModel>();
            #endregion
        }

        #region 特性
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        #endregion

        #region 返回Datacontext属性
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public CoordinateValueViewModel Corrdinate
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CoordinateValueViewModel>();
            }
        }
        #endregion

        #region 清空资源
        public static void Cleanup()
        {
        }
        #endregion
    }
}