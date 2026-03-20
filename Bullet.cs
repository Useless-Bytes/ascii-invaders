using System;

namespace ASCII_Invaders
{
    /// <summary>
    /// Class <c>Bullet</c> is the class for the bullet game object
    /// </summary>
    class Bullet : GameObject
    {
        public bool Shot { get; set; }
        /// <summary>
        /// Method <c>constructor</c>
        /// </summary>
        public Bullet()
        {
            Sprite = "🙭";
            Shot = false;
            Color = ConsoleColor.Yellow;
        }
    }
}
