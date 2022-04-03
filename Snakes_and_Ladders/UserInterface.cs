using System;

namespace Snakes_and_Ladders
{
    /// <summary>
    /// User Interface class.
    /// </summary>
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
        /// Breaks the main menu loop
        /// </summary>
        private bool mainMenu;

        /// <summary>
        /// User interface construtor
        /// </summary>
        public UserInterface()
        {
            horizontalSymbol = "---";
            verticalSymbol = "|";

            mainMenu = true;
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
        

        /// <summary>
        /// Shows game instructions.
        /// </summary>
        private void Instructions()
        {
            Console.WriteLine("\n- This is a game for 2 players to see which" + 
            " one is the fastest to reach the end of the board.");
            Console.WriteLine("\n- The board has 25 houses, and the number of" + 
            " houses the players has to go through is determined by dices of 6.");
            Console.WriteLine("\n- Normal houses do nothing special.");
            Console.WriteLine("\n- Snakes make the player descend one house directly below.");
            Console.WriteLine("\n- Ladders make the player ascend one house directly above.");
            Console.WriteLine("\n- Cobra makes the player go back to the" + 
            " first house.");
            Console.WriteLine("\n- Boost makes the player move 2 houses.");
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
        public void DisplayBoard(Board board, Player player_1, Player player_2)
        {
            
            Console.Clear();

            Console.WriteLine($"Turn: {board.Turn}");


            for (int i = board.GetBoard().GetLength(0)-1; i >= 0;i--)
            {
                for (int k = 0; k < board.GetBoard().GetLength(0); k++)
                {
                    if(k == 0) 
                        Console.Write("   ");

                    Console.Write(horizontalSymbol);
                }



                if (i % 2 != 0)
                {
                    
                    Console.Write("\n" +   "   ");
                    for (int j = board.GetBoard().GetLength(1) -1 ; j >= 0; j--)
                    {
                        Console.Write(verticalSymbol);
                        
                        int xdim = i;
                        int ydim = j;
                        board.GetColor((Houses)board.GetPosition(i,j));
                       Console.Write($"{xdim.ToString()}{ydim.ToString()}");
                        
                       if(player_1.PosX == j && player_1.PosY == i)
                       {
                            Console.Write(" " + player_1.Appearance.ToString().ToUpper());
                       }
                        
                        if(player_2.PosX == j && player_2.PosY == i)
                       {
                            Console.Write(" " + player_2.Appearance.ToString().ToUpper());
                       }

                       Console.ResetColor();
                    }
                }
                else
                {
                    Console.Write("\n" +   "   ");
                    for (int j = 0; j < board.GetBoard().GetLength(1); j++)
                    {
                        Console.Write(verticalSymbol);
                        
                        int xdim = i;
                        int ydim = j;
                        board.GetColor((Houses)board.GetPosition(i,j));
                        Console.Write($"{xdim.ToString()}{ydim.ToString()}");
                        
                        
                        if(player_1.PosX == j && player_1.PosY == i)
                       {
                            Console.Write(" " + player_1.Appearance.ToString().ToUpper());
                       }
                        
                        if(player_2.PosX == j && player_2.PosY == i)
                       {
                            Console.Write(" " + player_2.Appearance.ToString().ToUpper());
                       }
                        
                        Console.ResetColor();
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

            
            while (mainMenu)
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
                        mainMenu = false;
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
        
        /// <summary>
        /// Shows invalid option in game menu
        /// </summary>
        private void InvalidOption()
        {
            Console.WriteLine("Please type a valid option");
            return;
        }
        
        /// <summary>
        /// Display a winner message
        /// </summary>
        /// <param name="_playerName">Player name</param>
        public void WinnerMessage(string _playerName)
        {
            if (_playerName == "Player_1")
                Console.WriteLine("Player 1 has won!!!");
            if (_playerName == "Player_2")
                Console.WriteLine("Player 2 has won!!!");
        }


        /// <summary>
        /// Game instructions in game
        /// </summary>
        public void GameInstructions(Board board)
        {
            
            if(board.Turn == board.Player_1.PlayerName)
            {
                if(board.Player_1.HasExtra_die == true)
                {
                    Console.WriteLine($"{board.Turn} HAS EXTRA DIE");
                    Console.WriteLine("TYPE TAB TO USE IT!!");
                }
                
            }
            else if(board.Turn == board.Player_2.PlayerName)
            {
                if(board.Player_2.HasExtra_die == true)
                {
                    Console.WriteLine($"{board.Turn} HAS EXTRA DIE");
                    Console.WriteLine($"WHEN {board.Turn} TYPE  TO USE IT!!");
                }
                    

                
            }
                

            Console.WriteLine("Use SPACEBAR to advance....");

            Console.WriteLine("Player 1 Piece = X. \nPlayer 2 Piece = O. \n " );
            Console.WriteLine("Houses Colors:");

            

            Console.BackgroundColor = ConsoleColor.Black;
            System.Console.WriteLine(" Normal");
            Console.BackgroundColor = ConsoleColor.Blue;
            System.Console.WriteLine(" Boost");
            Console.BackgroundColor = ConsoleColor.Green;
            System.Console.WriteLine(" Cobra");
            Console.BackgroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine(" Ladder");
            Console.BackgroundColor = ConsoleColor.Magenta;
            System.Console.WriteLine(" Cheat Die");
            Console.BackgroundColor = ConsoleColor.Red;
            System.Console.WriteLine(" Extra Die ");
            Console.BackgroundColor = ConsoleColor.Gray;
            System.Console.WriteLine(" U Turn ");
            Console.BackgroundColor = ConsoleColor.Cyan;
            System.Console.WriteLine(" Snakes");

            Console.ResetColor();
            
        }
    }
}