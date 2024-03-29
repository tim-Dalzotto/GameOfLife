using GameOfLife.Application;
using GameOfLife.Interfaces;

namespace GameOfLife.Console
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


        public void GetUserPatternSelection(string[] arrayOfPatternNames)
        {
            var validator = false;
            var userSelectionPatternChoice = 0;
            while (!validator)
            {
                _output.DisplayPatternSelectionFromFile(arrayOfPatternNames);
                var userInputTemp = _input.GetUserInput();
                if (Validator.ValidateIfIsNumeric(userInputTemp))
                    userSelectionPatternChoice = int.Parse(userInputTemp);
                else
                    continue;
                validator = Validator.ValidateUserSelectedPatternExists(userSelectionPatternChoice, arrayOfPatternNames);
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