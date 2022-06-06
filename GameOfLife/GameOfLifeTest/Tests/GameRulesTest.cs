using FluentAssertions;
using GameOfLife.Application;
using GameOfLife.Domain;
using Newtonsoft.Json;
using Xunit;

namespace GameOfLifeTest.Tests
{
    public class GameRulesTest
    {
        [Fact]
        public void GivenWorldWhereEveryCellIsAlive_WhenUpdateWorldWithNextGenIsCaed_ThenReturnAWorldWithNoLivingCells()
        {
            var currentWorld = ExampleWorlds.CellsWontSurviveNextGenWorld();

            var actual = GameRules.UpdateWorldWithNextGen(currentWorld);
            
            actual.Should().BeEquivalentTo(ExampleWorlds.WorldEveryCellIsDead());
        }
        [Fact]
        public void GivenSquareWorldWith0Iteration_WhenUpdateWorldWithNextGen_ThenReturnAWorldTheMatchesSquareWorldWith1Iteration()
        {
            var currentWorld = ExampleWorlds.SquareWorlWithd0Iteration();

            var actual = GameRules.UpdateWorldWithNextGen(currentWorld);
            
            actual.Should().BeEquivalentTo(ExampleWorlds.SquareWorldWith1Iteration());
        }
    }
}