using System;

namespace ASCII_Invaders
{
    /// <summary>
    /// Classe <c>Cannon</c> representa o 'canhão' do jogador, que pode se mover horizontalmente e disparar projéteis. Ela herda de GameObject e é inicializada com um sprite específico, cor azul e posição central na parte inferior do campo de batalha.
    /// </summary>
    class Cannon : GameObject
    {
        /// <summary>
        /// Método construtor da classe <c>Cannon</c> inicializa o sprite do canhão, define a cor como azul e posiciona o canhão no centro da parte inferior do campo de batalha.
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
