using GameOfLife.Application;
using Xunit;

namespace GameOfLifeTest
{
    public class PatternTest
    {
        [Fact]
        public void GivenGetSelectedPattern_WhenUserInput_ReturnCorrectPatter()
        {
            var UserInput = 2;

            var actual = Pattern.GetSelectedPattern(UserInput);
            
            Assert.Equal(ExamplePatterns.ExampleBoxPattern, actual);
        }
    }
}