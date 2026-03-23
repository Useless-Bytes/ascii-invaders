using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Threading;

﻿namespace ASCII_Invaders
{
    /// <summary>
    /// Classe <c>Util</c> contém métodos utilitários para o jogo, como escrita na tela, leitura e escrita de pontuação, espera e reprodução de sons.
    /// </summary>
    public static class Util
    {
        public static string exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        private static readonly Random _random = new Random();

        /// <summary>
        /// Método <c>WriteAt</c> escreve um conteúdo em uma posição específica da tela, com uma cor opcional.
        /// </summary>
        /// <param name="col">Número da coluna (iniciando em 0)</param>
        /// <param name="row">Número da linha (iniciando em 0)</param>
        /// <param name="content">Conteúdo a ser impresso na tela</param>
        /// <param name="color">Cor opcional (branco se não for passada outra cor)</param>
        public static void WriteAt(int col, int row, string content, ConsoleColor color = ConsoleColor.White)
        {
            Console.SetCursorPosition(Constant.ScreenLeft + col, Constant.ScreenTop + row);

            Console.ForegroundColor = color;
            Console.Write(content);
            Console.ResetColor();
        }

        /// <summary>
        /// Método <c>Repeat</c> repete um texto um certo número de vezes, retornando a string resultante.
        /// </summary>
        /// <param name="text">Texto a ser repetido</param>
        /// <param name="count">Quantidade de vezes para reperir o texto</param>
        /// <returns>String com o texto repetido</returns>
        public static string Repeat(string text, int count)
        {
            return string.Concat(Enumerable.Repeat(text, count));
        }

        /// <summary>
        /// Método <c>ReadBestScore</c> lê a melhor pontuação do arquivo "score.dat" e retorna como um inteiro. Se o arquivo não existir, retorna 0.
        /// </summary>
        /// <returns>Best score</returns>
        public static int ReadBestScore()
        {
            if (File.Exists("score.dat"))
            {
                using (TextReader tr = File.OpenText(Constant.ScoreFile))
                {
                    var fileContent = tr.ReadToEnd();
                    return int.Parse(fileContent);
                }
            }        
            return 0;
        }

        /// <summary>
        /// Método <c>WriteBestScore</c> escreve a melhor pontuação no arquivo "score.dat", sobrescrevendo o conteúdo anterior.
        /// </summary>
        /// <param name="score">Melhor pontuação</param>
        public static void WriteBestScore(int score)
        {
            using (StreamWriter outputFile = new StreamWriter(Constant.ScoreFile))
            {
                outputFile.WriteLine(score);
            }
        }

        /// <summary>
        /// Método <c>Wait</c> pausa a execução do programa por um determinado número de milissegundos, usando Thread.Sleep.
        /// </summary>
        /// <param name="milliseconds">Duração da espera (em milissegundos)</param>
        public static void Wait(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }
        
        /// <summary>
        /// Método <c>PadCenter</c> retorna string com texto ajustado no centro
        /// </summary>
        /// <param name="text">Texto a ser ajustado</param>
        /// <param name="length">Comprimento do texto - 50 se não for passado outro valor</param>
        /// <returns>Texto ajustado ao centro</returns>
        public static string PadCenter(string text, int length = 50)
        {
            int spc = length - text.Length;
            int padl = spc / 2 + text.Length;
            return text.PadLeft(padl).PadRight(length);
        }

        /// <summary>
        /// Método <c>PlayWavFile</c> reproduz um arquivo de som WAV usando a classe SoundPlayer. O método verifica se a reprodução de som está habilitada antes de tentar tocar o arquivo.
        /// </summary>
        /// <param name="file">Arquivo de som a ser reproduzido</param>
        public static void PlayWavFile(Stream file)
        {
            if (!Program.PlaySound)
            {
                return;
            }
            // Cria um novo SoundPlayer
            using (SoundPlayer player = new SoundPlayer(file))
            {
                // Usa PlaySync para tocar o som de forma síncrona, garantindo que o método aguarde a reprodução completa do som antes
                player.Play();
            }
        }

        /// <summary>
        /// Método <c>GetConsoleColors</c> retorna lista das cores disponíveis no console
        /// </summary>
        /// <returns></returns>
        public static List<ConsoleColor> GetConsoleColors()
        {
            return Enum.GetValues(typeof(ConsoleColor))
                       .Cast<ConsoleColor>()
                       .ToList();
        }

        public static Position GetRandomEnemyPosition()
        {
            var x = _random.Next(0, Constant.EnemiesPerRow + 1);
            var y = _random.Next(0, Constant.EnemiesRows + 1);
            return new Position(x, y);
        }
    }
}
