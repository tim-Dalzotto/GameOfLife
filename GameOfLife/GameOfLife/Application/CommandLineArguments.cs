using System;
using System.IO;
using GameOfLife.Constants;

namespace GameOfLife.Application
{
    public static class CommandLineArguments
    {
        public static string GetPatternFromCmdLineArguments(string patternName)
        {
            if (!Directory.Exists(patternName))
            {
                return patternName;
            }
            var absolutePath = RootPathConstant.GetRootPath("/GameOfLife/GameOfLife/GameOfLife/PatternFileDirectory/");
            return absolutePath + patternName;
            //Check if arg is file name or file path
        }
    }
}