using GameOfLife.Domain;

namespace GameOfLife.Application
{
    public interface IGameRules
    {
        public World InitialiseWorld(World world, int worldRows, int worldColumns);

        public World NextGeneration(World world);

        public void CheckForLivingNeighbours(World world);
        
    }
}