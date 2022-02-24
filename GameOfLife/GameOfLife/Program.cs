using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using GameOfLife.Application;
using GameOfLife.Domain;
using GameOfLife.ConsoleOut;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new ConsoleUserInput();
            var output = new ConsoleOutput();
            var game = new GameEngine(input, output);
            
            game.PlayGame();
        }
    }
}