using System.IO;
using GameOfLife.Application;
using GameOfLife.Constants;
using Xunit;

namespace GameOfLifeTest.Tests
{
    public class PatternTest
    {
        [Fact]
        public void GivenGetRootPath_WhenCalled_ThenReturnCurrentRootPath()
        {
            var actual = RootPathConstant.GetRootPath("/GameOfLife/GameOfLife/GameOfLifeTest/PatternFileDirectory");
            Assert.Equal("/Users/Timothy.Dalzotto/RiderProjects/GameOfLife/GameOfLife/GameOfLifeTest/PatternFileDirectory", actual);
        }
        // [Fact]
        // public void GivenGetSelectedPattern_WhenUserInput_ThenReturnCorrectPatter()
        // {
        //     var UserInput = 2;
        //
        //     var actual = Pattern.GetSelectedPattern(UserInput);
        //     
        //     Assert.Equal(ExamplePatterns.ExampleBoxPattern, actual);
        // }

        [Fact]
        public void DisplayNamesOfPatternsInFile()
        {
            var actual = PatternLoader.GetPatternNamesFromFile();
            
            Assert.Equal("Duck.txt",Path.GetFileName(actual[0]));
        }

        [Fact]
        public void GetPatternFromFile()
        {
            var actual = PatternLoader.GetPatternFromFile("/Box.txt");
            
            Assert.Equal(ExamplePatterns.ExampleBoxPattern,actual);
        }

        [Fact]
        public void GetSelectedPatternFromFile()
        {
            var userInput = 1;
            var actual = PatternLoader.GetSelectedPatternFromFile(userInput);
            
            Assert.Equal(ExamplePatterns.ExampleDuckPattern,actual);
        }
        
    }
}