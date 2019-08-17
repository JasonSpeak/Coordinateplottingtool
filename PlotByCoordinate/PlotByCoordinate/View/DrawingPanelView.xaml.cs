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

            
            foreach (UIElement uiEle in canvas.Children)
            {              
                uiEle.MouseMove += new MouseEventHandler(Element_MouseMove);
                uiEle.MouseLeftButtonDown += new MouseButtonEventHandler(Element_MouseLeftButtonDown);
                uiEle.MouseLeftButtonUp += new MouseButtonEventHandler(Element_MouseLeftButtonUp);
            }
       
            
        }

        bool isDragDropInEffect = false;
        Point pos = new Point();

        void Element_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragDropInEffect)
            {
                FrameworkElement currEle = sender as FrameworkElement;
                double xPos = e.GetPosition(null).X - pos.X + (double)currEle.GetValue(Canvas.LeftProperty);
                double yPos = e.GetPosition(null).Y - pos.Y + (double)currEle.GetValue(Canvas.TopProperty);
                currEle.SetValue(Canvas.LeftProperty, xPos);
                currEle.SetValue(Canvas.TopProperty, yPos);
                pos = e.GetPosition(null);
            }
        }

        void Element_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            FrameworkElement fEle = sender as FrameworkElement;
            isDragDropInEffect = true;
            pos = e.GetPosition(null);
            fEle.CaptureMouse();
            fEle.Cursor = Cursors.Hand;
        }

        void Element_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (isDragDropInEffect)
            {
                FrameworkElement ele = sender as FrameworkElement;
                isDragDropInEffect = false;
                ele.ReleaseMouseCapture();
            }
            
        }
        private void DockPanel_LostFocus(object sender, RoutedEventArgs e)
        {
            pathangle.BeginStoryboard(story1);
        }

        private void DockPanel_LostFocus_1(object sender, RoutedEventArgs e)
        {
            pathangle.BeginStoryboard(story1);
        }

        private void DockPanel_LostFocus_2(object sender, RoutedEventArgs e)
        {
            pathangle.BeginStoryboard(story1);
        }

        private void DockPanel_LostFocus_3(object sender, RoutedEventArgs e)
        {
            pathangle.BeginStoryboard(story2);
        }

     
    }
}