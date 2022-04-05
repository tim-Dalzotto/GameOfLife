using System.IO;
using GameOfLife.Application;
using Xunit;

namespace GameOfLifeTest.Tests
{
    public class PatternTest
    {
        [Fact]
        public void GivenGetSelectedPattern_WhenUserInput_ThenReturnCorrectPatter()
        {
            var UserInput = 2;

            var actual = Pattern.GetSelectedPattern(UserInput);
            
            Assert.Equal(ExamplePatterns.ExampleBoxPattern, actual);
        }

        [Fact]
        public void DisplayNamesOfPatternsInFile()
        {
            var actual = Pattern.GetPatternNamesFromFile();
            
            Assert.Equal("ThisIsATestFile.txt",Path.GetFileName(actual[0]));
        }

        [Fact]
        public void GetPatternFromFile()
        {
            var actual = Pattern.GetPatternFromFile("/ThisIsATestFile.txt");
            
            Assert.Equal(ExamplePatterns.EveryCellAlive,actual);
        }

        [Fact]
        public void GetSelectedPatternFromFile()
        {
            var userInput = 1;
            var actual = Pattern.GetSelectedPatternFromFile(userInput);
            
            Assert.Equal(ExamplePatterns.EveryCellAlive,actual);
        }
        
    }
}