using GameOfLife.Domain;

namespace GameOfLifeTest
{
    public static class ExampleWorlds
    {
        public static World WorldEveryCellIsAlive()
        {
            var createWorld = new World();
            createWorld.InitialiseWorld(5,5);
            //createWorld.WorldPopulation = new Cell[5,5];
            
            createWorld.WorldPopulation[0, 0] = new Cell {IsAlive = true};
            createWorld.WorldPopulation[0, 1] = new Cell {IsAlive = true};
            createWorld.WorldPopulation[0, 2] = new Cell {IsAlive = true};
            createWorld.WorldPopulation[0, 3] = new Cell {IsAlive = true};
            createWorld.WorldPopulation[0, 4] = new Cell {IsAlive = true};
            
            createWorld.WorldPopulation[1, 0] = new Cell {IsAlive = true};
            createWorld.WorldPopulation[1, 1] = new Cell {IsAlive = true};
            createWorld.WorldPopulation[1, 2] = new Cell {IsAlive = true};
            createWorld.WorldPopulation[1, 3] = new Cell {IsAlive = true};
            createWorld.WorldPopulation[1, 4] = new Cell {IsAlive = true};
            
            createWorld.WorldPopulation[2, 0] = new Cell {IsAlive = true};
            createWorld.WorldPopulation[2, 1] = new Cell {IsAlive = true};
            createWorld.WorldPopulation[2, 2] = new Cell {IsAlive = true};
            createWorld.WorldPopulation[2, 3] = new Cell {IsAlive = true};
            createWorld.WorldPopulation[2, 4] = new Cell {IsAlive = true};
            
            createWorld.WorldPopulation[3, 0] = new Cell {IsAlive = true};
            createWorld.WorldPopulation[3, 1] = new Cell {IsAlive = true};
            createWorld.WorldPopulation[3, 2] = new Cell {IsAlive = true};
            createWorld.WorldPopulation[3, 3] = new Cell {IsAlive = true};
            createWorld.WorldPopulation[3, 4] = new Cell {IsAlive = true};
            
            createWorld.WorldPopulation[4, 0] = new Cell {IsAlive = true};
            createWorld.WorldPopulation[4, 1] = new Cell {IsAlive = true};
            createWorld.WorldPopulation[4, 2] = new Cell {IsAlive = true};
            createWorld.WorldPopulation[4, 3] = new Cell {IsAlive = true};
            createWorld.WorldPopulation[4, 4] = new Cell {IsAlive = true};

            return createWorld;
        }
        
        public static World WorldEveryCellIsDead()
        {
            var createWorld = new World();
            createWorld.InitialiseWorld(5,5);
            //createWorld.Size = 5;
            //createWorld.WorldPopulation = new Cell[5,5];
            
            createWorld.WorldPopulation[0, 0] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[0, 1] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[0, 2] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[0, 3] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[0, 4] = new Cell {IsAlive = false};
            
            createWorld.WorldPopulation[1, 0] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[1, 1] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[1, 2] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[1, 3] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[1, 4] = new Cell {IsAlive = false};
            
            createWorld.WorldPopulation[2, 0] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[2, 1] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[2, 2] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[2, 3] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[2, 4] = new Cell {IsAlive = false};
            
            createWorld.WorldPopulation[3, 0] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[3, 1] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[3, 2] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[3, 3] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[3, 4] = new Cell {IsAlive = false};
            
            createWorld.WorldPopulation[4, 0] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[4, 1] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[4, 2] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[4, 3] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[4, 4] = new Cell {IsAlive = false};
            
            return createWorld;
        }
        
        public static World WorldEveryCellOnFirstRowIsAlive()
        {
            var createWorld = new World();
            createWorld.InitialiseWorld(5,5);

            createWorld.WorldPopulation[0, 0] = new Cell {IsAlive = true};
            createWorld.WorldPopulation[0, 1] = new Cell {IsAlive = true};
            createWorld.WorldPopulation[0, 2] = new Cell {IsAlive = true};
            createWorld.WorldPopulation[0, 3] = new Cell {IsAlive = true};
            createWorld.WorldPopulation[0, 4] = new Cell {IsAlive = true};
            
            createWorld.WorldPopulation[1, 0] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[1, 1] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[1, 2] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[1, 3] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[1, 4] = new Cell {IsAlive = false};
            
            createWorld.WorldPopulation[2, 0] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[2, 1] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[2, 2] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[2, 3] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[2, 4] = new Cell {IsAlive = false};
            
            createWorld.WorldPopulation[3, 0] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[3, 1] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[3, 2] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[3, 3] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[3, 4] = new Cell {IsAlive = false};
            
            createWorld.WorldPopulation[4, 0] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[4, 1] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[4, 2] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[4, 3] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[4, 4] = new Cell {IsAlive = false};
            
            return createWorld;
        }
        
        public static World CellsWontSurviveNextGenWorld()
        {
            var createWorld = new World();
            createWorld.InitialiseWorld(5,5);

            createWorld.WorldPopulation[0, 0] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[0, 1] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[0, 2] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[0, 3] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[0, 4] = new Cell {IsAlive = false};
            
            createWorld.WorldPopulation[1, 0] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[1, 1] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[1, 2] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[1, 3] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[1, 4] = new Cell {IsAlive = false};
            
            createWorld.WorldPopulation[2, 0] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[2, 1] = new Cell {IsAlive = true};
            createWorld.WorldPopulation[2, 2] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[2, 3] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[2, 4] = new Cell {IsAlive = false};
            
            createWorld.WorldPopulation[3, 0] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[3, 1] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[3, 2] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[3, 3] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[3, 4] = new Cell {IsAlive = false};
            
            createWorld.WorldPopulation[4, 0] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[4, 1] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[4, 2] = new Cell {IsAlive = false};
            createWorld.WorldPopulation[4, 3] = new Cell {IsAlive = true};
            createWorld.WorldPopulation[4, 4] = new Cell {IsAlive = false};
            
            return createWorld;
        }
    }
}