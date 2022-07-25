using GameOfLife.Application;
using GameOfLife.Domain;
using Xunit;

namespace GameOfLifeTest.Tests.Application
{
    public class SavePatternTest
    {
        [Fact]
        public void GivenConvertCellArrayToString_WhenGivenArrayOfCells_ThenReturnStringArray()
        {
            var pattern = new Pattern(ExamplePatterns.EveryCellDead);
            pattern.UpdatePatternFromGameWorldStringArray(ExampleWorlds.WorldEveryCellIsAlive());
            
            Assert.Equal(ExamplePatterns.EveryCellAlive,pattern.CurrentPattern);
        }
        // [Fact]
        // public void GivenCustomPattern_WhenFinished_ThenSavePatter()
        // {
        //     var patternName = "zPatternName";
        //     Pattern.SavePatternToFile(ExamplePatterns.EveryCellAlive, patternName);
        //     var actual = Pattern.GetPatternNamesFromFile();
        //     var actual2 = actual.Last();
        //     
        //     Assert.Equal(patternName + ".txt", Path.GetFileName(actual2));
        //     Path.GetFileName(actual).Should().Contain(patternName + ".txt"));
        //     //Assert.Contains(patternName, actual);
        //     File.Delete(actual2);
        // }
    }
}