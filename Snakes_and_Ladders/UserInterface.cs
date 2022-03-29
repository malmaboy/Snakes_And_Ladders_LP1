using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snakes_and_Ladders
{
    public class UserInterface
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public UserInterface()
        {
            
        }
        
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

        public void DisplayMenu()
        {
            //Small introduction text
            Console.WriteLine("\nWellcome to Snakes and Ladders!");
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
                        //Calls Play method
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