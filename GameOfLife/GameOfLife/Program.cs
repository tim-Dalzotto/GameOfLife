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
            var gameRules = new PatternLogic();
            var game = new Game();
            var pattern = new pattern();

            // #region patterns and stuff
            //
            // // var livingCellCoOrds = new List<string>()
            // // {
            // //     "5,5","5,1","3,2","2,3","5,4","6,0","8,1","7,2","8,3","8,4","4,3","4,4","5,3","5,4"
            // // };
            //
            // var pattern1 =
            //     "-------------------------O----------\n" +
            //     "----------------------OOOO----O-----\n" +
            //     "-------------O-------OOOO-----O-----\n" +
            //     "------------O-O------O--O---------OO\n" +
            //     "-----------O---OO----OOOO---------OO\n" +
            //     "OO---------O---OO-----OOOO----------\n" +
            //     "OO---------O---OO--------O----------\n" +
            //     "------------O-O---------------------\n" +
            //     "-------------O----------------------";
            // var pattern2 =
            //     "------\n" +
            //     "------\n" +
            //     "--OOO-\n" +
            //     "-OOO--\n" +
            //     "------\n" +
            //     "------";
            //
            // #endregion
            //
            ConsoleOutput.DisplayPatternSelection();
            var userSelectionPatternchoice = Convert.ToInt32(Console.ReadLine());

            var patternTest = PatternLogic.GetSelectedPattern(userSelectionPatternchoice, pattern);
            var formattedPattern = PatternLogic.SplitPattern(patternTest);
            //use this to set a min requirements for custom world size
            var patternWorldRestrictions = (formattedPattern[0].Length, formattedPattern.Length);

            Console.WriteLine($"Select the size of the game board you would like to use, min requirements for selected pattern is {patternWorldRestrictions.Item2.ToString()}X{patternWorldRestrictions.Item1.ToString()}");
            Console.WriteLine("How many rows would you like?");
            var userSelectionHeight = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many columns would you like?");
            var userSelectionLength = Convert.ToInt32(Console.ReadLine());
            
            var world = new World();
            world.Height = userSelectionHeight;
            world.Length = userSelectionLength;

            
            var gameWorld = GameRules.CreateInitialWorld(formattedPattern, world);
            
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