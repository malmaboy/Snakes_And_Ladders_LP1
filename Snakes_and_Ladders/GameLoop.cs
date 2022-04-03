using System;

namespace Snakes_and_Ladders
{
    /// <summary>
    /// Gameloop class
    /// /// </summary>
    public class GameLoop
    {
        /// <summary>
        /// User interface instance variable
        /// </summary>
        private readonly UserInterface userInterface;
        
        /// <summary>
        /// Board instance variable.
        /// </summary>
        private readonly Board board;

        /// <summary>
        /// Variable loop to check the winner
        /// </summary>
        private bool loop;

        /// <summary>
        ///  space key to update the game
        /// </summary>
        private ConsoleKeyInfo spaceKey;

        /// <summary>
        /// Game Loop constructor
        /// </summary>
        public GameLoop()
        {
            loop = true;
            userInterface = new UserInterface();
            board = new Board();
        }
        
        /// <summary>
        /// Starts the game
        /// </summary>
        public void StartGame()
        {
            userInterface.DisplayMenu();
            
            Loop();
        }


        /// <summary>
        /// Runs the game loop
        /// </summary>
        private void Loop()
        {
            while(board.CheckWinner(loop))
            {
                
                userInterface.GameInstructions(board);

               spaceKey = Console.ReadKey();

                if (spaceKey.Key == ConsoleKey.Spacebar && spaceKey.Key != ConsoleKey.Tab)
                {
                    
                    //Update
                    if (board.Turn == "Player_1")
                        board.PlayerMovement(board.Player_1);

                    else if (board.Turn == "Player_2")
                        board.PlayerMovement(board.Player_2);

                     //Render
                    userInterface.DisplayBoard(board, board.Player_1, board.Player_2);
                    

                

                    board.ChangeTurn(board.Turn);
                }
            }
        }
  }
}