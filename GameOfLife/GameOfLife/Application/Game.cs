using System.Collections.Generic;
using GameOfLife.Domain;

namespace GameOfLife.Application
{
    public class Game
    {
        public World RunNextGeneration(World world)
        {
            var currentGeneration = world; 
            GameRules gameRule = new GameRules();
            
            gameRule.CheckForLivingNeighbours(currentGeneration);
            //gameRule.DoCellsSurviveNextGen(currentGeneration);
            
            var nextGeneration= gameRule.PopulateWorldWithNextGen(currentGeneration);
            
            return nextGeneration;
        }
    }
}