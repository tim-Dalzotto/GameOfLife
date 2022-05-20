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
        public void GivenCreateInitialWorld_WhenPatternAndSizeAreGiven_ThenReturnAWorldToThoseSpecifications()
        {
            var pattern = new Pattern(ExamplePatterns.EveryCellAlive);
            var actual = new World();
            
            actual.InitialiseWorld(5,5);
            actual.LoadPatternIntoWorld(pattern);
            
            actual.Should().BeEquivalentTo(ExampleWorlds.WorldEveryCellIsAlive());
        }
    }
}