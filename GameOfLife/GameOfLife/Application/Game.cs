using System.Collections.Generic;
using GameOfLife.Domain;

namespace GameOfLife.Application
{
    public class Game
    {
        public World RunNextGeneration(World world)
        {
            var currentGeneration = world; 
            var gameRule = new PatternLogic();

            var nextGeneration = GameRules.RunNextGeneration(currentGeneration);
            
            return nextGeneration;
        }
        
        
    }
}