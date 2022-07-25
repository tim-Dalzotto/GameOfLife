using System;
using System.Runtime.CompilerServices;
using FluentAssertions;
using GameOfLife.Application;
using GameOfLife.Console;
using GameOfLife.Constants;
using GameOfLife.Domain;
using GameOfLife.Interfaces;
using Moq;
using Xunit;

namespace GameOfLifeTest.Tests.Application
{
    public class GameSetupTests
    {
        private readonly RootPathConstant _rootPathConstant;
        private readonly Mock<IUserInput> _mockUserInput;
        private readonly GameSetup _gameSetup;
        private readonly CustomPatternBuilder _customPatternBuilder;
        private readonly CommandLineArgument _commandLineArgument;
        private readonly ConsoleOutput _consoleOutput;
        private readonly Riddler _riddler;
        public GameSetupTests()
        {
            _rootPathConstant = new RootPathConstant("/GameOfLife/GameOfLife/GameOfLifeTest/PatternFileDirectory");
            var consoleIO = new ConsoleIO();
            _consoleOutput = new ConsoleOutput(consoleIO);
            _customPatternBuilder = new CustomPatternBuilder();
            _commandLineArgument = new CommandLineArgument(_rootPathConstant);
            _mockUserInput = new Mock<IUserInput>();
            _riddler = new Riddler(_mockUserInput.Object, _consoleOutput);

            _gameSetup = new GameSetup(_mockUserInput.Object, _consoleOutput,
                _riddler, _customPatternBuilder, _commandLineArgument,
                _rootPathConstant);
        }
        [Fact]
        public void GivenGetPatternSelection_When()
        {
            _mockUserInput.Setup(x => x.GetUserInput()).Returns("1");

            var actual = _gameSetup.GetPatternSelection(new []{""});

            actual.CurrentPattern.Should().BeEquivalentTo(ExamplePatterns.EveryCellAlive);
        }
        
        [Fact]
        public void GivenSetWorldDimensions_When()
        {
            _mockUserInput.SetupSequence(x => x.GetUserInput()).Returns("10").Returns("20");

            var testPattern = new Pattern(ExamplePatterns.EveryCellAlive);
            

            _gameSetup.SetWorldDimensions(testPattern);
            var expectedWorldHeight = 10;
            var expectedWorldLength = 20;

            Assert.Equal(expectedWorldHeight,_gameSetup.WorldHeight);
            Assert.Equal(expectedWorldLength,_gameSetup.WorldLength);
        }
        
        [Fact]
        public void GivenCreateCustomWorldPattern_When()
        {
            _mockUserInput.SetupSequence(x => x.GetUserInput()).Returns("5").Returns("5").Returns("p").Returns("q");

            var mockGameSetup = new Mock<GameSetup>(_mockUserInput.Object, _consoleOutput,_riddler,_customPatternBuilder, _commandLineArgument, It.IsAny<RootPathConstant>());
            mockGameSetup.Setup(x => x.WorldHeight).Returns(5);
            mockGameSetup.Setup(x => x.WorldLength).Returns(5);
            
            
            var testPattern = new Pattern(ExamplePatterns.EveryCellDead);
            

            mockGameSetup.Object.CreateCustomWorldPattern(testPattern);
            
            Assert.Equal(testPattern.CurrentPattern,ExamplePatterns.Only00Alive);
        }
        
        
    }
}