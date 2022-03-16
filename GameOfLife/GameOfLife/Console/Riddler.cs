using System;
using GameOfLife.Application;
using GameOfLife.Domain;

namespace GameOfLife.ConsoleOut
{
    public static class Riddler
    {
        
        public static string[] GetUserPatternSelection(IUserInput input, IOutput output)
        {     
            output.DisplayPatternSelection();
            var userSelectionPatternChoice = input.GetUserInput();
            
            //var testInput = 
            return Pattern.GetSelectedPattern(userSelectionPatternChoice);
                        
        }

        public static int GetUserHeightSelection(IUserInput input, IOutput output)
        {
            output.DisplayChoiceForRowsMessage();
            return input.GetUserInput();
        }

        public static int GetUserLengthSelection(IUserInput input, IOutput output)
        {
            output.DisplayChoiceForColumnsMessage();
            return input.GetUserInput();
        }
        
    }
}