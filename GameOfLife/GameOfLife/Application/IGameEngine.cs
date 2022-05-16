using GameOfLife.Domain;

namespace GameOfLife.Application
{
    public interface IGameEngine
    {
        public World RunNextGeneration();

        public void PlayGame();

        public void RunSimulation();


        public void WantToSaveWorld(string[] currentPattern);

    }
}