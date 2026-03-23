using System;

namespace ASCII_Invaders
{
    /// <summary>
    /// Classe <c>BattleField</c> é a classe responsável por desenhar o campo de batalha, as telas de início, vitória e derrota, além de mostrar mensagens e atualizar a barra de status do jogo.
    /// </summary>
    class BattleField
    {
        /// <summary>
        /// Método <c>Draw</c> desenha o campo de batalha, com as bordas, o título do jogo e a barra de status.
        /// </summary>
        public void Draw()
        {
            Util.WriteAt(0, 0, "┍━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┑");
            Util.WriteAt(0, 1, "│                  ASCII INVADERS                  │");
            Util.WriteAt(0, 2, "├━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┤");
            for (int row = Constant.BattleFieldTop; row <= Constant.BattleFieldBottom; row++)
            {
                Util.WriteAt(0, row, "│                                                  │");
            }
            Util.WriteAt(0, Constant.BattleFieldBottom + 1, "├━━━━━━━━━┮━━━━━━━┮━━━━━━━━━━━━━┮━━━━━━━━━━━━━━━━━━┤");
            Util.WriteAt(0, Constant.BattleFieldStatusBar,  "│Sound:on │Level: │Score:       │Best Score:       │");
            Util.WriteAt(0, Constant.BattleFieldStatusBar + 1, "┖━━━━━━━━━┶━━━━━━━┶━━━━━━━━━━━━━┶━━━━━━━━━━━━━━━━━━┙");
        }

        /// <summary>
        /// Limpa uma linha do campo de batalha, escrevendo espaços em branco nela
        /// </summary>
        /// <param name="row">Número da linha</param>
        public void ClearLine(int row)
        {
            Util.WriteAt(1, row, Util.Repeat(" ", 80));
        }

        /// <summary>
        /// Mostra a tela de vitória, com uma animação de descida do texto "Congratulations"
        /// </summary>
        public void Congratulations()
        {
            for (var row = Constant.BattleFieldBottom - 8; row > Constant.BattleFieldTop; row--)
            {
                Util.WriteAt(7, row, "╔═══╗                     ╔╗     ", ConsoleColor.Red);
                Util.WriteAt(7, row + 1, "║╔═╗║                    ╔╝╚╗    ", ConsoleColor.Red);
                Util.WriteAt(7, row + 2, "║║ ╚╝╔══╗╔═╗ ╔══╗╔═╗╔══╗ ╚╗╔╝╔══╗", ConsoleColor.Red);
                Util.WriteAt(7, row + 3, "║║ ╔╗║╔╗║║╔╗╗║╔╗║║╔╝╚ ╗║  ║║ ║══╣", ConsoleColor.Red);
                Util.WriteAt(7, row + 4, "║╚═╝║║╚╝║║║║║║╚╝║║║ ║╚╝╚╗ ║╚╗╠══║", ConsoleColor.Red);
                Util.WriteAt(7, row + 5, "╚═══╝╚══╝╚╝╚╝╚═╗║╚╝ ╚═══╝ ╚═╝╚══╝", ConsoleColor.Red);
                Util.WriteAt(7, row + 6, "             ╔═╝║                ", ConsoleColor.Red);
                Util.WriteAt(7, row + 7, "             ╚══╝                ", ConsoleColor.Red);
                ClearLine(row + 8);
                Util.Wait(Constant.OneSecond / 10);
            }
            Util.Wait(Constant.OneSecond * 3);
            ClearBattleField();
        }

