using System;

﻿namespace ASCII_Invaders
{
    /// <summary>
    /// Classe <c>Program</c> é a classe principal do jogo ASCII Invaders. Ela contém a propriedade estática <c>PlaySound</c>, que indica se os sons do jogo devem ser reproduzidos, e o método <c>Main</c>, que é o ponto de entrada do programa. O método <c>Main</c> limpa a tela, define a codificação de saída para Unicode e inicia o jogo criando uma instância da classe <c>Game</c> e chamando seu método <c>Run</c>.
    /// </summary>
    class Program
    {
        public static bool PlaySound { get; set; }

        /// <summary>
        /// Método <c>Main</c> é o ponto de entrada do programa. Ele limpa a tela, define a codificação de saída para Unicode e inicia o jogo criando uma instância da classe <c>Game</c> e chamando seu método <c>Run</c>.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {            
            Console.Clear();

            // Define a codificação de saída para Unicode para suportar caracteres especiais usados no jogo.
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            // Inicia o jogo criando uma instância da classe Game e chamando seu método Run.
            new Game().Run();
        }
    }
}
