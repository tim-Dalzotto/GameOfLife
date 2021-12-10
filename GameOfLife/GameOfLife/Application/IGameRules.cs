using GameOfLife.Domain;

namespace GameOfLife.Application
{
    public interface IGameRules
    {
        public World InitialiseWorld(World world);

        public World PopulateWorldWithNextGen(World world);

        public void CheckForLivingNeighbours(World world);

        //public void DoCellsSurviveNextGen(World world);

    }
}