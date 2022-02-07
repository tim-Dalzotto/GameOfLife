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

        public World CreateInitialWorld(string[] formattedPattern, int patternSize)
        {
            //Get selected Pattern
            //var loadedPattern = GetSelectedPattern(userInput, pattern);
            //Format pattern
            //var formattedPattern = splitPattern(loadedPattern);
            //get size of pattern
            //var patternSize = 0;
            //patternSize = formattedPattern[0].Length > formattedPattern.Length ? (formattedPattern[0].Length + 5): (formattedPattern.Length + 5);
            //initialise world
            var currentWorld = InitialiseWorld(new World(), patternSize);
            //load format pattern
            var currentWorldWithPattern = LoadPatternIntoWorld(formattedPattern, currentWorld);
            //return formatted World 
            return currentWorldWithPattern;
        }

        public static string GetSelectedPattern(int userInput, pattern pattern)
        {
            var loadedPattern = userInput switch
            {
                //find which pattern to use
                1 => pattern.patternGlider(),
                2 => pattern.patternShip(),
                _ => ""
            };
            return loadedPattern;
        }

        public World InitialiseWorldRectangle(World world, int height, int length)
        {
            var createWorld = world;
            //createWorld.Size = size;
            createWorld.WorldPopulation = new Cell[height,length];

            for(var i = 0; i < height; i++)
            {
                for (var j = 0; j < world.Size; j++)
                {
                    createWorld.WorldPopulation[i, j] = new Cell { };
                }
            }
            return world;
        }
        public World InitialiseWorld(World world, int size)
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
        
        public static string[] splitPattern(string pattern)
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

        #region Might not need this anymore
        
        //Don't need this anymore
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
        
        #endregion
        
        public World RunNextGeneration(World world)
        {
            var currentWorld = world;
            var rowCount = currentWorld.WorldPopulation.GetLength(0);
            var columnCount = currentWorld.WorldPopulation.GetLength(1);
            var column = columnCount;
            var row = rowCount;

            var newWorld = InitialiseWorld(new World(), currentWorld.Size);
            
            for (var x = 0; x < column; x++)
            {
                for (var y = 0; y < row; y++)
                {
                    var currentCell = currentWorld.WorldPopulation[x, y];
                    
                    var liveNeighbours = FindLiveNeighbours(x, column, y, row, currentWorld);

                    PopulateNextGeneration(currentCell, liveNeighbours, newWorld, x, y);
                    
                    currentWorld.WorldPopulation[x, y] = currentCell;
                }
            }

            return newWorld;
        }

        private static int FindLiveNeighbours(int x, int column, int y, int row, World currentWorld)
        {
            var liveNeighbours = 0;

            var leftNeighbouringCell = (x > 0) ? x - 1 : column - 1;
            var rightNeighbouringCell = (x < column - 1) ? x + 1 : 0;

            var topNeighbouringCell = (y > 0) ? y - 1 : row - 1;
            var bottomNeighbouringCell = (y < row - 1) ? y + 1 : 0;

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

        private static void PopulateNextGeneration(Cell currentCell, int liveNeighbours, World newWorld, int x, int y)
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

        #region I Dont Care
        
        #region load List 
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

        #endregion
        
        
        
        //creating and loading the world when a pattern is implamented so the size can be adaptive and doesn't have to be predefined.
        public World LoadPatternIntoWorldTest(string[] patternSplitIntoLines, World currentGeneration)
        {
            int yOffSet = (currentGeneration.Size - patternSplitIntoLines.Length) / 2;
            int xOffSet = (currentGeneration.Size - patternSplitIntoLines[0].Length) / 2;

            var testWolrd = InitialiseWorld(new World(), patternSplitIntoLines.Length);
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