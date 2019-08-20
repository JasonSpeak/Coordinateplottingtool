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
using System.Windows.Data;

namespace PlotByCoordinate.ViewModel
{
    public class CoordinateValueViewModel:ViewModelBase 
    {
        #region 对象
        public CoordinateValueViewModel()
        {
            CoordinateValue = new CoordinateValueModel();
            CoordinateValue.CanSee = "Hidden";
            CoordinateValue.LineCanSee = "Hidden";
        }
        private CoordinateValueModel _coordinateValue;
        public CoordinateValueModel CoordinateValue
        {
            get { return _coordinateValue; }
            set { _coordinateValue = value; RaisePropertyChanged(() => CoordinateValue); }
        }
        #endregion


        #region 命令
        bool isDragDropInEffect = false;
        Point pos = new Point();
        private RelayCommand<MouseEventArgs> mouseButtonDownCommand;
        public RelayCommand<MouseEventArgs> MouseButtonDownCommand
        {
            get
            {

                if (mouseButtonDownCommand == null)
                    mouseButtonDownCommand = new RelayCommand<MouseEventArgs>(e => ExecuteMouseDown(e));
                return mouseButtonDownCommand;
            }
            set { mouseButtonDownCommand = value; }
        }
        private void ExecuteMouseDown(MouseEventArgs e)
        {
            FrameworkElement fEle = e.Source as FrameworkElement;
            isDragDropInEffect = true;
            fEle.CaptureMouse();
            fEle.Cursor = Cursors.Hand;
            pos = e.GetPosition(null);
        }
        private RelayCommand<MouseEventArgs> mouseLeftButtonUpCommand;
        public RelayCommand<MouseEventArgs> MouseLeftButtonUpCommand
        {
            get
            {
                if (mouseLeftButtonUpCommand == null)
                    mouseLeftButtonUpCommand = new RelayCommand<MouseEventArgs>(e => ExecuteMouseUp(e));
                return mouseLeftButtonUpCommand;
            }
            set { MouseLeftButtonUpCommand = value; }
        }
        private void ExecuteMouseUp(MouseEventArgs e)
        {
            if (isDragDropInEffect)
            {
                FrameworkElement ele = e.Source as FrameworkElement;            
                isDragDropInEffect = false;
                ele.ReleaseMouseCapture();

            }
        }
        private RelayCommand<MouseEventArgs> mouseMoveCommand;
        public RelayCommand<MouseEventArgs> MouseMoveCommand
        {
            get
            {

                if (mouseMoveCommand == null)
                    mouseMoveCommand = new RelayCommand<MouseEventArgs>(e => ExecutemouseMoveCommand(e));
                return mouseMoveCommand;
            }
            set { mouseMoveCommand = value; }
        }
        private void ExecutemouseMoveCommand(MouseEventArgs e)
        {
            if (isDragDropInEffect)
            {              
                double xPos = e.GetPosition(null).X - pos.X + (double)CoordinateValue.XPos;
                double yPos = e.GetPosition(null).Y - pos.Y + (double)CoordinateValue.YPos;
                CoordinateValue.XPos = xPos;
                CoordinateValue.YPos = yPos;
                pos = e.GetPosition(null);
            }
        }   
        private RelayCommand<MouseEventArgs> mouseButtonDownCommandLine;
        public RelayCommand<MouseEventArgs> MouseButtonDownCommandLine
        {
            get
            {

                if (mouseButtonDownCommandLine == null)
                    mouseButtonDownCommandLine = new RelayCommand<MouseEventArgs>(e => ExecuteMouseDownLine(e));
                return mouseButtonDownCommandLine;
            }
            set { mouseButtonDownCommandLine = value; }
        }
        private void ExecuteMouseDownLine(MouseEventArgs e)
        {
            FrameworkElement fEle = e.Source as FrameworkElement;
            isDragDropInEffect = true;
            fEle.CaptureMouse();
            fEle.Cursor = Cursors.Hand;
            pos = e.GetPosition(null);
        }
        private RelayCommand<MouseEventArgs> mouseLeftButtonUpCommandLine;
        public RelayCommand<MouseEventArgs> MouseLeftButtonUpCommandLine
        {
            get
            {
                if (mouseLeftButtonUpCommandLine == null)
                    mouseLeftButtonUpCommandLine = new RelayCommand<MouseEventArgs>(e => ExecuteMouseUpLine(e));
                return mouseLeftButtonUpCommandLine;
            }
            set { MouseLeftButtonUpCommandLine = value; }
        }
        private void ExecuteMouseUpLine(MouseEventArgs e)
        {
            if (isDragDropInEffect)
            {
                FrameworkElement ele = e.Source as FrameworkElement;
                isDragDropInEffect = false;
                ele.ReleaseMouseCapture();

            }
        }
        private RelayCommand<MouseEventArgs> mouseMoveCommandLine;
        public RelayCommand<MouseEventArgs> MouseMoveCommandLine
        {
            get
            {

                if (mouseMoveCommandLine == null)
                    mouseMoveCommandLine = new RelayCommand<MouseEventArgs>(e => ExecutemouseMoveCommandLine(e));
                return mouseMoveCommandLine;
            }
            set { mouseMoveCommandLine = value; }
        }
        private void ExecutemouseMoveCommandLine(MouseEventArgs e)
        {
            if (isDragDropInEffect)
            {
                double xPos = e.GetPosition(null).X - pos.X + (double)CoordinateValue.LineXPos;
                double yPos = e.GetPosition(null).Y - pos.Y + (double)CoordinateValue.LineYPos;
             

                CoordinateValue.LineXPos = xPos;
                CoordinateValue.LineYPos = yPos;
                pos = e.GetPosition(null);
            }
        }  
        private RelayCommand anglePaintCommand;
        public RelayCommand AnglePaintCommand
        {
            get
            {

                if (anglePaintCommand == null)
                    anglePaintCommand = new RelayCommand(() => ExecuteAngelPaintCommand());
                return anglePaintCommand;
            }
            set { anglePaintCommand = value; }
        }
        private void ExecuteAngelPaintCommand()
        {
            CoordinateValue.CanSee = "Visible";
            CoordinateValue.XPos = 0;
            CoordinateValue.YPos = 0;
        }
        private RelayCommand<RoutedEventArgs> linePaintCommand;
        public RelayCommand<RoutedEventArgs> LinePaintCommand
        {
            get
            {
                if (linePaintCommand == null)
                    linePaintCommand = new RelayCommand<RoutedEventArgs>((e) => ExecuteLinePaintCommand(e));
                return linePaintCommand;
            }
            set { linePaintCommand = value; }
        }
        private void ExecuteLinePaintCommand(RoutedEventArgs e)
        {
            FrameworkElement ele = e.Source as FrameworkElement;
            Console.WriteLine("{0}", ele);
            CoordinateValue.LineCanSee = "Visible";          
            CoordinateValue.LineXPos = 0;
            CoordinateValue.LineYPos = 0;
        }
        #endregion
    }
}
