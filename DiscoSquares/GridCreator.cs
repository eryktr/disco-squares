using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DiscoSquares
{
    class GridCreator
    {
        public Grid CreateGrid(int rows, int columns, DiscoSquare[,] squares)
        {
            var grid = new Grid();

            grid.HorizontalAlignment = HorizontalAlignment.Stretch;
     
            for (int i = 0; i < rows; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }

            for (int j = 0; j < columns; j++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(Simulation.WINDOW_WIDTH / columns )});
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    var rect = squares[i, j].Rectangle;
                    grid.Children.Add(rect);
                    Grid.SetRow(rect, i);
                    Grid.SetColumn(rect, j);
                }
            }

            //Simulation.GetWindowInstance().SizeToContent = SizeToContent.WidthAndHeight;
            return grid;
        }


    }
}
