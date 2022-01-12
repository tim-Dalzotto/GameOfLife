using GameOfLife.Domain;

namespace GameOfLife.Application
{
    public interface IGameRules
    {
        public World InitialiseWorld(World world, int size);

        public World PopulateWorldWithNextGen(World world);

        public World CheckForLivingNeighboursAndPopulateNextGeneration(World world);
        

        //public void DoCellsSurviveNextGen(World world);

    }
}