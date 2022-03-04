using GameOfLife.Application;
using GameOfLife.Domain;

namespace GameOfLifeTest
{
    public class PatternManagerAllLiveCells
    {
        public World CreateInitialWorld(string[] formattedPattern, int patternSize)
        {
            return new World(10,10);
        }

        public World CreateInitialWorld(string[] formattedPattern, World world)
        {
            throw new System.NotImplementedException();
        }

        public World InitialiseWorld(World world, int size)
        {
            var cell = new Cell();
            var createWorld = world;
            createWorld.WorldPopulation = new Cell[world.Size,world.Size];
            
            for(var i = 0; i < world.Size; i++)
            {
                for (var j = 0; j < world.Size; j++)
                {
                    cell.IsAlive = true;
                    createWorld.WorldPopulation[i, j] = cell;
                }
            }
            return createWorld;
        }

        public World PopulateWorldWithNextGen(World world)
        {
            throw new System.NotImplementedException();
        }

        public World RunNextGeneration(World world)
        {
            world = InitialiseWorld(world, world.Size);
            return world;
        }

        public void DoCellsSurviveNextGen(World world)
        {
            throw new System.NotImplementedException();
        }
    }
}