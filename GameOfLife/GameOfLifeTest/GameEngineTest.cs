using GameOfLife.Application;
using GameOfLife.ConsoleOut;
using Newtonsoft.Json;
using Xunit;

namespace GameOfLifeTest
{
    public class GameEngineTest
    {
        
        [Fact]
        public void RunNextGenerationTest_WhenAllCellsAlive_ThenReturnNextGenerationAllCellsAreDead()
        {
            var input = new ConsoleUserInput();
            var output = new ConsoleOutput();
            //Arrange 
            var gameEngine = new GameEngine(input, output);
            
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
            var input = new ConsoleUserInput();
            var output = new ConsoleOutput();
            //Arrange 
            var gameEngine = new GameEngine(input, output);
            
            //Act
            var actual = gameEngine.RunNextGeneration(ExampleWorlds.WorldEveryCellIsDead());
            
            var serializedActualWorldStr = JsonConvert.SerializeObject(actual);
            var serializedExpectedWorldStr = JsonConvert.SerializeObject(ExampleWorlds.WorldEveryCellIsDead());
            //Assert
            Assert.Equal(serializedExpectedWorldStr, serializedActualWorldStr);
        }
    }
}