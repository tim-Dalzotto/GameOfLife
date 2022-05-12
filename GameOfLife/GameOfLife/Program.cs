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
            var pattern = new Pattern();
            var game = new GameEngine(input, output, keyPress, pattern);
            var worldGenInfo = new WorldGenerationsInfo();
            var world = new World();
            var riddler = new Riddler(world);

            string[] patternInput;
            

            if (args.Length > 0 && Validator.ValidCmdLineArgumentIsValidPatternName(output, args[0]))
            {
                world.Pattern = CommandLineArguments.GetPatternFromCmdLineArguments(args[0]);
            }
            else
            {
                riddler.GetUserPatternSelection(input, output);
                
                world.Pattern = PatternLoader.GetSelectedPatternFromFile(world.PatternIndex);
            }

            var worldMinRowRequiredBasedOnSelectedPattern = world.Pattern.Length;
            var worldMinColumnsRequiredBasedOnSelectedPattern = world.Pattern[0].Length;
            output.DisplayGameBoardSizeSelectionMessage( worldMinRowRequiredBasedOnSelectedPattern,worldMinColumnsRequiredBasedOnSelectedPattern);


            var validInput = false;
            while (!validInput)
            { 
                riddler.GetUserWorldHeightSelection(input, output);
                validInput = Validator.WorldSizeValidator(output, world.Height.ToString(), worldMinRowRequiredBasedOnSelectedPattern);
            }

            validInput = false;
            while (!validInput)
            { 
                riddler.GetUserLengthSelection(input, output);
                validInput = Validator.WorldSizeValidator(output, world.Length.ToString(), worldMinColumnsRequiredBasedOnSelectedPattern);
            }

            if (world.CustomWorld)
            {
                var worldBuilder = new CustomWorldBuilder(world.Height, world.Length);
                worldBuilder.MakePattern(input,output);
                world.Pattern = worldBuilder.ConvertedCustomPattern;
            }
            game.PlayGame(world);
            
        }
    }
}