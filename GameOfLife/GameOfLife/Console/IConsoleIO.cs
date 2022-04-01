namespace GameOfLife.ConsoleOut
{
    public interface IConsoleIO
    {
        void WriteLine(string message);
        string ReadLine();
    }
}