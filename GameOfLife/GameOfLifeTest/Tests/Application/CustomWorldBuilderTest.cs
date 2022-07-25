using FluentAssertions;
using GameOfLife.Application;
using GameOfLife.Console;
using GameOfLifeTest.Mock;
using Xunit;

namespace GameOfLifeTest.Tests.Application
{
    public class CustomWorldBuilderTest
    {
        private readonly CustomPatternBuilder _customPatternBuilder;

        public CustomWorldBuilderTest()
        {
            _customPatternBuilder = new CustomPatternBuilder();
            _customPatternBuilder.InitialiseCustomPattern(5,5);
        }
        
        [Fact]
        public void GivenEmptyWorld_WhenInitialiseWorldCalled_ThenReturnNewWorld()
        {
            Assert.NotEmpty(_customPatternBuilder.CustomPattern);
        }
        
        [Fact]
        public void GivenCreateInitialWorld_WhenPatternAndSizeAreGiven_ThenReturnAWorldToThoseSpecifications()
        {
            var actual = _customPatternBuilder.CustomPattern;
            actual.Should().BeEquivalentTo(ExamplePatterns.ExampleMultidimensionalStringArrayAllCellsDead());
        }

        [Theory]
        [InlineData('w', 4)]
        [InlineData('s', 1)]

        public void  GivenMoveCursor_WhenInputIsWorS_ThenMoveCursorYValue(char input, int expectedResult)
        {
            _customPatternBuilder.MoveCursor(input);
            
            Assert.Equal(expectedResult,_customPatternBuilder.CursorYValue);
        }
        
        [Theory]
        [InlineData('a', 4)]
        [InlineData('d', 1)]

        public void  GivenMoveCursor_WhenInputIsAorD_ThenMoveCursorXValue(char input, int expectedResult)
        {
            _customPatternBuilder.MoveCursor(input);
            
            Assert.Equal(expectedResult,_customPatternBuilder.CursorXValue);
        }
        
        [Fact]
        public void GivenSetAliveOrDead_WhenPIsEnteredAndCursorIsAt00_ThenSet00ToAliveInThePattern()
        {
            _customPatternBuilder.CursorXValue = 0;
            _customPatternBuilder.CursorYValue = 0;

            _customPatternBuilder.SetAliveOrDead("p");
            
            Assert.Equal(ExamplePatterns.ExampleMultidimensionalStringArrayOnly00Alive2(), _customPatternBuilder.CustomPattern);
        }

        [Fact]
        public void GivenDisplayCustomWorld_WhenCalled_ThenDisplayGameCellShouldBeCalled30Times()
        {
            var mockOutputCount = new FakeOutputCount();

            _customPatternBuilder.DisplayWorldBuilder(mockOutputCount);
            
            Assert.Equal(29, mockOutputCount.Count);
        }

        [Fact]
        public void GivenMakePattern_WhenRunWithoutChangingState_ThenReturnEmptyWorld()
        {
            var mockInput = new FakeChangingUserInput("p","q");
            var output = new ConsoleOutput(new ConsoleIO());
            _customPatternBuilder.MakePattern(mockInput,output);
            
            Assert.Equal(ExamplePatterns.ExampleMultidimensionalStringArrayOnly00Alive2(), _customPatternBuilder.CustomPattern);
        }

        [Fact]
        public void GivenConvertMultiDimensionalArrayToStringArray_WhenMultiDimensionalArrayEntered_ThenConvertToStringArray()
        {
            _customPatternBuilder.ConvertMultiDimensionalArrayToStringArray(ExamplePatterns.ExampleMultidimensionalStringArrayOnly00Alive2());
            
            Assert.Equal(ExamplePatterns.Only00Alive, _customPatternBuilder.ConvertedCustomPattern);
        }
    }
}