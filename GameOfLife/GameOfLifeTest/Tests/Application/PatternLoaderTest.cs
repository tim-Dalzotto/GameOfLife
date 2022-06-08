using System.IO;
using GameOfLife.Application;
using GameOfLife.Constants;
using Moq;
using Xunit;

namespace GameOfLifeTest.Tests
{
    public class PatternLoaderTest
    {
        private readonly PatternLoader _patternLoader;

        public PatternLoaderTest()
        {
            var rootPath = new Mock<RootPathConstant>();
            rootPath.Setup(m => m.GetRootPath(It.IsAny<string>()))
                .Returns(
                    "/Users/Timothy.Dalzotto/RiderProjects/GameOfLife/GameOfLife/GameOfLifeTest/PatternFileDirectory");
            _patternLoader = new PatternLoader(rootPath.Object);
        }
        
        [Fact]
        public void GivenGetSelectedPattern_WhenUserInput_ThenReturnCorrectPatter()
        {
            var UserInput = 1;
        
            var actual = _patternLoader.GetSelectedPatternFromFile(UserInput);
            
            Assert.Equal(ExamplePatterns.EveryCellAlive, actual);
        }

        [Fact]
        public void DisplayNamesOfPatternsInFile()
        {
            var actual = _patternLoader.GetPatternNamesFromFile();
            
            Assert.Equal("ThisIsATestFile.txt",Path.GetFileName(actual[0]));
        }

        [Fact]
        public void GetPatternFromFile()
        {
            var actual = _patternLoader.GetPatternFromFile("/ThisIsATestFile.txt");
            
            Assert.Equal(ExamplePatterns.EveryCellAlive,actual);
        }

        [Fact]
        public void GetSelectedPatternFromFile()
        {
            var userInput = 1;
            var actual = _patternLoader.GetSelectedPatternFromFile(userInput);
            
            Assert.Equal(ExamplePatterns.EveryCellAlive,actual);
        }
    }
}