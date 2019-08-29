using GalaSoft.MvvmLight;

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

        public RespectToWindowModel()
        {
            HiddenOrVisibleOfCoordinator = "Hidden";
            TheWindowState = "最大化";
            OptionForm = "F1M11,11L1,11 1,1 11,1z M11,0L1,0 0,0 0,1 0,11 0,12 1,12 11,12 12,12 12,11 12,1 12,0z";
        }
    }
}
