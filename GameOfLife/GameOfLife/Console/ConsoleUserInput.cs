using System;
using GameOfLife.Application;

namespace GameOfLife.ConsoleOut
{
    public class ConsoleUserInput : IUserInput
    {
        public string GetUserInput()
        {
            return Console.ReadLine();
        }

        
    }
}