using GameOfLife.ConsoleOut;

namespace GameOfLifeTest
{
    public class TestInput : IUserInput

    {
        public int GetUserInputPatternSelection()
        {
            return 3;
        }
        public int GetUserInputSize()
        {
            return 10;
        }
    }
}