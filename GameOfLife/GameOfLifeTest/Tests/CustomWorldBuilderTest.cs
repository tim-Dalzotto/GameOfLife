using System;
using GameOfLife.Application;
using Xunit;

namespace GameOfLifeTest.Tests
{
    public class CustomWorldBuilderTest
    {
        [Theory]
        [InlineData('w', 5)]
        [InlineData('s', 1)]

        public void  GivenMoveCursor_WhenInputIsWorS_ThenMoveCursorYValue(char input, int expectedResult)
        {
            var customWorldBuilder = new CustomWorldBuilder(5,5);
            
            customWorldBuilder.MoveCursor(input);
            
            Assert.Equal(expectedResult,customWorldBuilder.CursorYValue);
        }
        
        [Theory]
        [InlineData('a', 5)]
        [InlineData('d', 1)]

        public void  GivenMoveCursor_WhenInputIsAorD_ThenMoveCursorXValue(char input, int expectedResult)
        {
            var customWorldBuilder = new CustomWorldBuilder(5,5);
            
            customWorldBuilder.MoveCursor(input);
            
            Assert.Equal(expectedResult,customWorldBuilder.CursorXValue);
        }
        
        [Theory]
        [InlineData('p', '0')]
        [InlineData('u', '-')]
        public void GivenSetAliveOrDead_WhenPorUIsEntered_ThenReturnEither0OrDash(char input, char result)
        {
            var customWorldBuilder = new CustomWorldBuilder(5, 5);

            var actual = customWorldBuilder.SetAliveOrDead(input);
            
            Assert.Equal(result, actual);
        }
    }
}