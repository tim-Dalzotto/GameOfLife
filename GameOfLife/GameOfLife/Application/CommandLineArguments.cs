namespace GameOfLife.Application
{
    public static class CommandLineArguments
    {
        public static string[] GetPatternFromCmdLineArguments(string PatternName)
        {
            return Pattern.GetPatternFromFile(PatternName);
        }
    }
}