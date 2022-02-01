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
            var world = new World();
            var gameRules = new GameRules();
            var game = new Game();
            var pattern = new pattern();

            var size = 40;

            #region patterns and shit
            
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

            var gameWorld = gameRules.CreateInitialWorld(userSelection, pattern);
            //initialiseWorld
            var currentGeneration = gameRules.InitialiseWorld(world, size);
            //gameRules.KillAllCells(currentGeneration);
            
            
            //format a pattern
            var boardPatternSetup = gameRules.splitPattern(pattern.patternShip());

            //load Pattern this should
            //gameRules.LoadListIntoWorld(livingCellCoOrds, currentGeneration);
            gameRules.LoadPatternIntoWorld(boardPatternSetup, currentGeneration);
            
            //display world
            ConsoleOutput.DisplayWorld(currentGeneration);
            //run Game of life.
            
            var count = 0;
            while (count < 100)
            {
                gameWorld = game.RunNextGeneration(gameWorld);
                ConsoleOutput.DisplayWorld(gameWorld);
                Console.WriteLine();
                Console.WriteLine();
                Thread.Sleep(100);

                count++;
            }
            // var count = 0;
            // while (count < 300)
            // {
            //     currentGeneration = game.RunNextGeneration(currentGeneration);
            //     ConsoleOutput.DisplayWorld(currentGeneration);
            //     Console.WriteLine();
            //     Console.WriteLine();
            //     Thread.Sleep(100);
            //
            //     count++;
            // }

        }
    }
}