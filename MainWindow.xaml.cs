using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace c_sharp_fluid_sim
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Point currentPoint = new Point();
        private Ellipse Mouse_cursor = new Ellipse();
        private double Radius = 12.0;

        public MainWindow()
        {
            Mouse_cursor.Height = 12 * 2;
            Mouse_cursor.Width = 12 * 2;
            InitializeComponent();

            Mouse_cursor.Fill = Brushes.Aqua;
            screen.Children.Add(Mouse_cursor);

        }

        private void MouseDownHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                currentPoint = e.GetPosition(this);
            
            DrawDroplet(currentPoint, 12);
        }

        private void MouseMoveHandler(object sender, MouseEventArgs e)
        {
            currentPoint = e.GetPosition(this);
            Canvas.SetLeft(screen.Children[0], currentPoint.X - Radius);
            Canvas.SetTop(screen.Children[0], currentPoint.Y - Radius);
            
        }

        private void DrawDroplet(Point position, double radius = default)
        {
            if (radius == default) radius = Radius;

            Ellipse drop = new Ellipse();
            drop.Height = radius * 2;
            drop.Width = radius * 2;

            drop.Fill = Brushes.Aqua;

            Canvas.SetLeft(drop, position.X - radius);
            Canvas.SetTop(drop, position.Y - radius);
            screen.Children.Add(drop);
        }
    }
}