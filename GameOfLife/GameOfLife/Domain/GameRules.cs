namespace GameOfLife.Domain
{
    public static class GameRules
    {
        public static World CreateInitialWorld(string[] formattedPattern, int height, int length)
        {
            //initialise Rectangle world Test 
            
            var emptyWorld = new World(height,length);
            //load format pattern
            var loadedWorld =  emptyWorld.LoadPatternIntoWorld(formattedPattern);
            //return formatted World 
            return loadedWorld;
        }

        public static World UpdateWorldWithNextGen(World world)
        {
            var currentWorld = world;
            var height = currentWorld.Height;
            var length = currentWorld.Length;


            var newWorld = new World(currentWorld.Height, currentWorld.Length);
            //this should not be here, add it's own check
            var livingCellCount = 0;
            for (var x = 0; x < currentWorld.Height; x++)
            {
                for (var y = 0; y < currentWorld.Length; y++)
                {
                    var currentCell = currentWorld.WorldPopulation[x, y];
                    
                    var liveNeighbours = FindLiveNeighbours(x, length, y, height, currentWorld);

                    PopulateNextGeneration(currentCell, liveNeighbours, newWorld, x, y);
                    //---------------------------------------------------------------------------------------------------
                    //This will check to see if there are any living cells left 
                    if (currentCell.IsAlive == true)
                        livingCellCount++;
                    currentWorld.WorldPopulation[x, y] = currentCell;
                }
            }
            
            //This should not be here
            //if no living cells make AnyLivingCells = to true

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
        
        public static void PopulateNextGeneration(Cell currentCell, int liveNeighbours, World newWorld, int x, int y)
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
        
        // public static World InitialiseWorld(World world, int size)
        // {
        //     var createWorld = world;
        //     createWorld.Size = size;
        //     createWorld.WorldPopulation = new Cell[world.Size,world.Size];
        //
        //     for(var i = 0; i < world.Size; i++)
        //     {
        //         for (var j = 0; j < world.Size; j++)
        //         {
        //             createWorld.WorldPopulation[i, j] = new Cell { };
        //         }
        //     }
        //     return world;
        // }
        //
    }
}