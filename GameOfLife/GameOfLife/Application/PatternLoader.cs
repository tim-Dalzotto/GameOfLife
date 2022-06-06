using System;
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
            var fileArray = Directory.GetFiles(_rootPathConstant.RootPath, "*.txt", SearchOption.AllDirectories)
                .Select(s => Path.GetFullPath(s)).ToArray();
            return fileArray;
        }

        public string[] GetPatternFromFile(string fileName)
        {
            var newStringList = new List<string>();
            foreach (var line in File.ReadLines(_rootPathConstant.RootPath + fileName))
            {
                newStringList.Add(line);
            }
            return newStringList.ToArray();
        }
        
        public string[] GetPatternFromFileArgument(string absoluteFilePath)
        {
            var newStringList = new List<string>();
            foreach (var line in File.ReadLines(absoluteFilePath))
            {
                newStringList.Add(line);
            }
            return newStringList.ToArray();
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