using System;
using GameOfLife.ConsoleOut;

namespace GameOfLifeTest.Mock
{
    public class MockChangingUserInput : IUserInput
    {
        private int _count;

        private readonly string[] _arguments;

        public MockChangingUserInput(params string[] firstInput)
        {
            _arguments = firstInput;
        }
        public string GetUserInput()
        {
            if (_count >= _arguments.Length)
            {
                throw new SystemException("not enough arguments");
            }
            return _arguments[_count++];
        }
    }
}