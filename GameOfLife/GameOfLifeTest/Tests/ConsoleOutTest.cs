using System;
using System.IO;
using GameOfLife.ConsoleOut;
using GameOfLife.Domain;
using GameOfLifeTest.Mock;
using Moq;
using Xunit;

namespace GameOfLifeTest.Tests
{
    public class ConsoleOutTest
    {
        private readonly ConsoleOutput _consoleOutput;
        private readonly FakeConsoleIO _fakeConsoleIo;

        public ConsoleOutTest()
        {
            _fakeConsoleIo = new  FakeConsoleIO("");
            _consoleOutput = new ConsoleOutput(_fakeConsoleIo);
        }


        [Fact]
        public void Test_stringOutput()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            var consoleOutput = new ConsoleOutput(new ConsoleIO());
            
            consoleOutput.DisplayGameCell("Test");
            
            Assert.Equal("Test", stringWriter.ToString());
        }

        [Fact]
        public void Test_DisplayMessage()
        {
            var mockConsoleIo = new Mock<IConsoleIO>();
            var consoleOut = new ConsoleOutput(mockConsoleIo.Object);
            
            consoleOut.DisplayMessage("This is a test");

            mockConsoleIo.Verify(t => t.WriteLine("This is a test"), Times.Once());
        }

        [Fact]
        public void GivenDisplayChoiceForRowsMessage_WhenCalled_ThenShouldDisplayCorrectMessage()
        {
            _consoleOutput.DisplayChoiceForRowsMessage();
            
            Assert.Equal("How many rows would you like?", _fakeConsoleIo.WriteLineOptions);
        }
        
        [Fact]
        public void GivenDisplayChoiceForColumns_WhenCalled_ThenShouldDisplayCorrectMessage()
        {
            _consoleOutput.DisplayChoiceForColumnsMessage();
            
            Assert.Equal("How many columns would you like?", _fakeConsoleIo.WriteLineOptions);
        }
        
        [Fact]
        public void GivenDisplayOptionsForPatternBuilder_WhenCalled_ThenShouldDisplayCorrectMessage()
        {
            _consoleOutput.DisplayOptionsForPatternBuilder();
            const string expectedMessage = "Press W,A,S,D to move the Cursor\n " +
                                           "press P to Populate the cell or O to depopulate the cell \n " +
                                           "Or press Q to quit world builder";
            
            Assert.Equal(expectedMessage, _fakeConsoleIo.WriteLineOptions);
        }
        
        [Fact]
        public void GivenDisplay_WhenCalled_ThenShouldDisplayCorrectMessage()
        {
            _consoleOutput.DisplayGameBoardSizeSelectionMessage(5,5);
            const string expectedMessage = "Select the size of the game board you would like to use, " +
                                           "min requirements for selected pattern is 5X5";
            
            Assert.Equal(expectedMessage, _fakeConsoleIo.WriteLineOptions);
        }
    }
}