using GameOfLife.Domain;
using Newtonsoft.Json;
using Xunit;

namespace GameOfLifeTest.Tests
{
    public class WorldTest
    {
        [Fact]
        public void GivenCreateInitialWorld_WhenPatternAndSizeAreGiven_ThenReturnAWorldToThoseSpecifications()
        {
            var actual = new World( 5, 5);
            
            
            var serializedActualWorldStr = JsonConvert.SerializeObject(actual);
            var serializedExpectedWorldStr = JsonConvert.SerializeObject(ExampleWorlds.WorldEveryCellIsAlive());
            
            Assert.Equal(serializedActualWorldStr,serializedExpectedWorldStr);
        }
    }
}