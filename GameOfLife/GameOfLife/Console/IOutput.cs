using System;
using GameOfLife.Domain;

namespace GameOfLife.ConsoleOut
{
    public interface IOutput
    {
        public void DisplayWorld(World world);
        public void DisplayPatternSelection();
        public void DisplayGameBoardSizeSelectionMessage(int minRowSize, int minColumnSize);
        public void DisplayPatternSelectionFromFile();
        public void DisplayChoiceForRowsMessage();
        public void DisplayChoiceForColumnsMessage();
        public void DisplayMessage(string message);
        public void DisplayGameCell(string message);
        public void DisplayOptionsForSaveQuitingAndPausing();
        public void DisplayOptionsForPatternBuilder();
    }
}