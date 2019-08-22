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
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Controls;
namespace PlotByCoordinate.ViewModel
{
    public class CoordinateValueViewModel:ViewModelBase 
    {       
        private bool isDragDropForPathangle = false;
        private bool isDragDropForPathline = false;
        private CoordinateValueModel _coordinateValue;
        Point pos = new Point();
        Point[] points = { new Point(0, 0), new Point(0, 0), new Point(0, 0), new Point(0, 0), new Point(0, 0) };

        public CoordinateValueViewModel()
        {
            MouseLeftButtonDownCommand = new RelayCommand<MouseEventArgs>(OnLeftMouseDownCommandExecuted);
            CoordinateValue = new CoordinateValueModel() {MaxX =550,MaxY=640};
        }
        
        public CoordinateValueModel CoordinateValue
        {
            get { return _coordinateValue; }
            set { _coordinateValue = value; RaisePropertyChanged(() => CoordinateValue); }
        }
        
        public RelayCommand<MouseEventArgs> MouseLeftButtonDownCommand { get; }

        private RelayCommand<MouseEventArgs> mouseMoveCommand;
        public RelayCommand<MouseEventArgs> MouseMoveCommand
        {
            get
            {
                if (mouseMoveCommand == null)
                    mouseMoveCommand = new RelayCommand<MouseEventArgs>
                    (
                        (e) =>
                        {
                            FrameworkElement ele = e.Source as FrameworkElement;
                            if (ele.Name == "pathangle")
                            {
                                if (isDragDropForPathangle)
                                {
                                    double xPos = e.GetPosition(null).X - pos.X + (double)CoordinateValue.TriangleXPos;
                                    double yPos = e.GetPosition(null).Y - pos.Y + (double)CoordinateValue.TriangleYPos;
                                    CoordinateValue.TriangleXPos = xPos;
                                    CoordinateValue.TriangleYPos = yPos;                             
                                    CoordinateValue.TriangleX1 = CoordinateValue.TriangleX1 + e.GetPosition(null).X - pos.X;
                                    CoordinateValue.TriangleY1 = CoordinateValue.TriangleY1 + e.GetPosition(null).Y - pos.Y;
                                    CoordinateValue.TriangleX2 = CoordinateValue.TriangleX2 + e.GetPosition(null).X - pos.X;
                                    CoordinateValue.TriangleY2 = CoordinateValue.TriangleY2 + e.GetPosition(null).Y - pos.Y;
                                    CoordinateValue.TriangleX3 = CoordinateValue.TriangleX3 + e.GetPosition(null).X - pos.X;
                                    CoordinateValue.TriangleY3 = CoordinateValue.TriangleY3 + e.GetPosition(null).Y - pos.Y;
                                    pos = e.GetPosition(null);
                                }
                            }
                            if (ele.Name == "pathline")
                            {
                                if (isDragDropForPathline)
                                {
                                    double xPos = e.GetPosition(null).X - pos.X + (double)CoordinateValue.LineXPos;
                                    double yPos = e.GetPosition(null).Y - pos.Y + (double)CoordinateValue.LineYPos;
                                    CoordinateValue.LineXPos = xPos;
                                    CoordinateValue.LineYPos = yPos;
                                    CoordinateValue.LineX1 = CoordinateValue.LineX1 + e.GetPosition(null).X - pos.X;
                                    CoordinateValue.LineY1 = CoordinateValue.LineY1 + e.GetPosition(null).Y - pos.Y;
                                    CoordinateValue.LineX2 = CoordinateValue.LineX2 + e.GetPosition(null).X - pos.X;
                                    CoordinateValue.LineY2 = CoordinateValue.LineY2 + e.GetPosition(null).Y - pos.Y;
                                    pos = e.GetPosition(null);
                                }

                            }
                        }
                     );
                return mouseMoveCommand;
            }
        }
        private RelayCommand<MouseEventArgs> mouseLeftButtonUpCommand;
        public RelayCommand<MouseEventArgs> MouseLeftButtonUpCommand
        {
            get
            {
                if (mouseLeftButtonUpCommand == null)
                    mouseLeftButtonUpCommand = new RelayCommand<MouseEventArgs>
                    (
                        (e) =>
                        {
                            FrameworkElement ele = e.Source as FrameworkElement;
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
                     );
                return mouseLeftButtonUpCommand;
            }
        }
        private RelayCommand<RoutedEventArgs> lostFocusCommand;
        public RelayCommand<RoutedEventArgs> LostFocusCommand
        {
            get
            {

                if (lostFocusCommand == null)
                    lostFocusCommand = new RelayCommand<RoutedEventArgs>
                    (
                        (e) =>
                        {
                            FrameworkElement ele = e.Source as FrameworkElement;
                            if (ele.Name == "ty3")
                            {
                                CoordinateValue.TriangleXPos = 0;
                                CoordinateValue.TriangleYPos = 0;
                                points[0].X = CoordinateValue.TriangleX1;
                                points[0].Y = CoordinateValue.TriangleY1;
                                points[1].X = CoordinateValue.TriangleX2;
                                points[1].Y = CoordinateValue.TriangleY2;
                                points[2].X = CoordinateValue.TriangleX3;
                                points[2].Y = CoordinateValue.TriangleY3;
                                CoordinateValue.Points = points;                             
                            }
                            if (ele.Name == "ly2")
                            {
                                CoordinateValue.LineXPos = 0;
                                CoordinateValue.LineYPos = 0;
                                points[3].X = CoordinateValue.LineX1;
                                points[3].Y = CoordinateValue.LineY1;
                                points[4].X = CoordinateValue.LineX2;
                                points[4].Y = CoordinateValue.LineY2;
                                CoordinateValue.Points = points;
                            }
                        }
                     );
                return lostFocusCommand;
            }
        }
        private RelayCommand<RoutedEventArgs> gotFocusCommand;
        public RelayCommand<RoutedEventArgs> GotFocusCommand
        {
            get
            {
                if (gotFocusCommand == null)
                    gotFocusCommand = new RelayCommand<RoutedEventArgs>
                    (
                        (e) =>
                        {
                            TextBox ele = e.Source as TextBox;
                            if(ele.Name!="x1")
                            ele.Clear();
                        }
                     );
                return gotFocusCommand;
            }
        }
        private RelayCommand<RoutedEventArgs> sizeChangedCommand;
        public RelayCommand<RoutedEventArgs> SizeChangedCommand
        {
            get
            {
                if (sizeChangedCommand == null)
                    sizeChangedCommand = new RelayCommand<RoutedEventArgs>
                    (
                        (e) =>
                        {
                            FrameworkElement ele = e.Source as FrameworkElement;
                            if (ele.Name == "win")
                            {
                                CoordinateValue.MaxX = (ele.Width) / 5 * 4;
                                CoordinateValue.MaxY = (ele.Height) / 12 * 11;
                            }
                        }
                     );
                return sizeChangedCommand;
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
    }
}
