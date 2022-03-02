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
        private readonly pattern _pattern;
        private readonly IOutput _output;
        private readonly IUserInput _input;

        public GameEngine(IUserInput input, IOutput output)
        {
            _output = output;
            _input = input;
            _pattern = new pattern();
        }
        public World RunNextGeneration(World world)
        {
            var currentGeneration = world; 
            var gameRule = new PatternManager();

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
            var userSelectionPatternChoice = Convert.ToInt32(_input.GetUserInputPatternSelection());

            var patternTest = PatternManager.GetSelectedPattern(userSelectionPatternChoice, _pattern);
            var formattedPattern = PatternManager.SplitPattern(patternTest);
            
            
            var worldMinRowRequiredBasedOnSelectedPattern = formattedPattern.Length;
            var worldMinColumnsRequiredBasedOnSelectedPattern = formattedPattern[0].Length;
            _output.DisplayGameBoardSizeSelectionMessage( worldMinRowRequiredBasedOnSelectedPattern,worldMinColumnsRequiredBasedOnSelectedPattern);
            
            
            _output.DisplayChoiceForRowsMessage();
            var userSelectionHeight = Convert.ToInt32(_input.GetUserInputSize());
            _output.DisplayChoiceForColumnsMessage();
            var userSelectionLength = Convert.ToInt32(_input.GetUserInputPatternSelection());
            
            var world = new World();
            world.Height = userSelectionHeight;
            world.Length = userSelectionLength;
            
            var gameWorld = GameRules.CreateInitialWorld(formattedPattern, world);
            
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