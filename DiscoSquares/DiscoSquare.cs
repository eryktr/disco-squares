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
    class DiscoSquare
    {
        private Rectangle _rectangle;
        private Thread _thread;

        public DiscoSquare(int width, int height)
        {
            _rectangle = new Rectangle
            {
                Width = width,
                Height = height,
                Fill = new SolidColorBrush(Utility.GetRandomColor())
            };
        }

        public void ChangeColor(ChangeColorMode mode)
        {

        }
    }
}
