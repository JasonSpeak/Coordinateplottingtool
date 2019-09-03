
using System.Collections.Generic;
using System.Windows.Documents;
using GalaSoft.MvvmLight;

namespace PlotByCoordinate.Models
{
    public class RespectToWindowModel:ObservableObject
    {
        private string theWindowState;


        public string TheWindowState
        {
            get => theWindowState;
            set { theWindowState = value; RaisePropertyChanged(() => TheWindowState); }
        }
        

        public RespectToWindowModel()
        {
            TheWindowState = "最大化";
        }
    }
}
