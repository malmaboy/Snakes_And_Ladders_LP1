namespace Snakes_and_Ladders
{
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

        /// <summary>
        /// Gets player's turn
        /// </summary>
        /// <value>Current player's turn</value>
        public User Turn{get; private set;}

        /// <summary>
        /// Creates bidimensional array with empty houses
        /// </summary>
        public Board()
        {
            board = new char[boardDimension,boardDimension];
            for(int i = 0; i < boardDimension; i++)
            {
                for(int j = 0; j < boardDimension; j++)
                {
                    board[i,j] = (char)Houses.Empty; 
                }
            }
            userInterface = new UserInterface();
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
    }
}