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
            if (TriangleCoordinate.ThirdPoint.Y != null) TriangleCoordinate.HiddenOrVisibleOfTriangleImage = "Visible";
            if (LineCoordinate.EndPoint.Y != null) LineCoordinate.HiddenOrVisibleOfLineImage = "Visible";
            RespectToWindow.HiddenOrVisibleOfCoordinator = "Visible";
            LineCoordinate.RestorationPathOfLine();
            LineCoordinate.RaiseLinePointChange();
            TriangleCoordinate.RestorationPathOfTriangle();
            TriangleCoordinate.RaiseTrianglePointChange();
            
        }

        private void OnLeftMouseDownCommandExecuted(MouseEventArgs args)
        {
            var element = args.Source as FrameworkElement;
            if (element == null) return;
            element.CaptureMouse();
            pointOfMouseDown = args.GetPosition(null);
            switch (element.Name)
            {
                case "PathTriangle":
                    isDragDropForPathTriangle = true;
                    break;
                case "PathLine":
                    isDragDropForPathLine = true;
                    break;

            }
        }

        private void OnLeftMouseUpCommandExecuted(MouseEventArgs args)
        {
            var element = args.Source as FrameworkElement;
            if (element != null && element.Name == "PathTriangle")
            {
                if (isDragDropForPathTriangle)
                {
                    isDragDropForPathTriangle = false;
                    
                }
            }
            else if (element != null && element.Name == "PathLine")
            {
                if (isDragDropForPathLine)
                {
                    isDragDropForPathLine = false;
                   
                }
            }
            element?.ReleaseMouseCapture();
        }

        private void OnMouseMoveCommandExecuted(MouseEventArgs args)
        {
            if (!(args.Source is FrameworkElement element)) return;
            switch (element.Name)
            {
                case "PathTriangle":
                {
                    if (isDragDropForPathTriangle)
                    {
                        TriangleCoordinate.TriangleMove(args.GetPosition(null),pointOfMouseDown);
                        TriangleCoordinate.RaiseTrianglePointChange();
                        pointOfMouseDown = args.GetPosition(null);
                    }
                    break;
                }
                case "PathLine":
                {
                    if (isDragDropForPathLine)
                    {
                        LineCoordinate.LineMove(args.GetPosition(null),pointOfMouseDown);
                        LineCoordinate.RaiseLinePointChange();
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
            if (RespectToWindow.TheWindowState == "最大化")
            {
                RespectToWindow.OptionForm = "F1M11,8L9,8 9,4 9,3 8,3 4,3 4,1 11,1z M8,11L1,11 1,4 3,4 4,4 8,4 8,8 8,9z M11,0L4,0 3,0 3,1 3,3 1,3 0,3 0,4 0,11 0,12 1,12 8,12 9,12 9,11 9,9 11,9 12,9 12,8 12,1 12,0z";
                if (Application.Current.MainWindow != null)
                        Application.Current.MainWindow.WindowState = WindowState.Maximized;
                RespectToWindow.TheWindowState = "向下还原";
            }
            else if (RespectToWindow.TheWindowState == "向下还原")
            {
                RespectToWindow.OptionForm =
                    "F1M11,11L1,11 1,1 11,1z M11,0L1,0 0,0 0,1 0,11 0,12 1,12 11,12 12,12 12,11 12,1 12,0z";
                if (Application.Current.MainWindow != null)
                        Application.Current.MainWindow.WindowState = WindowState.Normal;
                RespectToWindow.TheWindowState = "最大化";
            }
        }

        private void OnCloseCommand()
        {
            if (Application.Current.MainWindow == null) return;
            Application.Current.MainWindow.Close();
        }
    }
}
