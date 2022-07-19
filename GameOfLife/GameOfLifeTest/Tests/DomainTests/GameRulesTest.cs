using FluentAssertions;
using GameOfLife.Domain;
using Xunit;

namespace GameOfLifeTest.Tests.DomainTests
{
    public class GameRulesTest
    {
        [Fact]
        public void
            GivenWorldWhereEveryCellIsAlive_WhenUpdateWorldWithNextGenIsCalled_ThenReturnAWorldWithNoLivingCells()
        {
            var currentWorld = ExampleWorlds.CellsWontSurviveNextGenWorld();

            var actual = GameRules.UpdateWorldWithNextGen(currentWorld);

            actual.Should().BeEquivalentTo(ExampleWorlds.WorldEveryCellIsDead());
        }

        [Fact]
        public void
            GivenSquareWorldWith0Iteration_WhenUpdateWorldWithNextGen_ThenReturnAWorldTheMatchesSquareWorldWith1Iteration()
        {
            var currentWorld = ExampleWorlds.SquareWorldWith0Iteration();

            var actual = GameRules.UpdateWorldWithNextGen(currentWorld);

            actual.Should().BeEquivalentTo(ExampleWorlds.SquareWorldWith1Iteration());
        }

        [Fact]
        public void GivenAWorldWhereTheMiddleCellHas7Neighbours_WhenWeCallFindLiveNeighbours_ThenReturn7()
        {
            var testWorld = ExampleWorlds.WorldWhereCellMiddleHas7LiveNeighbours();
            var actualLivingNeighbours = GameRules.FindLiveNeighbours(1,5,1,5, testWorld);
            
            Assert.Equal(7, actualLivingNeighbours);
        }
}
}