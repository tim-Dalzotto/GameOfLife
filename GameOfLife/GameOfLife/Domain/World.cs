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
        private static World InitialiseWorldRectangle(World world, int height, int length)
        {
            var createWorld = world;
            createWorld.Height = height;
            createWorld.Length = length;
            createWorld.WorldPopulation = new Cell[height,length];

            for(var i = 0; i < world.Height; i++)
            {
                for (var j = 0; j < world.Length; j++)
                {
                    createWorld.WorldPopulation[i, j] = new Cell { };
                }
            }
            return createWorld;
        }
        
        //loadWorld
        private static World LoadPatternIntoWorld(string[] patternSplitIntoLines, World currentGeneration)
        {
            int yOffSet = (currentGeneration.Height - patternSplitIntoLines.Length) / 2;
            int xOffSet = (currentGeneration.Length - patternSplitIntoLines[0].Length) / 2;

            for (int y = 0; y < patternSplitIntoLines.Length; y++)
            {
                for (int x = 0; x < patternSplitIntoLines[y].Length; x++)
                {
                    if (patternSplitIntoLines[y].Substring(x, 1) == "O")
                        currentGeneration.WorldPopulation[y + yOffSet, x + xOffSet].IsAlive = true;
                }
            }
            return currentGeneration;
        }
        
    }
}