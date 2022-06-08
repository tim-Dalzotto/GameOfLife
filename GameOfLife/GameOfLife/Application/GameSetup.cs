using GameOfLife.ConsoleOut;
using GameOfLife.Constants;
using GameOfLife.Domain;

namespace GameOfLife.Application
{
    public class GameSetup
    {
        public Pattern GetPatternSelection(string[] args, IOutput output, Riddler riddler,World world)
        {
            var rootPath = new RootPathConstant();
            var patternLoader = new PatternLoader(rootPath);
            var commandLineArgument = new CommandLineArgument(rootPath);
            if (args.Length > 0 && Validator.ValidateCmdLineArgument(output, args[0], patternLoader.GetPatternNamesFromFile()))
            {
                var absolutePath = commandLineArgument.GetPatternFromCmdLineArguments(args[0]);
                return new Pattern(patternLoader.GetPatternFromFileArgument(absolutePath));
            }
            
            riddler.GetUserPatternSelection(patternLoader.GetPatternNamesFromFile());
            if (riddler.PatternIndex == patternLoader.GetPatternNamesFromFile().Length + 1)
                world.CustomWorld = true;
            return new Pattern(patternLoader.GetSelectedPatternFromFile(riddler.PatternIndex));
        }

        public void SetWorldDimensions(Riddler riddler, Pattern pattern, IOutput output)
        {
            var minRowRequiredForSelectedPattern = pattern.CurrentPattern.Length;
            var minColumnsRequiredForSelectedPattern = pattern.CurrentPattern[0].Length;
            output.DisplayGameBoardSizeSelectionMessage( minRowRequiredForSelectedPattern,minColumnsRequiredForSelectedPattern);

            var validInput = false;
            while (!validInput)
            { 
                riddler.GetUserWorldHeightSelection();
                validInput = Validator.ValidateWorldSize(output, riddler.Height.ToString(), minRowRequiredForSelectedPattern);
            }

            validInput = false;
            while (!validInput)
            { 
                riddler.GetUserLengthSelection();
                validInput = Validator.ValidateWorldSize(output, riddler.Length.ToString(), minColumnsRequiredForSelectedPattern);
            }
        }

        public void CreateCustomWorldPattern(Riddler riddler, Pattern pattern, IUserInput input, IOutput output)
        {
            var patternBuilder = new CustomPatternBuilder(riddler.Height, riddler.Length);
            patternBuilder.MakePattern(input,output);
            pattern.CurrentPattern = patternBuilder.ConvertedCustomPattern;
            
        }
    }
}