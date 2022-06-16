using GameOfLife.ConsoleOut;
using Moq;
using Xunit;

namespace GameOfLifeTest.Tests.Console
{
    public class ConsoleUserInputTest
    {
        [Fact]
        public void Test_Readline()
        {
            const string input = "Test";
            var mockConsoleIo = new Mock<IConsoleIO>();
            mockConsoleIo.Setup(t => t.ReadLine()).Returns(input);
            var consoleUserInput = new ConsoleUserInput(mockConsoleIo.Object);

            var actual = consoleUserInput.GetUserInput();
            
            Assert.Equal("Test",actual);
        }
    }
}