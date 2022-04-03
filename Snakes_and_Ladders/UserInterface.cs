using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snakes_and_Ladders
{
    public class UserInterface
    {
        /// <summary>
        /// Creates horizontal symbol for board creation
        /// </summary>
        private readonly string horizontalSymbol;
        /// <summary>
        /// Creates vertical symbol for board creation
        /// </summary>
        private readonly string verticalSymbol;
        /// <summary>
        /// Constructor
        /// </summary>
        
        public UserInterface()
        {
            horizontalSymbol = "-----";
            verticalSymbol = "|";
        }
        /// <summary>
        /// Displays main menu
        /// </summary>
        private void Main_Menu()
        {
            Console.WriteLine("\n-----------Menu-----------");
            Console.WriteLine();
            Console.WriteLine("          1.Play          ");
            Console.WriteLine("      2.Instructions      ");
            Console.WriteLine("          3.Quit          ");
            Console.WriteLine();
            Console.WriteLine("(please type in the number of the option you " + 
            "want)");
        }

        private void Instructions()
        {
            Console.WriteLine("\n- This is a game for 2 players to see which" + 
            " one is the fastest to reach the end of the board.");
            Console.WriteLine("\n- The board has 25 houses, and the number of" + 
            " houses the players go through is determined by dices of 6.");
            Console.WriteLine("\n- Normal houses do nothing special.");
            Console.WriteLine("\n- Snakes makes the player go back 5 houses.");
            Console.WriteLine("\n- Ladders makes the player go up 5 houses.");
            Console.WriteLine("\n- Cobra makes the player go back to the" + 
            " first house.");
            Console.WriteLine("\n- Boost makes the player go up 2 houses.");
            Console.WriteLine("\n- U-Turn makes the player go back 2 houses.");
            Console.WriteLine("\n- Extra Die gives the player 1 more dice" + 
            " to use whenever the player wants (//Type here command to use//).");
            Console.WriteLine("\n- Cheat Die gives the ability to change the" + 
            " number of any dice whenever the player wants.");

            Console.WriteLine("\nPress ENTER to continue...");
            Console.ReadLine();
        }
        /// <summary>
        /// Displays board on console and formats it
        /// </summary>
        /// <param name="board">board</param>
        public void DisplayBoard(Board board)
        {
            for (int i = 0; i < board.GetBoard().GetLength(0); i++)
            {
                for (int k = 0; k < board.GetBoard().GetLength(0); k++)
                {
                    if(k == 0) 
                        Console.Write("   ");

                    Console.Write(horizontalSymbol);
                }




                Console.Write("\n" +   "   ");
                for (int j = 0; j < board.GetBoard().GetLength(1); j++)
                {
                    Console.Write(verticalSymbol);

                        int xdim = i;
                        int ydim = j;
                        Console.Write($"{xdim}{ydim}");



                    



                }


                Console.Write(verticalSymbol);
                Console.WriteLine(String.Empty);


            }
        }
        /// <summary>
        /// Displays the menu
        /// </summary>
        public void DisplayMenu()
        { 
            
            //Small introduction text
            Console.WriteLine("\nWelcome to Snakes and Ladders!");
            Console.WriteLine("Please write the instructions after the arrow " +
                              "--->");

            while (true)
            {
                //Calls for Main_Menu method
                Main_Menu();

                //Reads user input
                Console.Write("---> ");
                string menu_option = Console.ReadLine();

                if (menu_option == "1" || menu_option == "2" || menu_option == "3")
                {
                    switch (menu_option)
                    {
                    case "1":
                        
                        break;

                    case "2":
                        Instructions();
                        break;

                    case "3":
                        Console.WriteLine("Bye!");
                        return;

                    default:
                        break;
                    }
                }
                else
                {
                    InvalidOption();
                }
            }
        }

        private void InvalidOption()
        {
            Console.WriteLine("Please type a valid option");
            return;
        }
    }
}