using GameOfLife.ConsoleOut;

namespace GameOfLifeTest.Mock
{
    public class MockConsoleIO: IConsoleIO
    {
        public void WriteLine(string message)
        {
            throw new System.NotImplementedException();
        }

        public string ReadLine()
        {
            throw new System.NotImplementedException();
        }
    }
}