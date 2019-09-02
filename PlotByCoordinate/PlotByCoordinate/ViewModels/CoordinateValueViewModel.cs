using System;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PlotByCoordinate.Models;

namespace PlotByCoordinate.ViewModels
{
    public class CoordinateValueViewModel : ViewModelBase
    {
        private bool isDragDropForPathTriangle;
        private bool isDragDropForPathLine;
        private Point pointOfMouseDown;


        public RespectToWindowModel RespectToWindow { get; }

        public TriangleCoordinateModel TriangleCoordinate { get; }

        public LineCoordinateModel LineCoordinate { get; }

        public RelayCommand KeyDownCommand { get; }

        public RelayCommand<MouseEventArgs> MouseLeftButtonDownCommand { get; }

        public RelayCommand<MouseEventArgs> MouseLeftButtonUpCommand { get; }

        public RelayCommand<MouseEventArgs> MouseMoveCommand { get; }

        public RelayCommand MinWindowCommand { get; }

        public RelayCommand MaximizeOrRestoreCommand { get; }

        public RelayCommand CloseCommand { get; }

        public CoordinateValueViewModel()
        {
            RespectToWindow=new RespectToWindowModel();
            TriangleCoordinate = new TriangleCoordinateModel();
            LineCoordinate = new LineCoordinateModel();
            KeyDownCommand = new RelayCommand(OnKeyDownCommandExecuted);
            MouseLeftButtonDownCommand = new RelayCommand<MouseEventArgs>(OnLeftMouseDownCommandExecuted);
            MouseLeftButtonUpCommand = new RelayCommand<MouseEventArgs>(OnLeftMouseUpCommandExecuted);
            MouseMoveCommand = new RelayCommand<MouseEventArgs>(OnMouseMoveCommandExecuted);
            MinWindowCommand = new RelayCommand(OnMinWindowCommandExecute);
            MaximizeOrRestoreCommand=new RelayCommand(OnMaximizeOrRestoreCommandExecute);
            CloseCommand=new RelayCommand(OnCloseCommand);
        }

        private void OnKeyDownCommandExecuted()
        {
            LineCoordinate.RestorationPathOfLine();
            LineCoordinate.RaiseLinePointChange();
          
            TriangleCoordinate.RestorationPathOfTriangle();
            TriangleCoordinate.RaiseTrianglePointChange();
        }

        private void OnLeftMouseDownCommandExecuted(MouseEventArgs args)
        {
            if (!(args.Source is FrameworkElement element)) return;
            element.CaptureMouse();
            pointOfMouseDown = args.GetPosition(null);
            switch (element.Name)
            {
                case "Triangle":
                    isDragDropForPathTriangle = true;
                    break;
                case "Line":
                    isDragDropForPathLine = true;
                    break;
            }
        }

        private void OnLeftMouseUpCommandExecuted(MouseEventArgs args)
        {
            if (!(args.Source is FrameworkElement element))return;
            switch (element.Name)
            {
                case "Triangle":
                {
                    if (isDragDropForPathTriangle)
                    {
                        isDragDropForPathTriangle = false;
                    }
                    break;
                }
                case "Line":
                {
                    if (isDragDropForPathLine)
                    {
                        isDragDropForPathLine = false;
                    }
                    break;
                }
            }
            element.ReleaseMouseCapture();
        }                   

        private void OnMouseMoveCommandExecuted(MouseEventArgs args)
        {
            if (!(args.Source is FrameworkElement element)) return;
            switch (element.Name)
            {
                case "Triangle":
                {
                    if (isDragDropForPathTriangle)
                    {
                        TriangleCoordinate.TriangleMove(args.GetPosition(null),pointOfMouseDown);
                        pointOfMouseDown = args.GetPosition(null);
                    }
                    break;
                }
                case "Line":
                {
                    if (isDragDropForPathLine)
                    {
                        LineCoordinate.LineMove(args.GetPosition(null),pointOfMouseDown);
                        pointOfMouseDown = args.GetPosition(null);
                    }
                    break;
                }
            }
        }

        private void OnMinWindowCommandExecute()
        {
            if (Application.Current.MainWindow == null) return;
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void OnMaximizeOrRestoreCommandExecute()
        {
            if (Application.Current.MainWindow == null) return;
            switch (RespectToWindow.TheWindowState)
            {
                case "最大化":
                    Application.Current.MainWindow.WindowState = WindowState.Maximized;
                    RespectToWindow.TheWindowState = "向下还原";
                    break;
                case "向下还原":
                    Application.Current.MainWindow.WindowState = WindowState.Normal;
                    RespectToWindow.TheWindowState = "最大化";
                    break;
            }
        }

        private void OnCloseCommand()
        {
            if (Application.Current.MainWindow == null) return;
            Application.Current.MainWindow.Close();
        }
    }
}
