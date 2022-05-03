using System;

namespace GameOfLife.ConsoleOut
{
    public interface IConsoleKeyPress
    {
        bool CheckKeyAvailable();
        ConsoleKey CheckReadKey();
    }
}