using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASCII_Invaders
{
    /// <summary>
    /// Classe <c>Logo</c> representa o logo do jogo, que é exibido na tela no início do jogo. Ela possui um método para mostrar o logo com uma animação de descida e um método para esconder o logo limpando a tela. O logo é representado como uma lista de strings, onde cada string é uma linha do logo.
    /// </summary>
    class Logo : ImageASCII
    {

        /// <summary>
        /// Construtor da classe <c>Logo</c> inicializa a propriedade Image com as linhas do logo do jogo, que é uma representação ASCII de um invasor. Cada linha do logo é adicionada à lista Image usando o método Add. O logo é composto por caracteres que formam a imagem de um invasor, com detalhes como os olhos, a boca e os braços. O logo é projetado para ser exibido na tela no início do jogo, criando uma introdução visual para os jogadores.
        /// </summary>
        public Logo()
        {                                      
             Image.Add("              ▒▒▒                ▒▒▒       "); 
             Image.Add("                 ▒▒▒          ▒▒▒          "); 
             Image.Add("                 ▒▒▒          ▒▒▒          "); 
             Image.Add("              ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒       "); 
             Image.Add("              ▒▒▒   ▒▒▒▒▒▒▒▒▒▒   ▒▒▒       "); 
             Image.Add("           ▒▒▒▒▒▒   ▒▒▒▒▒▒▒▒▒▒   ▒▒▒▒▒▒    "); 
             Image.Add("       ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒"); 
             Image.Add("       ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒"); 
             Image.Add("       ▒▒▒▒   ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒    ▒▒▒"); 
             Image.Add("       ▒▒▒▒   ▒▒▒                ▒▒▒    ▒▒▒"); 
             Image.Add("       ▒▒▒▒   ▒▒▒                ▒▒▒    ▒▒▒");
             Image.Add("                 ▒▒▒▒▒▒▒   ▒▒▒▒▒▒          "); 
        }
    }
}
