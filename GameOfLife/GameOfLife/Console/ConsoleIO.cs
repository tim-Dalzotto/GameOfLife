using System;

namespace GameOfLife.ConsoleOut
{
    public class ConsoleIO: IConsoleIO
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}