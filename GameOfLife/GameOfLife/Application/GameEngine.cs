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
        private readonly IKeyPress _keyPress;
        private readonly Pattern _pattern;

        public GameEngine(IUserInput input, IOutput output, IKeyPress keyPress, Pattern pattern)
        {
            _output = output;
            _input = input;
            _keyPress = keyPress;
            _pattern = pattern;
        }
        public World RunNextGeneration(World world)
        {
            var currentGeneration = world; 

            var nextGeneration = GameRules.UpdateWorldWithNextGen(currentGeneration);
            
            return nextGeneration;
        }
        
        public void PlayGame(World world)
        {
            var gameWorld = GameRules.CreateInitialWorld(world);
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
                    Console.Clear();
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
                    _pattern.UpdatePatternFromGameWorldStringArray(gameWorld);
                    WantToSaveWorld(_pattern.CurrentPattern);
                }
                if (userInput == 'Q')
                {
                    keepRunning = false;
                }
            }   
        }

        public virtual void WantToSaveWorld(string[] currentPattern)
        {
            _output.DisplayMessage("Please Enter file name");
            var fileName = _input.GetUserInput();
            PatternSaver.SavePatternToFile(currentPattern, fileName);
        }
    }
}