using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace GameOfLife.Application
{
    public static class Pattern
    {
        private static readonly string RootPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/PatternFileDirectory";

        
        private static readonly Dictionary<PatternEnum,string[]> PatternDictionary = new Dictionary<PatternEnum,string[]>
        {
            {PatternEnum.Glider, PatternGlider()},
            {PatternEnum.Box, PatternBox()},
            {PatternEnum.Duck, PatternDuck()}
        };

        public enum PatternEnum
        {
            Glider = 1,
            Box,
            Duck 
        }
       
        private static string[] PatternBox()
        {
            var shipPattern = new string[]
            {
                "--000-\n", 
                "-000--\n"
            };
            return shipPattern;
        }
        
        private static string[] PatternDuck()
        {
            var shipPattern = new string[]
            {
                "--------",
                "-000000-",
                "0-----0-",
                "------0-",
                "0----0--",
                "--00----"
            };
                
            return shipPattern;
        }

        private static string[] PatternGlider()
        {
            var gliderPattern = new string[]
            {
                "-------------------------0----------", 
                "----------------------0000----0-----", 
                "-------------0-------0000-----0-----",
                "------------0-0------0--0---------00", 
                "-----------0---00----0000---------00",
                "00---------0---00-----0000----------", 
                "00---------0---00--------0----------", 
                "------------0-0---------------------", 
                "-------------0----------------------"
            };
                
            return gliderPattern;
        }
        
        public static string[] GetSelectedPattern(int userInput)
        {
            var loadedPattern = (PatternEnum)userInput;
            var actualPattern = PatternDictionary[loadedPattern];
            return actualPattern;
        }

        public static string[] GetPatternNamesFromFile()
        {
            var fileArray = Directory.GetFiles(RootPath, "*.txt", SearchOption.AllDirectories)
                .Select(x => Path.GetFullPath(x)).ToArray();
            Console.WriteLine(fileArray[0]);
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

        public static string[] GetSelectedPatternFromFile(int userInput)
        {
            var fileName = GetPatternNamesFromFile()[userInput -1];
            var pattern = GetPatternFromFile("/" +Path.GetFileName(fileName));
            return pattern;
        }

        public static void SavePatternToFile(string[] pattern, string patternName)
        {
            File.WriteAllLinesAsync(RootPath + "/" + patternName + ".txt", pattern);
        }
    }
}