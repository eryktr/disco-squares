using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DiscoSquares
{
    /// <summary>
    /// Interaction logic for Simulation.xaml
    /// </summary>
    public partial class Simulation : Window
    {
        public const double WINDOW_WIDTH = 800d;
        public const double WINDOW_HEIGHT = 600d;

        public readonly int _rows, _columns;
        private readonly int _probablity;
        private readonly int _delay;
        private DiscoSquare[,] _squares;
        private readonly GridCreator _gridCreator;
        private readonly SquareCreator _squareCreator;
        private readonly Grid _mainGrid;
        private static Simulation _instance;
        private Simulation() { }
  

        public Simulation(int rows, int columns, int delay, int probablity)
        {
            
            _instance = this;
            _rows = rows;
            _columns = columns;
            _delay = delay;
            _probablity = probablity;
            _gridCreator = new GridCreator();
            _squareCreator = new SquareCreator(_rows, _columns);
            _squares = _squareCreator.GetSquares();
            _squareCreator.StartThreads(_squares);
            _mainGrid = _gridCreator.CreateGrid(_rows, _columns, _squares);


            this.Content = _mainGrid;
            this.Title = "Threading Disco Squares Simulation"; // This one works
            this.SizeToContent = SizeToContent.WidthAndHeight;
        }


        public static Simulation GetWindowInstance()
        {
            return _instance;
        }

        public int GetProbability()
        {
            return _probablity;
        }

        public static DiscoSquare GetSquare(int row, int col)
        {
            if (row >= _instance._rows) row = row % _instance._rows;
            if (col >= _instance._columns) col = col % _instance._columns;
            if (row < 0) row = row % _instance._rows + _instance._rows;
            if (col < 0) col = col % _instance._columns + _instance._columns;
            return _instance._squares[row, col];
        }

        public int GetDelay()
        {
            return _delay;
        }
    }
}
