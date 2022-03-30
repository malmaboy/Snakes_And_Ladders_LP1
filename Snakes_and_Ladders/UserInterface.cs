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
        }

        private void Instructions()
        {
            Console.WriteLine("Write here instructions of the game");
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



                    if ((User) board.GetPosition(i,j) == board.Turn)
                    {
                        Console.Write(" " + board.GetPosition(i, j).ToString().ToLower() + " ");
                    }
                    else
                    {
                        Console.Write(" " + board.GetPosition(i, j) + " ");

                    }



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
                //Calls for Main_Menu method in Menu class
                Main_Menu();

                //Reads user input
                Console.Write("---> ");
                int menu_option = Convert.ToInt32(Console.ReadLine());

                //Switch case for the option chosen by the user
                switch (menu_option)
                {
                    case 1:
                        
                        break;

                    case 2:
                        Instructions();
                        break;

                    case 3:
                        Console.WriteLine("Bye!");
                        return;

                    default:
                        Console.WriteLine("Please use a valid option.");
                        break;
                }
            }
        }
    }
}