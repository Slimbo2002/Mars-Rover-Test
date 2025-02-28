using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover_Technical_Test
{
    internal class Plateau
    {
        public int xMax;
        public int yMax;

        public Plateau(int maxX, int maxY)
        {
            xMax = maxX;
            yMax = maxY;
        }
        public bool WithinBounds(int x, int y)
        {
            return x >= 0 && x <= xMax && y >= 0 && y <= yMax;
        }

    }
}
