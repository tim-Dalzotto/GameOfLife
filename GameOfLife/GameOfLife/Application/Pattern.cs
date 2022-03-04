namespace GameOfLife.Domain
{
    public static class Pattern
    {
        private static string[] PatternBox()
        {
            var shipPattern = new string[]
            {
                "--OOO-\n", 
                "-OOO--\n"
            };
            return shipPattern;
        }
        
        private static string[] PatternDuck()
        {
            var shipPattern = new string[]
            {
                "--------",
                "-OOOOOO-",
                "O-----O-",
                "------O-",
                "0----O--",
                "--OO----"
            };
                
            return shipPattern;
        }

        private static string[] PatternGlider()
        {
            var gliderPattern = new string[]
            {
                "-------------------------O----------", 
                "----------------------OOOO----O-----", 
                "-------------O-------OOOO-----O-----",
                "------------O-O------O--O---------OO", 
                "-----------O---OO----OOOO---------OO",
                "OO---------O---OO-----OOOO----------", 
                "OO---------O---OO--------O----------", 
                "------------O-O---------------------", 
                "-------------O----------------------"
            };
                
            return gliderPattern;
        }
        
        public static string[] GetSelectedPattern(int userInput)
        {
            string[] loadedPattern;
            switch (userInput)
            {
                case 1:
                    loadedPattern = PatternGlider();
                    break;
                case 2:
                    loadedPattern = PatternBox();
                    break;
                case 3:
                    loadedPattern = PatternDuck();
                    break;
                default:
                    loadedPattern = new[] {""};
                    break;
            }

            return loadedPattern;
        }
    }
}