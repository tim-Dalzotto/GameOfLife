using System;
using System.Collections.Generic;
using System.Linq;
using GameOfLife.Application;
using GameOfLife.Domain;
using Xunit;
using Newtonsoft.Json;
using Xunit.Sdk;

namespace GameOfLifeTest
{
    public class GameRuleTest
    {
        [Fact]
        public void GivenNewWorld_WhenNextGenerationRun_ThenReturnUpdatedWorld()
        {
            var world = new World
            {
                Size = 5
            };
            var gameRule = new GameRules();
            var mockGameRule = new GameRuleAllLiveCells();
            //create original generation and populate world
            var originalGeneration = mockGameRule.InitialiseWorld(world, world.Size);
            //finding Neighbours
            gameRule.RunNextGeneration(originalGeneration);
            //determine if cells survives the next gen
            //gameRule.DoCellsSurviveNextGen(originalGeneration);
            //populate world with next gen
            var nextGeneration= gameRule.PopulateWorldWithNextGen(originalGeneration);
            
            Assert.Equal(PreDefinedWorlds.EveryCellIsDead(world), nextGeneration);
            
        } 
        
        
        
        [Fact]
        public void GivenEmptyWorld_WhenInitialiseWorldCalled_ThenReturnNewWorld()
        {
            var world = new World();
            var gameRule = new GameRules();
            world.Size = 5;

            var test = gameRule.InitialiseWorld(world, world.Size);
            
            Assert.NotEmpty(test.WorldPopulation);
        }
        
        [Fact]
        public void GivenEmptyWorld_WhenInitialiseWorldCalled_ThenWorldWillHaveSomeLivingCells()
        {
            var world = new World();
            var gameRule = new GameRules();
            world.Size = 5;

            var test = gameRule.InitialiseWorld(world, world.Size);
            
            Assert.NotEmpty(test.WorldPopulation);
        }

        [Fact]
        public void GivenWorld_WhenCellIsSelected_ThenReturnAllLivingNeighbours()
        {
            var world = new World();
            world.Size = 8;
            var originalGeneration = world;
            var gameRules = new GameRules();
            var MockgameRules = new GameRuleAllLiveCells();
            var cell = new Cell();
            var liveCell = cell;
            liveCell.IsAlive = true;
            var deadCell = cell;
            deadCell.IsAlive = false;
            
            originalGeneration = MockgameRules.InitialiseWorld(world, world.Size);
            gameRules.RunNextGeneration(originalGeneration);
            var actual = originalGeneration.WorldPopulation[1, 1].Neighbours.Count(x => x.IsAlive);

            Assert.Equal(8,actual);
        }
        
        [Fact]
        public void GivenWorld_WhenCellIsSelectedAndCellIsOnAnEdge_ThenReturnAllLivingNeighboursWhileLoopingToTheOtherSideOfTheGrid()
        {
            var world = new World();
            world.Size = 8;
            var originalGeneration = world;
            var mockGameRules = new GameRuleAllLiveCells();
            var gameRules = new GameRules();
            var cell = new Cell();
            var liveCell = cell;
            liveCell.IsAlive = true;
            var deadCell = cell;
            deadCell.IsAlive = false;

            originalGeneration = mockGameRules.InitialiseWorld(world, world.Size);
            gameRules.RunNextGeneration(originalGeneration);

            var actual = originalGeneration.WorldPopulation[1, 1].Neighbours.Count(x => x.IsAlive);

            Assert.Equal(8,actual);
        }

        [Fact]
        public void GivenWorld_WhenKillAllIsCalled_ThenKillAllLivingCells()
        {
            var world = new World();
            world.Size = 5;
            var gameRules = new GameRules();
            var mockGameRule = new GameRuleAllLiveCells();
            

            var currentGeneration = mockGameRule.InitialiseWorld(world, world.Size);
            

            gameRules.KillAllCells(currentGeneration);
            
            var testWorld = PreDefinedWorlds.EveryCellIsDead(new World());
            
            var serializedActualWorldStr = JsonConvert.SerializeObject(currentGeneration);
            var serializedExpectedWorldStr = JsonConvert.SerializeObject(testWorld);
            Assert.Equal(serializedExpectedWorldStr, serializedActualWorldStr );



        }
        
