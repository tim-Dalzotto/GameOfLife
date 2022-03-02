using System.Collections.Generic;
using GameOfLife.Application;
using GameOfLife.ConsoleOut;
using GameOfLife.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Xunit;

namespace GameOfLifeTest
{
    public class SimEndCriteriaTest
    {
        [Fact]
        public void GivenCreateInitialWorld_WhenPatternRepeats_ShouldReturnTrue()
        {
            var world = new World();
            var currentWorld = PreDefinedWorlds.EveryCellIsAlive(world);
            var listOfPreviousWorlds = new List<string>();
            listOfPreviousWorlds.Add(JsonConvert.SerializeObject(currentWorld));

            var actual = SimEndCriteria.SimulationRepeated(listOfPreviousWorlds, currentWorld);
            
            Assert.True(actual);
        }
        
        [Fact]
        public void GivenCreateInitialWorld_WhenPatternDoesNotRepeat_ThenReturnFalse()
        {
            var world = new World();
            var currentWorld = PreDefinedWorlds.EveryCellIsAlive(world);
            var listOfPreviousWorlds = new List<string>();
            listOfPreviousWorlds.Add(JsonConvert.SerializeObject(PreDefinedWorlds.EveryCellIsDead(new World())));

            var actual = SimEndCriteria.SimulationRepeated(listOfPreviousWorlds, currentWorld);
            
            Assert.False(actual);
        }
    }
}