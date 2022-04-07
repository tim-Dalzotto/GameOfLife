using GameOfLife.ConsoleOut;
using GameOfLife.Constants;

namespace GameOfLife.Application
{
    public static class Validator
    {
        public static bool ValidateUserInputRows(int minHeight, int userInput)
        {
            return userInput >= minHeight;
        }

        public static bool ValidateUserInputBiggerThanMinRequirements(int minLength, int userInput)
        {
            return userInput >= minLength;
        }

        public static bool ValidatePatternSelection(int userInput)
        {
            return Pattern.GetPatternNamesFromFile().Length >= userInput && userInput > 0;
        }

        public static bool IsNumeric(string userInput)
        {
            var isNumeric = int.TryParse(userInput, out _);
            return isNumeric;
        }

        public static bool WorldSizeValidator(IOutput output, string input, int minWorldCapacity)
        {
            int intInput;
            var userInputTemp = input;
            if (IsNumeric(userInputTemp))
                intInput = int.Parse(userInputTemp);
            else
            {
                output.DisplayMessage(ErrorMessageConstants.ErrorNotAnInt);
                return false;
            }
            
            var validator = ValidateUserInputBiggerThanMinRequirements(minWorldCapacity, intInput);

            if (validator == false)
                output.DisplayMessage(ErrorMessageConstants.ErrorNotAValidPatternSelection);
            else
                return true;
            return false;
        }
    }
}