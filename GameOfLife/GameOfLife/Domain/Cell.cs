using System.Collections.Generic;

namespace GameOfLife.Domain
{
    public class Cell
    {
        public bool IsAlive { get; set; }

        public List<Cell> Neighbours { get; set; }
        
        public bool SurvivesNextGen { get; set; }
        
    }
}