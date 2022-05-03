using System;
using System.Collections.Generic;
using System.Threading;
using GameOfLife.ConsoleOut;
using GameOfLife.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GameOfLife.Application
{
    public class GameEngine : IGameEngine
    {
        private readonly IOutput _output;
        private readonly IUserInput _input;
        private readonly IConsoleKeyPress _keyPress;

        public GameEngine(IUserInput input, IOutput output, IConsoleKeyPress keyPress)
        {
            _output = output;
            _input = input;
            _keyPress = keyPress;
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

        public void RunSimulation(World gameWorld)
        {
            var count = 1;
            var keepRunning = true;
            while (keepRunning)
            {
                while (!(_keyPress.CheckKeyAvailable() && _keyPress.CheckReadKey() == ConsoleKey.P))
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
                    keepRunning = false;
                }
            }   
        }

        public void WantToSaveWorld(string[] currentPattern)
        {
            _output.DisplayMessage("Please Enter file name");
            var fileName = _input.GetUserInput();
            Pattern.SavePatternToFile(currentPattern, fileName);
        }
    }
}