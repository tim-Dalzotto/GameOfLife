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

        public void PlayGame()
        {
            //var gameRules = new PatternLogic();
            //var game = new Game();
            // var pattern = new pattern();
            // var output = new IOutput();

           
            _output.DisplayPatternSelection();
            var userSelectionPatternChoice = _input.GetUserInputPatternSelection();

            var selectedPattern = Pattern.GetSelectedPattern(userSelectionPatternChoice);
            
            
            
            var worldMinRowRequiredBasedOnSelectedPattern = selectedPattern.Length;
            var worldMinColumnsRequiredBasedOnSelectedPattern = selectedPattern[0].Length;
            _output.DisplayGameBoardSizeSelectionMessage( worldMinRowRequiredBasedOnSelectedPattern,worldMinColumnsRequiredBasedOnSelectedPattern);
            
            
            _output.DisplayChoiceForRowsMessage();
            var userSelectedHeight = _input.GetUserInputSize();
            _output.DisplayChoiceForColumnsMessage();
            var userSelectedLength = _input.GetUserInputSize();
            
            // var world = new World();
            // world.Height = userSelectedHeight;
            // world.Length = userSelectedLength;
            
            var gameWorld = GameRules.CreateInitialWorld(selectedPattern, userSelectedHeight, userSelectedLength);
            
            RunSimulation(gameWorld);
            
        }

        private void RunSimulation(World gameWorld)
        {
            var count = 0;
            var gameRunOut = 0;
            var listOfPreviousWorlds = new List<string>();
            while ( count < 100 )
            {
                _output.DisplayWorld(gameWorld);
                gameWorld = RunNextGeneration(gameWorld);
                if (SimEndCriteria.SimulationRepeated(listOfPreviousWorlds,gameWorld))
                    gameRunOut++;
                if(gameRunOut >10)
                    break;
                listOfPreviousWorlds.Add(JsonConvert.SerializeObject(gameWorld));
                Thread.Sleep(100);
                
                count++;
            }   
        }
        
        
    }
}