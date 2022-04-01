using System;
using GameOfLife.Application;

namespace GameOfLife.ConsoleOut
{
    public class ConsoleUserInput : IUserInput
    {
        private readonly IConsoleIO ConsoleIo;

        public ConsoleUserInput(IConsoleIO consoleIo)
        {
            ConsoleIo = consoleIo;
        }
        public string GetUserInput()
        {
            return ConsoleIo.ReadLine();
        }

        
    }
}