using System.IO;
using System.Linq;
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

        public static bool ValidateUserSelectedPatternExists(int userInput, string[] listOfAvailablePatterns)
        {
            return listOfAvailablePatterns.Length + 1 >= userInput && userInput > 0;
        }

        public static bool ValidateIfIsNumeric(string userInput)
        {
            var isNumeric = int.TryParse(userInput, out _);
            return isNumeric;
        }

        public static bool ValidateWorldSize(IOutput output, string input, int minWorldCapacity)
        {
            int intInput;
            var userInputTemp = input;
            if (ValidateIfIsNumeric(userInputTemp))
                intInput = int.Parse(userInputTemp);
            else
            {
                output.DisplayMessage(ValidationConstants.ErrorNotAnInt);
                return false;
            }
            
            var validator = ValidateUserInputBiggerThanMinRequirements(minWorldCapacity, intInput);

            if (validator == false)
                output.DisplayMessage(ValidationConstants.ErrorNotAValidPatternSelection);
            else
                return true;
            return false;
        }


        public static bool ValidateCmdLineArgument(IOutput output, string patternName, string[] listOfPatternNames)
        {
            
            var patternExistsInFile = false;
            if (File.Exists(patternName))
            {
                return true;
            }
            
            foreach (var patternInFile in listOfPatternNames)
            {
                if (patternName == Path.GetFileName(patternInFile))
                    patternExistsInFile = true;
            }

            if (patternExistsInFile == false)
            {
                output.DisplayMessage(patternName);
                output.DisplayMessage(ValidationConstants.FileDoesNotExist);
            }
                
            return patternExistsInFile;
        }

        public static bool ValidateCharFromListOfChars(string userInput, string allowedChars)
        {
            return userInput.All(allowedChars.Contains) && userInput.Length == 1;
        }
    }
}