using System;

namespace ASCII_Invaders
{
    /// <summary>
    /// Classe <c>Constant</c> contém as constantes usadas no jogo, como as dimensões do campo de batalha, o número de inimigos, os sons e o arquivo de pontuação.
    /// </summary>
    public static class Constant
    {
        public static readonly int ScreenTop = Console.CursorTop;
        public static readonly int ScreenBottom = Console.WindowHeight - 1;
        public static readonly int ScreenLeft = Console.CursorLeft;
        public static readonly int ScreenRight = Console.WindowWidth - 1;

        public static readonly int BattleFieldLeft = 1;
        public static readonly int BattleFieldTop = 3;
        public static readonly int BattleFieldBottom = 20;
        public static readonly int BattleFieldWidth = 50;
        public static readonly int BattleFieldStatusBar = 22;
        public static readonly int BattleFieldSoundStatusCol = 7;
        public static readonly int BattleFieldLevelCol = 17;
        public static readonly int BattleFieldScoreCol = 26;
        public static readonly int BattleFieldBestScoreCol = 45;

        public static readonly int Cannons = 3;
        public static readonly int OneSecond = 1000;
        public static readonly int FinalLevel = 9;
        public static readonly int EnemiesPerRow = 7;
        public static readonly int EnemiesRows = 5;
        public static readonly int PlayerBullets = 2;
        public static readonly int EnemiesBullets = 10;
        public static readonly int EnemiesTimer = 10;        

        public static readonly int DirectionUp = 0;
        public static readonly int DirectionDown = 1;

        public static readonly string ShotSound = "hitHurt.wav";
        public static readonly string ExplosionSound = "explosion.wav";
        public static readonly string ScoreFile = "score.dat";
    }
}