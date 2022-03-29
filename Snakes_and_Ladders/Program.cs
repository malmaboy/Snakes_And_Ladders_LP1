using System;
using System.Security.Cryptography.X509Certificates;

namespace Snakes_and_Ladders
{
    class Program
    {
        /// <summary>
        /// Instance of the class User Interface
        /// </summary>
        private UserInterface userInterface;
        
        /// <summary>
        /// Constructor
        /// </summary>
        public Program()
        {
            // Instance of the class User Interface
            userInterface = new UserInterface();
        }
        
        /// <summary>
        /// Main 
        /// </summary>
        /// <param name="args">Arguments received from console</param>
        static void Main(string[] args)
        {
            // Creates a instance of class Program
            Program program;
            program = new Program();
            program.Run();
        }
        
        
        /// <summary>
        /// Runs the program
        /// </summary>
        private void Run()
        {
            userInterface.DisplayMenu();
        }
    }
}
