using GameOfLife.ConsoleOut;
using GameOfLife.Domain;

namespace GameOfLifeTest
{
    public class TestOutput : IOutput
    {
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

        public void DisplayChoiceForRowsMessage()
        {
            throw new System.NotImplementedException();
        }

        public void DisplayChoiceForColumnsMessage()
        {
            throw new System.NotImplementedException();
        }
    }
}