using GameOfLife.Application;

namespace GameOfLife.Domain
{
    public static class GameRules
    {
        public static World UpdateWorldWithNextGen(World world)
        {
            var currentWorld = world;
            var height = currentWorld.Height;
            var length = currentWorld.Length;


            var newWorld = new World();
            newWorld.InitialiseWorld(height,length);
            for (var x = 0; x < currentWorld.Height; x++)
            {
                for (var y = 0; y < currentWorld.Length; y++)
                {
                    var currentCell = currentWorld.WorldPopulation[x, y];
                    
                    var liveNeighbours = FindLiveNeighbours(x, length, y, height, currentWorld);

                    PopulateWorldWithNextGeneration(currentCell, liveNeighbours, newWorld, x, y);
                    currentWorld.WorldPopulation[x, y] = currentCell;
                }
            }
            return newWorld;
        }
        
        private static int FindLiveNeighbours(int x, int height, int y, int length, World currentWorld)
        {
            var liveNeighbours = 0;

            var leftNeighbouringCell = (x > 0) ? x - 1 : length - 1;
            var rightNeighbouringCell = (x < length - 1) ? x + 1 : 0;

            var topNeighbouringCell = (y > 0) ? y - 1 : height - 1;
            var bottomNeighbouringCell = (y < height - 1) ? y + 1 : 0;

            liveNeighbours += currentWorld.WorldPopulation[leftNeighbouringCell, y].IsAlive ? 1 : 0;
            liveNeighbours += currentWorld.WorldPopulation[leftNeighbouringCell, topNeighbouringCell].IsAlive ? 1 : 0;
            liveNeighbours += currentWorld.WorldPopulation[x, topNeighbouringCell].IsAlive ? 1 : 0;
            liveNeighbours += currentWorld.WorldPopulation[rightNeighbouringCell, topNeighbouringCell].IsAlive ? 1 : 0;
            liveNeighbours += currentWorld.WorldPopulation[rightNeighbouringCell, y].IsAlive ? 1 : 0;
            liveNeighbours += currentWorld.WorldPopulation[leftNeighbouringCell, bottomNeighbouringCell].IsAlive ? 1 : 0;
            liveNeighbours += currentWorld.WorldPopulation[x, bottomNeighbouringCell].IsAlive ? 1 : 0;
            liveNeighbours += currentWorld.WorldPopulation[rightNeighbouringCell, bottomNeighbouringCell].IsAlive ? 1 : 0;
            return liveNeighbours;
        }

        private static void PopulateWorldWithNextGeneration(Cell currentCell, int liveNeighbours, World newWorld, int x, int y)
        {
            if (currentCell.IsAlive && liveNeighbours is 2 or 3)
                newWorld.WorldPopulation[x, y].IsAlive = true;

            else if (currentCell.IsAlive && liveNeighbours > 3)
                newWorld.WorldPopulation[x, y].IsAlive = false;

            else if (currentCell.IsAlive && liveNeighbours < 2)
                newWorld.WorldPopulation[x, y].IsAlive = false;

            else if (!currentCell.IsAlive && liveNeighbours == 3)
                newWorld.WorldPopulation[x, y].IsAlive = true;
        }
    }
}