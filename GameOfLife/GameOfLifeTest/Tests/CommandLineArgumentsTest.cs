using GameOfLife.Application;
using Xunit;

namespace GameOfLifeTest.Tests
{
    public class CommandLineArgumentsTest
    {
        [Fact]
        public void GivenCommandLineArgument_WhenPatternNameExists_ThenReturnPattern()
        {
            var actual = CommandLineArguments.GetPatternFromCmdLineArguments("/GameOfLife/GameOfLife/GameOfLifeTest/PatternFileDirectory/ThisIsATestFile.txt");
            
            Assert.Equal(ExamplePatterns.EveryCellAlive, actual);
        }
        
        
    }
}