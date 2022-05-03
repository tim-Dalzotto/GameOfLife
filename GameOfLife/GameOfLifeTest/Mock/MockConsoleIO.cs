using System;
using GameOfLife.ConsoleOut;

namespace GameOfLifeTest.Mock
{
    public class MockConsoleIO: IConsoleIO
    {
        public MockConsoleIO(string readlineOptions)
        {
            ReadlineOptions = readlineOptions;
        }

        private string ReadlineOptions { get; }
        public void WriteLine(string message)
        {
            throw new System.NotImplementedException();
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