        [Fact]
        public void GivenNumberOfNeighbours_WhenDoesCellSurviveIsCalled_ThenReturnIfTheCellLivesOrDies()
        {
            var world = new World();
            world.Size = 8;
            var mockGameRules = new GameRuleAllLiveCells();
            var gameRules = new GameRules();
            
            var originalGeneration = mockGameRules.InitialiseWorld(world, world.Size);
            gameRules.RunNextGeneration(originalGeneration);

            //gameRules.DoCellsSurviveNextGen(originalGeneration);

            Assert.False(originalGeneration.WorldPopulation[5,5].SurvivesNextGen);
        }

        [Fact]
        public void GivenGeneratePreDeterminedWorld_WhenGivenAListOfCoOrd_ThenReturnAWorldWithAllGivenCoOrdsAlive()
        {
            var world = new World();
            world.Size = 5;
            var gameRules = new GameRules();
            var livingCellCoOrds = new List<string>()
            {
                "0,0","0,1","0,2","0,3","0,4"
            };

            var boardSetup = gameRules.splitCoOrds(livingCellCoOrds);

            var currentGeneration = gameRules.InitialiseWorld(world, world.Size);
            
            gameRules.LoadListIntoWorld(livingCellCoOrds, currentGeneration);

            var testWorld = PreDefinedWorlds.EveryCellOnFirstRowIsAlive(new World());
            
            var serializedActualWorldStr = JsonConvert.SerializeObject(currentGeneration);
            var serializedExpectedWorldStr = JsonConvert.SerializeObject(testWorld);
            //Assert.Equal(serializedExpectedWorldStr, serializedActualWorldStr );
        }

        [Fact]
        public void GivenSplitCoOrds_WhenListOfStringsIsEntered_ThenReturnAListOfTuplesWithInts()
        {
            var gameRules = new GameRules();
            
            var livingCellCoOrds = new List<string>()
            {
                "5,5","1,1"
            };

            var currentList = gameRules.splitCoOrds(livingCellCoOrds);
            
            Assert.Equal(5, currentList.ElementAt(0).Item1);
        }
        
        [Fact]
        public void GivenLoadWorldFromPattern_WhenGivenAPattern_ThenReturnWorldWithPattern()
        {
            var world = new World();
            world.Size = 5;
            var gameRules = new GameRules();
            string pattern1 =
                "-------------------------X----------\n" +
                "----------------------XXXX----X-----\n" +
                "-------------X-------XXXX-----X-----\n" +
                "------------X-X------X--X---------XX\n" +
                "-----------X---XX----XXXX---------XX\n" +
                "XX---------X---XX-----XXXX----------\n" +
                "XX---------X---XX--------X----------\n" +
                "------------X-X---------------------\n" +
                "-------------X----------------------";

            string patternTest = 
                "OOOOO\n" +
                "-----\n" +
                "-----\n" +
                "-----\n" +
                "-----\n";
            

            var boardSetup = GameRules.SplitPattern(patternTest);

            var currentGeneration = gameRules.InitialiseWorld(world, world.Size);
            
            var testGeneration = gameRules.LoadPatternIntoWorld(boardSetup, currentGeneration);

            var testWorld = PreDefinedWorlds.EveryCellOnFirstRowIsAlive(new World());
            
            var serializedActualWorldStr = JsonConvert.SerializeObject(testGeneration);
            var serializedExpectedWorldStr = JsonConvert.SerializeObject(testWorld);
            Assert.Equal(serializedExpectedWorldStr, serializedActualWorldStr );
        }

        [Fact]
        public void GivenCreateInitialWorld_WhenGivenUserInput_ReturnWorld()
        {
            var world = new World();
            var gameRules = new GameRules();
            var pattern = new pattern();

            var formattedPattern = new[] {
                "OOOOO\n",
                "-----\n",
                "-----\n",
                "-----\n",
                "-----\n",
                "-----"
            };

            var actual = gameRules.CreateInitialWorld(formattedPattern, world);
            var serializedActual = JsonConvert.SerializeObject(actual);
            var serializedExpectedWorld =
                JsonConvert.SerializeObject(PreDefinedWorlds.EveryCellOnFirstRowIsAlive(new World()));
            Assert.Equal(serializedExpectedWorld,serializedActual);

        }

    }
}