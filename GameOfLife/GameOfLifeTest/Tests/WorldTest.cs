using System.Reflection;
using GameOfLife.Application;
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
            var world = new World();
            world.Height = 5;
            world.Length = 5;
            world.InitialiseWorld();

            Assert.NotEmpty(world.WorldPopulation);
        }
        
        [Fact]
        public void GivenCreateInitialWorld_WhenPatternAndSizeAreGiven_ThenReturnAWorldToThoseSpecifications()
        {
            var actual = new World();
            actual.Height = 5;
            actual.Length = 5;
            actual.InitialiseWorld();
            
            var serializedActualWorldStr = JsonConvert.SerializeObject(actual);
            var serializedExpectedWorldStr = JsonConvert.SerializeObject(ExampleWorlds.WorldEveryCellIsDead());
            
            Assert.Equal(serializedActualWorldStr,serializedExpectedWorldStr);
        }
        
        [Fact]
        public void GivenLoadWorldFromPattern_WhenGivenAPattern_ThenReturnWorldWithPattern()
        {
            var pattern = new Pattern();
            var world = new World();
            world.Height = 5;
            world.Length = 5;
            world.InitialiseWorld();

            var patternTest = new string[]
            {
                "00000\n", 
                "-----\n",
                "-----\n",
                "-----\n",
                "-----\n"
            };
            pattern.CurrentPattern = patternTest;

            world.LoadPatternIntoWorld(pattern);

            var testWorld = ExampleWorlds.WorldEveryCellOnFirstRowIsAlive();
            
            var serializedActualWorldStr = JsonConvert.SerializeObject(world);
            var serializedExpectedWorldStr = JsonConvert.SerializeObject(testWorld);
            Assert.Equal(serializedExpectedWorldStr, serializedActualWorldStr );
        }

    }
}