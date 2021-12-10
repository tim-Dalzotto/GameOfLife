using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using GameOfLife.Domain;

namespace GameOfLife.Application
{
    public class GameRules : IGameRules
    {
        
        public World InitialiseWorld(World world)
        {
            var createWorld = world;
            createWorld.WorldPopulation = new Cell[world.Size,world.Size];

            var rnd = new Random();
            for(var i = 0; i < world.Size; i++)
            {
                for (var j = 0; j < world.Size; j++)
                {
                    createWorld.WorldPopulation[i, j] = new Cell
                    {
                        IsAlive = rnd.Next(10) >= 5
                    };
                }
            }
            return world;
        }

        public World PopulateWorldWithNextGen(World world)
        {
            var originalGen = world;
           
            var column = world.WorldPopulation.GetLength(1);
            var row = world.WorldPopulation.GetLength(0);
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

                    world.WorldPopulation[x, y].Neighbours = new List<Cell>
                    {
                        world.WorldPopulation[leftNeighbouringCell, topNeighbouringCell],
                        world.WorldPopulation[x, topNeighbouringCell],
                        world.WorldPopulation[rightNeighbouringCell,topNeighbouringCell],
                        world.WorldPopulation[leftNeighbouringCell,y],
                        world.WorldPopulation[rightNeighbouringCell,y],
                        world.WorldPopulation[leftNeighbouringCell,bottomNeighbouringCell],
                        world.WorldPopulation[x,bottomNeighbouringCell],
                        world.WorldPopulation[rightNeighbouringCell,bottomNeighbouringCell]
                    };
                }
            }
        }

        public void CheckForLivingN(World world)
        {
            var rowCount = world.WorldPopulation.GetLength(0);
            var columnCount = world.WorldPopulation.GetLength(1);
            
            var column = columnCount;
            var row = rowCount;

            
            for (int x = 0; x < column; x++)
            {
                for (int y = 0; y < row; y++)
                {
                    var currentCell = world.WorldPopulation[x, y];
                    var liveNeighbours = 0;
                    
                    int leftNeighbouringCell = (x > 0) ? x - 1 : column - 1;
                    int rightNeighbouringCell = (x < column - 1) ? x + 1 : 0;

                    int topNeighbouringCell = (y > 0) ? y - 1 : row - 1;
                    int bottomNeighbouringCell = (y <row - 1) ? y +1 : 0;
                    
                    liveNeighbours+= world.WorldPopulation[leftNeighbouringCell, y].IsAlive ? 1:0;
                    liveNeighbours+= world.WorldPopulation[leftNeighbouringCell, topNeighbouringCell].IsAlive ? 1:0;
                    liveNeighbours+= world.WorldPopulation[x, topNeighbouringCell].IsAlive ? 1:0;
                    liveNeighbours+= world.WorldPopulation[rightNeighbouringCell,topNeighbouringCell].IsAlive ? 1:0;
                    liveNeighbours+= world.WorldPopulation[rightNeighbouringCell,y].IsAlive ? 1:0;
                    liveNeighbours+= world.WorldPopulation[leftNeighbouringCell,bottomNeighbouringCell].IsAlive ? 1:0;
                    liveNeighbours+= world.WorldPopulation[x,bottomNeighbouringCell].IsAlive ? 1:0;
                    liveNeighbours+= world.WorldPopulation[rightNeighbouringCell,bottomNeighbouringCell].IsAlive ? 1:0;

                    if (currentCell.IsAlive && liveNeighbours is 2 or 3)
                    {
                        currentCell.SurvivesNextGen = true;
                    }
                    else if(currentCell.IsAlive && liveNeighbours > 3)
                    {
                        currentCell.SurvivesNextGen = false;
                    }
                    else if(currentCell.IsAlive && liveNeighbours < 2)
                    {
                        currentCell.SurvivesNextGen = false;
                    }
                    else if (!currentCell.IsAlive && liveNeighbours == 3)
                    {
                        currentCell.SurvivesNextGen = true;
                    }

                    world.WorldPopulation[x, y] = currentCell;

                }
            }
        }

        #region I Dont Care
        

        //This needs to take in the list of Tuple not the list of string, the split needs to happen outside the method-----------------
        public World LoadListIntoWorld(List<string> livingCellCoOrds, World world)
        {
            var boardCoOrds = splitCoOrds(livingCellCoOrds);
            
            var createWorld = world;
            
            for (int i = 0; i < boardCoOrds.Count; i++)
            {
                createWorld.WorldPopulation[boardCoOrds.ElementAt(i).Item1, boardCoOrds.ElementAt(i).Item2].IsAlive = true;
            }
            
            return createWorld;
        }

        public List<Tuple<int,int>> splitCoOrds(List<string> livingCells)
        {
            var listOfXAndYCoOrds = new List<Tuple<int, int>>();
            foreach (var cell in livingCells)
            {
                var xAndYCoOrds = cell.Split(',');
                listOfXAndYCoOrds.Add(new Tuple<int, int>(Int32.Parse(xAndYCoOrds[0]), Int32.Parse(xAndYCoOrds[1])));
                
            }

            return listOfXAndYCoOrds;
        }

        public string[] splitPattern(string pattern)
        {
            var patternSplitIntoLines = pattern.Split('\n');
            return patternSplitIntoLines;
        }

        public World LoadPatternIntoWorld(string[] patternSplitIntoLines, World currentGeneration)
        {
            int yOffSet = (currentGeneration.Size - patternSplitIntoLines.Length) / 2;
            int xOffSet = (currentGeneration.Size - patternSplitIntoLines[0].Length) / 2;

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

        public void KillAllCells(World currentGeneration)
        {
            foreach (var cell in currentGeneration.WorldPopulation)
            {
                cell.IsAlive = false;
            }
        }
        

        #endregion
        
        
        
        
    }
}