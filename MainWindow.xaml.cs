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
using System.Windows.Threading;

namespace c_sharp_fluid_sim
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Point _currentPoint = new Point();
        private Ellipse _mouseCursor = new Ellipse();
        private double _radius = 12.0;
        private PhysicsEngine _physicsEngine;

        public MainWindow()
        {
            _mouseCursor.Height = 5 * 2;
            _mouseCursor.Width = 5 * 2;

            InitializeComponent();
            _physicsEngine = new PhysicsEngine(450, 800);
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.03);
            timer.Start();
            timer.Tick += timer_Tick;
            
            _mouseCursor.Fill = Brushes.Aqua;
            screen.Children.Add(_mouseCursor);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            _physicsEngine.Iterate();

            if (screen.Children.Count - 1 < _physicsEngine.particleList.Count)
            {
                for (int i = screen.Children.Count - 1; i < _physicsEngine.particleList.Count; i++)
                    DrawDroplet(new Point(0, 0), _physicsEngine.particleList[i].radius);
            }

            for (int i = 0; i < _physicsEngine.particleList.Count; i++)
            {
                Canvas.SetLeft(screen.Children[i + 1],
                    _physicsEngine.particleList[i].X - _physicsEngine.particleList[i].radius);
                Canvas.SetTop(screen.Children[i + 1],
                    (_physicsEngine.particleList[i].Y - _physicsEngine.particleList[i].radius));
            }
        }


        private void MouseDownHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                _currentPoint = e.GetPosition(this);
            _physicsEngine.AddParticle(_currentPoint.X, _currentPoint.Y, _radius);
        }

        private void MouseMoveHandler(object sender, MouseEventArgs e)
        {
            _currentPoint = e.GetPosition(this);
            Canvas.SetLeft(screen.Children[0], _currentPoint.X - _radius);
            Canvas.SetTop(screen.Children[0], _currentPoint.Y - _radius);
        }

        private void DrawDroplet(Point position = default, double radius = default)
        {
            if (radius == default) radius = _radius;
            if (position == default) position = new Point(0, 0 + radius);

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