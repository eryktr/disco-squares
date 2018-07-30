using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DiscoSquares
{
    class SquareCreator
    {
        private readonly int _rows;
        private readonly int _columns;
        private readonly double _width;
        private readonly double _height;
        public SquareCreator(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;
            _width =  Simulation.WINDOW_WIDTH / columns;
            _height =  Simulation.WINDOW_HEIGHT / rows;
        }
        public DiscoSquare[,] GetSquares()
        {
            var squares = new DiscoSquare[_rows, _columns];
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    squares[i,j] = new DiscoSquare(_width, _height, i, j);
                }
            }


            return squares;
        }
    }
}