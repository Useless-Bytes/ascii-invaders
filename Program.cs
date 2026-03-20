using System;

﻿namespace ASCII_Invaders
{
    /// <summary>
    /// Class <c>Program</c> is the entry point of the game
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            new Game().Run();
        }
    }
}
