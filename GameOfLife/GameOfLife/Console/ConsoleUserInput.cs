using GameOfLife.Interfaces;

namespace GameOfLife.Console
{
    public class ConsoleUserInput : IUserInput
    {
        private readonly IConsoleIO ConsoleIo;

        public ConsoleUserInput(IConsoleIO consoleIo)
        {
            ConsoleIo = consoleIo;
        }
        public string GetUserInput()
        {
            return ConsoleIo.ReadLine();
        }

        
    }
}