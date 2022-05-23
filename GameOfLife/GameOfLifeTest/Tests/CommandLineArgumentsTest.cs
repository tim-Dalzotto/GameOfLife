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
        
        [Fact]
        public void GivenCommandLineArgument_WhenPatternNameExists_ThenReturnPatter_n()
        {
            var actual = CommandLineArguments.GetPatternFromCmdLineArguments("/Users/Timothy.Dalzotto/testPatternFile.txt");
            
            Assert.Equal("/Users/Timothy.Dalzotto/testPatternFile.txt", actual);
        }
        
        
    }
}