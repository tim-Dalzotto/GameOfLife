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
            var count = 1;
            while (true)
            {
                while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.P))
                {
                    _output.DisplayMessage(count.ToString());
                    _output.DisplayWorld(gameWorld);
                    gameWorld = RunNextGeneration(gameWorld);
                    Thread.Sleep(100);
                    count++;
                }
                _output.DisplayMessage("Please select from the following options\n" +
                                       "S: Save current world state to file\n" +
                                       "C: Continue running simulation\n" +
                                       "Q: Quit simulation" );
                var userInput = char.Parse(_input.GetUserInput());
                if (userInput == 'S')
                {
                    WantToSaveWorld(Pattern.ConvertCellArrayToStringArray(gameWorld));
                }
                if (userInput == 'Q')
                {
                    break;
                }
            }   
        }

        private void WantToSaveWorld(string[] currentPattern)
        {
            _output.DisplayMessage("Please Enter file name");
            var fileName = _input.GetUserInput();
            Pattern.SavePatternToFile(currentPattern, fileName);
        }
    }
}