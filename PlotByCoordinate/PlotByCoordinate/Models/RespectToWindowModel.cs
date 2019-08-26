using GalaSoft.MvvmLight;

namespace PlotByCoordinate.Models
{
    public class RespectToWindowModel:ObservableObject
    {
        private string theWindowState;
        private string optionForm;
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
    }
}
