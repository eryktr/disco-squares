using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DiscoSquares
{
    public class DiscoSquare
    {
        public Rectangle Rectangle { get; set; }
        private Thread _thread;
        private bool _isRunning;
        private readonly int probability;
        private readonly int delay;
        private readonly int _row, _col;

        public DiscoSquare(double width, double height, int row, int col)
        {
            _row = row;
            _col = col;
            Rectangle = new Rectangle
            {
                Width = width,
                Height = height,
                Fill = new SolidColorBrush(Utility.GetRandomColor())
            };
            probability = Simulation.GetWindowInstance().GetProbability();
            delay = Simulation.GetWindowInstance().GetDelay();
            _thread = new Thread(new ThreadStart(Start));
            _isRunning = true;
        }

        public void Start()
        {
            while (_isRunning)
            {
                var n = Utility.GetRandomNumber();
                ChangeColor(n >= probability ? ChangeColorMode.AverageColor : ChangeColorMode.RandomColor);
                var r = Utility.GetRandomDelay(delay);
                
                Thread.Sleep(r);
            }
        }

        public void ChangeColor(ChangeColorMode mode)
        {
            switch (mode)
            {
                case ChangeColorMode.RandomColor:
                    Rectangle.Dispatcher.Invoke( new Action(() => Rectangle.Fill = new SolidColorBrush(Utility.GetRandomColor())));
                    break;

                case ChangeColorMode.AverageColor:
                    Rectangle.Dispatcher.Invoke( new Action( () => Rectangle.Fill = new SolidColorBrush(GetAverageColor())));
                    break;
            }
        }

        public Color GetAverageColor()
        {
            var neighbors = (Simulation.GetSquare(_row + 1, _col), Simulation.GetSquare(_row - 1, _col),
                Simulation.GetSquare(_row, _col - 1), Simulation.GetSquare(_row, _col + 1));

            var topBrush = neighbors.Item1.Rectangle.Fill as SolidColorBrush;
            var bottomBrush = neighbors.Item2.Rectangle.Fill as SolidColorBrush;
            var leftBrush = neighbors.Item3.Rectangle.Fill as SolidColorBrush;
            var rightBrush = neighbors.Item1.Rectangle.Fill as SolidColorBrush;

            var color1 = topBrush.Color;
            var color2 = bottomBrush.Color;
            var color3 = leftBrush.Color;
            var color4 = rightBrush.Color;

            var red = (byte) ((color1.R + color2.R + color3.R + color4.R) / 4);
            var green = (byte) ((color1.G + color2.G + color3.G + color4.G) / 4);
            var blue = (byte) ((color1.B + color2.B + color3.B + color4.B) / 4);

            var color = Color.FromRgb(red, green, blue);

            return color;
        }

        public void RunThread()
        {
            _thread.Start();
        }
    }
}