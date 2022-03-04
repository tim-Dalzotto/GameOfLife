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
            var currentWorld = TestPatterns.EveryCellIsAlive();
            var listOfPreviousWorlds = new List<string>();
            listOfPreviousWorlds.Add(JsonConvert.SerializeObject(currentWorld));

            var actual = SimEndCriteria.SimulationRepeated(listOfPreviousWorlds, currentWorld);
            
            Assert.True(actual);
        }
        
        [Fact]
        public void GivenCreateInitialWorld_WhenPatternDoesNotRepeat_ThenReturnFalse()
        {
            var currentWorld = TestPatterns.EveryCellIsAlive();
            var listOfPreviousWorlds = new List<string>();
            listOfPreviousWorlds.Add(JsonConvert.SerializeObject(TestPatterns.EveryCellIsDead()));

            var actual = SimEndCriteria.SimulationRepeated(listOfPreviousWorlds, currentWorld);
            
            Assert.False(actual);
        }

        public void GivenWorld_WhenEverCellIsDead_ThenReturnTrue()
        {
            //arrange
            //act
            //asset                   
        }
    }
}