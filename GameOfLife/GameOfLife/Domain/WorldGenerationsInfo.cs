using System.ComponentModel.DataAnnotations;

namespace GameOfLife.Domain
{
    public class WorldGenerationsInfo
    {
        public string[] CellPattern { get; set; }
        
        public int PatternSelection { get; set; }
        public string Height { get; set; }
        public string Length { get; set; }

        public bool BuildCustomWorld { get; set; } = false;



        // public WorldGenerationsInfo(int height, int length, string[] cellPattern)
        // {
        //     Height = height;
        //     Length = length;
        //     CellPattern = cellPattern;
        // }
    }
}