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
        //Main Program
        static void Main(string[] args)
        {
            //
            Plateau plateau = Plateau();
            Command command = new Command(plateau);

            string[] roverCoords = new string[2];

            //Loop twice for 2 rovers
            for(int i = 0; i < 2; i++) 
            {
                Rover rover = CreateRover(plateau, command, i+1); //Get input to create Rover

                MoveRover(rover, i+1, command); //Get input to move Rover

                roverCoords[i] = $"{rover.X} {rover.Y} {rover.direction}"; //Stores Rover Coordinates
            }
            
            //Output each coordinate and direction
            foreach(string coords in roverCoords)
            {
                Console.WriteLine($"{coords}\n");
            }

            Console.Read();
        }
        #region Creation Methods
        /// <summary>
        /// Get user input to create plateau
        /// - User enters the x,y coordinates for upper right corner of plateau
        /// - Create Plateau
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Get user input to create rover
        ///  - Get rover coordinates
        ///  - Get Rover facing direction
        ///  - Create rover
        /// </summary>
        /// <param name="plateau"></param>
        /// <param name="command"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        static Rover CreateRover(Plateau plateau, Command command, int index)
        {
            bool getRover = false;
            string[] input = new string[0];
            int x = 0;
            int y = 0;

            //Loop until valid
            while (!getRover)
            {
                Console.WriteLine($"Please select Rover {index} start point and Orientation e.g. 2 2 E");
                input = Console.ReadLine().Split(' '); //Splits the input 
                if (input.Length != 3) 
                {
                    Console.WriteLine("Please enter as instructed, include spaces");
                }
                else
                {
                    //Convert the strings to ints for coordinates
                    x = int.Parse(input[0]); 
                    y = int.Parse(input[1]);

                    if (plateau.WithinBounds(x, y)) //Check if the rover is in the plateau
                    {
                        getRover = true;
                    }
                    else
                    {
                        Console.WriteLine("Please ensure the rover is within the plateau");
                    }

                    
                    
                }
                

            }
            return command.CreateRover(x, y, input[2].ToUpper(),plateau);
        }
        /// <summary>
        /// Method runs the script to get user input and move rover
        /// - Gets input from user where to move rover to
        /// - Checks if it is valid and only contains valid characters
        /// - Moves rover
        /// </summary>
        /// <param name="rover"></param>
        /// <param name="roverIndex"></param>
        /// <param name="command"></param>
        static void MoveRover(Rover rover, int roverIndex, Command command)
        {
            bool isValid = false;
            string input = "";

            //Loop until valid
            while (!isValid)
            {
                Console.WriteLine($"Please enter the rover {roverIndex} movement (M - Move forward, L - Turn Left, R - Turn Left) \n Make sure there is no spaces ");
                input = Console.ReadLine().ToUpper();

                if (FormatValid(input))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Please enter valid movement commands");
                }
            }
            


            command.MoveRover(rover, input);

        }
        //Input a string to check if it a valid input
        static bool FormatValid(string format)
        {
            string allowableLetters = "MLR";

            foreach (char c in format)
            {
                if (!allowableLetters.Contains(c.ToString()))
                    return false;
            }

            return true;
        }
        #endregion
    }


}
