using GameOfLife.Domain;
using Newtonsoft.Json;
using Xunit;

namespace GameOfLifeTest
{
    public class GameRulesTest
    {
        [Fact]
        public void GivenCreateInitialWorld_WhenPatternAndSizeAreGiven_ThenReturnAWorldToThoseSpecifications()
        {
            var actual = GameRules.CreateInitialWorld(ExamplePatterns.EveryCellAlive, 5, 5);
            
            var serializedActualWorldStr = JsonConvert.SerializeObject(actual);
            var serializedExpectedWorldStr = JsonConvert.SerializeObject(ExampleWorlds.WorldEveryCellIsAlive());
            
            Assert.Equal(serializedActualWorldStr,serializedExpectedWorldStr);
        }
    }
}