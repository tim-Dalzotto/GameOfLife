using GameOfLife.Console;
using GameOfLife.Constants;
using GameOfLife.Domain;
using GameOfLife.Interfaces;

namespace GameOfLife.Application
{
    public class GameSetup
    {
        private readonly IUserInput _input;
        private readonly IOutput _output;
        private readonly Riddler _riddler;
        private readonly CustomPatternBuilder _customPatternBuilder;
        private readonly CommandLineArgument _commandLineArgument;
        private readonly RootPathConstant _rootPathConstant;
        public bool CustomWorld { get; private set; }
        public virtual int WorldLength { get; private set; }
        public virtual int WorldHeight { get; private set; }

        public GameSetup(IUserInput userInput, IOutput output, Riddler riddler, CustomPatternBuilder customPatternBuilder, CommandLineArgument commandLineArgument, RootPathConstant rootPathConstant)
        {
            _input = userInput;
            _output = output;
            _riddler = riddler;
            _customPatternBuilder = customPatternBuilder;
            _commandLineArgument = commandLineArgument;
            _rootPathConstant = rootPathConstant;
        }
        public Pattern GetPatternSelection(string[] args)
        {
            var patternLoader = new PatternLoader(_rootPathConstant);

            if (args.Length > 0 && Validator.ValidateCmdLineArgument(_output, args[0], patternLoader.GetPatternNamesFromFile()))
            {
                var absolutePath = _commandLineArgument.GetPatternFromCmdLineArguments(args[0]);
                return new Pattern(patternLoader.GetPatternFromFileArgument(absolutePath));
            }
            
            _riddler.GetUserPatternSelection(patternLoader.GetPatternNamesFromFile());
            
            if (_riddler.PatternIndex == patternLoader.GetPatternNamesFromFile().Length + 1)
                CustomWorld = true;
            return new Pattern(patternLoader.GetSelectedPatternFromFile(_riddler.PatternIndex));
        }

        public void SetWorldDimensions(Pattern pattern)
        {
            var minRowRequiredForSelectedPattern = pattern.CurrentPattern.Length;
            var minColumnsRequiredForSelectedPattern = pattern.CurrentPattern[0].Length;
            _output.DisplayGameBoardSizeSelectionMessage( minRowRequiredForSelectedPattern,minColumnsRequiredForSelectedPattern);

            var validInput = false;
            while (!validInput)
            { 
                _riddler.GetUserWorldHeightSelection();
                validInput = Validator.ValidateWorldSize(_output, _riddler.Height.ToString(), minRowRequiredForSelectedPattern);
            }

            validInput = false;
            while (!validInput)
            { 
                _riddler.GetUserLengthSelection();
                validInput = Validator.ValidateWorldSize(_output, _riddler.Length.ToString(), minColumnsRequiredForSelectedPattern);
            }

            WorldLength = _riddler.Length;
            WorldHeight = _riddler.Height;
        }

        public void CreateCustomWorldPattern(Pattern pattern)
        {
            _customPatternBuilder.InitialiseCustomPattern(WorldHeight, WorldLength);
            _customPatternBuilder.MakePattern(_input,_output);
            pattern.CurrentPattern = _customPatternBuilder.ConvertedCustomPattern;
        }
    }
}