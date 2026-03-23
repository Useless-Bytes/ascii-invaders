namespace ASCII_Invaders
{
    /// <summary>
    /// Classe <c>Position</c> representa a posição de um objeto no campo de batalha. Ela possui propriedades para as coordenadas X e Y, e métodos para mover a posição em diferentes direções (esquerda, direita, cima, baixo) e para definir uma posição absoluta. Os métodos de movimento garantem que a posição permaneça dentro dos limites do campo de batalha definidos na classe Constant. A classe Position é usada por outros objetos do jogo, como o jogador e os inimigos, para controlar suas posições na tela.
    /// </summary>
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        /// <summary>
        /// Construtor da classe <c>Position</c> inicializa as coordenadas X e Y com os valores fornecidos como parâmetros. Ele define a posição inicial de um objeto no campo de batalha, permitindo que outros objetos do jogo possam ser posicionados corretamente na tela. O construtor é chamado quando um novo objeto é criado e recebe os valores de X e Y para definir a posição inicial do objeto.
        /// </summary>
        /// <param name="x">Coluna</param>
        /// <param name="y">Linha</param>
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Método <c>MoveLeft()</c> move a posição para a esquerda, decrementando a coordenada X em 1. Ele verifica se a nova posição ainda está dentro dos limites do campo de batalha, garantindo que o objeto não se mova para fora da tela. Se a coordenada X for maior que o limite esquerdo do campo de batalha definido na classe Constant, a posição é atualizada; caso contrário, ela permanece inalterada.
        /// </summary>
        public void MoveLeft()
        {
            // Verifica se a nova posição ainda está dentro dos limites do campo de batalha
            if (X > Constant.BattleFieldLeft)
            {
                X--;
            }
        }

        /// <summary>
        /// Método <c>MoveRight()</c> move a posição para a direita, incrementando a coordenada X em 1. Ele verifica se a nova posição ainda está dentro dos limites do campo de batalha, garantindo que o objeto não se mova para fora da tela. Se a coordenada X for menor que o limite direito do campo de batalha definido na classe Constant, a posição é atualizada; caso contrário, ela permanece inalterada.
        /// </summary>
        public void MoveRight()
        {
            // Verifica se a nova posição ainda está dentro dos limites do campo de batalha
            if (X < Constant.BattleFieldWidth - 1)
            {
                X++;
            }
        }

        /// <summary>
        /// Método <c>MoveUp()</c> move a posição para cima, decrementando a coordenada Y em 1. Ele verifica se a nova posição ainda está dentro dos limites do campo de batalha, garantindo que o objeto não se mova para fora da tela. Se a coordenada Y for maior que o limite superior do campo de batalha definido na classe Constant, a posição é atualizada; caso contrário, ela permanece inalterada.
        /// </summary>
        public void MoveUp()
        {
            // Verifica se a nova posição ainda está dentro dos limites do campo de batalha
            if (Y > Constant.BattleFieldTop)
            {
                Y--;
            }
        }

        /// <summary>
        /// Método <c>MoveDown()</c> move a posição para baixo, incrementando a coordenada Y em 1. Ele verifica se a nova posição ainda está dentro dos limites do campo de batalha, garantindo que o objeto não se mova para fora da tela. Se a coordenada Y for menor que o limite inferior do campo de batalha definido na classe Constant, a posição é atualizada; caso contrário, ela permanece inalterada.
        /// </summary>
        public void MoveDown()
        {
            // Verifica se a nova posição ainda está dentro dos limites do campo de batalha
            if (Y < Constant.BattleFieldBottom)
            {
                Y++;
            }
        }

        /// <summary>
        /// Método <c>SetPosition()</c> define a posição absoluta, atualizando as coordenadas X e Y com os valores fornecidos por um objeto Position. Ele é usado para definir a posição de um objeto de forma direta, sem depender dos métodos de movimento. O método recebe um objeto Position como parâmetro e atualiza as coordenadas X e Y da posição atual com os valores correspondentes do objeto fornecido.
        /// </summary>
        /// <param name="pos">Posição do objeto</param>
        public void SetPosition(Position pos)
        {
            X = pos.X;
            Y = pos.Y;
        }
    }
}
