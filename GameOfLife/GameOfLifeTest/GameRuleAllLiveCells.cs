using GameOfLife.Application;
using GameOfLife.Domain;

namespace GameOfLifeTest
{
    public class GameRuleAllLiveCells : IGameRules
    {
        public World InitialiseWorld(World world, int worldRows, int worldColumns)
        {
            var cell = new Cell();
            var createWorld = world;
            createWorld.WorldPopulation = new Cell[worldRows,worldColumns];
            
            for(var i = 0; i < worldRows; i++)
            {
                for (var j = 0; j < worldColumns; j++)
                {
                    cell.IsAlive = true;
                    createWorld.WorldPopulation[i, j] = cell;
                }
            }
            return world;
        }

        public World PopulateWorldWithNextGen(World world)
        {
            throw new System.NotImplementedException();
        }

        public void CheckForLivingNeighbours(World world)
        {
            world = InitialiseWorld(world,5, 5);
        }
    }
}