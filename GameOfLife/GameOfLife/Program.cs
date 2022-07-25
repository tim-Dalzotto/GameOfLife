using System;
using GameOfLife.Application;
using GameOfLife.Console;
using GameOfLife.Domain;
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
            var customPatternBuilder = new CustomPatternBuilder();
            var rootPath = new RootPathConstant("/GameOfLife/GameOfLife/GameOfLife/PatternFileDirectory/");
            var patternSaver = new PatternSaver(rootPath);
            var commandLineArgument = new CommandLineArgument(rootPath);
            var gameSetup = new GameSetup(input,output,riddler,customPatternBuilder, commandLineArgument, rootPath);
            
            var pattern = gameSetup.GetPatternSelection(args);

            gameSetup.SetWorldDimensions(pattern);

            if (gameSetup.CustomWorld)
                gameSetup.CreateCustomWorldPattern(pattern);
            
            world.InitialiseWorld(gameSetup.WorldHeight,gameSetup.WorldLength);
            world.LoadPatternIntoWorld(pattern);
            
            var game = new GameEngine(input, output, keyPress, pattern, world, patternSaver);
            game.RunSimulation();
        }
    }
}
