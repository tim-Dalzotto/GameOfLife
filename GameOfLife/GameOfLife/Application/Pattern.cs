using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Application
{
    public static class Pattern
    {
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
    }
}