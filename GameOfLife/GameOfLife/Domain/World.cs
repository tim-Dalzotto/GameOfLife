using System.Collections.Generic;

namespace GameOfLife.Domain
{
    public class World
    {
        public int Size { get; set; }
        public Cell[,] WorldPopulation { get; set; }
    }
}