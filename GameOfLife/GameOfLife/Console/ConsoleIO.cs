using System;
using GameOfLife.Interfaces;

namespace GameOfLife.Console
{
    public class ConsoleIO: IConsoleIO
    {
        public void WriteLine(string message)
        {
            System.Console.WriteLine(message);
        }

        public void Write(string message)
        {
            System.Console.Write(message);
        }

        public string ReadLine()
        {
            return System.Console.ReadLine();
        }

        public ConsoleKey ReadKey(bool b)
        {
            return System.Console.ReadKey(b).Key;
        }

        public bool KeyAvailable()
        {
            return System.Console.KeyAvailable;
        }
        
    }
}