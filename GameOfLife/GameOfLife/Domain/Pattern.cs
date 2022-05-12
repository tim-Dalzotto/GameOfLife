using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using GameOfLife.Domain;

namespace GameOfLife.Application
{
    /**
     * should represent a single pattern
     * 
     */
    public class Pattern
    {

        public string[] CurrentPattern { get; set; }


        public void UpdatePatternFromGameWorldStringArray(World currentCellArray)
        {
            List<string> convertedList = new List<string>();
            for(var i = 0; i < currentCellArray.Height; i++)
            {
                string tempString = null;
                for (var j = 0; j < currentCellArray.Length; j++)
                {
                    if (currentCellArray.WorldPopulation[i, j].IsAlive)
                        tempString += "0";
                    else
                        tempString += "-";
                }
                convertedList.Add(tempString);
            }

            CurrentPattern = convertedList.ToArray();
        }
        
        #region old stuff
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
        #endregion

    }
}