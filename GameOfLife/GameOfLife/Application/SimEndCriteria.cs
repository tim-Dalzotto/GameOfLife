using System.Collections.Generic;
using System.Text.Json;
using GameOfLife.Domain;
using Newtonsoft.Json;


namespace GameOfLife.Application
{
    public static class SimEndCriteria
    {
        public static bool SimulationRepeated(List<string> pastWorlds, World currentWorld)
        {
            return pastWorlds.Contains(JsonConvert.SerializeObject(currentWorld));
        }

        public static bool IsEverythingDead()
        {
            
            return false;
        }
        
    }
    
    
}