using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASCII_Invaders
{
    /// <summary>
    /// Classe <c>Logo</c> representa o logo do jogo, que é exibido na tela no início do jogo. Ela possui um método para mostrar o logo com uma animação de descida e um método para esconder o logo limpando a tela. O logo é representado como uma lista de strings, onde cada string é uma linha do logo.
    /// </summary>
    class Logo
    {
        public List<String> Image = new List<String>();

        /// <summary>
        /// Construtor da classe <c>Logo</c> inicializa a propriedade Image com as linhas do logo do jogo, que é uma representação ASCII de um invasor. Cada linha do logo é adicionada à lista Image usando o método Add. O logo é composto por caracteres que formam a imagem de um invasor, com detalhes como os olhos, a boca e os braços. O logo é projetado para ser exibido na tela no início do jogo, criando uma introdução visual para os jogadores.
        /// </summary>
        public Logo()
        {
            Image.Add("             W88888W                               d8888Wk             ");
            Image.Add("             %$$$$$%                               h$$$$B*             ");
            Image.Add("             %$$$$$%                               h$$$$B*             ");
            Image.Add("             dkkkkkoW%%%%Wh                 h8%%%%80kkkkdm             ");
            Image.Add("                   $$$$$$8a                 MB$$$$$$                   ");
            Image.Add("                   $$$$$$8a                 MB$$$$$$                   ");
            Image.Add("                   @$$$$$&o                 #B$$$$$Y                   ");
            Image.Add("             #%%%%%B$$$$$B%%%%%%%%%%%%%%%%%%%@$$$$$%%%%%&a             ");
            Image.Add("             W$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$BM             ");
            Image.Add("             W$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$BM             ");
            Image.Add("       k&&&&M%$$$$$8khhhhkB$$$$$$$$$$$$$$$$@Mphhhhk$$$$$@&&&&&&O       ");
            Image.Add("       o$$$$$$$$$$$%     O@$$$$$$$$$$$$$$$$$*     $$$$$$$$$$$$$q       ");
            Image.Add("       o$$$$$$$$$$$%     O@$$$$$$$$$$$$$$$$$*     $$$$$$$$$$$$$q       ");
            Image.Add("_<>>>><#$$$$$$$$$$$8I>>>>C@$$$$$$$$$$$$$$$$$a;>>>>]$$$$$$$$$$$$w>>>>>> ");
            Image.Add("$@$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$Wo");
            Image.Add("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$Wo");
            Image.Add("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$Wo");
            Image.Add("$$$$$$@Yddddp%$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$%hpdddd0B$$$$Wo");
            Image.Add("$$$$$$@-     B$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$%k     |%$$$$Wo");
            Image.Add("$$$$$$@-     B$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$%k     |%$$$$Wo");
            Image.Add("$$$$$$@-     B$$$$$@@$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$%$$$$%k     |%$$$$Wo");
            Image.Add("$$$$$$@-     B$$$$$%                               o$$$$%k     |%$$$$Wo");
            Image.Add("$$$$$$@-     B$$$$$%                               o$$$$%k     |%$$$$Wo");
            Image.Add("$@@@@@@-     B$@@@@%                               o@@@@8k     |%@@@@Wo");
            Image.Add("                   )&8888888888%&     w888888888888?                   ");
            Image.Add("                   /%$$$$$$$$$$$B     d$$$$$$$$$$$$Y                   ");
            Image.Add("                   /%$$$$$$$$$$$B     d$$$$$$$$$$$$Y                   ");
            Image.Add("                   {dkkkkkkkkkkkb     CkkkkkkkkkkkhQ                   ");
        }

        /// <summary>
        /// Método <c>Show</c> exibe o logo na tela com uma animação de descida. Ele percorre cada linha do logo e, para cada linha, move o texto da linha para baixo, criando um efeito visual de descida. O método utiliza a função Util.WriteAt para escrever o texto na posição correta da tela, e a função Util.Wait para criar um atraso entre cada movimento, tornando a animação mais suave. O parâmetro color permite definir a cor do texto do logo, com um valor padrão de branco.
        /// </summary>
        public void Show(ConsoleColor color = ConsoleColor.White)
        {
            // Percorre cada linha do logo e move o texto para baixo, criando uma animação de descida
            for (var line = 0; line < Image.Count; line++)
            {
                var text = Image.ElementAt(line);
                var topLimit = Constant.ScreenTop + line;
                var bottomLimit = Constant.ScreenBottom;
                // Move o texto da linha para baixo, criando um efeito visual de descida
                for (var row = bottomLimit; row > topLimit; row--)
                {
                    // Aguarda um curto período de tempo para criar a animação suave
                    Util.Wait(1);
                    // Limpa a linha anterior para evitar sobreposição de texto
                    if (row > topLimit && row < bottomLimit)
                    {
                        // Escreve uma linha em branco para limpar a linha anterior
                        Util.WriteAt(0, row + 1, string.Concat(Enumerable.Repeat(" ", 80)));
                    }
                    // Escreve o texto da linha atual na posição correta da tela
                    Util.WriteAt(0, row, text, color);
                }
            }
        }

        /// <summary>
        /// Método <c>Hide</c> limpa a tela para esconder o logo. Ele percorre cada linha do logo e escreve uma linha em branco na posição correspondente, efetivamente apagando o logo da tela. O método utiliza a função Util.WriteAt para escrever as linhas em branco, criando um efeito de limpeza da tela. O método é chamado quando o logo precisa ser removido da tela, como após a introdução do jogo ou quando o jogador inicia uma nova partida.
        /// </summary>
        public void Hide()
        {
            // Percorre cada linha do logo e escreve uma linha em branco para limpar a tela
            for (var line = 0; line <= Image.Count; line++)
            {
                // Aguarda um curto período de tempo para criar uma transição suave ao limpar a tela
                Util.Wait(10);
                // Escreve uma linha em branco para limpar a linha correspondente do logo
                Util.WriteAt(0, line, string.Concat(Enumerable.Repeat(" ", 80)));
            }
        }
    }
}
