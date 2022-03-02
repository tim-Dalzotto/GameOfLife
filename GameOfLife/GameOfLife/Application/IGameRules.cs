using GameOfLife.Domain;

namespace GameOfLife.Application
{
    public interface IGameRules
    {
        public World CreateInitialWorld(string[] formattedPattern, World world);
        
        
    }
}