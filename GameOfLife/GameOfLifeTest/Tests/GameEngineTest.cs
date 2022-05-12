using System;
using System.Runtime.CompilerServices;
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
            var pattern = new Pattern();
            //Arrange 
            var gameEngine = new GameEngine(input, output, keyPress, pattern);
            
            //Act
            var actual = gameEngine.RunNextGeneration(ExampleWorlds.WorldEveryCellIsAlive());
            
            var serializedActualWorldStr = JsonConvert.SerializeObject(actual);
            var serializedExpectedWorldStr = JsonConvert.SerializeObject(ExampleWorlds.WorldEveryCellIsDead());
            //Assert
            Assert.Equal(serializedExpectedWorldStr, serializedActualWorldStr);
        }
        
        [Fact]
        public void RunNextGenerationTest_WhenAllCellsDead_ThenReturnNextGenerationAllCellsAreDead()
        {
            var input = new ConsoleUserInput(new ConsoleIO());
            var output = new ConsoleOutput(new ConsoleIO());
            var keyPress = new KeyPress(new ConsoleIO());
            var pattern = new Pattern();
            //Arrange 
            var gameEngine = new GameEngine(input, output, keyPress, pattern);
            
            //Act
            var actual = gameEngine.RunNextGeneration(ExampleWorlds.WorldEveryCellIsDead());
            
            var serializedActualWorldStr = JsonConvert.SerializeObject(actual);
            var serializedExpectedWorldStr = JsonConvert.SerializeObject(ExampleWorlds.WorldEveryCellIsDead());
            //Assert
            Assert.Equal(serializedExpectedWorldStr, serializedActualWorldStr);
        }

        [Fact]
        public void GivenRunSimulation_WhenUserInputIsMocked_ThenShouldCallSaveWorldMethodOnce()
        {
            var mockInput = new MockChangingUserInput("S","Q");
            var output = new ConsoleOutput(new ConsoleIO());
            
            var mockKeyPress = new Mock<IKeyPress>();
            mockKeyPress.Setup(mock => mock.CheckKeyAvailable()).Returns(true);
            mockKeyPress.Setup(mock => mock.CheckReadKey()).Returns(ConsoleKey.P);

            var gameEngine = new Mock<GameEngine>(mockInput, output, mockKeyPress.Object);
            //gameEngine.CallBase = false;
            //gameEngine.Setup(mock => mock.RunSimulation(new World(10,10))).CallBase();
            
            gameEngine.Object.RunSimulation(ExampleWorlds.WorldEveryCellIsAlive());
            gameEngine.Verify(mock => mock.WantToSaveWorld(It.IsAny<string[]>()), Times.Exactly(1));
        }
    }
}