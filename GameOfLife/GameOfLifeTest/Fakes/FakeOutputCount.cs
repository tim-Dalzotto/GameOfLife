using GameOfLife.Domain;
using GameOfLife.Interfaces;

namespace GameOfLifeTest
{
    public class FakeOutputCount : IOutput
    {
        public int Count { get; set; } = 0;
        public void DisplayWorld(World world)
        {
            throw new System.NotImplementedException();
        }

        public void DisplayPatternSelection()
        {
            throw new System.NotImplementedException();
        }

        public void DisplayGameBoardSizeSelectionMessage(int minRowSize, int minColumnSize)
        {
            throw new System.NotImplementedException();
        }

        public void DisplayPatternSelectionFromFile(string[] arrayOfPatternsToBeDisplayed)
        {
            throw new System.NotImplementedException();
        }
        
        public void DisplayChoiceForRowsMessage()
        {
            throw new System.NotImplementedException();
        }

        public void DisplayChoiceForColumnsMessage()
        {
            throw new System.NotImplementedException();
        }

        public void DisplayMessage(string message)
        {
            throw new System.NotImplementedException();
        }

        public void DisplayGameCell(string message)
        {
            Count++;
        }

        public void DisplayOptionsForSaveQuitingAndPausing()
        {
            throw new System.NotImplementedException();
        }

        public void DisplayCustomWorldBuilder(int height, int length, int cursorYValue, int cursorXValue, string[,] customPattern)
        {
            throw new System.NotImplementedException();
        }

        public void ClearGameBoard()
        {
            throw new System.NotImplementedException();
        }

        public void DisplayOptionsForPatternBuilder()
        {
            throw new System.NotImplementedException();
        }
    }
}