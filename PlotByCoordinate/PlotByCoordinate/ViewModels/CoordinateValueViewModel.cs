using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using PlotByCoordinate.Models;
using System;
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
        private List<int> _rulerListOfHorizontal;
        private List<int> _rulerListOfVertical;

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

        public ICommand GetHorizontalRulerListCommand { get; }

        public ICommand GetVerticalRulerListCommand { get; }

        public List<int> RulerListOfHorizontal
        {
            get => _rulerListOfHorizontal;
            set
            {
                _rulerListOfHorizontal = value;
                RaisePropertyChanged(()=>RulerListOfHorizontal);
            }
        }

        public List<int> RulerListOfVertical
        {
            get => _rulerListOfVertical;
            set
            {
                _rulerListOfVertical = value;
                RaisePropertyChanged(()=>RulerListOfVertical);
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
            GetHorizontalRulerListCommand = new RelayCommand<string>(OnGetHorizontalRulerListExecuted);
            GetVerticalRulerListCommand = new RelayCommand<string>(OnGetVerticalRulerListExecuted);
        }

        private void OnKeyDownCommandExecuted()
        {
            if (LineCoordinate.LineEndPointY != null)
            {
                LineCoordinate.RestorationLine();
                LineCoordinate.AddPointToCollection();
            }
            if (TriangleCoordinate.TriangleThirdPointY == null) return;
            TriangleCoordinate.RestorationTriangle();
            TriangleCoordinate.AddPointToCollection();
        }

        private void OnGetHorizontalRulerListExecuted(string canvasWidth)
        {
            if (!double.TryParse(canvasWidth, out var width)) return;
            RulerListOfHorizontal = CreateIntList(width);
        }

        private void OnGetVerticalRulerListExecuted(string canvasHeight)
        {
            if (!double.TryParse(canvasHeight, out var height)) return;
            RulerListOfVertical = CreateIntList(height);
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

        private void OnMinWindowCommandExecute()
        {
            if (Application.Current.MainWindow == null) return;
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void OnCloseCommand()
        {
            if (Application.Current.MainWindow == null) return;
            Application.Current.MainWindow.Close();
        }

        private List<int> CreateIntList(double value)
        {
            var resultList = new List<int>();
            for (var i = 50; i < value; i += 50)
            {
                resultList.Add(i);
            }
            return resultList;
        }
    }
}
