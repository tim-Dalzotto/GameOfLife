using System;

namespace GameOfLife.Application
{
    public static class CommandLineArguments
    {
        public static string[] GetPatternFromCmdLineArguments(string patternName)
        {
            var absolutePath = Pattern.GetRootPath("/GameOfLife/GameOfLife/GameOfLife/PatternFileDirectory/");
            return Pattern.GetPatternFromFileArgument(absolutePath  + patternName);
        }
    }
}