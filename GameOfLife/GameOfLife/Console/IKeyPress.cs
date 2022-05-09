using System;

namespace GameOfLife.ConsoleOut
{
    public interface IKeyPress
    {
        bool CheckKeyAvailable();
        ConsoleKey CheckReadKey();
    }
}