using GameOfLife.ConsoleOut;

namespace GameOfLifeTest.Mock
{
    public class MockChangingUserInput : IUserInput
    {
        internal int Count { get; set; } = 1;
        private string FirstInput { get;}
        private string SecondInput { get;}

        public MockChangingUserInput(string firstInput, string secondInput)
        {
            FirstInput = firstInput;
            SecondInput = secondInput;
        }
        public string GetUserInput()
        {
            if (Count == 1)
            {
                Count++;
                return FirstInput;
            }

            return SecondInput;
        }
    }
}