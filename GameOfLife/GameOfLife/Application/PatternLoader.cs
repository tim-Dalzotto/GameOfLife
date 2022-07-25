using System.Collections.Generic;
using System.IO;
using System.Linq;
using GameOfLife.Constants;

namespace GameOfLife.Application
{
    public class PatternLoader
    {
        private readonly RootPathConstant _rootPathConstant;

        public PatternLoader(RootPathConstant rootPathConstant)
        {
            _rootPathConstant = rootPathConstant;
        }
        public string[] GetPatternNamesFromFile()
        {
            var fileArray = Directory.GetFiles(_rootPathConstant.RootPath, "*.txt")
                .Select(Path.GetFullPath).ToArray();
            return fileArray;
        }

        public string[] GetPatternFromFile(string fileName)
        {
            return File.ReadLines(_rootPathConstant.RootPath + fileName).ToArray();
        }
        
        public string[] GetPatternFromFileArgument(string absoluteFilePath)
        {
            return File.ReadLines(absoluteFilePath).ToArray();
        }

        public string[] GetSelectedPatternFromFile(int userInput)
        {
            if (userInput > GetPatternNamesFromFile().Length)
                return new[] {"-"};
            var fileName = GetPatternNamesFromFile()[userInput -1];
            var pattern = GetPatternFromFile("/" +Path.GetFileName(fileName));
            return pattern;
        }
    }
}