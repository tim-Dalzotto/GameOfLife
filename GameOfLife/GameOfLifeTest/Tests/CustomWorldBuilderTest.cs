using System;
using GameOfLife.Application;
using GameOfLife.ConsoleOut;
using GameOfLifeTest.Mock;
using Xunit;

namespace GameOfLifeTest.Tests
{
    public class CustomWorldBuilderTest
    {
        [Theory]
        [InlineData('w', 4)]
        [InlineData('s', 1)]

        public void  GivenMoveCursor_WhenInputIsWorS_ThenMoveCursorYValue(char input, int expectedResult)
        {
            var customWorldBuilder = new CustomPatternBuilder(5,5);
            
            customWorldBuilder.MoveCursor(input);
            
            Assert.Equal(expectedResult,customWorldBuilder.CursorYValue);
        }
        
        [Theory]
        [InlineData('a', 4)]
        [InlineData('d', 1)]

        public void  GivenMoveCursor_WhenInputIsAorD_ThenMoveCursorXValue(char input, int expectedResult)
        {
            var customWorldBuilder = new CustomPatternBuilder(5,5);
            
            customWorldBuilder.MoveCursor(input);
            
            Assert.Equal(expectedResult,customWorldBuilder.CursorXValue);
        }
        
        [Fact]
        public void GivenSetAliveOrDead_WhenPIsEnteredAndCursorIsAt00_ThenSet00ToAliveInThePattern()
        {
            var customWorldBuilder = new CustomPatternBuilder(5, 5);
            customWorldBuilder.CursorXValue = 0;
            customWorldBuilder.CursorYValue = 0;

            customWorldBuilder.SetAliveOrDead("p");
            
            Assert.Equal(ExamplePatterns.ExampleMultidimensionalStringArrayOnly00Alive2(), customWorldBuilder.CustomPattern);
        }

        [Fact]
        public void GivenDisplayCustomWorld_WhenCalled_ThenDisplayGameCellShouldBeCalled30Times()
        {
            var customWorldBuilder = new CustomPatternBuilder(5, 5);
            var mockOutputCount = new MockOutputCount();

            customWorldBuilder.DisplayWorldBuilder(mockOutputCount);
            
            Assert.Equal(29, mockOutputCount.Count);
        }

        [Fact]
        public void GivenMakePattern_WhenRunWithoutChangingState_ThenReturnEmptyWorld()
        {
            var customWorldBuilder = new CustomPatternBuilder(5, 5);
            var mockInput = new MockChangingUserInput("p","q");
            var output = new ConsoleOutput(new ConsoleIO());
            customWorldBuilder.MakePattern(mockInput,output);
            
            Assert.Equal(ExamplePatterns.ExampleMultidimensionalStringArrayOnly00Alive2(), customWorldBuilder.CustomPattern);
        }

        [Fact]
        public void GivenConvertMultiDimensionalArrayToStringArray_WhenMultiDimensionalArrayEntered_ThenConvertToStringArray()
        {
            var customWorldBuilder = new CustomPatternBuilder(5, 5);
            
            customWorldBuilder.ConvertMultiDimensionalArrayToStringArray(ExamplePatterns.ExampleMultidimensionalStringArrayOnly00Alive2());
            
            Assert.Equal(ExamplePatterns.Only00Alive, customWorldBuilder.ConvertedCustomPattern);
        }
    }
}