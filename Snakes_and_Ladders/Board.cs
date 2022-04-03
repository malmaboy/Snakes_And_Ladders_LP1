namespace Snakes_and_Ladders
{
    /// <summary>
    /// Board class, contains game info.
    /// </summary>
    public class Board
    {   
        /// <summary>
        /// Creates constant variable for board size
        /// </summary>
        private const int boardDimension = 5;

        /// <summary>
        /// Creates array of board positions
        /// </summary>
        private char[,] board;

        /// <summary>
        /// Creates an instance of UserInterface
        /// </summary>
        private UserInterface userInterface;
        
        // Players created
        
        /// <summary>
        /// Creates a instance for player 1
        /// </summary>
        private Player player_1;
        /// <summary>
        /// Creates a instance for player 2
        /// </summary>
        private Player player_2;

        // Properties
        
        /// <summary>
        /// Get players 1 instance.
        /// </summary>
        public Player Player_1 => player_1;
        /// <summary>
        /// Get player 2 instance.
        /// </summary>
        public Player Player_2 => player_2;
        
        /// <summary>
        /// Returns Players Turn
        /// </summary>
        public string Turn { get; private set; }
 


         /// <summary>
         /// Creates two-dimensional array with empty houses
         /// </summary>

          public Board()
            {
              userInterface = new UserInterface();
 
            player_1 = new Player("Player_1", 'X',
               -1, 0, false);
            player_2 = new Player("Player_2", 'O',
                -1, 0, false);
            
            
            board = new char[boardDimension,boardDimension];
            for(int i = 0; i < boardDimension; i++)
            {
                for(int j = 0; j < boardDimension; j++)
                {
                    board[i,j] = (char)Houses.Normal; 
                }
            }
            
        }

        /// <summary>
        /// Change turn through players
        /// </summary>
        /// <param name="_currentPlayer">Current player to play.</param>
        public void ChangeTurn(string _currentPlayer)
        {
            if (_currentPlayer == player_1.PlayerName)
                Turn = player_2.PlayerName;
            else if (_currentPlayer == player_2.PlayerName)
                Turn = player_1.PlayerName;

        }

        
        /// <summary>
        /// Moves the player though the board.
        /// </summary>
        /// <param name="player">Player to move.</param>
        public void PlayerMovement(Player player)
        {

        }
        

        
        
        
        /// <summary>
        /// Returns game board
        /// </summary>
        /// <returns>board</returns>
        public char[,] GetBoard() => board;
        
        /// <summary>
        /// Returns board's positions
        /// </summary>
        /// <param name="x">line</param>
        /// <param name="y">column</param>
        /// <returns>houses</returns>
        public char GetPosition(int x,int y) => board[x,y];

        
        
        /// <summary>
        ///  Verify Who is the Winner
        /// </summary>
        public bool CheckWinner(bool loop)
        {
            if(player_1.PosX == 4 && player_1.PosY == 4)
            {
                
                loop = false;
            }
                

            if(player_2.PosX == 4 && player_2.PosY == 4)
            {
                
                loop = false;
            }
            return loop;
        }
    }
}