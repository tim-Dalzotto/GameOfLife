using System;

namespace GameOfLife.Interfaces
{
    public interface IConsoleIO
    {
        void WriteLine(string message);

        void Write(string message);
        string ReadLine();
        ConsoleKey ReadKey(bool b);
        bool KeyAvailable();
    }
}