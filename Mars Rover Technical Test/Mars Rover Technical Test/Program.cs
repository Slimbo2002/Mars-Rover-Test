using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover_Technical_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Plateau plateau = Plateau();
            Command command = new Command(plateau);



            for(int i = 0; i < 2; i++)
            {
                Rover rover = CreateRover(plateau, command, i+1);

                command.MoveRover(rover, "RM");

                Console.WriteLine($"Rover {i+1} ended Up {rover.X}, {rover.Y}, {rover.direction}");
            }

            
            

        }
        //Get User Input to create a plateau
        static Plateau Plateau()
        {
            string[] userInput;
            int plateauMaxX = 0;
            int plateauMaxY = 0;

            bool getPlateau = false;

            //Loop until valid input
            while (!getPlateau)
            {
                //Get Plateau Max Values
                Console.WriteLine("Please enter the plateau size");
                userInput = Console.ReadLine().Split(' ');

                //Check for the length of userInput
                if (userInput.Length != 2)
                {
                    Console.WriteLine("Please separate numbers by a space");
                }
                else
                {
                    plateauMaxX = int.Parse(userInput[0]);
                    plateauMaxY = int.Parse(userInput[1]);
                    getPlateau = true;
                }
                

            }
            return new Plateau(plateauMaxX, plateauMaxY);
        }
        //Get User Input to create a Rover
        static Rover CreateRover(Plateau plateau, Command command, int index)
        {
            bool getRover = false;
            string[] input = new string[0];
            int x = 0;
            int y = 0;

            while (!getRover)
            {
                Console.WriteLine($"Please select Rover {index} start point and Orientation e.g. 2 2 E");
                input = Console.ReadLine().Split(' ');
                if (input.Length != 3) {
                    Console.WriteLine("Please enter as instructed");
                }
                else
                {
                    x = int.Parse(input[0]);
                    y = int.Parse(input[1]);

                    if (plateau.WithinBounds(x, y))
                    {
                        getRover = true;
                    }

                    
                    
                }
                

            }
            return command.CreateRover(x, y, input[2]);
        }
    }


}
