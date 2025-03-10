﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover_Technical_Test
{
    internal class Command
    {
        Plateau plateau;

        //Sets the plateau
        public Command(Plateau plateau)
        {
            this.plateau = plateau;
        }

        //Create Rover with Starting Coordinates
        public Rover CreateRover(int x, int y, string dir, Plateau plateau)
        {
            return new Rover(x, y, dir, plateau);
        }

        /// <summary>
        /// Moves rover based on input
        /// - Recieves input from main
        /// - Splits the input into Chars
        /// - Cycles each input and moves rover based on input
        /// </summary>
        /// <param name="rover"></param>
        /// <param name="commands"></param>
        public void MoveRover(Rover rover, string commands)
        {
            char[] temp = commands.ToCharArray();

            for (int i = 0; i < temp.Length; i++)
            {
                switch (temp[i]) 
                {
                    case 'M':
                        rover.MoveForward();
                        break;
                    case 'L':
                        rover.MoveLeft();
                        break;
                    case 'R':
                        rover.MoveRight();
                        break;


                }
            }


        }

    }
}