        /// <summary>
        /// Mostra a tela de início do jogo, com uma animação de descida do texto "ASCII Invaders"
        /// </summary>
        public void ShowSplashScreen()
        {
            for (var row = Constant.BattleFieldBottom - 13; row > Constant.BattleFieldTop; row--)
            {
                Util.WriteAt(7, row, "╔═══╗        ╔══╗╔══╗", ConsoleColor.Red);
                Util.WriteAt(7, row + 1, "║╔═╗║        ╚╣╠╝╚╣╠╝", ConsoleColor.Red);
                Util.WriteAt(7, row + 2, "║║ ║║╔══╗╔══╗ ║║  ║║ ", ConsoleColor.Red);
                Util.WriteAt(7, row + 3, "║╚═╝║║══╣║╔═╝ ║║  ║║ ", ConsoleColor.Red);
                Util.WriteAt(7, row + 4, "║╔═╗║╠══║║╚═╗╔╣╠╗╔╣╠╗", ConsoleColor.Red);
                Util.WriteAt(7, row + 5, "╚╝ ╚╝╚══╝╚══╝╚══╝╚══╝", ConsoleColor.Red);
                Util.WriteAt(7, row + 6, "       ╔══╗               ╔╗           ", ConsoleColor.Red);
                Util.WriteAt(7, row + 7, "       ╚╣╠╝               ║║           ", ConsoleColor.Red);
                Util.WriteAt(7, row + 8, "        ║║ ╔═╗ ╔╗╔╗╔══╗ ╔═╝║╔══╗╔═╗╔══╗", ConsoleColor.Red);
                Util.WriteAt(7, row + 9, "        ║║ ║╔╗╗║╚╝║╚ ╗║ ║╔╗║║╔╗║║╔╝║══╣", ConsoleColor.Red);
                Util.WriteAt(7, row + 10, "       ╔╣╠╗║║║║╚╗╔╝║╚╝╚╗║╚╝║║║═╣║║ ╠══║", ConsoleColor.Red);
                Util.WriteAt(7, row + 11, "       ╚══╝╚╝╚╝ ╚╝ ╚═══╝╚══╝╚══╝╚╝ ╚══╝", ConsoleColor.Red);
                Util.WriteAt(7, row + 12, "               alovasconcelos.github.io", ConsoleColor.DarkBlue);
                ClearLine(row + 13);
                Util.Wait(Constant.OneSecond / 10);
            }
            Util.Wait(Constant.OneSecond * 3);
            ClearBattleField();
        }

        /// <summary>
        /// Tela de game over, com uma animação de descida do texto "Game Over" e a pontuação final do jogador
        /// </summary>
        /// <param name="score">Placar</param>
        public void GameOver(int score)
        {
            ClearBattleField();
            for (var row = Constant.BattleFieldBottom - 12; row > Constant.BattleFieldTop; row--)
            {
                Util.WriteAt(7, row, "╔═══╗             ", ConsoleColor.Red);
                Util.WriteAt(7, row + 1, "║╔═╗║             ", ConsoleColor.Red);
                Util.WriteAt(7, row + 2, "║║ ╚╝╔══╗ ╔╗╔╗╔══╗", ConsoleColor.Red);
                Util.WriteAt(7, row + 3, "║║╔═╗╚ ╗║ ║╚╝║║╔╗║", ConsoleColor.Red);
                Util.WriteAt(7, row + 4, "║╚╩═║║╚╝╚╗║║║║║║═╣", ConsoleColor.Red);
                Util.WriteAt(7, row + 5, "╚═══╝╚═══╝╚╩╩╝╚══╝", ConsoleColor.Red);
                Util.WriteAt(7, row + 6, "                  ╔══╗╔╗╔╗╔══╗╔═╗", ConsoleColor.Red);
                Util.WriteAt(7, row + 7, "                  ║╔╗║║╚╝║║╔╗║║╔╝", ConsoleColor.Red);
                Util.WriteAt(7, row + 8, "                  ║╚╝║╚╗╔╝║║═╣║║ ", ConsoleColor.Red);
                Util.WriteAt(7, row + 9, "                  ╚══╝ ╚╝ ╚══╝╚╝ ", ConsoleColor.Red);
                ClearLine(row + 10);
                Util.WriteAt(7, row + 11, "    Your score: " + score.ToString().PadLeft(6, '0'), ConsoleColor.Yellow);
                ClearLine(row + 12);
                Util.Wait(Constant.OneSecond / 10);
            }
            Util.Wait(Constant.OneSecond * 5);

            ClearBattleField();
        }

