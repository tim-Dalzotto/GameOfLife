using System;
using FluentAssertions;
using GameOfLife.Application;
using GameOfLife.ConsoleOut;
using GameOfLife.Constants;
using GameOfLifeTest.Mock;
using Moq;
using Xunit;

namespace GameOfLifeTest.Tests.Application
{
    public class GameEngineTest
    {
        private readonly ConsoleUserInput _input;
        private readonly ConsoleOutput _output;
        private readonly KeyPress _keyPress;
        private readonly ConsoleIO _consoleIo = new ();

        public GameEngineTest()
        {
            _input = new ConsoleUserInput(_consoleIo);
            _output = new ConsoleOutput(_consoleIo);
            _keyPress = new KeyPress(_consoleIo);
            
        }

        [Fact]
        public void RunNextGenerationTest_WhenAllCellsAlive_ThenReturnNextGenerationAllCellsAreDead()
        {
            var pattern = new Pattern(ExamplePatterns.EveryCellDead);
            //Arrange 
            var gameEngine = new GameEngine(_input, _output, _keyPress, pattern, ExampleWorlds.WorldEveryCellIsAlive(), It.IsAny<PatternSaver>());
            //Act
            var actual = gameEngine.RunNextGeneration();
            //Assert
            actual.Should().BeEquivalentTo(ExampleWorlds.WorldEveryCellIsDead());
        }
        
        [Fact]
        public void RunNextGenerationTest_WhenAllCellsDead_ThenReturnNextGenerationAllCellsAreDead()
        {
           
            var pattern = new Pattern(ExamplePatterns.EveryCellDead);
            //Arrange 
            var gameEngine = new GameEngine(_input, _output, _keyPress, pattern, ExampleWorlds.WorldEveryCellIsDead(),It.IsAny<PatternSaver>());
            //Act
            var actual = gameEngine.RunNextGeneration();
            //Assert
            actual.Should().BeEquivalentTo(ExampleWorlds.WorldEveryCellIsDead());
        }

        [Fact]
        public void GivenRunSimulation_WhenUserInputIsMocked_ThenShouldCallSaveWorldMethodOnce()
        {
            var fakeInput = new FakeChangingUserInput("S","Q"); //Fake
            
            var mockKeyPress = new Mock<IKeyPress>();//stub
            mockKeyPress.Setup(mock => mock.CheckKeyAvailable()).Returns(true);
            mockKeyPress.Setup(mock => mock.CheckReadKey()).Returns(ConsoleKey.P);

            var pattern = new Pattern(ExamplePatterns.EveryCellAlive /*fake*/);
            
            var gameEngine = new Mock<GameEngine>(fakeInput, _output, mockKeyPress.Object, pattern, ExampleWorlds.WorldEveryCellIsAlive(), It.IsAny<PatternSaver>()); //spy

            gameEngine.Object.RunSimulation();
            gameEngine.Verify(mock => mock.SaveWorld(It.IsAny<string[]>()/*dummy*/), Times.Exactly(1));//spy usage 
        }
    }
}
