using System.IO;
using GameOfLife.Domain;

namespace GameOfLife.ConsoleOut
{
    public class ConsoleOutput : IOutput
    {
        private readonly IConsoleIO _consoleIO;

        public ConsoleOutput(IConsoleIO consoleIo)
        {
            _consoleIO = consoleIo;
        }
        
        public void DisplayWorld(World world)
        {
            for (var i = 0; i < world.WorldPopulation.GetLength(0); i++)
            {
                for (var j = 0; j < world.WorldPopulation.GetLength(1); j++)
                {
                    DisplayGameCell(world.WorldPopulation[i, j].IsAlive ? "0" : "-");
                    DisplayGameCell(" ");
                }
                DisplayGameCell("\n");
            }
            DisplayMessage("Press 'p' at anytime to pause the simulation");
        }

        public void DisplayPatternSelectionFromFile(string[] arrayOfPatternToBeDisplayed)
        {
            DisplayMessage("Please select a pattern to load");
            var count = 1;
            foreach (var pattern in arrayOfPatternToBeDisplayed)
            {
                DisplayMessage($"{count.ToString()}: "+Path.GetFileName(pattern)[..^4]);
                count++;
            }
            DisplayMessage($"{count.ToString()}: Build a Custom Pattern");
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

        public void DisplayOptionsForSaveQuitingAndPausing()
        {
            DisplayMessage("Please select from the following options\n" +
                           "S: Save current world state to file\n" +
                           "C: Continue running simulation\n" +
                           "Q: Quit simulation" );
        }

        public void DisplayOptionsForPatternBuilder()
        {
            DisplayMessage("Press W,A,S,D to move the Cursor\n " +
                           "press P to Populate the cell or O to depopulate the cell \n " +
                           "Or press Q to quit world builder");
        }
        
        public void DisplayMessage(string message)
        {
            _consoleIO.WriteLine(message);
        }
        public void DisplayGameCell(string message)
        {
            _consoleIO.Write(message);
        }

    }
}