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
            var keyPress = new ConsoleKeyPress(new ConsoleIO());
            var game = new GameEngine(input, output, keyPress);
            var worldGenInfo = new WorldGenerationsInfo();
            var riddler = new Riddler(worldGenInfo);

            string[] patternInput;
            

            if (args.Length > 0 && Validator.ValidCmdLineArgumentIsValidPatternName(output, args[0]))
            {
                patternInput = CommandLineArguments.GetPatternFromCmdLineArguments(args[0]);
            }
            else
            {
                riddler.GetUserPatternSelection(input, output);
                patternInput = worldGenInfo.CellPattern;
            }
            //patternInput = Riddler.GetUserPatternSelection(input, output);

            var worldMinRowRequiredBasedOnSelectedPattern = patternInput.Length;
            var worldMinColumnsRequiredBasedOnSelectedPattern = patternInput[0].Length;
            output.DisplayGameBoardSizeSelectionMessage( worldMinRowRequiredBasedOnSelectedPattern,worldMinColumnsRequiredBasedOnSelectedPattern);


            var validInput = false;
            while (!validInput)
            { 
                riddler.GetUserWorldHeightSelection(input, output);
                validInput = Validator.WorldSizeValidator(output, worldGenInfo.Height, worldMinRowRequiredBasedOnSelectedPattern);
            }
            //var heightInput = Riddler.GetUserWorldSizeSelection(input, output, worldMinColumnsRequiredBasedOnSelectedPattern);

            validInput = false;
            while (!validInput)
            { 
                riddler.GetUserLengthSelection(input, output);
                validInput = Validator.WorldSizeValidator(output, worldGenInfo.Length, worldMinColumnsRequiredBasedOnSelectedPattern);
            }

            
            game.PlayGame(patternInput,int.Parse(worldGenInfo.Height),int.Parse(worldGenInfo.Length));
            
        }
    }
}