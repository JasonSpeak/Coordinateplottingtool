using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlotByCoordinate.Model;
using GalaSoft.MvvmLight.Command;
using System.Windows.Media.Animation;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;

namespace PlotByCoordinate.ViewModel
{
    public class CoordinateValueViewModel:ViewModelBase 
    {

        public CoordinateValueViewModel()
        {
            CoordinateValue = new CoordinateValueModel();      
        }

        private CoordinateValueModel _coordinateValue;

        public CoordinateValueModel CoordinateValue
        {
            get { return _coordinateValue; }
            set { _coordinateValue = value; RaisePropertyChanged(() => CoordinateValue); }
        }
        private ICommand mouseButtonDownCommand;

        public ICommand MouseButtonDownCommand
        {
            get
            {
                return new DelegateCommand<>(win=>win+=(sender,e)=> 
                {
                    MessageBox.Show("aaa");
                });
            }
            set { mouseButtonDownCommand = value; }
        }


        private RelayCommand mouseLeftButtonUp;

        public RelayCommand MouseLeftButtonUp
        {
            get
            {

                if (mouseLeftButtonUp == null)
                    mouseLeftButtonUp = new RelayCommand(() => ExecuteMouseUp());
                return mouseLeftButtonUp;
            }
            set { mouseLeftButtonUp = value; }
        }
        private void ExecuteMouseUp()
        {
           
        }
        private RelayCommand mouseMoveCommand;

        public RelayCommand MouseMoveCommand
        {
            get
            {

                if (mouseMoveCommand == null)
                    mouseMoveCommand = new RelayCommand(() => ExecutemouseMoveCommand());
                return mouseMoveCommand;
            }
            set { mouseMoveCommand = value; }
        }

        private void ExecutemouseMoveCommand()
        {
           // MessageBox.Show("cccc");
        }
    }
}
