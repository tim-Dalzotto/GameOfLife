using System.Runtime.InteropServices;
using GameOfLife.Application;
using GameOfLife.ConsoleOut;
using GameOfLife.Domain;
using Xunit;

namespace GameOfLifeTest.Tests
{
    public class ValidationsTest
    {
        [Theory]
        [InlineData(5,5,true)]
        [InlineData(5,10,true)]
        [InlineData(5,4,false)]
        [InlineData(5,-5,false)]
        public void GivenValidateHeightInput_WhenCorrectEntered_ThenReturnExpectedResult(int minRequiredValue, int userInput, bool expected)
        {
            
            var actual = Validator.ValidateUserInputRows(minRequiredValue,userInput);
            
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData(5,5,true)]
        [InlineData(5,10,true)]
        [InlineData(5,4,false)]
        [InlineData(5,-5,false)]
        public void GivenValidateLengthInput_WhenInputEntered_ThenReturnExpectedResult(int minRequiredValue, int userInput, bool expected)
        {
            var actual = Validator.ValidateUserInputBiggerThanMinRequirements(minRequiredValue,userInput);
            
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(3, true)]
        [InlineData(4, false)]
        [InlineData(2, true)]
        [InlineData(0, false)]
        public void GivenValidatePatternSelection_WhenGivenUserInput_ThenReturnExpectedResult(int userInput, bool expected)
        {
            var actual = Validator.ValidatePatternSelection(userInput);
            
            Assert.Equal(expected, actual);

        }
        
        [Theory]
        [InlineData("3", true)]
        [InlineData("blue", false)]
        [InlineData("2", true)]
        [InlineData("Red", false)]
        [InlineData("2.3", false)]
        public void GivenValidateIsNumeric_WhenGivenStringInputCanBeConvertedToInt_ThenReturnTrue(string userInput, bool expected)
        {
            var actual = Validator.IsNumeric(userInput);
            
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void GivenCommandLineArgumentPatternName_WhenPatternNameExistInfile_ThenReturnTrue()
        {
            var actual = Validator.ValidCmdLineArgumentIsValidPatternName(new ConsoleOutput(new ConsoleIO()), "Glider.txt");
            
            Assert.True(actual);
        }
        
        [Fact]
        public void GivenCommandLineArgumentPatternName_WhenPatternNameDoesNotExistInfile_ThenReturnFalse()
        {
            var actual = Validator.ValidCmdLineArgumentIsValidPatternName(new ConsoleOutput(new ConsoleIO()),"ThisTestWillBeFalse.txt");
            
            Assert.False(actual);
        }

        [Theory]
        [InlineData("w",true)]
        [InlineData("a",true)]
        [InlineData("s",true)]
        [InlineData("d",true)]
        [InlineData("o",true)]
        [InlineData("p",true)]
        [InlineData("q",true)]
        [InlineData("b",false)]
        [InlineData("wa",false)]
        public void GivenValidCharForCustomWorldBuilder_WhenInputIsEitherWorAorSorDorOorP_ThenReturnTrue(string input, bool expectedResult)
        {
            var actual = Validator.ValidCharForCustomWorldBuilder(input);
            
            Assert.Equal(expectedResult, actual);
        }
        
    }
}