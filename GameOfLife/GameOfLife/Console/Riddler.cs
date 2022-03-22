using System;
using GameOfLife.Application;
using GameOfLife.Constants;
using GameOfLife.Domain;

namespace GameOfLife.ConsoleOut
{
    public static class Riddler
    {
        
        public static string[] GetUserPatternSelection(IUserInput input, IOutput output)
        {
            var validator = false;
            var userSelectionPatternChoice = NumberConst.EmptyChoice;
            while (validator == false)
            {
                output.DisplayPatternSelection();
                var userInputTemp = input.GetUserInput();
                if (Validator.IsNumeric(userInputTemp))
                    userSelectionPatternChoice = Int32.Parse(userInputTemp);
                else
                    break;
                validator = Validator.ValidatePatternSelection(userSelectionPatternChoice, Pattern.PatternList);
            }
            
            //var testInput = 
            return Pattern.GetSelectedPattern(userSelectionPatternChoice);
                        
        }

        public static string GetUserWorldHeightSelection(IUserInput input, IOutput output)
        {
            
            output.DisplayChoiceForRowsMessage();
            var userInput = input.GetUserInput();
            return userInput;
        }

        public static string GetUserLengthSelection(IUserInput input, IOutput output)
        {
            output.DisplayChoiceForColumnsMessage();
            var userWorldSizeSelection = input.GetUserInput();
            return userWorldSizeSelection;
        }
        
    }
}