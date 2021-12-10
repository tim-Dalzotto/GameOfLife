using System;
using System.Collections.Generic;
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
            world.Size = 40;
            var livingCellCoOrds = new List<string>()
            {
                "5,5","5,1","3,2","2,3","5,4","6,0","8,1","7,2","8,3","8,4","4,3","4,4","5,3","5,4"
            };
            
            string pattern1 =
                "-------------------------O----------\n" +
                "----------------------OOOO----O-----\n" +
                "-------------O-------OOOO-----O-----\n" +
                "------------O-O------O--O---------OO\n" +
                "-----------O---OO----OOOO---------OO\n" +
                "OO---------O---OO-----OOOO----------\n" +
                "OO---------O---OO--------O----------\n" +
                "------------O-O---------------------\n" +
                "-------------O----------------------";
            string pattern2 =
                "------\n" +
                "------\n" +
                "--OOO-\n" +
                "-OOO--\n" +
                "------\n" +
                "------";
            var boardListSetup = gameRules.splitCoOrds(livingCellCoOrds);
            var boardPatternSetup = gameRules.splitPattern(pattern1);

            var currentGeneration = gameRules.InitialiseWorld(world);
            gameRules.KillAllCells(currentGeneration);
            //gameRules.LoadListIntoWorld(livingCellCoOrds, currentGeneration);
            gameRules.LoadPatternIntoWorld(boardPatternSetup, currentGeneration);
            
            ConsoleOutput.DisplayWorld(currentGeneration);

            var count = 0;
            while (count < 100)
            {
                
                currentGeneration = game.RunNextGeneration(currentGeneration);
                ConsoleOutput.DisplayWorld(currentGeneration);
                Thread.Sleep(500);
                Console.WriteLine();
                Console.WriteLine();
                count++;
            }

        }
    }
}