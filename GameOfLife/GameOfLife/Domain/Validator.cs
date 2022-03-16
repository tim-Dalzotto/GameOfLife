using System.Collections.Generic;
using System.Reflection;

namespace GameOfLife.Domain
{
    public static class Validator
    {
        public static bool ValidateUserInputRows(int minHeight, int userInput)
        {
            return userInput >= minHeight;
        }

        public static bool ValidateUserInputColumns(int minLength, int userInput)
        {
            return userInput >= minLength;
        }

        public static bool ValidatePatternSelection(int userInput, List<string[]> patternList)
        {
            if (userInput > 0 && userInput <= patternList.Count)
                return true;
            return false;
        }
    }
}