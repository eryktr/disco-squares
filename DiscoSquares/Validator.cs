using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscoSquares
{
    class Validator
    {
        public void ValidateData(int rows, int cols, int prob, int del)
        {
            if (rows <= 0 || cols <= 0 || prob < 0 || del < 0) throw new FormatException("The input must be positive / non-zero, relatively.");
        }
    }
}
