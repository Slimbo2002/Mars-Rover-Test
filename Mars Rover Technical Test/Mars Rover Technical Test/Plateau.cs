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

        //Sets the upper right corner of plateau
        public Plateau(int maxX, int maxY)
        {
            xMax = maxX;
            yMax = maxY;
        }
        //Checks if object is in bounds of rover (between 0 and max values)
        public bool WithinBounds(int x, int y)
        {
            return x >= 0 && x <= xMax && y >= 0 && y <= yMax;
        }

    }
}
