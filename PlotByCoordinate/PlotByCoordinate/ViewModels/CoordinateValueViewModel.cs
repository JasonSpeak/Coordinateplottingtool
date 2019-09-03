using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using PlotByCoordinate.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using RelayCommand = GalaSoft.MvvmLight.Command.RelayCommand;
namespace PlotByCoordinate.ViewModels
{
    public class CoordinateValueViewModel : ViewModelBase
    {
        private bool isDragDropForPathTriangle;
        private bool isDragDropForPathLine;
        private Point pointOfMouseDown;
        private List<int> _rulerList;
        private List<int> _tempRulerList;
        private List<int> _rulerListForHeight;
        private List<int> _tempRulerListForHeight;
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

        public ICommand CreateRulerListCommand { get; }

        public ICommand SizeChangedCommand { get; }
       

        public ICommand CreateRulerListForHeightCommand { get; }

        public ICommand SizeChangedForHeightCommand { get; }

        public List<int> RulerList
        {
            get => _rulerList;
            set
            {
                _rulerList = value;
                RaisePropertyChanged(() => RulerList);
            }
        }
        public List<int> TempRulerList
        {
            get => _tempRulerList;
            set
            {
                _tempRulerList = value;
                RaisePropertyChanged(() => TempRulerList);
            }
        }
        public List<int> RulerListForHeight
        {
            get => _rulerListForHeight;
            set
            {
                _rulerListForHeight = value;
                RaisePropertyChanged(() => RulerListForHeight);
            }
        }
        public List<int> TempRulerListForHeight
        {
            get => _tempRulerListForHeight;
            set
            {
                _tempRulerListForHeight = value;
                RaisePropertyChanged(() => TempRulerListForHeight);
            }
        }

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
            CreateRulerListCommand = new RelayCommand<string>(OnCreateRulerListExecuted);
            SizeChangedCommand = new RelayCommand<string>(OnSizeChangedCommandExecute);
            CreateRulerListForHeightCommand = new RelayCommand<string>(OnCreateRulerListForHeightExecuted);
            SizeChangedForHeightCommand = new RelayCommand<string>(OnSizeChangedCommandForHeightExecute);
            RulerList=new List<int>();
            RulerListForHeight=new List<int>();
        }

        private void OnSizeChangedCommandExecute(string canvasWidth)
        {
      

            if (double.TryParse(canvasWidth, out var width))
            {
                TempRulerList = new List<int>();
                for (int i = 50; i < width; i += 50)
                {
                    TempRulerList.Add(i);
                }

                RulerList = TempRulerList;
            }
        }
        private void OnCreateRulerListExecuted(string canvasWidth)
        {
     
            if (double.TryParse(canvasWidth, out var width))
            {
               
                TempRulerList = new List<int>();
                for (int i = 50; i < width; i += 50)
                {
                    TempRulerList.Add(i);
                }

                RulerList = TempRulerList;
            }
        }
        private void OnSizeChangedCommandForHeightExecute(string canvasWidth)
        {


            if (double.TryParse(canvasWidth, out var width))
            {
                TempRulerListForHeight = new List<int>();
                for (int i = 50; i < width-100; i += 50)
                {
                    TempRulerListForHeight.Add(i);
                }

                RulerListForHeight = TempRulerListForHeight;
            }
        }
        private void OnCreateRulerListForHeightExecuted(string canvasWidth)
        {

            if (double.TryParse(canvasWidth, out var width))
            {

                TempRulerListForHeight = new List<int>();
                for (int i = 50; i < width-100; i += 50)
                {
                    TempRulerListForHeight.Add(i);
                }

                RulerListForHeight = TempRulerListForHeight;
            }
        }
        private void OnKeyDownCommandExecuted()
        {
            if (LineCoordinate.LineEndPointY != null)
            {
                LineCoordinate.RestorationPathOfLine();
                LineCoordinate.RaiseLinePointChange();
            }
            if (TriangleCoordinate.TriangleThirdPointY != null)
            {
                TriangleCoordinate.RestorationPathOfTriangle();
                TriangleCoordinate.RaiseTrianglePointChange();
            }
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
