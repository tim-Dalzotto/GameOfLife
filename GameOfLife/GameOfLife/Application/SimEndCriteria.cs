
using GameOfLife.Domain;
using Newtonsoft.Json;


namespace GameOfLife.Application
{
    public static class SimEndCriteria
    {
        public static bool SimulationRepeated(string pastWorlds, World currentWorld)
        {
            return pastWorlds.Equals(JsonConvert.SerializeObject(currentWorld));
        }
    }
}