using System;
using System.Collections.Generic;
using System.Threading;
using GameOfLife.ConsoleOut;
using GameOfLife.Constants;
using GameOfLife.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GameOfLife.Application
{
    public class GameEngine
    {
        private readonly IOutput _output;
        private readonly IUserInput _input;
        private readonly IKeyPress _keyPress;
        private readonly Pattern _pattern;
        private World _world;

        public GameEngine(IUserInput input, IOutput output, IKeyPress keyPress, Pattern pattern, World world)
        {
            _output = output;
            _input = input;
            _keyPress = keyPress;
            _pattern = pattern;
            _world = world;
        }
        public World RunNextGeneration()
        {
            var currentGeneration = _world; 

            var nextGeneration = GameRules.UpdateWorldWithNextGen(currentGeneration);
            
            return nextGeneration;
        }

        public void RunSimulation()
        {
            var count = 1;
            var previousWorld = "";
            var keepRunning = true;
            while (keepRunning)
            {
                while (!(_keyPress.CheckKeyAvailable() && _keyPress.CheckReadKey() == ConsoleKey.P))
                {
                    Console.Clear();
                    _output.DisplayMessage(count.ToString());
                    _output.DisplayWorld(_world);
                    previousWorld = JsonConvert.SerializeObject(_world);
                    _world = RunNextGeneration();
                    Thread.Sleep(1000);
                    count++;
                    if (SimEndCriteria.SimulationRepeated(previousWorld, _world))
                        break;
                }
                char userInput;
                while (true)
                {
                    _output.DisplayOptionsForSaveQuitingAndPausing();
                    var stringUserInput = _input.GetUserInput().ToLower();
                    if (!Validator.ValidCharFromListOfChars(stringUserInput,ValidationConstants.AllowedCharsForSimulationMenuOptions)) continue;
                    userInput = char.Parse(stringUserInput);
                    break;
                }
                
                switch (userInput)
                {
                    case 's':
                        _pattern.UpdatePatternFromGameWorldStringArray(_world);
                        SaveWorld(_pattern.CurrentPattern);
                        break;
                    case 'q':
                        keepRunning = false;
                        break;
                    case 'c':
                        continue;
                }
            }   
        }

        public virtual void SaveWorld(string[] currentPattern)
        {
            var rootPath = new RootPathConstant();
            var patternSaver = new PatternSaver(rootPath);
            _output.DisplayMessage("Please Enter file name");
            var fileName = _input.GetUserInput();
            patternSaver.SavePatternToFile(currentPattern, fileName);
        }
        
    }
}