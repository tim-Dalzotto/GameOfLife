using System;
using GameOfLife.Application;
using GameOfLife.Constants;
using GameOfLife.Domain;

namespace GameOfLife.ConsoleOut
{
    public class Riddler
    {
        public int Height { get; private set; }
        public int Length { get; private set; }
        public int PatternIndex { get; private set; }

        public void GetUserPatternSelection(IUserInput input, IOutput output)
        {
            var validator = false;
            var userSelectionPatternChoice = 0;
            while (!validator)
            {
                output.DisplayPatternSelectionFromFile();
                var userInputTemp = input.GetUserInput();
                if (Validator.IsNumeric(userInputTemp))
                    userSelectionPatternChoice = int.Parse(userInputTemp);
                else
                    break;
                validator = Validator.ValidateUserSelectedPatternExists(userSelectionPatternChoice, PatternLoader.GetPatternNamesFromFile());
            }

            
            
            PatternIndex = userSelectionPatternChoice;          
        }

        public void GetUserWorldHeightSelection(IUserInput input, IOutput output)
        {
            output.DisplayChoiceForRowsMessage();
            var userInput = int.Parse(input.GetUserInput());
            Height = userInput;
        }

        public void GetUserLengthSelection(IUserInput input, IOutput output)
        {
            output.DisplayChoiceForColumnsMessage();
            var userInput = int.Parse(input.GetUserInput());
            Length = userInput;
        }
        
    }
}