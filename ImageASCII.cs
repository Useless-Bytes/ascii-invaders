using System;
using System.Collections.Generic;
using System.Linq;

namespace ASCII_Invaders
{
    class ImageASCII
    {
        public List<String> Image = new List<String>();

        /// <summary>
        /// Método <c>Show</c> exibe a imagem
        /// </summary>
        /// <param name="color"></param>
        public void Show(ConsoleColor color = ConsoleColor.White)
        {
            for (var line = 0; line < Image.Count; line++)
            {
                Util.WriteAt(8, 3 + line, Image.ElementAt(line), color);
                Util.Wait(1);
            }
        }

        /// <summary>
        /// Método <c>Hide</c> apaga a imagem
        /// </summary>
        public void Hide()
        {
            for (var line = 0; line < Image.Count; line++)
            {
                Util.WriteAt(Constant.BattleFieldLeft, 3 + line, Util.Repeat(" ", Constant.BattleFieldWidth));
                Util.Wait(1);
            }
        }

    }
}
