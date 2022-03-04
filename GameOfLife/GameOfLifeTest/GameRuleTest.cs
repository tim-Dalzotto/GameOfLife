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
            var world = new World(5, 5);
            var mockGameRule = new PatternManagerAllLiveCells();
            //create original generation and populate world
            var originalGeneration = mockGameRule.InitialiseWorld(world, world.Size);
            //finding Neighbours
            GameRules.UpdateWorldWithNextGen(originalGeneration);
            //determine if cells survives the next gen
            //gameRule.DoCellsSurviveNextGen(originalGeneration);
            //populate world with next gen
            var nextGeneration= GameRules.UpdateWorldWithNextGen(originalGeneration);
            
            Assert.Equal(TestPatterns.EveryCellIsDead(), nextGeneration);
            
        } 
        
        
        
        [Fact]
        public void GivenEmptyWorld_WhenInitialiseWorldCalled_ThenReturnNewWorld()
        {
            var world = new World(5,5);

            Assert.NotEmpty(world.WorldPopulation);
        }
        

        // [Fact]
        // public void GivenWorld_WhenCellIsSelected_ThenReturnAllLivingNeighbours()
        // {
        //     var world = new World();
        //     world.Size = 8;
        //     var originalGeneration = world;
        //     //var gameRules = new PatternManager();
        //     var MockgameRules = new PatternManagerAllLiveCells();
        //     var cell = new Cell();
        //     var liveCell = cell;
        //     liveCell.IsAlive = true;
        //     var deadCell = cell;
        //     deadCell.IsAlive = false;
        //     
        //     originalGeneration = MockgameRules.InitialiseWorld(world, world.Size);
        //     GameRules.UpdateWorldWithNextGen(originalGeneration);
        //     var actual = originalGeneration.WorldPopulation[1, 1].Neighbours.Count(x => x.IsAlive);
        //
        //     Assert.Equal(8,actual);
        // }
        //
        // [Fact]
        // public void GivenWorld_WhenCellIsSelectedAndCellIsOnAnEdge_ThenReturnAllLivingNeighboursWhileLoopingToTheOtherSideOfTheGrid()
        // {
        //     var world = new World();
        //     world.Size = 8;
        //     var originalGeneration = world;
        //     var mockGameRules = new PatternManagerAllLiveCells();
        //     //var gameRules = new PatternManager();
        //     var cell = new Cell();
        //     var liveCell = cell;
        //     liveCell.IsAlive = true;
        //     var deadCell = cell;
        //     deadCell.IsAlive = false;
        //
        //     originalGeneration = mockGameRules.InitialiseWorld(world, world.Size);
        //     GameRules.UpdateWorldWithNextGen(originalGeneration);
        //
        //     var actual = originalGeneration.WorldPopulation[1, 1].Neighbours.Count(x => x.IsAlive);
        //
        //     Assert.Equal(8,actual);
        // }

        // [Fact]
        // public void GivenWorld_WhenKillAllIsCalled_ThenKillAllLivingCells()
        // {
        //     var world = new World();
        //     world.Size = 5;
        //     //var gameRules = new PatternManager();
        //     var mockGameRule = new PatternManagerAllLiveCells();
        //     
        //
        //     var currentGeneration = mockGameRule.InitialiseWorld(world, world.Size);
        //     
        //
        //     gameRules.KillAllCells(currentGeneration);
        //     
        //     var testWorld = PreDefinedWorlds.EveryCellIsDead(new World());
        //     
        //     var serializedActualWorldStr = JsonConvert.SerializeObject(currentGeneration);
        //     var serializedExpectedWorldStr = JsonConvert.SerializeObject(testWorld);
        //     Assert.Equal(serializedExpectedWorldStr, serializedActualWorldStr );
        //
        //
        //
        // }
        
        // [Fact]
        // public void GivenNumberOfNeighbours_WhenDoesCellSurviveIsCalled_ThenReturnIfTheCellLivesOrDies()
        // {
        //     var world = new World();
        //     world.Size = 8;
        //     var mockGameRules = new PatternManagerAllLiveCells();
        //     var gameRules = new PatternManager();
        //     
        //     var originalGeneration = mockGameRules.InitialiseWorld(world, world.Size);
        //     GameRules.UpdateWorldWithNextGen(originalGeneration);
        //
        //     //gameRules.DoCellsSurviveNextGen(originalGeneration);
        //
        //     Assert.False(originalGeneration.WorldPopulation[5,5].SurvivesNextGen);
        // }

        // [Fact]
        // public void GivenGeneratePreDeterminedWorld_WhenGivenAListOfCoOrd_ThenReturnAWorldWithAllGivenCoOrdsAlive()
        // {
        //     var world = new World();
        //     world.Size = 5;
        //     var gameRules = new PatternManager();
        //     var livingCellCoOrds = new List<string>()
        //     {
        //         "0,0","0,1","0,2","0,3","0,4"
        //     };
        //
        //     var boardSetup = gameRules.splitCoOrds(livingCellCoOrds);
        //
        //     var currentGeneration = GameRules.InitialiseWorld(world, world.Size);
        //     
        //     gameRules.LoadListIntoWorld(livingCellCoOrds, currentGeneration);
        //
        //     var testWorld = PreDefinedWorlds.EveryCellOnFirstRowIsAlive(new World());
        //     
        //     var serializedActualWorldStr = JsonConvert.SerializeObject(currentGeneration);
        //     var serializedExpectedWorldStr = JsonConvert.SerializeObject(testWorld);
        //     //Assert.Equal(serializedExpectedWorldStr, serializedActualWorldStr );
        // }

        // [Fact]
        // public void GivenSplitCoOrds_WhenListOfStringsIsEntered_ThenReturnAListOfTuplesWithInts()
        // {
        //     var gameRules = new PatternManager();
        //     
        //     var livingCellCoOrds = new List<string>()
        //     {
        //         "5,5","1,1"
        //     };
        //
        //     var currentList = gameRules.splitCoOrds(livingCellCoOrds);
        //     
        //     Assert.Equal(5, currentList.ElementAt(0).Item1);
        // }
        
        [Fact]
        public void GivenLoadWorldFromPattern_WhenGivenAPattern_ThenReturnWorldWithPattern()
        {
            var world = new World(5,5);

            string[] patternTest = new string[]
            {
                "OOOOO\n", 
                "OOOOO\n", 
                "OOOOO\n", 
                "OOOOO\n", 
                "OOOOO\n"
            };
            world.LoadPatternIntoWorld(patternTest);

            var testWorld = TestPatterns.EveryCellOnFirstRowIsAlive();
            
            var serializedActualWorldStr = JsonConvert.SerializeObject(world);
            var serializedExpectedWorldStr = JsonConvert.SerializeObject(testWorld);
            Assert.Equal(serializedExpectedWorldStr, serializedActualWorldStr );
        }

    //     [Fact]
    //     public void GivenCreateInitialWorld_WhenGivenUserInput_ReturnWorld()
    //     {
    //         var world = new World();
    //         //var gameRules = new PatternManager();
    //         var pattern = new Pattern();
    //
    //         var formattedPattern = new[] {
    //             "OOOOO\n",
    //             "-----\n",
    //             "-----\n",
    //             "-----\n",
    //             "-----\n",
    //             "-----"
    //         };
    //
    //         var actual = GameRules.CreateInitialWorld(formattedPattern, world);
    //         var serializedActual = JsonConvert.SerializeObject(actual);
    //         var serializedExpectedWorld =
    //             JsonConvert.SerializeObject(PreDefinedWorlds.EveryCellOnFirstRowIsAlive(new World()));
    //         Assert.Equal(serializedExpectedWorld,serializedActual);
    //
    //     }
    //
    }
}