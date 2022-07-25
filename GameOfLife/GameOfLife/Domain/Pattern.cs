using System.Collections.Generic;

namespace GameOfLife.Domain
{
    
    public class Pattern
    {

        public string[] CurrentPattern { get; set; }

        public Pattern(string[] currentPattern)
        {
            CurrentPattern = currentPattern;
        }
        
        public void UpdatePatternFromGameWorldStringArray(World currentCellArray)
        {
            var convertedList = new List<string>();
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
    }
}