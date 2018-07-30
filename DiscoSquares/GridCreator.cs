using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DiscoSquares
{
    class GridCreator
    {
        public Grid CreateGrid(int rows, int columns)
        {
            var grid = new Grid();

            for (int i = 0; i < rows; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }

            for (int j = 0; j < columns; j++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            grid.Children.Add(new Label {Content = "XD"});
            return grid;
        }


    }
}
