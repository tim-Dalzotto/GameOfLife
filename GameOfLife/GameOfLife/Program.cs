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

            //get userinput
            
            //displayPattern
            //get pattern choice
            var patternInput = Riddler.GetUserPatternSelection(input, output);
            
            var worldMinRowRequiredBasedOnSelectedPattern = patternInput.Length;
            var worldMinColumnsRequiredBasedOnSelectedPattern = patternInput[0].Length;
            output.DisplayGameBoardSizeSelectionMessage( worldMinRowRequiredBasedOnSelectedPattern,worldMinColumnsRequiredBasedOnSelectedPattern);


            var heightInput = Riddler.GetUserHeightSelection(input, output);
            var lengthInput = Riddler.GetUserLengthSelection (input, output);


            // var worldMinRowRequiredBasedOnSelectedPattern = patternInput.Length;
            // var worldMinColumnsRequiredBasedOnSelectedPattern = patternInput[0].Length;
            // output.DisplayGameBoardSizeSelectionMessage( worldMinRowRequiredBasedOnSelectedPattern,worldMinColumnsRequiredBasedOnSelectedPattern);
            //
            
            // output.DisplayChoiceForRowsMessage();
            // var userSelectedHeight = input.GetUserInput();
            // output.DisplayChoiceForColumnsMessage();
            // var userSelectedLength = input.GetUserInput();
            //
            //create loaded world
            //var world = (heightInput, lengthInput);
            //run sim
            game.PlayGame(patternInput,heightInput,lengthInput);
            //var WorldGenInfo = game.getWorldGenInfo();
            //game.PlayGame(game.GameSetup());
        }
    }
}