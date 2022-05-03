using GameOfLife.Domain;

namespace GameOfLife.Application
{
    public interface IGameEngine
    {
        public World RunNextGeneration(World world);

        public void PlayGame(string[] pattern, int height, int length);

        public void RunSimulation(World gameWorld);


        public void WantToSaveWorld(string[] currentPattern);

    }
}