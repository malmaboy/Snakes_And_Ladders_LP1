using System;

namespace Snakes_and_Ladders
{
    /// <summary>
    /// Dice class to create dices
    /// </summary>
    public class Dice
    {
        /// <summary>
        /// Variable of random
        /// </summary>
        private Random random;
        /// <summary>
        /// Variable of dice
        /// </summary>
        private int dice;

        /// <summary>
        /// Get random
        /// </summary>
        public Random Random => random;

        /// <summary>
        /// /// Constructor of dice
        /// </summary>
        public Dice()
        {
            random = new Random();
        }

        /// <summary>
        ///  Return number of the dice
        /// </summary>
        public int RollDice()
        {
            dice = random.Next(1, 7);
            return dice;
        }
    }
}