using System.Globalization;
using GalaSoft.MvvmLight;
using PlotByCoordinate.Converts;

namespace PlotByCoordinate.Models
{
    public class RespectToWindowModel:ObservableObject
    {
        private string theWindowState;
        private string optionForm;
        private string hiddenOrVisibleOfCoordinator;

        public string TheWindowState
        {
            get => theWindowState;
            set { theWindowState = value; RaisePropertyChanged(() => TheWindowState); }
        }

        public string OptionForm
        {
            get => optionForm;
            set { optionForm = value; RaisePropertyChanged(()=>OptionForm);}
        }

        public string HiddenOrVisibleOfCoordinator
        {
            get => hiddenOrVisibleOfCoordinator;
            set { hiddenOrVisibleOfCoordinator = value; RaisePropertyChanged(() => HiddenOrVisibleOfCoordinator); }
        }

        public void ShowCoordinate()
        {
            HiddenOrVisibleOfCoordinator = "Visible";
        }

        public RespectToWindowModel()
        {
            HiddenOrVisibleOfCoordinator = "Hidden";
            TheWindowState = "最大化";
        }
    }
}
