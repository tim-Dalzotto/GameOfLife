using System.ComponentModel.DataAnnotations;

namespace GameOfLife.Domain
{
    public class WorldGenerationsInfo
    {
        public string[] CellPattern { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }



        public WorldGenerationsInfo(int height, int length, string[] cellPattern)
        {
            Height = height;
            Length = length;
            CellPattern = cellPattern;
        }
    }
}