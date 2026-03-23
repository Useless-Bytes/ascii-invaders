using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCII_Invaders
{
    /// <summary>
    /// Class <c>Congratulations</c> apresenta a imagem da medalha para o jogador que supere o maior placar
    /// </summary>
    class Congratulations
    {
        public List<String> Image = new List<String>();

        /// <summary>
        /// Método construtor - carrega a imagem 
        /// </summary>
        public Congratulations()
        {
            Image.Add("            @@@@@@@%#%@@@@           ");
            Image.Add("         @@@#-::--::::-=*#%@@        ");
            Image.Add("      @@#+=-:=+#%@@@@%*=-::-@@@@     ");
            Image.Add("    @@%-:*%=::::::::::::::#%-::=@@   ");
            Image.Add("   @%-:-%%::::::-%@@%-:::::=@+:=@@   ");
            Image.Add("   @#--*%:::::+@#+=+@=::::::=%--*@@  ");
            Image.Add("   @%--%=:::::%%#@#+@=:::::::#+::+@@ ");
            Image.Add("  @@=:-@-::::::--%#+@=:::::::#*:-%@  ");
            Image.Add("   @@=:*@::::::::%#+@=::::::+%-:=@@  ");
            Image.Add("    @#:-#%-::::::+@@#::::::+@=:-*@@  ");
            Image.Add("     @@%*:-+%#+-::::::=*%#=::=@@@@   ");
            Image.Add("     @@+@%-:::=*%@@@@#+-:--+#@@@@    ");
            Image.Add("   @@+=#@:..=@*@%%@@@%@@#..:@#=+%@   ");
            Image.Add("  @+=*@=:.-@+--@@   @@=-+@=.:=@*=+@  ");
            Image.Add("@@%@@@@@@#@+-=@@     @@=-=@#@@@@@@%@@");
            Image.Add("@@@     @@*-=%@       @@=-*@@     @@@");
            Image.Add("         @@-%@         @%-@@         ");
            Image.Add("          @@@           @@@          ");
        }

        /// <summary>
        /// Método <c>Show</c> exibe a tela de congratulações
        /// </summary>
        /// <param name="color"></param>
        public void Show(ConsoleColor color = ConsoleColor.White)
        {
            // Percorre cada linha do logo e move o texto para baixo, criando uma animação 
            for (var line = 0; line < Image.Count; line++)
            {
                Util.WriteAt(8, 3 + line, Image.ElementAt(line), color);
                Util.Wait(1);
            }
        }
        public void Hide()
        {
            // Percorre cada linha do logo e move o texto para baixo, criando uma animação 
            for (var line = 0; line < Image.Count; line++)
            {
                Util.WriteAt(Constant.BattleFieldLeft, 3 + line, Util.Repeat(" ", Constant.BattleFieldWidth));
                Util.Wait(1);
            }
        }

    }
}
