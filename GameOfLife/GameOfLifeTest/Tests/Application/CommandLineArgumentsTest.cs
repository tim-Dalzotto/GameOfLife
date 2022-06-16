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
            var rootPath = new Mock<RootPathConstant>();
            rootPath.Setup(m => m.GetRootPath(It.IsAny<string>()))
                .Returns(
                    "/Users/Timothy.Dalzotto/RiderProjects/GameOfLife/GameOfLife/GameOfLifeTest/PatternFileDirectory/");
            _commandLineArgument = new CommandLineArgument(rootPath.Object);
        }
        
        
        [Fact]
        public void GivenCommandLineArgument_WhenPatternExistsAtGivenFilePath_ThenReturnPattern()
        {
            var actual = _commandLineArgument.GetPatternFromCmdLineArguments("/Users/Timothy.Dalzotto/testPatternFile.txt");
            
            Assert.Equal("/Users/Timothy.Dalzotto/testPatternFile.txt", actual);
        }
        
        [Fact]
        public void GivenCommandLineArgument_WhenPatternNameExistsInDefaultFile_ThenReturnPattern()
        {
            var actual = _commandLineArgument.GetPatternFromCmdLineArguments("ThisIsATestFile.txt");
            
            Assert.Equal("/Users/Timothy.Dalzotto/RiderProjects/GameOfLife/GameOfLife/GameOfLifeTest/PatternFileDirectory/ThisIsATestFile.txt", actual);
        }
        
        
    }
}