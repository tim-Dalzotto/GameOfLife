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
            var input = new ConsoleUserInput();
            var output = new ConsoleOutput();
            var game = new GameEngine(input, output);

            var patternInput = Riddler.GetUserPatternSelection(input, output);
            
            var worldMinRowRequiredBasedOnSelectedPattern = patternInput.Length;
            var worldMinColumnsRequiredBasedOnSelectedPattern = patternInput[0].Length;
            output.DisplayGameBoardSizeSelectionMessage( worldMinRowRequiredBasedOnSelectedPattern,worldMinColumnsRequiredBasedOnSelectedPattern);


            var validInput = false;
            string heightInput = null;
            while (!validInput)
            { 
                heightInput = Riddler.GetUserWorldHeightSelection(input, output);
                validInput = Validator.WorldSizeValidator(output, heightInput, worldMinColumnsRequiredBasedOnSelectedPattern);
            }
            //var heightInput = Riddler.GetUserWorldSizeSelection(input, output, worldMinColumnsRequiredBasedOnSelectedPattern);
            
            string lengthInput = null;
            validInput = false;
            while (!validInput)
            { 
                lengthInput = Riddler.GetUserLengthSelection(input, output);
                validInput = Validator.WorldSizeValidator(output, lengthInput, worldMinColumnsRequiredBasedOnSelectedPattern);
            }

            
            game.PlayGame(patternInput,int.Parse(heightInput),int.Parse(lengthInput));
            
        }
    }
}