        /// <summary>
        /// Tela de início de cada nível, com uma animação de descida do texto "Level X", onde X é o número do nível
        /// </summary>
        /// <param name="level">Nível</param>
        public void ShowLevelSplashScreen(int level)
        {
            for (var row = Constant.BattleFieldBottom - 6; row > Constant.BattleFieldTop; row--)
            {
                Util.WriteAt(7, row, "#       ######  #    #  ######  #     ", ConsoleColor.Red);
                Util.WriteAt(7, row + 1, "#       #       #    #  #       #     ", ConsoleColor.Red);
                Util.WriteAt(7, row + 2, "#       #####   #    #  #####   #     ", ConsoleColor.Red);
                Util.WriteAt(7, row + 3, "#       #       #    #  #       #     ", ConsoleColor.Red);
                Util.WriteAt(7, row + 4, "#       #        #  #   #       #     ", ConsoleColor.Red);
                Util.WriteAt(7, row + 5, "######  ######    ##    ######  ######", ConsoleColor.Red);
                ClearLine(row + 6);
                Util.Wait(Constant.OneSecond / 10);
            }

            switch (level)
            {
                case 1:
                    Util.WriteAt(23, Constant.BattleFieldTop + 8, "  #", ConsoleColor.Yellow);
                    Util.WriteAt(23, Constant.BattleFieldTop + 9, " ##", ConsoleColor.Yellow);
                    Util.WriteAt(23, Constant.BattleFieldTop + 10, "# #", ConsoleColor.Yellow);
                    Util.WriteAt(23, Constant.BattleFieldTop + 11, "  #", ConsoleColor.Yellow);
                    Util.WriteAt(23, Constant.BattleFieldTop + 12, "  #", ConsoleColor.Yellow);
                    Util.WriteAt(23, Constant.BattleFieldTop + 13, "  #", ConsoleColor.Yellow);
                    Util.WriteAt(23, Constant.BattleFieldTop + 14, "#####", ConsoleColor.Yellow);
                    break;
                case 2:
                    Util.WriteAt(22, Constant.BattleFieldTop + 8, " ##### ", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 9, "#     #", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 10, "      #", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 11, " ##### ", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 12, "#      ", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 13, "#      ", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 14, "#######", ConsoleColor.Yellow);
                    break;
                case 3:
                    Util.WriteAt(22, Constant.BattleFieldTop + 8, " ##### ", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 9, "#     #", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 10, "      #", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 11, " ##### ", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 12, "      #", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 13, "#     #", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 14, " ##### ", ConsoleColor.Yellow);
                    break;
                case 4:
                    Util.WriteAt(22, Constant.BattleFieldTop + 8, "#     ", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 9, "#    #", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 10, "#    #", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 11, "#######", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 12, "     #", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 13, "     #", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 14, "     #", ConsoleColor.Yellow);
                    break;
                case 5:
                    Util.WriteAt(22, Constant.BattleFieldTop + 8, "#######", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 9, "#      ", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 10, "#      ", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 11, " ##### ", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 12, "      #", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 13, "#     #", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 14, " ##### ", ConsoleColor.Yellow);
                    break;
                case 6:
                    Util.WriteAt(22, Constant.BattleFieldTop + 8, " ##### ", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 9, "#     #", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 10, "#      ", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 11, "###### ", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 12, "#     #", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 13, "#     #", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 14, " ##### ", ConsoleColor.Yellow);
                    break;
                case 7:
                    Util.WriteAt(22, Constant.BattleFieldTop + 8, "#######", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 9, "#    # ", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 10, "    #  ", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 11, "   #   ", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 12, "  #    ", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 13, "  #    ", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 14, "  #    ", ConsoleColor.Yellow);
                    break;
                case 8:
                    Util.WriteAt(22, Constant.BattleFieldTop + 8, " ##### ", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 9, "#     #", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 10, "#     #", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 11, " ##### ", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 12, "#     #", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 13, "#     #", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 14, " ##### ", ConsoleColor.Yellow);
                    break;
                case 9:
                    Util.WriteAt(22, Constant.BattleFieldTop + 8, " ##### ", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 9, "#     #", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 10, "#     #", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 11, " ######", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 12, "      #", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 13, "#     #", ConsoleColor.Yellow);
                    Util.WriteAt(22, Constant.BattleFieldTop + 14, " ##### ", ConsoleColor.Yellow);
                    break;
            }
            Util.Wait(Constant.OneSecond * 2);
            ClearBattleField();
        }

