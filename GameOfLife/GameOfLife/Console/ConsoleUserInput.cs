using System;
using GameOfLife.Application;

namespace GameOfLife.ConsoleOut
{
    public class ConsoleUserInput : IUserInput
    {
        public int GetUserInputPatternSelection()
        {
            var patternSelection = Console.ReadLine();
            return Convert.ToInt32(patternSelection);
        }

        public int GetUserInputSize()
        {
            var WorldSizeSelection = Console.ReadLine();
            return Convert.ToInt32(WorldSizeSelection);
        }
    }
}