using System;
using System.Linq;

namespace ASCII_Invaders
{
    /// <summary>
    /// Classe <c>GameObject</c> representa um objeto genérico no jogo, com propriedades para sprite, posição, visibilidade e cor. Ela possui métodos para desenhar, limpar e mover o objeto na tela.
    /// </summary>
    public class GameObject
    {
        public string Sprite { get; set; }
        public Position Position { get; set; }
        public Position PreviousPosition { get; set; }
        public bool Visible { get; set; }
        public ConsoleColor Color { get; set; }

        /// <summary>
        /// Construtor da classe <c>GameObject</c> inicializa o sprite como um espaço em branco, define as posições como (0, 0), torna o objeto visível e define a cor como branco.
        /// </summary>
        public GameObject()
        {
            Sprite = " ";
            Position = new Position(0, 0);
            PreviousPosition = new Position(0, 0);
            Visible = true;
            Color = ConsoleColor.White;
        }

        /// <summary>
        /// Método <c>Draw</c> desenha o objeto na tela. Se o objeto for visível, ele limpa a posição anterior (se houver) e desenha o sprite na posição atual usando a cor definida. Em seguida, atualiza a posição anterior para a posição atual.
        /// </summary>
        public void Draw()
        {
            // Desenha o objeto apenas se ele for visível
            if (Visible)
            {
                // Se a posição anterior for válida (X > 0), limpa o sprite na posição anterior
                if (PreviousPosition.X > 0)
                {
                    // Limpa o sprite na posição anterior escrevendo um espaço em branco
                    Util.WriteAt(PreviousPosition.X, PreviousPosition.Y, " ");
                }
                // Desenha o sprite na posição atual usando a cor definida
                Util.WriteAt(Position.X, Position.Y, Sprite, Color);
                // Atualiza a posição anterior para a posição atual
                PreviousPosition.SetPosition(Position);
            }
        }

        /// <summary>
        /// Método <c>Clear</c> limpa o sprite do objeto da tela. Se o objeto for visível, ele escreve um espaço em branco na posição atual para remover o sprite da tela.
        /// </summary>
        public void Clear()
        {
            // Limpa o sprite do objeto da tela apenas se ele for visível
            if (Visible)
            {
                // Escreve um espaço em branco na posição atual para limpar o sprite da tela
                Util.WriteAt(Position.X, Position.Y, " ");
            }
        }

        /// <summary>
        /// Método <c>MoveLeft</c> move o objeto para a esquerda. Ele chama o método MoveLeft da posição atual para atualizar a posição do objeto e, em seguida, chama o método Draw para redesenhar o objeto na nova posição.
        /// </summary>
        public void MoveLeft()
        {
            Position.MoveLeft();
        }

        /// <summary>
        /// Método <c>MoveRight</c> move o objeto para a direita. Ele chama o método MoveRight da posição atual para atualizar a posição do objeto e, em seguida, chama o método Draw para redesenhar o objeto na nova posição.
        /// </summary>
        public void MoveRight()
        {
            Position.MoveRight();
        }

        /// <summary>
        /// ´Método <c>MoveUp</c> move o objeto para cima. Ele chama o método MoveUp da posição atual para atualizar a posição do objeto e, em seguida, chama o método Draw para redesenhar o objeto na nova posição.
        /// </summary>
        public void MoveUp()
        {
            Position.MoveUp();
        }

        /// <summary>
        /// Método <c>MoveDown</c> move o objeto para baixo. Ele chama o método MoveDown da posição atual para atualizar a posição do objeto e, em seguida, chama o método Draw para redesenhar o objeto na nova posição.
        /// </summary>
        public void MoveDown()
        {
            Position.MoveDown();
        }
    }
}
