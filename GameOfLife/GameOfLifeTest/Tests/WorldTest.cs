using GameOfLife.Domain;
using Newtonsoft.Json;
using Xunit;

namespace GameOfLifeTest.Tests
{
    public class WorldTest
    {
        [Fact]
        public void GivenEmptyWorld_WhenInitialiseWorldCalled_ThenReturnNewWorld()
        {
            var world = new World(5,5);

            Assert.NotEmpty(world.WorldPopulation);
        }
        
        [Fact]
        public void GivenCreateInitialWorld_WhenPatternAndSizeAreGiven_ThenReturnAWorldToThoseSpecifications()
        {
            var actual = new World( 5, 5);
            
            
            var serializedActualWorldStr = JsonConvert.SerializeObject(actual);
            var serializedExpectedWorldStr = JsonConvert.SerializeObject(ExampleWorlds.WorldEveryCellIsDead());
            
            Assert.Equal(serializedActualWorldStr,serializedExpectedWorldStr);
        }
        
        [Fact]
        public void GivenLoadWorldFromPattern_WhenGivenAPattern_ThenReturnWorldWithPattern()
        {
            var world = new World(5,5);

            var patternTest = new string[]
            {
                "00000\n", 
                "-----\n",
                "-----\n",
                "-----\n",
                "-----\n"
            };
            world.LoadPatternIntoWorld(patternTest);

            var testWorld = ExampleWorlds.WorldEveryCellOnFirstRowIsAlive();
            
            var serializedActualWorldStr = JsonConvert.SerializeObject(world);
            var serializedExpectedWorldStr = JsonConvert.SerializeObject(testWorld);
            Assert.Equal(serializedExpectedWorldStr, serializedActualWorldStr );
        }

    }
}