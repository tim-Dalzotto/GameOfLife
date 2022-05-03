using System;

namespace GameOfLife.ConsoleOut
{
    public class ConsoleKeyPress : IConsoleKeyPress
    {
        private readonly IConsoleIO _consoleIo;

        public ConsoleKeyPress(IConsoleIO consoleIo)
        {
            _consoleIo = consoleIo;
        }

        public bool CheckKeyAvailable()
        {
            return _consoleIo.KeyAvailable();
        }

        public ConsoleKey CheckReadKey()
        {
            return _consoleIo.ReadKey(true);
        }
    }
}