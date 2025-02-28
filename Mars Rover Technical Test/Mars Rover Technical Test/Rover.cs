using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover_Technical_Test
{
    internal class Rover
    {
        public Dictionary<string, Action> moveDir;
        public List<string> directions;

        public int X = 0;
        public int Y = 0;
        public string direction;

        public Rover (int x, int y, string dir)
        {
            X = x;
            Y = y;
            direction = dir;

            directions = new List<string> {"N", "E", "S", "W"};

            moveDir = new Dictionary<string, Action>()
            {
                {"N" , MoveNorth },
                {"S", MoveSouth },
                {"E", MoveEast },
                {"W", MoveWest },
            };
        }
        //move forward one by direction
        public void MoveForward()
        {
            moveDir[direction].Invoke();
        }
        //rotates the rover left
        public void MoveLeft()
        {
            int index = directions.IndexOf(direction);
            index--;

            if (index < 0)
            {
                index = directions.Count;
            }

            direction = directions[index];
        }
        //rotates the rover right
        public void MoveRight()
        {
            int index = directions.IndexOf(direction);
            index++;

            if(index > directions.Count)
            {
                index = 0;
            }

            direction = directions[index];

        }

        void MoveNorth() => Y++;
        void MoveSouth() => Y--;
        void MoveWest() => X--;
        void MoveEast() => X++;

    }
}
