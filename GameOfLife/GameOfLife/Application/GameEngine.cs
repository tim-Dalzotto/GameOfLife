using System;
using System.Collections.Generic;
using System.Threading;
using GameOfLife.ConsoleOut;
using GameOfLife.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GameOfLife.Application
{
    public class GameEngine
    {
        private readonly IOutput _output;
        private readonly IUserInput _input;

        public GameEngine(IUserInput input, IOutput output)
        {
            _output = output;
            _input = input;
        }
        public World RunNextGeneration(World world)
        {
            var currentGeneration = world; 

            var nextGeneration = GameRules.UpdateWorldWithNextGen(currentGeneration);
            
            return nextGeneration;
        }
        
        public void PlayGame(string[] pattern, int height, int length)
        {
            var gameWorld = GameRules.CreateInitialWorld(pattern,height,length);
            RunSimulation(gameWorld);
            
        }

        private void RunSimulation(World gameWorld)
        {
            var count = 0;
            while ( count < 100 )
            {
                _output.DisplayWorld(gameWorld);
                gameWorld = RunNextGeneration(gameWorld);
                Thread.Sleep(100);
                
                count++;
            }   
        }
    }
}