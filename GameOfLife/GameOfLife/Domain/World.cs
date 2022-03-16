using System.Collections.Generic;

namespace GameOfLife.Domain
{
    public class World
    {
        public int Size { get; set; }
        
        public int Length { get; }
        
        public int Height { get; }
        public Cell[,] WorldPopulation { get; set; }
        
        public string[] WorldPattern { get; set; }
        
        //initialise world
        public World ( int height, int length)
        {
            Height = height;
            Length = length;
            WorldPopulation = new Cell[height,length];

            for(var i = 0; i < Height; i++)
            {
                for (var j = 0; j < Length; j++)
                {
                    WorldPopulation[i, j] = new Cell { };
                }
            }
        }
        
        //loadWorld
        public World LoadPatternIntoWorld(string[] pattern)
        {
            int yOffSet = (Height - pattern.Length) / 2;
            int xOffSet = (Length - pattern[0].Length) / 2;

            for (int y = 0; y < pattern.Length; y++)
            {
                for (int x = 0; x < pattern[y].Length; x++)
                {
                    if (pattern[y].Substring(x, 1) == "O")
                        WorldPopulation[y + yOffSet, x + xOffSet].IsAlive = true;
                }
            }

            return this;
        }
        
    }
}