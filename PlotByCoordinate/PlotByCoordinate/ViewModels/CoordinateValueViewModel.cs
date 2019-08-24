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
        Point pointOfMouseDown = new Point();
        private bool isDragDropForPathline = false;
        private TriangleCoordModel triangleCoord;
        private LineCoordModel lineCoord;
        private InputLimitsModel inputLimits;
        public CoordinateValueViewModel()
        {
            InputLimits = new InputLimitsModel() { MaxX = 550, MaxY = 640 };
            TriangleCoord = new TriangleCoordModel();
            LineCoord = new LineCoordModel();         
            KeyDownCommand = new RelayCommand(OnKeyDownCommandExecuted);
            SizeChangedCommand = new RelayCommand<RoutedEventArgs>(OnSizeChangedCommandExecuted);
            MouseLeftButtonDownCommand = new RelayCommand<MouseEventArgs>(OnLeftMouseDownCommandExecuted);
            MouseLeftButtonUpCommand = new RelayCommand<MouseEventArgs>(OnLeftMouseUpCommandExecuted);
            MouseMoveCommand = new RelayCommand<MouseEventArgs>(OnMouseMoveCommandExecuted);
        }

        public InputLimitsModel InputLimits { get; }

        public TriangleCoordModel TriangleCoord{ get; }

        public LineCoordModel LineCoord{ get; }

        public RelayCommand KeyDownCommand { get; }

        public RelayCommand<RoutedEventArgs> SizeChangedCommand{ get;}

        public RelayCommand<MouseEventArgs> MouseLeftButtonDownCommand { get; }

        public RelayCommand<MouseEventArgs> MouseLeftButtonUpCommand { get; }

        public RelayCommand<MouseEventArgs> MouseMoveCommand { get; }

        private void OnKeyDownCommandExecuted()
        {
            TriangleCoord.TriangleXPos = 0;
            TriangleCoord.TriangleYPos = 0;
            LineCoord.LineXPos = 0;
            LineCoord.LineYPos = 0;     
            TriangleCoord.RaisePropertyChanged(()=>TriangleCoord.FirstPoint);
            TriangleCoord.RaisePropertyChanged(() => TriangleCoord.SecondPoint);
            TriangleCoord.RaisePropertyChanged(() => TriangleCoord.ThirdPoint);
            LineCoord.RaisePropertyChanged(() => LineCoord.StartPoint);
            LineCoord.RaisePropertyChanged(() => LineCoord.EndPoint);   
        }

        private void OnSizeChangedCommandExecuted(RoutedEventArgs args)
        {
            FrameworkElement ele = args.Source as FrameworkElement;
            
            if (ele.Name == "win")
            {
                InputLimits.MaxX = ele.Width / 5 * 4;
                InputLimits.MaxY = ele.Height / 12 * 11;
            }
        }

        private void OnLeftMouseDownCommandExecuted(MouseEventArgs args)
        {
            FrameworkElement ele = args.Source as FrameworkElement;
            ele.CaptureMouse();
            ele.Cursor = Cursors.Hand;
            pointOfMouseDown = args.GetPosition(null);
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
                    double xPos = args.GetPosition(null).X - pointOfMouseDown.X + (double)TriangleCoord.TriangleXPos;
                    double yPos = args.GetPosition(null).Y - pointOfMouseDown.Y + (double)TriangleCoord.TriangleYPos;
                    TriangleCoord.TriangleXPos = xPos;
                    TriangleCoord.TriangleYPos = yPos;                   
                    TriangleCoord.FirstPoint.X= TriangleCoord.FirstPoint.X + args.GetPosition(null).X - pointOfMouseDown.X;
                    TriangleCoord.FirstPoint.Y= TriangleCoord.FirstPoint.Y + args.GetPosition(null).Y - pointOfMouseDown.Y;
                    TriangleCoord.SecondPoint.X= TriangleCoord.SecondPoint.X+ args.GetPosition(null).X - pointOfMouseDown.X;
                    TriangleCoord.SecondPoint.Y= TriangleCoord.SecondPoint.Y + args.GetPosition(null).Y - pointOfMouseDown.Y;
                    TriangleCoord.ThirdPoint.X = TriangleCoord.ThirdPoint.X+ args.GetPosition(null).X - pointOfMouseDown.X;
                    TriangleCoord.ThirdPoint.Y=TriangleCoord.ThirdPoint.Y+ args.GetPosition(null).Y - pointOfMouseDown.Y;
                    TriangleCoord.RaisePropertyChanged(() => TriangleCoord.FirstPoint);
                    TriangleCoord.RaisePropertyChanged(() => TriangleCoord.SecondPoint);
                    TriangleCoord.RaisePropertyChanged(() => TriangleCoord.ThirdPoint);
                    pointOfMouseDown = args.GetPosition(null);
                }
            }
            if (ele.Name == "pathline")
            {
                if (isDragDropForPathline)
                {
                    double xPos = args.GetPosition(null).X - pointOfMouseDown.X + (double)LineCoord.LineXPos;
                    double yPos = args.GetPosition(null).Y - pointOfMouseDown.Y + (double)LineCoord.LineYPos;
                    LineCoord.LineXPos = xPos;
                    LineCoord.LineYPos = yPos;
                    LineCoord.StartPoint.X= LineCoord.StartPoint.X + args.GetPosition(null).X - pointOfMouseDown.X;
                    LineCoord.StartPoint.Y= LineCoord.StartPoint.Y + args.GetPosition(null).Y - pointOfMouseDown.Y;
                    LineCoord.EndPoint.X= LineCoord.EndPoint.X + args.GetPosition(null).X - pointOfMouseDown.X;
                    LineCoord.EndPoint.Y = LineCoord.EndPoint.Y+ args.GetPosition(null).Y - pointOfMouseDown.Y;
                    LineCoord.RaisePropertyChanged(() => LineCoord.StartPoint);
                    LineCoord.RaisePropertyChanged(() => LineCoord.EndPoint);
                    pointOfMouseDown = args.GetPosition(null);
                }

            }                 
        }       
        
    }
}
