using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASCII_Invaders
{
    /// <summary>
    /// Class <c>Logo</c> is the class for the logo game object
    /// </summary>
    class Logo
    {
        public List<String> Image = new List<String>();

        /// <summary>
        /// Method <c>constructor</c>
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
        /// Shows the Logo screen
        /// </summary>
        public void Show(ConsoleColor color = ConsoleColor.White)
        {
            for (var line = 0; line < Image.Count; line++)
            {
                var text = Image.ElementAt(line);
                var topLimit = Constant.ScreenTop + line;
                var bottomLimit = Constant.ScreenBottom;
                for (var row = bottomLimit; row > topLimit; row--)
                {
                    Util.Wait(1);
                    if (row > topLimit && row < bottomLimit)
                    {
                        Util.WriteAt(0, row + 1, string.Concat(Enumerable.Repeat(" ", 80)));
                    }
                    Util.WriteAt(0, row, text, color);
                }
            }
        }
        /// <summary>
        /// Hides the Logo screen
        /// </summary>
        public void Hide()
        {
            for (var line = 0; line <= Image.Count; line++)
            {
                Util.Wait(10);
                Util.WriteAt(0, line, string.Concat(Enumerable.Repeat(" ", 80)));
            }
        }
    }
}
