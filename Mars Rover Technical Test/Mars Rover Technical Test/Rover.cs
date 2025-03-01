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
        Plateau plateau1;

        public Rover (int x, int y, string dir, Plateau plateau)
        {
            X = x;
            Y = y;
            direction = dir;
            plateau1 = plateau;

            directions = new List<string> {"N", "E", "S", "W"}; //List of directions in a list

            moveDir = new Dictionary<string, Action>() //Sets the rules for movement
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
            moveDir[direction].Invoke(); //Triggers move based on current direction
        }
        //rotates the rover left
        public void MoveLeft()
        {
            int index = directions.IndexOf(direction); //Get index of the current direction
            index--;

            if (index < 0) //Ensures the index is within bounds
            {
                index = directions.Count - 1;
            }

            direction = directions[index]; //Sets new direction
        }
        //rotates the rover right
        public void MoveRight()
        {
            int index = directions.IndexOf(direction); //Get index of the current direction
            index++;

            if(index >= directions.Count) //Ensures the index is within bounds
            {
                index = 0;
            }

            direction = directions[index]; //Sets new direction

        }

        //Methods moves the rover accordingly, +/- the X/Y axis
        void MoveNorth() {if(Y < plateau1.yMax) Y++; }
        void MoveSouth() {if(Y > 0) Y--; }
        void MoveWest() { if (X > 0) X--; }
        void MoveEast() { if (X < plateau1.xMax) X++; }

    }
}
