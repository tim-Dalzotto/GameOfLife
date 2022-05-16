using System.Collections.Generic;
using GameOfLife.Application;

namespace GameOfLife.Domain
{
    public class World
    {
        //public int Size { get; set; }

        public string[] WorldPattern { get; set; }
        
        public int Length { get; set; }

        public int Height { get; set; }
        public Cell[,] WorldPopulation { get; set; }

        public bool CustomWorld { get; set; }

        //public string[] Pattern { get; set; }

        //public int PatternIndex { get; set; }

        // public World ( int height, int length)
        // {
        //     Height = height;
        //     Length = length;
        //     WorldPopulation = new Cell[height,length];
        //     
        //     for(var i = 0; i < Height; i++)
        //     {
        //         for (var j = 0; j < Length; j++)
        //         {
        //             WorldPopulation[i, j] = new Cell { };
        //         }
        //     }
        // }

        public void InitialiseWorld()
        {
            WorldPopulation = new Cell[Height,Length];

            for(var i = 0; i < Height; i++)
            {
                for (var j = 0; j < Length; j++)
                {
                    WorldPopulation[i, j] = new Cell { };
                }
            }
        }
        
        public World LoadPatternIntoWorld(Pattern pattern)
        {
            
            var yOffSet = (Height - pattern.CurrentPattern.Length) / 2;
            var xOffSet = (Length - pattern.CurrentPattern[0].Length) / 2;

            for (var y = 0; y < pattern.CurrentPattern.Length; y++)
            {
                for (var x = 0; x < pattern.CurrentPattern[y].Length; x++)
                {
                    if (pattern.CurrentPattern[y].Substring(x, 1) == "0")
                        WorldPopulation[y + yOffSet, x + xOffSet].IsAlive = true;
                }
            }

            return this;
        }
    }
}