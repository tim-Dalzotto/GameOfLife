using System;
using GameOfLife.Application;
using GameOfLife.Domain;
using GameOfLife.ConsoleOut;
using GameOfLife.Constants;

namespace GameOfLife
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var consoleIO = new ConsoleIO();
            var input = new ConsoleUserInput(consoleIO);
            var output = new ConsoleOutput(consoleIO);
            var keyPress = new KeyPress(consoleIO);
            var world = new World();
            var riddler = new Riddler(input,output);
            var gameSetup = new GameSetup();
            
            var pattern = gameSetup.GetPatternSelection(args, output, riddler, world);

            gameSetup.SetWorldDimensions(riddler, pattern, output);

            if (world.CustomWorld)
                gameSetup.CreateCustomWorldPattern(riddler, pattern,input,output);
            
            world.InitialiseWorld(riddler.Height,riddler.Length);
            world.LoadPatternIntoWorld(pattern);
            
            var game = new GameEngine(input, output, keyPress, pattern, world);
            game.RunSimulation();
            Environment.Exit(0);
            
        }
    }
}