        /// <summary>
        /// Limpa o campo de batalha, linha por linha, com um pequeno delay entre cada linha para criar um efeito visual de limpeza
        /// </summary>
        private void ClearBattleField()
        {
            for (var row = Constant.BattleFieldBottom; row >= Constant.BattleFieldTop; row--)
            {
                ClearLine(row);
                Util.Wait(Constant.OneSecond / 20);
            }
        }

        /// <summary>
        /// Mostra uma mensagem de confirmação no centro do campo de batalha, esperando o jogador pressionar a tecla "Y" para confirmar ou qualquer outra tecla para cancelar. Retorna true quando confirmado, false caso contrário.
        /// </summary>
        /// <param name="message">Mensagem</param>
        /// <returns>Verdadeiro quando confirmado ou falso caso contrário</returns>
        public bool Confirm(string message)
        {
            // Limpa o campo de batalha
            ClearBattleField();
            Util.WriteAt(1, 11, Util.PadCenter(message), ConsoleColor.Red);

            // Espera o jogador pressionar uma tecla e verifica se é a tecla "Y"
            var ret = Console.ReadKey(true).Key.Equals(ConsoleKey.Y);

            // Limpa a linha da mensagem
            ClearLine(11);

            return ret;
        }

        /// <summary>
        /// Pausa o jogo, mostrando uma mensagem no centro do campo de batalha e esperando o jogador pressionar qualquer tecla para continuar. Durante a pausa, o campo de batalha é limpo para evitar distrações.
        /// </summary>
        public void Pause()
        {
            // Limpa o campo de batalha
            ClearBattleField();

            // Mostra a mensagem de pausa no centro do campo de batalha
            Util.WriteAt(1, 10, Util.PadCenter("Press any key to continue"), ConsoleColor.Red);

            // Espera o jogador pressionar qualquer tecla
            Console.ReadKey(true);

            // Limpa a linha da mensagem de pausa
            ClearLine(10);
        }

        /// <summary>
        /// Mostra a barra de status do jogo, atualizando as informações de som, nível, pontuação e melhor pontuação. O status do som é mostrado como "On" ou "Off", o nível é mostrado como um número inteiro, a pontuação e a melhor pontuação são mostrados como números inteiros com 6 dígitos, preenchidos com zeros à esquerda se necessário.
        /// </summary>
        /// <param name="soundOn">Som ligado</param>
        /// <param name="level">Nível</param>
        /// <param name="score">Placar</param>
        /// <param name="bestScore">Melhor placar</param>
        public void UpdateStatusBar(bool soundOn, int level, int score, int bestScore)
        {
            Util.WriteAt(Constant.BattleFieldSoundStatusCol, Constant.BattleFieldStatusBar, soundOn ? "On " : "Off");
            Util.WriteAt(Constant.BattleFieldLevelCol, Constant.BattleFieldStatusBar, level.ToString());
            Util.WriteAt(Constant.BattleFieldScoreCol, Constant.BattleFieldStatusBar, score.ToString().PadLeft(6, '0'));
            Util.WriteAt(Constant.BattleFieldBestScoreCol, Constant.BattleFieldStatusBar, bestScore.ToString().PadLeft(6, '0'));
        }
    }
}
