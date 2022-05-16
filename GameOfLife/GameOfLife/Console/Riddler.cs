using System;
using GameOfLife.Application;
using GameOfLife.Constants;
using GameOfLife.Domain;

namespace GameOfLife.ConsoleOut
{
    public class Riddler
    {
        private static World WorldCurrent { get; set; }

        public Riddler(World world)
        {
            WorldCurrent = world;
        }
        public void GetUserPatternSelection(IUserInput input, IOutput output, Pattern pattern)
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

            if (userSelectionPatternChoice == PatternLoader.GetPatternNamesFromFile().Length + 1)
                WorldCurrent.CustomWorld = true;
            
            pattern.CurrentPattern= PatternLoader.GetSelectedPatternFromFile(userSelectionPatternChoice);          
        }

        public void GetUserWorldHeightSelection(IUserInput input, IOutput output)
        {
            output.DisplayChoiceForRowsMessage();
            var userInput = int.Parse(input.GetUserInput());
            WorldCurrent.Height = userInput;
        }

        public void GetUserLengthSelection(IUserInput input, IOutput output)
        {
            output.DisplayChoiceForColumnsMessage();
            var userInput = int.Parse(input.GetUserInput());
            WorldCurrent.Length = userInput;
        }
        
    }
}