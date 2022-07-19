using System;
using GameOfLife.Interfaces;

namespace GameOfLife.Console
{
    public class KeyPress : IKeyPress
    {
        private readonly IConsoleIO _consoleIo;

        public KeyPress(IConsoleIO consoleIo)
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