namespace GameOfLife.Domain
{
    public class pattern
    {
        public string PatternBox()
        {
            var shipPattern =

                "--OOO-\n" +
                "-OOO--\n";
               
            return shipPattern;
        }
        
        public string PatternDuck()
        {
            var shipPattern =
                "--------\n" +
                "-OOOOOO-\n" +
                "O-----O-\n" +
                "------O-\n" +
                "0----O--\n" +
                "--OO----";
            return shipPattern;
        }

        public string PatternGlider()
        {
            var gliderPattern =
                "-------------------------O----------\n" +
                "----------------------OOOO----O-----\n" +
                "-------------O-------OOOO-----O-----\n" +
                "------------O-O------O--O---------OO\n" +
                "-----------O---OO----OOOO---------OO\n" +
                "OO---------O---OO-----OOOO----------\n" +
                "OO---------O---OO--------O----------\n" +
                "------------O-O---------------------\n" +
                "-------------O----------------------";
            return gliderPattern;
        }
    }
}