using System;
using System.IO;
using System.Linq;
using GameOfLife.Application;
using GameOfLife.Domain;

namespace GameOfLife.ConsoleOut
{
    public class ConsoleOutput : IOutput
    {
        private readonly IConsoleIO ConsoleIo;

        public ConsoleOutput(IConsoleIO consoleIo)
        {
            ConsoleIo = consoleIo;
        }
        
        public void DisplayWorld(World world)
        {
            Console.Clear();
            for (var i = 0; i < world.WorldPopulation.GetLength(0); i++)
            {
                for (var j = 0; j < world.WorldPopulation.GetLength(1); j++)
                {
                    DisplayGameCell(world.WorldPopulation[i, j].IsAlive == true ? "0" : "-");
                    DisplayGameCell(" ");
                }
                DisplayGameCell("\n");
            }
            DisplayMessage("Press 'p' at anytime to pause the simulation");
        }

        public void DisplayPatternSelection()
        {
            DisplayMessage("Please select a pattern to load");
            DisplayMessage($"1.{Pattern.PatternEnum.Glider}");
            //DisplayMessage($"1.{Enum.GetName(typeof(Pattern.PatternEnum),1)}");
            DisplayMessage($"2.{Pattern.PatternEnum.Box}");
            DisplayMessage($"3.{Pattern.PatternEnum.Duck}");
        }

        public void DisplayPatternSelectionFromFile()
        {
            DisplayMessage("Please select a pattern to load");
            var count = 1;
            foreach (var pattern in Pattern.GetPatternNamesFromFile())
            {
                DisplayMessage($"{count.ToString()}: "+Path.GetFileName(pattern)[..^4]);
                count++;
            }
        }

        public void DisplayGameBoardSizeSelectionMessage(int minRowSize, int minColumnSize)
        {
            DisplayMessage(
                "Select the size of the game board you would like to use, " +
                $"min requirements for selected pattern is {minRowSize.ToString()}X{minColumnSize.ToString()}");
        }

        public void DisplayChoiceForRowsMessage()
        {
            DisplayMessage("How many rows would you like?");
        }

        public void DisplayChoiceForColumnsMessage()
        {
            DisplayMessage("How many columns would you like?");
        }
        
        public void DisplayMessage(string message)
        {
            ConsoleIo.WriteLine(message);
        }
        
        public void DisplayGameCell(string message)
        {
            Console.Write($"{message}");
        }

    }
}