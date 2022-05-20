using GameOfLife.Application;
using Xunit;

namespace GameOfLifeTest.Tests
{
    public class CommandLineArgumentsTest
    {
        [Fact]
        public void GivenCommandLineArgument_WhenPatternNameExists_ThenReturnPattern()
        {
            var actual = CommandLineArguments.GetPatternFromCmdLineArguments("Duck.txt");
            
            Assert.Equal("/GameOfLife/GameOfLife/GameOfLife/PatternFileDirectory/Duck.txt", actual);
        }
        
        
    }
}