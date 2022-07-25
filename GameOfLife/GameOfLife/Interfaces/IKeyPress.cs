using System;

namespace GameOfLife.Interfaces
{
    public interface IKeyPress
    {
        bool CheckKeyAvailable();
        ConsoleKey CheckReadKey();
    }
}