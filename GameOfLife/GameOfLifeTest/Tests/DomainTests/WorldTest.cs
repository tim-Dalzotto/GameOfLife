using FluentAssertions;
using GameOfLife.Application;
using GameOfLife.Domain;
using Xunit;

namespace GameOfLifeTest.Tests.DomainTests
{
    public class WorldTest
    {

        [Fact]
        public void GivenEmptyWorld_WhenInitialiseWorldCalled_ThenReturnNewWorld()
        {
            var world = new World();
            world.InitialiseWorld(5,5);

            Assert.NotEmpty(world.WorldPopulation);
        }
        
        [Fact]
        public void GivenCreateInitialWorld_WhenPatternAndSizeAreGiven_ThenReturnAWorldToThoseSpecifications()
        {
            var actual = new World();
            actual.InitialiseWorld(5,5);
            actual.Should().BeEquivalentTo(ExampleWorlds.WorldEveryCellIsDead());
        }
        
        [Fact]
        public void GivenLoadWorldFromPattern_WhenGivenAPattern_ThenReturnWorldWithPattern()
        {
            var world = new World();
            world.InitialiseWorld(5,5);

            var patternTest = new string[]
            {
                "00000\n", 
                "-----\n",
                "-----\n",
                "-----\n",
                "-----\n"
            };
            var pattern = new Pattern(patternTest);
            
            world.LoadPatternIntoWorld(pattern);

            var testWorld = ExampleWorlds.WorldEveryCellOnFirstRowIsAlive();
            
            
            world.Should().BeEquivalentTo(testWorld);
        }

    }
}