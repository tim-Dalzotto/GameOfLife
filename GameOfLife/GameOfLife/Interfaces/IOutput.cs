using GameOfLife.Domain;

namespace GameOfLife.Interfaces
{
    public interface IOutput
    {
        public void DisplayWorld(World world);
        public void DisplayGameBoardSizeSelectionMessage(int minRowSize, int minColumnSize);
        public void DisplayPatternSelectionFromFile(string[] arrayOfPatternsToBeDisplayed);
        public void DisplayChoiceForRowsMessage();
        public void DisplayChoiceForColumnsMessage();
        public void DisplayMessage(string message);
        public void DisplayGameCell(string message);
        public void DisplayOptionsForSaveQuitingAndPausing();
        void DisplayCustomWorldBuilder(int height, int length, int cursorYValue, int cursorXValue,
            string[,] customPattern);

        void ClearGameBoard();
        public void DisplayOptionsForPatternBuilder();
    }
}