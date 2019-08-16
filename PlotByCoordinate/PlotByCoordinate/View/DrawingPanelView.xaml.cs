using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PlotByCoordinate.ViewModel;
namespace PlotByCoordinate.View
{
    /// <summary>
    /// DrawingPanelView.xaml 的交互逻辑
    /// </summary>
    public partial class DrawingPanelView : Window
    {
        
        
        public DrawingPanelView()
        {

            InitializeComponent();
           

            }
    


        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
           
        }


  

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var canvas = new Canvas();                              
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Content = grid;
            
            var points =
                new List<Point>()
                {
                    new Point(Convert.ToDouble((this.lx1.Text)), Convert.ToDouble((this.ly1.Text))),
                    new Point(Convert.ToDouble((this.lx2.Text)), Convert.ToDouble((this.ly2.Text))),
               //     new Point(10, 10)
                };
            var sb = new Storyboard();
         
            for (int i = 0; i < points.Count - 1; i++)
            {
                var lineGeometry = new LineGeometry(points[i], points[i]);
                var path =
                    new Path()
                    {
                        Stroke = Brushes.White,
                        StrokeThickness = 3,
                        Data = lineGeometry
                    };
                this.canvas.Children.Add(path);
                var animation =
                    new PointAnimation(points[i], points[i + 1], new Duration(TimeSpan.FromMilliseconds(1000)))
                    {
                        BeginTime = TimeSpan.FromMilliseconds(i * 1010)
                    };
                sb.Children.Add(animation);
                RegisterName("geometry" + i, lineGeometry);
                Storyboard.SetTargetName(animation, "geometry" + i);
                Storyboard.SetTargetProperty(animation, new PropertyPath(LineGeometry.EndPointProperty));
               
            }
           
            sb.Begin(this);
            
        }
        static Point startPoint;
        static Point endPoint;
        static bool isCapture = false;
        private void PathFigure_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Window win = sender as Window;
            startPoint = e.GetPosition(win);
            isCapture = true;
        }

        private void PathFigure_MouseMove(object sender, MouseEventArgs e)
        {
            endPoint = e.GetPosition(sender as Window);
            if (isCapture)
            {
                DrawRectangle(sender); 
            }
        }
        private void DrawRectangle(object sender)
        {
        
        }
    }
}
