﻿using System.Windows;
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
        private bool isDragDropForWindow;
        private Point pointOfMouseDown;


        public CoordinateValueViewModel()
        {
            InputLimits = new InputLimitsModel() { MaxX = 550, MaxY = 640};
            RespectToWindow=new RespectToWindowModel(){ TheWindowState = "最大化" , OptionForm = "F1M11,11L1,11 1,1 11,1z M11,0L1,0 0,0 0,1 0,11 0,12 1,12 11,12 12,12 12,11 12,1 12,0z"};
            TriangleCoordinate = new TriangleCoordinateModel();
            LineCoordinate = new LineCoordinateModel();         
            KeyDownCommand = new RelayCommand(OnKeyDownCommandExecuted);
            SizeChangedCommand = new RelayCommand<RoutedEventArgs>(OnSizeChangedCommandExecuted);
            MouseLeftButtonDownCommand = new RelayCommand<MouseEventArgs>(OnLeftMouseDownCommandExecuted);
            MouseLeftButtonUpCommand = new RelayCommand<MouseEventArgs>(OnLeftMouseUpCommandExecuted);
            MouseMoveCommand = new RelayCommand<MouseEventArgs>(OnMouseMoveCommandExecuted);
            MinWindowCommand = new RelayCommand<Window>(OnMinWindowCommandExecute);
            MaximizeOrRestoreCommand=new RelayCommand<Window>(OnMaximizeOrRestoreCommandExecute);
            CloseCommand=new RelayCommand<Window>(OnCloseCommand);
        }

        public RespectToWindowModel RespectToWindow { get; }

        public InputLimitsModel InputLimits { get; }

        public TriangleCoordinateModel TriangleCoordinate{ get; }

        public LineCoordinateModel LineCoordinate{ get; }

        public RelayCommand KeyDownCommand { get; }

        public RelayCommand<RoutedEventArgs> SizeChangedCommand{ get;}

        public RelayCommand<MouseEventArgs> MouseLeftButtonDownCommand { get; }

        public RelayCommand<MouseEventArgs> MouseLeftButtonUpCommand { get; }

        public RelayCommand<MouseEventArgs> MouseMoveCommand { get; }

        public RelayCommand<Window> MinWindowCommand { get;  }

        public RelayCommand<Window> MaximizeOrRestoreCommand { get; }

        public RelayCommand<Window> CloseCommand { get; }

        private void OnKeyDownCommandExecuted()
        {
            TriangleCoordinate.TriangleXPos = 0;
            TriangleCoordinate.TriangleYPos = 0;
            LineCoordinate.LineXPos = 0;
            LineCoordinate.LineYPos = 0;
            TriangleCoordinate.RaisePropertyChanged(()=>TriangleCoordinate.FirstPoint);
            TriangleCoordinate.RaisePropertyChanged(() => TriangleCoordinate.SecondPoint);
            TriangleCoordinate.RaisePropertyChanged(() => TriangleCoordinate.ThirdPoint);
            LineCoordinate.RaisePropertyChanged(() => LineCoordinate.StartPoint);
            LineCoordinate.RaisePropertyChanged(() => LineCoordinate.EndPoint);   
        }

        private void OnSizeChangedCommandExecuted(RoutedEventArgs args)
        {
            if (!(args.Source is FrameworkElement ele)) return;
            InputLimits.MaxX = ele.Width / 5 * 4;
            InputLimits.MaxY = ele.Height / 12 * 11;
        }

        private void OnLeftMouseDownCommandExecuted(MouseEventArgs args)
        {
            var ele = args.Source as FrameworkElement;
            if (ele == null) return;
            ele.CaptureMouse();
            pointOfMouseDown = args.GetPosition(null);
            switch (ele.Name)
            {
                case "PathTriangle":
                    isDragDropForPathTriangle = true;
                    break;
                case "PathLine":
                    isDragDropForPathLine = true;
                    break;
                case "Win":
                    isDragDropForWindow = true;
                    break;
            }
        }

        private void OnLeftMouseUpCommandExecuted(MouseEventArgs args)
        {

            var ele = args.Source as FrameworkElement;
            if (ele != null && ele.Name == "PathTriangle")
            {
                if (isDragDropForPathTriangle)
                {
                    isDragDropForPathTriangle = false;
                    ele.ReleaseMouseCapture();
                }
            }
            if (ele != null && ele.Name == "PathLine")
            {
                if (isDragDropForPathLine)
                {
                    isDragDropForPathLine = false;
                    ele.ReleaseMouseCapture();
                }

            }
            if (ele != null && ele.Name == "Win")
            {
                if (isDragDropForPathLine)
                {
                    isDragDropForWindow = false;
                    ele.ReleaseMouseCapture();
                }

            }
        }

        private void OnMouseMoveCommandExecuted(MouseEventArgs args)
        {
            var ele = args.Source as FrameworkElement;
            if (ele == null) return;
            switch (ele.Name)
            {
                case "PathTriangle":
                {
                    if (isDragDropForPathTriangle)
                    {
                        var xPos = args.GetPosition(null).X - pointOfMouseDown.X +
                                      TriangleCoordinate.TriangleXPos;
                        var yPos = args.GetPosition(null).Y - pointOfMouseDown.Y +
                                      TriangleCoordinate.TriangleYPos;
                        TriangleCoordinate.TriangleXPos = xPos;
                        TriangleCoordinate.TriangleYPos = yPos;
                        TriangleCoordinate.FirstPoint.X =
                            TriangleCoordinate.FirstPoint.X + args.GetPosition(null).X - pointOfMouseDown.X;
                        TriangleCoordinate.FirstPoint.Y =
                            TriangleCoordinate.FirstPoint.Y + args.GetPosition(null).Y - pointOfMouseDown.Y;
                        TriangleCoordinate.SecondPoint.X =
                            TriangleCoordinate.SecondPoint.X + args.GetPosition(null).X - pointOfMouseDown.X;
                        TriangleCoordinate.SecondPoint.Y =
                            TriangleCoordinate.SecondPoint.Y + args.GetPosition(null).Y - pointOfMouseDown.Y;
                        TriangleCoordinate.ThirdPoint.X =
                            TriangleCoordinate.ThirdPoint.X + args.GetPosition(null).X - pointOfMouseDown.X;
                        TriangleCoordinate.ThirdPoint.Y =
                            TriangleCoordinate.ThirdPoint.Y + args.GetPosition(null).Y - pointOfMouseDown.Y;
                        TriangleCoordinate.RaisePropertyChanged(() => TriangleCoordinate.FirstPoint);
                        TriangleCoordinate.RaisePropertyChanged(() => TriangleCoordinate.SecondPoint);
                        TriangleCoordinate.RaisePropertyChanged(() => TriangleCoordinate.ThirdPoint);
                        pointOfMouseDown = args.GetPosition(null);
                    }
                    break;
                }
                case "PathLine":
                {
                    if (isDragDropForPathLine)
                    {
                        var xPos = args.GetPosition(null).X - pointOfMouseDown.X + LineCoordinate.LineXPos;
                        var yPos = args.GetPosition(null).Y - pointOfMouseDown.Y + LineCoordinate.LineYPos;
                        LineCoordinate.LineXPos = xPos;
                        LineCoordinate.LineYPos = yPos;
                        LineCoordinate.StartPoint.X =
                            LineCoordinate.StartPoint.X + args.GetPosition(null).X - pointOfMouseDown.X;
                        LineCoordinate.StartPoint.Y =
                            LineCoordinate.StartPoint.Y + args.GetPosition(null).Y - pointOfMouseDown.Y;
                        LineCoordinate.EndPoint.X = LineCoordinate.EndPoint.X + args.GetPosition(null).X - pointOfMouseDown.X;
                        LineCoordinate.EndPoint.Y = LineCoordinate.EndPoint.Y + args.GetPosition(null).Y - pointOfMouseDown.Y;
                        LineCoordinate.RaisePropertyChanged(() => LineCoordinate.StartPoint);
                        LineCoordinate.RaisePropertyChanged(() => LineCoordinate.EndPoint);
                        pointOfMouseDown = args.GetPosition(null);
                    }
                    break;
                }
            }
        }

        private void OnMinWindowCommandExecute(Window args)
        {
            args.WindowState = WindowState.Minimized;
        }

        private void OnMaximizeOrRestoreCommandExecute(Window args)
        {
            if (RespectToWindow.TheWindowState == "最大化")
            {
                RespectToWindow.OptionForm = "F1M11,8L9,8 9,4 9,3 8,3 4,3 4,1 11,1z M8,11L1,11 1,4 3,4 4,4 8,4 8,8 8,9z M11,0L4,0 3,0 3,1 3,3 1,3 0,3 0,4 0,11 0,12 1,12 8,12 9,12 9,11 9,9 11,9 12,9 12,8 12,1 12,0z";
                args.WindowState = WindowState.Maximized;
                RespectToWindow.TheWindowState = "向下还原";
            }
            else if (RespectToWindow.TheWindowState == "向下还原")
            {
                RespectToWindow.OptionForm =
                    "F1M11,11L1,11 1,1 11,1z M11,0L1,0 0,0 0,1 0,11 0,12 1,12 11,12 12,12 12,11 12,1 12,0z";
                args.WindowState = WindowState.Normal;
                RespectToWindow.TheWindowState = "最大化";
            }
        }

        private void OnCloseCommand(Window args)
        {
            args.Close();
        }
    }
}
