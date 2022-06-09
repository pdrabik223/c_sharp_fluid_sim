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
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void MouseDownHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                currentPoint = e.GetPosition(this);
            Ellipse drop = new Ellipse();
            drop.Height = 50;
            drop.Width = 50;
            
            drop.Fill = Brushes.Aqua;
            Canvas.SetLeft(drop, currentPoint.X - drop.Width/2);
            Canvas.SetTop(drop, currentPoint.Y- drop.Height/2);
            screen.Children.Add(drop);
            
        }
    }
}