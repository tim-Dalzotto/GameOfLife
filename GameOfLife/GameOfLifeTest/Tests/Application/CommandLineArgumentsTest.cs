using System.IO;
using GameOfLife.Application;
using GameOfLife.Constants;
using Moq;
using Xunit;

namespace GameOfLifeTest.Tests.Application
{
    public class CommandLineArgumentsTest
    {
        private readonly CommandLineArgument _commandLineArgument;

        public CommandLineArgumentsTest()
        {
            var rootPathConstant = new RootPathConstant("/GameOfLife/GameOfLife/GameOfLifeTest/PatternFileDirectory/");
            _commandLineArgument = new CommandLineArgument(rootPathConstant);
        }
        
        
        // [Fact]
        // public void GivenCommandLineArgument_WhenPatternExistsAtGivenFilePath_ThenReturnPattern()
        // {
        //     var actual = _commandLineArgument.GetPatternFromCmdLineArguments("/Users/Timothy.Dalzotto/testPatternFile.txt");
        //     
        //     Assert.Equal("/Users/Timothy.Dalzotto/testPatternFile.txt", actual);
        // }
        
        [Fact]
        public void GivenCommandLineArgument_WhenPatternNameExistsInDefaultFile_ThenReturnPattern()
        {
            var actual = _commandLineArgument.GetPatternFromCmdLineArguments("ThisIsATestFile.txt");
            
            Assert.Equal("ThisIsATestFile.txt", Path.GetFileName(actual));
        }
        
        
    }
}