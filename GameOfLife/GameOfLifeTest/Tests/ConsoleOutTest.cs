using System;
using System.IO;
using GameOfLife.ConsoleOut;
using GameOfLife.Domain;
using Moq;
using Xunit;

namespace GameOfLifeTest.Tests
{
    public class ConsoleOutTest
    {
         

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
    }
}