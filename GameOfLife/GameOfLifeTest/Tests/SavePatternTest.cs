using System.IO;
using System.Linq;
using GameOfLife.Application;
using Xunit;

namespace GameOfLifeTest.Tests
{
    public class SavePatternTest
    {
        [Fact]
        public void GivenCustomPattern_WhenFinished_ThenSavePatter()
        {
            var patternName = "zPatternName";
            Pattern.SavePatternToFile(ExamplePatterns.EveryCellAlive, patternName);
            var actual = Pattern.GetPatternNamesFromFile();
            var actual2 = actual.Last();
            
            Assert.Equal(patternName + ".txt", Path.GetFileName(actual2));
            File.Delete( actual2);
        }
    }
}