using GameOfLife.Application;
using GameOfLife.Domain;
using Newtonsoft.Json;
using Xunit;

namespace GameOfLifeTest.Tests
{
    public class GameRulesTest
    {
        [Fact]
        public void GivenCreateInitialWorld_WhenPatternAndSizeAreGiven_ThenReturnAWorldToThoseSpecifications()
        {
            var pattern = new Pattern();
            pattern.CurrentPattern = ExamplePatterns.EveryCellAlive;
            var actual = new World();
            actual.Height = 5;
            actual.Length = 5;
            actual.LoadPatternIntoWorld(pattern);
            
            var serializedActualWorldStr = JsonConvert.SerializeObject(actual);
            var serializedExpectedWorldStr = JsonConvert.SerializeObject(ExampleWorlds.WorldEveryCellIsAlive());
            
            Assert.Equal(serializedActualWorldStr,serializedExpectedWorldStr);
        }
    }
}