namespace GameOfLife.Domain
{
    public class GameRules
    {
        public static World CreateInitialWorld(string[] formattedPattern, World world)
        {
            //initialise Rectangle world Test 
            var emptyWorld = InitialiseWorldRectangle(new World(), world.Height, world.Length);
            //load format pattern
            var loadedWorld = LoadPatternIntoWorld(formattedPattern, emptyWorld);
            //return formatted World 
            return loadedWorld;
        }

        private static World InitialiseWorldRectangle(World world, int height, int length)
        {
            var createWorld = world;
            createWorld.Height = height;
            createWorld.Length = length;
            createWorld.WorldPopulation = new Cell[height,length];

            for(var i = 0; i < world.Height; i++)
            {
                for (var j = 0; j < world.Length; j++)
                {
                    createWorld.WorldPopulation[i, j] = new Cell { };
                }
            }
            return createWorld;
        }

        
        //This is might not be business logic 
        private static World LoadPatternIntoWorld(string[] patternSplitIntoLines, World currentGeneration)
        {
            int yOffSet = (currentGeneration.Height - patternSplitIntoLines.Length) / 2;
            int xOffSet = (currentGeneration.Length - patternSplitIntoLines[0].Length) / 2;

            for (int y = 0; y < patternSplitIntoLines.Length; y++)
            {
                for (int x = 0; x < patternSplitIntoLines[y].Length; x++)
                {
                    if (patternSplitIntoLines[y].Substring(x, 1) == "O")
                        currentGeneration.WorldPopulation[y + yOffSet, x + xOffSet].IsAlive = true;
                }
            }
            return currentGeneration;
        }
        
        public static World RunNextGeneration(World world)
        {
            var currentWorld = world;
            var height = currentWorld.Height;
            var length = currentWorld.Length;


            var newWorld = InitialiseWorldRectangle(new World(), currentWorld.Height, currentWorld.Length);
            
            for (var x = 0; x < currentWorld.Height; x++)
            {
                for (var y = 0; y < currentWorld.Length; y++)
                {
                    var currentCell = currentWorld.WorldPopulation[x, y];
                    
                    var liveNeighbours = FindLiveNeighbours(x, length, y, height, currentWorld);

                    PopulateNextGeneration(currentCell, liveNeighbours, newWorld, x, y);
                    
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
        
        public static World InitialiseWorld(World world, int size)
        {
            var createWorld = world;
            createWorld.Size = size;
            createWorld.WorldPopulation = new Cell[world.Size,world.Size];
        
            for(var i = 0; i < world.Size; i++)
            {
                for (var j = 0; j < world.Size; j++)
                {
                    createWorld.WorldPopulation[i, j] = new Cell { };
                }
            }
            return world;
        }
        
    }
}