using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snakes_and_Ladders
{
    public class Menu
    {
        public static void Main_Menu()
        {
            Console.WriteLine("\n-----------Menu-----------");
            Console.WriteLine();
            Console.WriteLine("          1.Play          ");
            Console.WriteLine("      2.Instructions      ");
            Console.WriteLine("          3.Quit          ");
        }

        public static void Instructions()
        {
            Console.WriteLine("Write here instructions of the game");
        }
    }
}