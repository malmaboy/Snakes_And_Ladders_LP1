using System;

namespace Snakes_and_Ladders
{
    class Program
    {
        static void Main(string[] args)
        {
            //Small introduction text
            Console.WriteLine("\nWellcome to Snakes and Ladders!");
            Console.WriteLine("Please write the instructions after the arrow " + 
            "--->");

            while (true)
            {
                //Calls for Main_Menu method in Menu class
                Menu.Main_Menu();

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
                        Menu.Instructions();
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
