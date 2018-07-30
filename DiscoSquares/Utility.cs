using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DiscoSquares
{
    class Utility
    {
        static Random r = new Random();
        public static Color GetRandomColor()
        {
            var red = (byte) r.Next(0, 255);
            var green = (byte)r.Next(0, 255);
            var blue = (byte)r.Next(0, 255);
            var color = Color.FromRgb(red, green, blue);

            return color;
            
        }

        public static int GetRandomNumber()
        {
            return r.Next(0, 100);
        }
    }
}
