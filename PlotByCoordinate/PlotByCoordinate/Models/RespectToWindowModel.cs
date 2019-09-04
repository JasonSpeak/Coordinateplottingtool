using GalaSoft.MvvmLight;
using System.Collections.Generic;

namespace PlotByCoordinate.Models
{
    public class RespectToWindowModel:ObservableObject
    {
        private string theWindowState;
        private List<int> rulerListOfHorizontal;
        private List<int> rulerListOfVertical;

        public string TheWindowState
        {
            get => theWindowState;
            set
            {
                theWindowState = value;
                RaisePropertyChanged(() => TheWindowState);
            }
        }

        public List<int> RulerListOfHorizontal
        {
            get => rulerListOfHorizontal;
            set
            {
                rulerListOfHorizontal = value;
                RaisePropertyChanged(()=>RulerListOfHorizontal);
            }
        }

        public List<int> RulerListOfVertical
        {
            get => rulerListOfVertical;
            set
            {
                rulerListOfVertical = value;
                RaisePropertyChanged(()=>RulerListOfVertical);
            }
        }

        public RespectToWindowModel()
        {
            TheWindowState = "最大化";
            RulerListOfHorizontal =new List<int>();
            RulerListOfVertical=new List<int>();
        }
    }
}
