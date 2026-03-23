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
    class Congratulations : ImageASCII
    {

        /// <summary>
        /// Método construtor - carrega a imagem 
        /// </summary>
        public Congratulations()
        {
            Image.Add("                   @@@@@@@%#%@@@@           ");
            Image.Add("                @@@#-::--::::-=*#%@@        ");
            Image.Add("             @@#+=-:=+#%@@@@%*=-::-@@@@     ");
            Image.Add("           @@%-:*%=::::::::::::::#%-::=@@   ");
            Image.Add("          @%-:-%%::::::-%@@%-:::::=@+:=@@   ");
            Image.Add("          @#--*%:::::+@#+=+@=::::::=%--*@@  ");
            Image.Add("          @%--%=:::::%%#@#+@=:::::::#+::+@@ ");
            Image.Add("         @@=:-@-::::::--%#+@=:::::::#*:-%@  ");
            Image.Add("          @@=:*@::::::::%#+@=::::::+%-:=@@  ");
            Image.Add("           @#:-#%-::::::+@@#::::::+@=:-*@@  ");
            Image.Add("            @@%*:-+%#+-::::::=*%#=::=@@@@   ");
            Image.Add("            @@+@%-:::=*%@@@@#+-:--+#@@@@    ");
            Image.Add("          @@+=#@:..=@*@%%@@@%@@#..:@#=+%@   ");
            Image.Add("         @+=*@=:.-@+--@@   @@=-+@=.:=@*=+@  ");
            Image.Add("       @@%@@@@@@#@+-=@@     @@=-=@#@@@@@@%@@");
            Image.Add("       @@@     @@*-=%@       @@=-*@@     @@@");
            Image.Add("                @@-%@         @%-@@         ");
            Image.Add("                 @@@           @@@          ");
        }
    }
}
