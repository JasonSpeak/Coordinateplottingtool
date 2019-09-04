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
        private bool _isDragDropForPathTriangle;
        private bool _isDragDropForPathLine;
        private Point _pointOfMouseDown;

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

        public ICommand CreateHorizontalRulerListCommand { get; }

        public ICommand HorizontalSizeChangedCommand { get; }
        
        public ICommand CreateVerticalRulerListCommand { get; }

        public ICommand VerticalSizeChangedCommand { get; }

        public List<int> TempRulerList { get; set; }

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
            CreateHorizontalRulerListCommand = new RelayCommand<string>(OnCreateHorizontalRulerListExecuted);
            HorizontalSizeChangedCommand = new RelayCommand<string>(OnHorizontalSizeChangedCommandExecute);
            CreateVerticalRulerListCommand = new RelayCommand<string>(OnCreateVerticalRulerListExecuted);
            VerticalSizeChangedCommand = new RelayCommand<string>(OnVerticalSizeChangedCommandExecute);
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

        private void OnHorizontalSizeChangedCommandExecute(string canvasWidth)
        {
            if (!double.TryParse(canvasWidth, out var width)) return;
            TempRulerList = new List<int>();
            for (var i = 50; i < width; i += 50)
            {
                TempRulerList.Add(i);
            }
            RespectToWindow.RulerListOfHorizontal = TempRulerList;
        }

        private void OnCreateHorizontalRulerListExecuted(string canvasWidth)
        {
            Console.WriteLine(canvasWidth);
            if (!double.TryParse(canvasWidth, out var width)) return;
            TempRulerList = new List<int>();
            for (var i = 50; i < width; i += 50)
            {
                TempRulerList.Add(i);
            }
            RespectToWindow.RulerListOfHorizontal = TempRulerList;
        }

        private void OnVerticalSizeChangedCommandExecute(string canvasHeight)
        {
            if (!double.TryParse(canvasHeight, out var height)) return;
            TempRulerList = new List<int>();
            for (var i = 50; i < height; i += 50)
            {
                TempRulerList.Add(i);
            }

            RespectToWindow.RulerListOfVertical = TempRulerList;
        }

        private void OnCreateVerticalRulerListExecuted(string canvasHeight)
        {
            if (!double.TryParse(canvasHeight, out var height)) return;
            TempRulerList = new List<int>();
            for (var i = 50; i < height; i += 50)
            {
                TempRulerList.Add(i);
            }
            RespectToWindow.RulerListOfVertical = TempRulerList;
        }

        private void OnLeftMouseDownCommandExecuted(MouseEventArgs args)
        {
            if (!(args.Source is FrameworkElement element)) return;
            element.CaptureMouse();
            _pointOfMouseDown = args.GetPosition(null);
            switch (element.Name)
            {
                case "Triangle":
                    _isDragDropForPathTriangle = true;
                    break;
                case "Line":
                    _isDragDropForPathLine = true;
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
                    if (_isDragDropForPathTriangle)
                    {
                        _isDragDropForPathTriangle = false;
                    }
                    break;
                }
                case "Line":
                {
                    if (_isDragDropForPathLine)
                    {
                        _isDragDropForPathLine = false;
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
                    if (_isDragDropForPathTriangle)
                    {
                        TriangleCoordinate.TriangleMove(args.GetPosition(null),_pointOfMouseDown);
                        _pointOfMouseDown = args.GetPosition(null);
                    }
                    break;
                }
                case "Line":
                {
                    if (_isDragDropForPathLine)
                    {
                        LineCoordinate.LineMove(args.GetPosition(null),_pointOfMouseDown);
                        _pointOfMouseDown = args.GetPosition(null);
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
    }
}
