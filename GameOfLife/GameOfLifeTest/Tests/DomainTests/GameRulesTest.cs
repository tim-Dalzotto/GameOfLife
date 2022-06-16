using FluentAssertions;
using GameOfLife.Domain;
using Xunit;

namespace GameOfLifeTest.Tests.DomainTests
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