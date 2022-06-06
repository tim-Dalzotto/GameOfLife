using System;
using GameOfLife.Application;
using GameOfLife.Constants;
using GameOfLife.Domain;

namespace GameOfLife.ConsoleOut
{
    public class Riddler
    {
        public int Height { get; private set; }
        public int Length { get; private set; }
        public int PatternIndex { get; private set; }
        private readonly IUserInput _input;
        private readonly IOutput _output;

        public Riddler(IUserInput userInput, IOutput output)
        {
            _input = userInput;
            _output = output;
        }


        public void GetUserPatternSelection( string[] ArrayOfPatternNames)
        {
            var validator = false;
            var userSelectionPatternChoice = 0;
            while (!validator)
            {
                _output.DisplayPatternSelectionFromFile(ArrayOfPatternNames);
                var userInputTemp = _input.GetUserInput();
                if (Validator.IsNumeric(userInputTemp))
                    userSelectionPatternChoice = int.Parse(userInputTemp);
                else
                    break;
                validator = Validator.ValidateUserSelectedPatternExists(userSelectionPatternChoice, ArrayOfPatternNames);
            }
            PatternIndex = userSelectionPatternChoice;          
        }

        public void GetUserWorldHeightSelection()
        {
            _output.DisplayChoiceForRowsMessage();
            var userInput = int.Parse(_input.GetUserInput());
            Height = userInput;
        }

        public void GetUserLengthSelection()
        {
            _output.DisplayChoiceForColumnsMessage();
            var userInput = int.Parse(_input.GetUserInput());
            Length = userInput;
        }
        
    }
}