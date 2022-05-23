using System;

namespace GameOfLife.ConsoleOut
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