using System;
using System.Linq;
using GameOfLife.Application;
using GameOfLife.Domain;
using Xunit;
using Xunit.Sdk;

namespace GameOfLifeTest
{
    public class GameOfLifeTest
    {
        [Fact]
        public void GivenNewWorld_WhenNextGenerationRun_ThenReturnUpdatedWorld()
        {
            var world = new World();
            var gameRule = new GameRules();

            var originalGeneration = gameRule.InitialiseWorld(world, 5,5);

            var nextGeneration= gameRule.NextGeneration(world);
            
            Assert.NotEqual(originalGeneration, nextGeneration);
            
        } 
        
        
        
        [Fact]
        public void GivenEmptyWorld_WhenInitialiseWorldCalled_ThenReturnNewWorld()
        {
            var world = new World();
            var gameRule = new GameRules();

            var test = gameRule.InitialiseWorld(world, 5, 5);
            
            Assert.NotEmpty(test.WorldPopulation);
        }
        
        [Fact]
        public void GivenEmptyWorld_WhenInitialiseWorldCalled_ThenWorldWillHaveSomeLivingCells()
        {
            var world = new World();
            var gameRule = new GameRules();

            var test = gameRule.InitialiseWorld(world, 5, 5);
            
            Assert.NotEmpty(test.WorldPopulation);
        }

        [Fact]
        public void GivenWorld_WhenCellIsSelected_ThenReturnAllLivingNeighbours()
        {
            var world = new World();
            var originalGeneration = world;
            var gameRules = new GameRules();
            var MockgameRules = new GameRuleAllLiveCells();
            var cell = new Cell();
            var liveCell = cell;
            liveCell.IsAlive = true;
            var deadCell = cell;
            deadCell.IsAlive = false;
            
            originalGeneration = MockgameRules.InitialiseWorld(world, 8, 8);
            gameRules.CheckForLivingNeighbours(originalGeneration);
            var actual = originalGeneration.WorldPopulation[1, 1].Neighbours.Count(x => x.IsAlive);

            Assert.Equal(8,actual);
        }
        
        [Fact]
        public void GivenWorld_WhenCellIsSelectedAndCellIsOnAnEdge_ThenReturnAllLivingNeighboursWhileLoopingToTheOtherSideOfTheGrid()
        {
            var world = new World();
            var originalGeneration = world;
            var mockGameRules = new GameRuleAllLiveCells();
            var gameRules = new GameRules();
            var cell = new Cell();
            var liveCell = cell;
            liveCell.IsAlive = true;
            var deadCell = cell;
            deadCell.IsAlive = false;

            originalGeneration = mockGameRules.InitialiseWorld(world, 8, 8);
            gameRules.CheckForLivingNeighbours(originalGeneration);

            var actual = originalGeneration.WorldPopulation[1, 1].Neighbours.Count(x => x.IsAlive);

            Assert.Equal(8,actual);
        }
    }
}