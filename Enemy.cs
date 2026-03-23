using System;

namespace ASCII_Invaders
{
    /// <summary>
    /// Classe <c>Enemy</c> representa um inimigo no jogo. Ela herda de GameObject e possui um método para destruir o inimigo, que exibe uma animação de destruição antes de limpar o inimigo da tela e torná-lo invisível.
    /// </summary>
    class Enemy : GameObject
    {
        public bool IsShooting { get; set; }

        /// <summary>
        /// Construtor da classe <c>Enemy</c> inicializa o sprite do inimigo como um emoji de alienígena, define a cor como verde e deixa as posições padrão para serem definidas posteriormente.
        /// </summary>
        public Enemy() 
        {
            Sprite = "👾";
            IsShooting = false;
        }

        /// <summary>
        /// Método <c>Destroy</c> exibe uma animação de destruição do inimigo, alternando as cores do sprite para criar um efeito visual. Após a animação, o método limpa o sprite da tela e torna o inimigo invisível.
        /// </summary>
        public void Destroy()
        {
            Sprite = "#";
            Draw();
            Util.Wait(50);
            Sprite = "*";
            Draw();
            Util.Wait(50);
            Sprite = ".";
            Draw();
            Util.Wait(50);
            Sprite = "#";
            Draw();
            Util.Wait(10);
            Clear();
            Visible = false;
        }

        /// <summary>
        /// Método <c>Shoot</c> dispara projéteis
        /// </summary>
        public void Shoot()
        {
            IsShooting = true;

        }
    }
}