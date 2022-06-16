using GameOfLife.Application;
using Newtonsoft.Json;
using Xunit;

namespace GameOfLifeTest.Tests.Application
{
    public class SimEndCriteriaTest
    {
        [Fact]
        public void GivenCreateInitialWorld_WhenPatternRepeats_ShouldReturnTrue()
        {
            var currentWorld = ExampleWorlds.WorldEveryCellIsAlive();
            var listOfPreviousWorlds = JsonConvert.SerializeObject(currentWorld);

            var actual = SimEndCriteria.SimulationRepeated(listOfPreviousWorlds, currentWorld);
            
            Assert.True(actual);
        }
        
        [Fact]
        public void GivenCreateInitialWorld_WhenPatternDoesNotRepeat_ThenReturnFalse()
        {
            var currentWorld = ExampleWorlds.WorldEveryCellIsAlive();
            var listOfPreviousWorlds = JsonConvert.SerializeObject(ExampleWorlds.WorldEveryCellIsDead());

            var actual = SimEndCriteria.SimulationRepeated(listOfPreviousWorlds, currentWorld);
            
            Assert.False(actual);
        }
    }
}