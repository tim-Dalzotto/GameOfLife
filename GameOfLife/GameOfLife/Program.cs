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
            var input = new ConsoleUserInput(new ConsoleIO());
            var output = new ConsoleOutput(new ConsoleIO());
            var keyPress = new KeyPress(new ConsoleIO());
            Pattern pattern;
            var world = new World();
            var riddler = new Riddler();

            string[] patternInput;
            

            if (args.Length > 0 && Validator.ValidCmdLineArgumentIsValidPatternName(output, args[0]))
            {
                var absolutePath = CommandLineArguments.GetPatternFromCmdLineArguments(args[0]);
                pattern = new Pattern(PatternLoader.GetPatternFromFileArgument(absolutePath));

            }
            else
            {
                riddler.GetUserPatternSelection(input, output);
                if (riddler.PatternIndex == PatternLoader.GetPatternNamesFromFile().Length + 1)
                    world.CustomWorld = true;
                pattern = new Pattern(PatternLoader.GetSelectedPatternFromFile(riddler.PatternIndex));
                //pattern.CurrentPattern = PatternLoader.GetSelectedPatternFromFile(world.PatternIndex);
            }

            var worldMinRowRequiredBasedOnSelectedPattern = pattern.CurrentPattern.Length;
            var worldMinColumnsRequiredBasedOnSelectedPattern = pattern.CurrentPattern[0].Length;
            output.DisplayGameBoardSizeSelectionMessage( worldMinRowRequiredBasedOnSelectedPattern,worldMinColumnsRequiredBasedOnSelectedPattern);


            var validInput = false;
            while (!validInput)
            { 
                riddler.GetUserWorldHeightSelection(input, output);
                validInput = Validator.WorldSizeValidator(output, riddler.Height.ToString(), worldMinRowRequiredBasedOnSelectedPattern);
            }

            validInput = false;
            while (!validInput)
            { 
                riddler.GetUserLengthSelection(input, output);
                validInput = Validator.WorldSizeValidator(output, riddler.Length.ToString(), worldMinColumnsRequiredBasedOnSelectedPattern);
            }

            if (world.CustomWorld)
            {
                var PatternBuilder = new CustomPatternBuilder(riddler.Height, riddler.Length);
                PatternBuilder.MakePattern(input,output);
                pattern.CurrentPattern = PatternBuilder.ConvertedCustomPattern;
            }
            world.InitialiseWorld(riddler.Height,riddler.Length);
            world.LoadPatternIntoWorld(pattern);
            var game = new GameEngine(input, output, keyPress, pattern, world);
            game.PlayGame();
            
        }
    }
}
