using GameOfLife.Domain;

namespace GameOfLife.Application
{
    public interface IGameRules
    {
        public World CreateInitialWorld(string[] formattedPattern, int patternSize);
        public World InitialiseWorld(World world, int size);

        public World PopulateWorldWithNextGen(World world);

        public World RunNextGeneration(World world);
        

        //public void DoCellsSurviveNextGen(World world);

    }
}