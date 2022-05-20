using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameOfLife.Application
{
    public static class PatternLoader
    {
        private static readonly string RootPath = GetRootPath("/GameOfLife/GameOfLife/GameOfLife/PatternFileDirectory/");


        private static string GetRootPath(string pathFromRootToSelectedFile)
        {
            var customRootPath = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.FullName;
            var subRootPath = customRootPath[..37];
            return $"{subRootPath}{pathFromRootToSelectedFile}";
        }
        
        public static string[] GetPatternNamesFromFile()
        {
            var fileArray = Directory.GetFiles(RootPath, "*.txt", SearchOption.AllDirectories)
                .Select(s => Path.GetFullPath(s)).ToArray();
            return fileArray;
        }

        public static string[] GetPatternFromFile(string fileName)
        {
            var newStringList = new List<string>();
            foreach (var line in File.ReadLines(RootPath + fileName))
            {
                newStringList.Add(line);
            }
            return newStringList.ToArray();
        }
        
        public static string[] GetPatternFromFileArgument(string absoluteFilePath)
        {
            var newStringList = new List<string>();
            foreach (var line in File.ReadLines(absoluteFilePath))
            {
                newStringList.Add(line);
            }
            return newStringList.ToArray();
        }

        public static string[] GetSelectedPatternFromFile(int userInput)
        {
            if (userInput > GetPatternNamesFromFile().Length)
                return new[] {"-"};
            var fileName = GetPatternNamesFromFile()[userInput -1];
            var pattern = GetPatternFromFile("/" +Path.GetFileName(fileName));
            return pattern;
        }
    }
}