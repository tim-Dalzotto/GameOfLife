using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Application
{
    public static class Pattern
    {
        public static readonly List<string[]> PatternList = new List<string[]>
        {
            PatternGlider(),
            PatternBox(),
            PatternDuck()
        };
        
        public enum PatternEnum
        {
            PatternGlider = 1,
            PatternBox,
            PatternDuck
        }
       
        private static string[] PatternBox()
        {
            var shipPattern = new string[]
            {
                "--OOO-\n", 
                "-OOO--\n"
            };
            return shipPattern;
        }
        
        private static string[] PatternDuck()
        {
            var shipPattern = new string[]
            {
                "--------",
                "-OOOOOO-",
                "O-----O-",
                "------O-",
                "0----O--",
                "--OO----"
            };
                
            return shipPattern;
        }

        private static string[] PatternGlider()
        {
            var gliderPattern = new string[]
            {
                "-------------------------O----------", 
                "----------------------OOOO----O-----", 
                "-------------O-------OOOO-----O-----",
                "------------O-O------O--O---------OO", 
                "-----------O---OO----OOOO---------OO",
                "OO---------O---OO-----OOOO----------", 
                "OO---------O---OO--------O----------", 
                "------------O-O---------------------", 
                "-------------O----------------------"
            };
                
            return gliderPattern;
        }
        
        public static string[] GetSelectedPattern(int userInput)
        {
            var loadedPattern = PatternList.ElementAt(userInput -1);
            return loadedPattern;
        }
    }
}