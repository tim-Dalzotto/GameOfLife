using System;
using GameOfLife.Constants;

namespace GameOfLife.Application
{
    public static class CommandLineArguments
    {
        public static string[] GetPatternFromCmdLineArguments(string patternName)
        {
            var absolutePath = RootPathConstant.GetRootPath("/GameOfLife/GameOfLife/GameOfLife/PatternFileDirectory/");
            return PatternLoader.GetPatternFromFileArgument(absolutePath  + patternName);
        }
    }
}