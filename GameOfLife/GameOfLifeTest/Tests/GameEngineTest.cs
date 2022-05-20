using System;
using System.Runtime.CompilerServices;
using FluentAssertions;
using GameOfLife.Application;
using GameOfLife.ConsoleOut;
using GameOfLife.Domain;
using GameOfLifeTest.Mock;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace GameOfLifeTest.Tests
{
    public class GameEngineTest
    {
        
        
        [Fact]
        public void RunNextGenerationTest_WhenAllCellsAlive_ThenReturnNextGenerationAllCellsAreDead()
        {
            var input = new ConsoleUserInput(new ConsoleIO());
            var output = new ConsoleOutput(new ConsoleIO());
            var keyPress = new KeyPress(new ConsoleIO());
            var pattern = new Pattern(ExamplePatterns.EveryCellDead);
            //Arrange 
            var gameEngine = new GameEngine(input, output, keyPress, pattern, ExampleWorlds.WorldEveryCellIsAlive());
            //Act
            var actual = gameEngine.RunNextGeneration();
            //Assert
            actual.Should().BeEquivalentTo(ExampleWorlds.WorldEveryCellIsDead());
        }
        
        [Fact]
        public void RunNextGenerationTest_WhenAllCellsDead_ThenReturnNextGenerationAllCellsAreDead()
        {
            var input = new ConsoleUserInput(new ConsoleIO());
            var output = new ConsoleOutput(new ConsoleIO());
            var keyPress = new KeyPress(new ConsoleIO());
            var pattern = new Pattern(ExamplePatterns.EveryCellDead);
            var world = new World();
            //Arrange 
            var gameEngine = new GameEngine(input, output, keyPress, pattern, ExampleWorlds.WorldEveryCellIsDead());
            //Act
            var actual = gameEngine.RunNextGeneration();
            //Assert
            actual.Should().BeEquivalentTo(ExampleWorlds.WorldEveryCellIsDead());
        }

        [Fact]
        public void GivenRunSimulation_WhenUserInputIsMocked_ThenShouldCallSaveWorldMethodOnce()
        {
            var mockInput = new MockChangingUserInput("S","Q");
            var output = new ConsoleOutput(new ConsoleIO());
            
            var mockKeyPress = new Mock<IKeyPress>();
            mockKeyPress.Setup(mock => mock.CheckKeyAvailable()).Returns(true);
            mockKeyPress.Setup(mock => mock.CheckReadKey()).Returns(ConsoleKey.P);

            var pattern = new Pattern(ExamplePatterns.EveryCellAlive);
            
            var gameEngine = new Mock<GameEngine>(mockInput, output, mockKeyPress.Object, pattern, ExampleWorlds.WorldEveryCellIsAlive());
            //gameEngine.CallBase = false;
            //gameEngine.Setup(mock => mock.RunSimulation(new World(10,10))).CallBase();
            
            gameEngine.Object.RunSimulation();
            gameEngine.Verify(mock => mock.WantToSaveWorld(It.IsAny<string[]>()), Times.Exactly(1));
        }
    }
}
