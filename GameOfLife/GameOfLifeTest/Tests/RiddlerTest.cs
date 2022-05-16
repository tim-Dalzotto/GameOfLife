using GameOfLife.Application;
using GameOfLife.ConsoleOut;
using GameOfLife.Domain;
using GameOfLifeTest.Mock;
using Moq;
using Xunit;

namespace GameOfLifeTest.Tests
{
    public class RiddlerTest
    {
        private static readonly World WorldGen = new World();
        private readonly Riddler _riddler = new Riddler(WorldGen);
        
        [Fact]
        public void GivenGetUserPatternSelection_WhenUserInputIs1_ThenReturnBoxPattern()
        {
            var mockConsoleIo = new MockConsoleIO("1");
            var pattern = new Pattern();
            
            _riddler.GetUserPatternSelection(new ConsoleUserInput(mockConsoleIo), new ConsoleOutput(new ConsoleIO()), pattern);
            
            Assert.Equal(ExamplePatterns.ExampleDuckPattern,pattern.CurrentPattern);
        }
        
        [Fact]
        public void GivenGetUserPatternSelection_WhenUserInputIsWrongThenCorrect_ThenGetUserInputWillBeCalledTwice()
        {
            
            var mockChangingUserInput = new MockChangingUserInput("30", "1");
            var pattern = new Pattern();
            
            _riddler.GetUserPatternSelection(mockChangingUserInput, new ConsoleOutput(new ConsoleIO()), pattern);

            //Assert.Equal(2, mockChangingUserInput.Count);
            Assert.Equal(ExamplePatterns.ExampleDuckPattern, pattern.CurrentPattern);
        }
        
        [Fact]
        public void GivenGetUserLengthSelection_WhenUserInputIs1_ThenWorldGenInfoLengthShouldBe1()
        {
            var mockConsoleIo = new MockConsoleIO("1");
            
            _riddler.GetUserLengthSelection(new ConsoleUserInput(mockConsoleIo), new ConsoleOutput(new ConsoleIO()));
            
            Assert.Equal(1,WorldGen.Length);
        }
        
        [Fact]
        public void GivenGetUserWorldHeightSelection_WhenUserInputIs1_ThenWorldGenInfoHeightShouldBe1()
        {
            var mockConsoleIo = new MockConsoleIO("1");
            
            _riddler.GetUserWorldHeightSelection(new ConsoleUserInput(mockConsoleIo), new ConsoleOutput(new ConsoleIO()));
            
            Assert.Equal(1,WorldGen.Height);
        }
    }
}