using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using GameOfLife.Domain;

namespace GameOfLife.Application
{
    public class PatternLogic : IGameRules
    {
        public static string GetSelectedPattern(int userInput, pattern pattern)
        {
            var loadedPattern = userInput switch
            {
                //select Pattern
                1 => pattern.patternGlider(),
                2 => pattern.patternShip(),
                3 => pattern.patternDuck(),
                _ => ""
            };
            return loadedPattern;
        }
        
        public static string[] SplitPattern(string pattern)
       {
            var patternSplitIntoLines = pattern.Split('\n');
            return patternSplitIntoLines.SkipLast(1).ToArray();
       }
        
        public World LoadPatternIntoWorld(string[] patternSplitIntoLines, World currentGeneration)
        {
            int yOffSet = (currentGeneration.Height - patternSplitIntoLines[0].Length) / 2;
            int xOffSet = (currentGeneration.Length - patternSplitIntoLines.Length) / 2;
        
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