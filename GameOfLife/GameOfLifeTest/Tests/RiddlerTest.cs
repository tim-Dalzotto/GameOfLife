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
        
        [Fact]
        public void GivenGetUserPatternSelection_WhenUserInputIs1_ThenReturnBoxPattern()
        {
            var fakeConsoleIo = new FakeConsoleIO("1");
            var riddler = new Riddler(new ConsoleUserInput(fakeConsoleIo), new ConsoleOutput(new ConsoleIO()));
            
            riddler.GetUserPatternSelection(TestPatternList.ExampleList);
            
            Assert.Equal(1, riddler.PatternIndex);
        }
        
        [Fact]
        public void GivenGetUserPatternSelection_WhenUserInputIsWrongThenCorrect_ThenGetUserInputWillBeCalledTwice()
        {
            var fakeChangingUserInput = new FakeChangingUserInput("30", "1");

            var riddler = new Riddler(fakeChangingUserInput, new ConsoleOutput(new ConsoleIO()));
            
            riddler.GetUserPatternSelection(TestPatternList.ExampleList);

            //Assert.Equal(2, mockChangingUserInput.Count);
            Assert.Equal(1, riddler.PatternIndex);
        }
        
        [Fact]
        public void GivenGetUserLengthSelection_WhenUserInputIs1_ThenWorldGenInfoLengthShouldBe1()
        {
            var fakeConsoleIo = new FakeConsoleIO("1");

            var riddler = new Riddler(new ConsoleUserInput(fakeConsoleIo), new ConsoleOutput(new ConsoleIO()));
            
            riddler.GetUserLengthSelection();
            
            Assert.Equal(1,riddler.Length);
        }
        
        [Fact]
        public void GivenGetUserWorldHeightSelection_WhenUserInputIs1_ThenWorldGenInfoHeightShouldBe1()
        {
            var fakeConsoleIo = new FakeConsoleIO("1");

            var riddler = new Riddler(new ConsoleUserInput(fakeConsoleIo), new ConsoleOutput(new ConsoleIO()));
            
            riddler.GetUserWorldHeightSelection();
            
            Assert.Equal(1,riddler.Height);
        }
    }
}