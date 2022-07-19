using FluentAssertions;
using GameOfLife.Application;
using GameOfLife.Domain;
using Xunit;

namespace GameOfLifeTest.Tests.DomainTests
{
    public class PatternTests
    {
        [Fact]
        public void GivenACurrentPatternHasEveryCellAlive_WhenCurrentWorldHasEveryCellDead_ThenUpdatePatternToHaveEveryCellDead()
        {
            var pattern = new Pattern(ExamplePatterns.EveryCellAlive);
            
            pattern.UpdatePatternFromGameWorldStringArray(ExampleWorlds.WorldEveryCellIsDead());

            pattern.CurrentPattern.Should().BeEquivalentTo(ExamplePatterns.EveryCellDead);
        }
        
        [Fact]
        public void GivenACurrentPatternHasEveryCellDead_WhenCurrentWorldHasEveryCellAlive_ThenUpdatePatternToHaveEveryCellAlive()
        {
            var pattern = new Pattern(ExamplePatterns.EveryCellDead);
            
            pattern.UpdatePatternFromGameWorldStringArray(ExampleWorlds.WorldEveryCellIsAlive());

            pattern.CurrentPattern.Should().BeEquivalentTo(ExamplePatterns.EveryCellAlive);
        }
    }
}