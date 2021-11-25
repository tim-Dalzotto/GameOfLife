using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using GameOfLife.Domain;

namespace GameOfLife.Application
{
    public class GameRules : IGameRules
    {
        
        public World InitialiseWorld(World world, int worldRows, int worldColumns)
        {
            var cell = new Cell();
            var createWorld = world;
            createWorld.WorldPopulation = new Cell[worldRows,worldColumns];

            var rnd = new Random();
            for(var i = 0; i < worldRows; i++)
            {
                for (var j = 0; j < worldColumns; j++)
                {
                    cell.IsAlive = rnd.Next(10) >= 5;
                    createWorld.WorldPopulation[i, j] = cell;
                }
            }
            return world;
        }

        public World PopulateWorldWithNextGen(World world)
        {
            var nextGen = new World();
            var originalGen = world;
           
            var column = world.WorldPopulation.GetLength(1);
            var row = world.WorldPopulation.GetLength(0);;
            for (int x = 0; x < column; x++)
            {
                for (int y = 0; y < row; y++)
                {
                    if (originalGen.WorldPopulation[x, y].SurvivesNextGen)
                    {
                        originalGen.WorldPopulation[x, y].IsAlive = true;
                        originalGen.WorldPopulation[x, y].SurvivesNextGen = false;
                    }
                    else originalGen.WorldPopulation[x, y].IsAlive = false;
                    
                }
            }

            return originalGen;
        }
        

        public void CheckForLivingNeighbours(World world)
        {
            var rowCount = world.WorldPopulation.GetLength(0);
            var columnCount = world.WorldPopulation.GetLength(1);
            
            var column = columnCount;
            var row = rowCount;
            for (int x = 0; x < column; x++)
            {
                for (int y = 0; y < row; y++)
                {
                    int leftNeighbouringCell = (x > 0) ? x - 1 : column - 1;
                    int rightNeighbouringCell = (x < column - 1) ? x + 1 : 0;

                    int topNeighbouringCell = (y > 0) ? y - 1 : row - 1;
                    int bottomNeighbouringCell = (y <row - 1) ? y +1 : 0;

                    world.WorldPopulation[x, y].Neighbours = new List<Cell>();
                    world.WorldPopulation[x,y].Neighbours.Add(world.WorldPopulation[leftNeighbouringCell,topNeighbouringCell]);
                    world.WorldPopulation[x,y].Neighbours.Add(world.WorldPopulation[x,topNeighbouringCell]);
                    world.WorldPopulation[x,y].Neighbours.Add(world.WorldPopulation[rightNeighbouringCell,topNeighbouringCell]);
                    world.WorldPopulation[x,y].Neighbours.Add(world.WorldPopulation[leftNeighbouringCell,y]);
                    world.WorldPopulation[x,y].Neighbours.Add(world.WorldPopulation[rightNeighbouringCell,y]);
                    world.WorldPopulation[x,y].Neighbours.Add(world.WorldPopulation[leftNeighbouringCell,bottomNeighbouringCell]);
                    world.WorldPopulation[x,y].Neighbours.Add(world.WorldPopulation[x,bottomNeighbouringCell]);
                    world.WorldPopulation[x,y].Neighbours.Add(world.WorldPopulation[rightNeighbouringCell,bottomNeighbouringCell]);
                }
            }
        }
        
        
        public void DoesCellSurviveNextGen(Cell cell)
        {
            var liveNeighbours = cell.Neighbours.Count(x => x.IsAlive);

            if (cell.IsAlive)
            {
                if (liveNeighbours is 2 or 3) cell.SurvivesNextGen = true;
            }

            else
            {
                if (liveNeighbours > 3) cell.SurvivesNextGen = true;
            }
        }
    }
}