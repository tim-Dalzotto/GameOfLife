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
            var actual = new World();
            actual.Height = 5;
            actual.Length = 5;
            actual.Pattern = ExamplePatterns.EveryCellAlive;
            actual.LoadPatternIntoWorld();
            
            var serializedActualWorldStr = JsonConvert.SerializeObject(actual);
            var serializedExpectedWorldStr = JsonConvert.SerializeObject(ExampleWorlds.WorldEveryCellIsAlive());
            
            Assert.Equal(serializedActualWorldStr,serializedExpectedWorldStr);
        }
    }
}