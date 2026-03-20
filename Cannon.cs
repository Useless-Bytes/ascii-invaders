using System;

namespace ASCII_Invaders
{
    /// <summary>
    /// Class <c>Cannon</c> is the class for the cannon game object
    /// </summary>
    class Cannon : GameObject
    {
        /// <summary>
        /// Method <c>constructor</c>
        /// </summary>
        public Cannon()
        {
            Color = ConsoleColor.Blue;
            Sprite = "🤖";
            Position = new Position((Constant.BattleFieldWidth - 2) / 2 - 1, Constant.BattleFieldBottom);
            PreviousPosition = new Position((Constant.BattleFieldWidth - 2) / 2 - 1, Constant.BattleFieldBottom);
        }
    }
}
