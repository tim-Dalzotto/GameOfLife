using System;
using System.IO;
using GameOfLife.Constants;

namespace GameOfLife.Application
{
    public class CommandLineArgument
    {
        private readonly RootPathConstant _rootPathConstant;

        public CommandLineArgument(RootPathConstant rootPathConstant)
        {
            _rootPathConstant = rootPathConstant;
        } 
        public string GetPatternFromCmdLineArguments(string patternName)
        {
            if (File.Exists(patternName))
            {
                return patternName;
            }
            
            var absolutePath = _rootPathConstant.RootPath;
            return absolutePath + patternName;
        }
    }
}