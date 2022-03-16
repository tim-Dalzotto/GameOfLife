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
        //private readonly Pattern _pattern;
        private readonly IOutput _output;
        private readonly IUserInput _input;

        public GameEngine(IUserInput input, IOutput output)
        {
            _output = output;
            _input = input;
            //_pattern = new Pattern();
        }
        public World RunNextGeneration(World world)
        {
            var currentGeneration = world; 

            var nextGeneration = GameRules.UpdateWorldWithNextGen(currentGeneration);
            
            return nextGeneration;
        }

        public WorldGenerationsInfo GameSetup()
        {
            _output.DisplayPatternSelection();
            var userSelectionPatternChoice = _input.GetUserInput();

            var selectedPattern = Pattern.GetSelectedPattern(userSelectionPatternChoice);
            
            
            
            var worldMinRowRequiredBasedOnSelectedPattern = selectedPattern.Length;
            var worldMinColumnsRequiredBasedOnSelectedPattern = selectedPattern[0].Length;
            _output.DisplayGameBoardSizeSelectionMessage( worldMinRowRequiredBasedOnSelectedPattern,worldMinColumnsRequiredBasedOnSelectedPattern);
            
            
            _output.DisplayChoiceForRowsMessage();
            var userSelectedHeight = _input.GetUserInput();
            _output.DisplayChoiceForColumnsMessage();
            var userSelectedLength = _input.GetUserInput();

            return new WorldGenerationsInfo(userSelectedHeight, userSelectedLength, selectedPattern);
        }

        public void PlayGame(string[] pattern, int height, int length)
        {
            
            //var gameWorld = GameRules.CreateInitialWorld(selectedPattern, userSelectedHeight, userSelectedLength);
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