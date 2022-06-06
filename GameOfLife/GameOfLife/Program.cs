using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using GameOfLife.Application;
using GameOfLife.Domain;
using GameOfLife.ConsoleOut;
using GameOfLife.Constants;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new ConsoleUserInput(new ConsoleIO());
            var output = new ConsoleOutput(new ConsoleIO());
            var keyPress = new KeyPress(new ConsoleIO());
            Pattern pattern;
            var rootPath = new RootPathConstant();
            var patternLoader = new PatternLoader(rootPath);
            var commandLineArgument = new CommandLineArgument(rootPath);
            var world = new World();
            var riddler = new Riddler(input,output);
            
            
            if (args.Length > 0 && Validator.ValidateCmdLineArgument(output, args[0], patternLoader.GetPatternNamesFromFile()))
            {
                var absolutePath = commandLineArgument.GetPatternFromCmdLineArguments(args[0]);
                pattern = new Pattern(patternLoader.GetPatternFromFileArgument(absolutePath));

            }
            else
            {
                riddler.GetUserPatternSelection(patternLoader.GetPatternNamesFromFile());
                if (riddler.PatternIndex == patternLoader.GetPatternNamesFromFile().Length + 1)
                    world.CustomWorld = true;
                pattern = new Pattern(patternLoader.GetSelectedPatternFromFile(riddler.PatternIndex));
            }

            var minRowRequiredForSelectedPattern = pattern.CurrentPattern.Length;
            var minColumnsRequiredForSelectedPattern = pattern.CurrentPattern[0].Length;
            output.DisplayGameBoardSizeSelectionMessage( minRowRequiredForSelectedPattern,minColumnsRequiredForSelectedPattern);


            var validInput = false;
            while (!validInput)
            { 
                riddler.GetUserWorldHeightSelection();
                validInput = Validator.ValidateWorldSize(output, riddler.Height.ToString(), minRowRequiredForSelectedPattern);
            }

            validInput = false;
            while (!validInput)
            { 
                riddler.GetUserLengthSelection();
                validInput = Validator.ValidateWorldSize(output, riddler.Length.ToString(), minColumnsRequiredForSelectedPattern);
            }

            if (world.CustomWorld)
            {
                var patternBuilder = new CustomPatternBuilder(riddler.Height, riddler.Length);
                patternBuilder.MakePattern(input,output);
                pattern.CurrentPattern = patternBuilder.ConvertedCustomPattern;
            }
            world.InitialiseWorld(riddler.Height,riddler.Length);
            world.LoadPatternIntoWorld(pattern);
            var game = new GameEngine(input, output, keyPress, pattern, world);
            game.RunSimulation();
            
        }
    }
}
