using GameOfLife.Interfaces;

namespace GameOfLifeTest
{
    public class TestInput : IUserInput

    {
        public string GetUserInput()
        {
            return "3";
        }
        
    }
}