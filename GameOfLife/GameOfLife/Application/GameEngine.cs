using System;
using System.Collections.Generic;
using System.Threading;
using GameOfLife.ConsoleOut;
using GameOfLife.Domain;

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

            var nextGeneration = GameRules.RunNextGeneration(currentGeneration);
            
            return nextGeneration;
        }

        public void PlayGame()
        {
            //var gameRules = new PatternLogic();
            //var game = new Game();
            // var pattern = new pattern();
            // var output = new IOutput();

           
            _output.DisplayPatternSelection();
            var userSelectionPatternChoice = Convert.ToInt32(Console.ReadLine());

            var patternTest = PatternManager.GetSelectedPattern(userSelectionPatternChoice, _pattern);
            var formattedPattern = PatternManager.SplitPattern(patternTest);
            
            
            var worldMinRowRequiredBasedOnSelectedPattern = formattedPattern.Length;
            var worldMinColumnsRequiredBasedOnSelectedPattern = formattedPattern[0].Length;
            _output.DisplayGameBoardSizeSelectionMessage( worldMinRowRequiredBasedOnSelectedPattern,worldMinColumnsRequiredBasedOnSelectedPattern);
            
            
            _output.DisplayChoiceForRowsMessage();
            var userSelectionHeight = Convert.ToInt32(_input.GetUserInput());
            _output.DisplayChoiceForColumnsMessage();
            var userSelectionLength = Convert.ToInt32(_input.GetUserInput());
            
            var world = new World();
            world.Height = userSelectionHeight;
            world.Length = userSelectionLength;
            
            var gameWorld = GameRules.CreateInitialWorld(formattedPattern, world);
            
            var count = 0;
            while (count < 100)
            {
                _output.DisplayWorld(gameWorld);
                gameWorld = RunNextGeneration(gameWorld);
                Thread.Sleep(100);
                count++;
            }
        }
        
        
    }
}