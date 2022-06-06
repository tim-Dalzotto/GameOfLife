using System;
using GameOfLife.ConsoleOut;

namespace GameOfLifeTest.Mock
{
    public class FakeConsoleIO: IConsoleIO
    {
        public FakeConsoleIO(string readlineOptions)
        {
            ReadlineOptions = readlineOptions;
        }

        private string ReadlineOptions { get; }
        public string WriteLineOptions { get; set; }
        public  string WriteOptions { get; set; }
        public void WriteLine(string message)
        {
            WriteLineOptions = message;
        }

        public void Write(string message)
        {
            WriteOptions = message;
        }

        public string ReadLine()
        {
            return ReadlineOptions;
        }

        public ConsoleKey ReadKey(bool b)
        {
            throw new NotImplementedException();
        }

        public bool KeyAvailable()
        {
            throw new NotImplementedException();
        }
    }
}