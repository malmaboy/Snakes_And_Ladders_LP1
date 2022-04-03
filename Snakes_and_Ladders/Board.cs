using System;

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

        // Dice
        
        /// <summary>
        /// Variable for class dice
        /// </summary>
        private Dice dice;
        
        /// <summary>
        /// Die value
        /// </summary>
        private int die;
        
        

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
        /// Get die value
        /// </summary>
        public int Die => die;

        /// <summary>
        /// Current House name for player 1
        /// </summary>
        public string HouseToShow_1{get; private set;}
        
        /// <summary>
        /// Current House name for player 2
        /// </summary>
        public string HouseToShow_2{get; private set;}

        /// <summary>
        /// Creates two-dimensional array with empty houses
        /// /// </summary>
        public Board()
        {
            dice = new Dice();
            userInterface = new UserInterface();

            player_1 = new Player("Player_1", 'X',
               -1, 0, false);
            player_2 = new Player("Player_2", 'O',
                -1, 0, false);


            board = new char[boardDimension, boardDimension];
            for (int i = 0; i < boardDimension; i++)
            {
                for (int j = 0; j < boardDimension; j++)
                {
                    board[i, j] = (char)Houses.Normal;
                }
            }


            // Generate houses with amount
            int amount = dice.Random.Next(2,5);
            HousesGeneration(Houses.Snakes,amount);

             amount = dice.Random.Next(2,5);
            HousesGeneration(Houses.Ladders, amount);

             amount = dice.Random.Next(0,3);
            HousesGeneration(Houses.Boost, amount);

             amount = dice.Random.Next(0,3);
            HousesGeneration(Houses.U_Turn, amount);

             amount = 1;
            HousesGeneration(Houses.Cobra, amount);

             amount = 1;
            HousesGeneration(Houses.Extra_Die, amount);
            
             amount =1;
            HousesGeneration(Houses.Cheat_Die, amount);
            
            
            FirstPlayerToPlay();

        }
        
        
        // Player
        
        /// <summary>
        /// Decides who the first player to play
        /// </summary>
        /// <param name="dados"></param>
        private void FirstPlayerToPlay()
        {
            int firstDice = dice.RollDice();
            int secondDice = dice.RollDice();

            while (true)
            {
                if(firstDice == secondDice)
                    continue;
                
                if (firstDice > secondDice)
                {
                    Turn = player_1.PlayerName;
                    break;
                }
                if (secondDice > firstDice)
                {
                    Turn = player_1.PlayerName;
                    
                    break;
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
        ///  Verify Who is the Winner
        /// </summary>
        public bool CheckWinner(bool loop)
        {
            if (player_1.PosX == 4 && player_1.PosY == 4)
            {
                userInterface.WinnerMessage("Player_1");
                loop = false;
            }


            if (player_2.PosX == 4 && player_2.PosY == 4)
            {
                userInterface.WinnerMessage("Player_2");
                loop = false;
            }
            return loop;
        }


        /// <summary>
        /// Moves the player though the board.
        /// </summary>
        /// <param name="player">Player to move.</param>
        public void PlayerMovement(Player player)
        {
            die = dice.RollDice();

            player.PosX += die;
            
            TransformPlayer(player);
            CheckCollisionWithPlayer(Turn);
            TransformPlayer(player);
            CheckHouses();
            TransformPlayer(player);
        }

        /// <summary>
        /// Clamp players position so they dont get out of the array
        /// </summary>
        /// <param name="player">Current Player</param>
        private void TransformPlayer(Player player)
        {
            while(player.PosX > board.GetLength(0) - 1 
                  || player.PosX < 0)
            {
                if(player.PosY == board.GetLength(1) 
                    - 1 && player.PosX > 0)
                    player.PosX = board.GetLength(1) - 1 
                        - (player.PosX - (board.GetLength(1)- 1));
                
                else if(player.PosX < 0)
                {
                    if(player.PosY == 0)
                        return;
                    
                    player.PosY -= 1;
                    player.PosX += board.GetLength(0);
                }

                else
                {
                    player.PosY += 1;
                    player.PosX -= board.GetLength(0);    
                }
            }
        }
        
        /// <summary>
        /// Check if player are in the same house
        /// </summary>
        /// <param name="turn">Player turn</param>
        private void CheckCollisionWithPlayer(string turn)
        {
            if(player_1.PosY == player_2.PosY && player_1.PosX == player_2.PosX)
            {
                if(turn == "Player_1")
                    player_2.PosX -= 1;
                else
                    player_1.PosX -= 1; 
                
            }
        
        }


        //Board

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
        public char GetPosition(int x, int y) => board[x, y];
        


        // Houses


        /// <summary>
        /// Get color of the uses to print in the UI
        /// </summary>
        /// <param name="_houses"> Houses Enum</param>
        public void GetColor(Houses _houses)
        {
            switch (_houses)
            {
                case Houses.Boost:
                    Console.BackgroundColor = ConsoleColor.Blue; //0-2
                    break;
                case Houses.Cobra: 
                    Console.BackgroundColor = ConsoleColor.Green; // 1
                    break;
                case Houses.Ladders:
                    Console.BackgroundColor = ConsoleColor.Yellow; // 2-4
                    break;
                case Houses.Normal:
                     Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case Houses.Cheat_Die:
                  Console.BackgroundColor = ConsoleColor.Magenta;
                    break;
                case Houses.Extra_Die:
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
                case Houses.U_Turn:
                   Console.BackgroundColor = ConsoleColor.Gray; // 0-2
                    break;
                case Houses.Snakes:
                    Console.BackgroundColor = ConsoleColor.Cyan; // 2-4
                    break;
                
            }

        }
        
        /// <summary>
        /// Generate Houses in board
        /// </summary>
        private void HousesGeneration(Houses house,int amount)
        {

            int x ;
            int y;

            for(int i =0; i<amount;){
                x = dice.Random.Next(0,5);
                y = dice.Random.Next(0,5);
                
                if(board[y,x] != (char)Houses.Normal||
                   x==0&&y==0||
                   x==4&&y==4)
                    continue;

                if(house == Houses.Snakes &&
                   y==0)
                    continue;

                if(house == Houses.Ladders&&
                   y==4)
                    continue;

                board[y,x] = (char)house;
                i++;
            }            
        }

        /// <summary>
        /// Check the house that current player is a special house
        /// </summary>
        private void CheckHouses()
        {
            if(player_1.PosX >= 0 && player_2.PosX >= 0)
            {
                SnakeHouse();
                LadderHouse();
                CobraHouse();
                BoostHouse();
            }
        }

        /// <summary>
        /// Down one house in vertical
        /// </summary>
        private void SnakeHouse()
        {   
            if(board[player_1.PosY, player_1.PosX] == (char) Houses.Snakes)
            {
                player_1.PosY -= 1;
                player_1.PosX = board.GetLength(0) - 1 - player_1.PosX;
                HouseToShow_1 = "Snakes";
            }
             if(board[player_2.PosY, player_2.PosX] == (char) Houses.Snakes)
            {
                player_2.PosY -= 1;
                player_2.PosX = board.GetLength(0) - 1 - player_2.PosX;
                HouseToShow_2 = "Snakes";
            }
        }  

        /// <summary>
        ///  up one house in vertical
        /// </summary>
        private void LadderHouse()
        {
            if(board[player_1.PosY, player_1.PosX] == (char) Houses.Ladders)
            {
                player_1.PosY += 1;
                player_1.PosX = board.GetLength(0) - 1 - player_1.PosX;
                HouseToShow_1 = "Ladders";
            }
            if(board[player_2.PosY, player_2.PosX] == (char) Houses.Ladders)
            {
                player_2.PosY += 1;
                player_2.PosX = board.GetLength(0) - 1 - player_2.PosX;
                HouseToShow_2 = "Ladders";
            }  
        } 
        
        /// <summary>
        /// Return Player to the beginning of the board
        /// </summary>
        private void CobraHouse()
        {
            if(board[player_1.PosY, player_1.PosX] == (char) Houses.Cobra)
            {
                player_1.PosX = 0;
                player_1.PosY = 0;
                HouseToShow_1 = "Cobra";
            }
            if(board[player_2.PosY, player_2.PosX] == (char) Houses.Cobra)
            {
                player_2.PosX = 0;
                player_2.PosY = 0;
                HouseToShow_2 = "Cobra";
            }

            
        }
        
        /// <summary>
        /// Player advance 2 houses
        /// </summary>
        private void BoostHouse()
        {
            if(board[player_1.PosY, player_1.PosX] == (char) Houses.Boost)
            {
                player_1.PosX += 2;
                HouseToShow_1 = "Boost";
            }
            if(board[player_2.PosY, player_2.PosX] == (char) Houses.Boost)
            {
                player_2.PosX += 2;
                HouseToShow_2 = "Boost";
            }

        }

        /// <summary>
        ///  Player go back 2 houses
        /// </summary>
        private void U_TurnHouse()
        {
            if(board[player_1.PosY, player_1.PosX] == (char) Houses.U_Turn)
            {
                player_1.PosX -= 2;
                HouseToShow_1= "U-Turn";
            }
             if(board[player_2.PosY, player_2.PosX] == (char) Houses.U_Turn)
            {
                player_2.PosX -= 2;
                HouseToShow_2 = "U-Turn";
            }

            
        }

        /// <summary>
        /// Gives a extra die to the player
        /// </summary>
        private void ExtraDieHouse()
        {
            if(board[player_1.PosY, player_1.PosX] == (char) Houses.Extra_Die)
            {
                if(player_1.HasExtra_die == false)
                    player_1.HasExtra_die = true;

                HouseToShow_1 = "Extra Die";
            }
             if(board[player_2.PosY, player_2.PosX] == (char) Houses.Extra_Die)
            {
                if(player_2.HasExtra_die == false)
                    player_2.HasExtra_die = true;

                HouseToShow_2 = "Extra Die";
            }

        }

        /// <summary>
        /// Does nothing, only to save the house type for description
        /// </summary>
        private void NormalHouse()
        {
            if(board[player_1.PosY, player_1.PosX] == (char) Houses.Normal)
            {
                HouseToShow_1 = "Normal";
            }
             if(board[player_2.PosY, player_2.PosX] == (char) Houses.Normal)
            {
                HouseToShow_2 = "Normal";
            }
        }


        private void UseExtraDie()
        {
            // Input
            ConsoleKeyInfo key;
            key = Console.ReadKey();


            if(player_1.HasExtra_die == true && Turn == player_1.PlayerName) 
            {
                if(key.Key == ConsoleKey.Tab)
                {
                    player_1.HasExtra_die = false;
                    PlayerMovement(player_1);
                }
                
            }

            if(player_2.HasExtra_die == true && Turn == player_2.PlayerName) 
            {
                if(key.Key == ConsoleKey.Tab)
                {
                    player_2.HasExtra_die = false;
                    PlayerMovement(player_2);
                }
                
            }
                
        }

        

    }
}