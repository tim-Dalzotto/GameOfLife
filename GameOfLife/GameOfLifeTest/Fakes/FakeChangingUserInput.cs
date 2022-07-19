using System;
using GameOfLife.Interfaces;

namespace GameOfLifeTest.Mock
{
    public class FakeChangingUserInput : IUserInput
    {
        private int _count;

        private readonly string[] _arguments;

        public FakeChangingUserInput(params string[] firstInput)
        {
            _arguments = firstInput;
        }
        public string GetUserInput()
        {
            return _arguments[_count++];
        }
    }
}