using System;

namespace GameOfLife.ConsoleOut
{
    public interface IConsoleIO
    {
        void WriteLine(string message);
        string ReadLine();
        ConsoleKey ReadKey(bool b);
        bool KeyAvailable();
    }
}