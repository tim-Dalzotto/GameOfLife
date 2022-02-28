using System.Collections.Generic;

namespace GameOfLife.Domain
{
    public class World
    {
        public int Size { get; set; }
        
        public int Length { get; set; }
        
        public int Height { get; set; }
        public Cell[,] WorldPopulation { get; set; }
        
        //initialise world
        public void InitialiseWorldRectangle( int height, int length)
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
        public void LoadPatternIntoWorld(string[] patternSplitIntoLines)
        {
            int yOffSet = (Height - patternSplitIntoLines.Length) / 2;
            int xOffSet = (Length - patternSplitIntoLines[0].Length) / 2;

            for (int y = 0; y < patternSplitIntoLines.Length; y++)
            {
                for (int x = 0; x < patternSplitIntoLines[y].Length; x++)
                {
                    if (patternSplitIntoLines[y].Substring(x, 1) == "O")
                        WorldPopulation[y + yOffSet, x + xOffSet].IsAlive = true;
                }
            }
            
        }
        
    }
}