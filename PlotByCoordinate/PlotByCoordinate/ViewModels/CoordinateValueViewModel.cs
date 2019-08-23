using GalaSoft.MvvmLight;
using PlotByCoordinate.Model;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;
using PlotByCoordinate.Models;
using System;

namespace PlotByCoordinate.ViewModel
{
    public class CoordinateValueViewModel : ViewModelBase
    {
        private bool isDragDropForPathangle = false;
        private bool isDragDropForPathline = false;
        private CoordinateValueModel _coordinateValue;
        private TriangleCoordModel _triangleCoord;
        private LineCoordModel _lineCoord;

        Point pos = new Point();
        Point[] points = { new Point(0, 0), new Point(0, 0), new Point(0, 0), new Point(0, 0), new Point(0, 0) };
        
        public CoordinateValueViewModel()
        {
            CoordinateValue = new CoordinateValueModel() { MaxX = 550, MaxY = 640 };
            TriangleCoord = new TriangleCoordModel();
            LineCoord = new LineCoordModel();
            KeyDownCommand = new RelayCommand(OnKeyDownCommandExecuted);
            SizeChangedCommand = new RelayCommand<RoutedEventArgs>(OnSizeChangedCommandExecuted);
            MouseLeftButtonDownCommand = new RelayCommand<MouseEventArgs>(OnLeftMouseDownCommandExecuted);
            MouseLeftButtonUpCommand = new RelayCommand<MouseEventArgs>(OnLeftMouseUpCommandExecuted);
            MouseMoveCommand = new RelayCommand<MouseEventArgs>(OnMouseMoveCommandExecuted);
        }

        public CoordinateValueModel CoordinateValue
        {
            get { return _coordinateValue; }
            set { _coordinateValue = value; RaisePropertyChanged(() => CoordinateValue); }
        }

        public TriangleCoordModel TriangleCoord
        {
            get { return _triangleCoord; }
            set { _triangleCoord = value; RaisePropertyChanged(() => CoordinateValue); }
        }
        
        public LineCoordModel LineCoord
        {
            get { return _lineCoord; }
            set { _lineCoord = value; RaisePropertyChanged(() => LineCoord); }
        }

        public RelayCommand KeyDownCommand { get; }

        public RelayCommand<RoutedEventArgs> SizeChangedCommand{ get;}

        public RelayCommand<MouseEventArgs> MouseLeftButtonDownCommand { get; }

        public RelayCommand<MouseEventArgs> MouseLeftButtonUpCommand { get; }

        public RelayCommand<MouseEventArgs> MouseMoveCommand { get; }

        private void OnKeyDownCommandExecuted()
        {          
            CoordinateValue.TriangleXPos = 0;
            CoordinateValue.TriangleYPos = 0;
            CoordinateValue.LineXPos = 0;
            CoordinateValue.LineYPos = 0;
            points[0].X = CoordinateValue.TriangleX1;
            points[0].Y = CoordinateValue.TriangleY1;
            points[1].X = CoordinateValue.TriangleX2;
            points[1].Y = CoordinateValue.TriangleY2;
            points[2].X = CoordinateValue.TriangleX3;
            points[2].Y = CoordinateValue.TriangleY3;
            points[3].X = CoordinateValue.LineX1;
            points[3].Y = CoordinateValue.LineY1;
            points[4].X = CoordinateValue.LineX2;
            points[4].Y = CoordinateValue.LineY2;
            CoordinateValue.Points = points;           
        }

        private void OnSizeChangedCommandExecuted(RoutedEventArgs args)
        {

            FrameworkElement ele = args.Source as FrameworkElement;
            if (ele.Name == "win")
            {
                CoordinateValue.MaxX = (ele.Width) / 5 * 4;
                CoordinateValue.MaxY = (ele.Height) / 12 * 11;
            }
        }

        private void OnLeftMouseDownCommandExecuted(MouseEventArgs args)
        {
            FrameworkElement ele = args.Source as FrameworkElement;
            ele.CaptureMouse();
            ele.Cursor = Cursors.Hand;
            pos = args.GetPosition(null);
            if (ele.Name == "pathangle")
            {
                isDragDropForPathangle = true;
            }
            if (ele.Name == "pathline")
            {
                isDragDropForPathline = true;
            }
        }

        private void OnLeftMouseUpCommandExecuted(MouseEventArgs args)
        {

            FrameworkElement ele = args.Source as FrameworkElement;
            if (ele.Name == "pathangle")
            {
                if (isDragDropForPathangle)
                {
                    isDragDropForPathangle = false;
                    ele.ReleaseMouseCapture();
                }
            }
            if (ele.Name == "pathline")
            {
                if (isDragDropForPathline)
                {
                    isDragDropForPathline = false;
                    ele.ReleaseMouseCapture();
                    Console.WriteLine("{0}", TriangleCoord.FirstPoint.X);
                }

            }
        }

        private void OnMouseMoveCommandExecuted(MouseEventArgs args)
        {
           
            FrameworkElement ele = args.Source as FrameworkElement;
            if (ele.Name == "pathangle")
            {
                if (isDragDropForPathangle)
                {
                    double xPos = args.GetPosition(null).X - pos.X + (double)CoordinateValue.TriangleXPos;
                    double yPos = args.GetPosition(null).Y - pos.Y + (double)CoordinateValue.TriangleYPos;
                    CoordinateValue.TriangleXPos = xPos;
                    CoordinateValue.TriangleYPos = yPos;                             
                    CoordinateValue.TriangleX1 = CoordinateValue.TriangleX1 + args.GetPosition(null).X - pos.X;
                    CoordinateValue.TriangleY1 = CoordinateValue.TriangleY1 + args.GetPosition(null).Y - pos.Y;
                    CoordinateValue.TriangleX2 = CoordinateValue.TriangleX2 + args.GetPosition(null).X - pos.X;
                    CoordinateValue.TriangleY2 = CoordinateValue.TriangleY2 + args.GetPosition(null).Y - pos.Y;
                    CoordinateValue.TriangleX3 = CoordinateValue.TriangleX3 + args.GetPosition(null).X - pos.X;
                    CoordinateValue.TriangleY3 = CoordinateValue.TriangleY3 + args.GetPosition(null).Y - pos.Y;
                    pos = args.GetPosition(null);
                }
            }
            if (ele.Name == "pathline")
            {
                if (isDragDropForPathline)
                {
                    double xPos = args.GetPosition(null).X - pos.X + (double)CoordinateValue.LineXPos;
                    double yPos = args.GetPosition(null).Y - pos.Y + (double)CoordinateValue.LineYPos;
                    CoordinateValue.LineXPos = xPos;
                    CoordinateValue.LineYPos = yPos;
                    CoordinateValue.LineX1 = CoordinateValue.LineX1 + args.GetPosition(null).X - pos.X;
                    CoordinateValue.LineY1 = CoordinateValue.LineY1 + args.GetPosition(null).Y - pos.Y;
                    CoordinateValue.LineX2 = CoordinateValue.LineX2 + args.GetPosition(null).X - pos.X;
                    CoordinateValue.LineY2 = CoordinateValue.LineY2 + args.GetPosition(null).Y - pos.Y;
                    pos = args.GetPosition(null);
                }

            }                 
        }       
        
    }
}
