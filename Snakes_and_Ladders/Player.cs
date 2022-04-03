namespace Snakes_and_Ladders
{
    /// <summary>
    /// Creates players, with positions and appearance
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Player name
        /// </summary>
        private string playerName;
        /// <summary>
        /// Player appearance
        /// </summary>
        private char appearance;
        /// <summary>
        /// Player position in X coordinate
        /// </summary>
        private int posX;
        /// <summary>
        /// Player position in Y coordinate
        /// </summary>
        private int posY;
        /// <summary>
        /// Player Extra die
        /// </summary>
        private bool hasExtra_die;

        // Properties
        
        /// <summary>
        /// Get player name
        /// </summary>
        public string PlayerName => playerName;
        /// <summary>
        /// Get player appearance
        /// </summary>
        public char Appearance => appearance;
        
        /// <summary>
        /// Get and set Player extra die
        /// </summary>
        public bool HasExtra_die
        {
            get => hasExtra_die;
            set => hasExtra_die = value;
        }
        
        /// <summary>
        /// Get and set player position in X coordinate.
        /// </summary>
        public int PosX
        {
            get => posX;
            set => posX = value;
        }
        /// <summary>
        /// Get and set player position in Y coordinate.
        /// </summary>
        public int PosY
        {
            get => posY;
            set => posY = value;
        }
        
        /// <summary>
        /// Players Constructor
        /// </summary>
        /// <param name="_playerName"> Player name.</param>
        /// <param name="_appearance">Player appearance.</param>
        /// <param name="_posX">Player position in X coordinates.</param>
        /// <param name="_posY">Player position in Y coordinates.</param>
        /// <param name="_hasExtra_die">Player extra die.</param>
        public Player(string _playerName,char _appearance, int _posX, int _posY,bool _hasExtra_die)
        {
            playerName = _playerName;
            appearance = _appearance;
            posX = _posX;
            posY = _posY;
            hasExtra_die = _hasExtra_die;

        }
    }
}