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
        private readonly int _rows, _columns;
        private readonly int _probablity;
        private readonly int _delay;
        private readonly int _width;
        private readonly int _height;
        private readonly DiscoSquare[,] _squares;
        private readonly GridCreator _gridCreator;
        private readonly Grid _mainGrid;

        
        private Simulation()
        {
            InitializeComponent();
            
        }

        public Simulation(int rows, int columns, int delay, int probablity)
        {
            _rows = rows;
            _columns = columns;
            _delay = delay;
            _probablity = probablity;
            _squares = new DiscoSquare[_rows, _columns];
            _gridCreator = new GridCreator();
            _mainGrid = _gridCreator.CreateGrid(_rows, _columns);
            this.Content = _mainGrid;
        }
    }
}
