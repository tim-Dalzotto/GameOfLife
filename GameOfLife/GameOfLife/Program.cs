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
            var gameRules = new GameRules();
            var game = new Game();
            var pattern = new pattern();

            #region patterns and stuff
            
            // var livingCellCoOrds = new List<string>()
            // {
            //     "5,5","5,1","3,2","2,3","5,4","6,0","8,1","7,2","8,3","8,4","4,3","4,4","5,3","5,4"
            // };
            
            var pattern1 =
                "-------------------------O----------\n" +
                "----------------------OOOO----O-----\n" +
                "-------------O-------OOOO-----O-----\n" +
                "------------O-O------O--O---------OO\n" +
                "-----------O---OO----OOOO---------OO\n" +
                "OO---------O---OO-----OOOO----------\n" +
                "OO---------O---OO--------O----------\n" +
                "------------O-O---------------------\n" +
                "-------------O----------------------";
            var pattern2 =
                "------\n" +
                "------\n" +
                "--OOO-\n" +
                "-OOO--\n" +
                "------\n" +
                "------";
            
            #endregion
            
            ConsoleOutput.DisplayPatternSelection();
            var userSelection = Convert.ToInt32(Console.ReadLine());

            var patternTest = GameRules.GetSelectedPattern(userSelection, pattern);
            var formattedPattern = GameRules.SplitPattern(patternTest);
            var patternSize = formattedPattern[0].Length > formattedPattern.Length ? (formattedPattern[0].Length + 5): (formattedPattern.Length + 5);
            var world = new World();
            world.Height = 30;
            world.Length = 30;

            
            var gameWorld = gameRules.CreateInitialWorld(formattedPattern, world);
            
            var count = 0;
            while (count < 100)
            {
                ConsoleOutput.DisplayWorld(gameWorld);
                gameWorld = game.RunNextGeneration(gameWorld);
                Thread.Sleep(100);
                count++;
            }
        }
    }
}