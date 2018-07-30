using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DiscoSquares
{
    public class DiscoSquare
    {
        public Rectangle Rectangle { get;  set; }
        private Thread _thread;
        private bool _isRunning;
        private readonly int probability;
        private readonly int _row, _col;

        public DiscoSquare(double width, double height, int row, int col)
        {
            Rectangle = new Rectangle
            {
                Width = width,
                Height = height,
                Fill = new SolidColorBrush(Utility.GetRandomColor())
            };
            probability = Simulation.GetWindowInstance().GetProbability();
        }

        public void Start()
        {
            var n = Utility.GetRandomNumber();
            if (n < probability)
            {
                ChangeColor(ChangeColorMode.RandomColor);
            }
            else
            {
                ChangeColor(ChangeColorMode.AverageColor);
            }
        }

        public void ChangeColor(ChangeColorMode mode)
        {
            switch (mode)
            {
                case ChangeColorMode.RandomColor: 
                    Rectangle.Fill = new SolidColorBrush(Utility.GetRandomColor());
                    break;

                case ChangeColorMode.AverageColor:
                    break;

            }
        }

        public (DiscoSquare top, DiscoSquare bottom, DiscoSquare left, DiscoSquare right) GetNeighbors()
        {
            return (Simulation.GetSquare(_row + 1, _col), Simulation.GetSquare(_row - 1, _col),
                Simulation.GetSquare(_row, _col - 1), Simulation.GetSquare(_row, _col + 1));
        }


    }
}