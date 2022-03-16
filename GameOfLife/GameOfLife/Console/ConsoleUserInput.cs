using System;
using GameOfLife.Application;

namespace GameOfLife.ConsoleOut
{
    public class ConsoleUserInput : IUserInput
    {
        public int GetUserInput()
        {
            var patternSelection = Console.ReadLine();
            return Convert.ToInt32(patternSelection);
        }

        
    }
}