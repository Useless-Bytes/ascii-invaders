using System;

namespace ASCII_Invaders
{
    /// <summary>
    /// Classe <c>Bullet</c> representa um projétil disparado pelo jogador ou pelos inimigos. Ela herda de GameObject e possui uma propriedade para indicar se o projétil foi disparado ou não.
    /// </summary>
    class Bullet : GameObject
    {
        public bool Shot { get; set; }

        public int Direction { get; set; }
        /// <summary>
        /// Construtor da classe <c>Bullet</c> inicializa o sprite do projétil, define que ele ainda não foi disparado e define a cor como amarelo.
        /// </summary>
        public Bullet(bool enemy = false)
        {
            Sprite = "│";
            Shot = false;
            Color = ConsoleColor.Yellow;
            Direction = Constant.DirectionUp;
            if (enemy)
            {
                Color = ConsoleColor.Red;
                Direction = Constant.DirectionDown;
            }
        }
    }
}
