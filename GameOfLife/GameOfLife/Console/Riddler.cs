using System;
using GameOfLife.Application;
using GameOfLife.Constants;
using GameOfLife.Domain;

namespace GameOfLife.ConsoleOut
{
    public class Riddler
    {
        private static WorldGenerationsInfo WorldCurrent { get; set; }

        public Riddler(WorldGenerationsInfo world)
        {
            WorldCurrent = world;
        }
        public void GetUserPatternSelection(IUserInput input, IOutput output)
        {
            var validator = false;
            var userSelectionPatternChoice = NumberConst.EmptyChoice;
            while (validator == false)
            {
                output.DisplayPatternSelectionFromFile();
                var userInputTemp = input.GetUserInput();
                if (Validator.IsNumeric(userInputTemp))
                    userSelectionPatternChoice = int.Parse(userInputTemp);
                else
                    break;
                validator = Validator.ValidatePatternSelection(userSelectionPatternChoice);
            }
            
            WorldCurrent.CellPattern = Pattern.GetSelectedPatternFromFile(userSelectionPatternChoice);
                        
        }

        public void GetUserWorldHeightSelection(IUserInput input, IOutput output)
        {
            
            output.DisplayChoiceForRowsMessage();
            var userInput = input.GetUserInput();
            WorldCurrent.Height = userInput;
        }

        public void GetUserLengthSelection(IUserInput input, IOutput output)
        {
            output.DisplayChoiceForColumnsMessage();
            var userWorldSizeSelection = input.GetUserInput();
            WorldCurrent.Length = userWorldSizeSelection;
        }
        
    }
}