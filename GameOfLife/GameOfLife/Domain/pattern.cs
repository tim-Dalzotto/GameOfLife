namespace GameOfLife.Domain
{
    public class pattern
    {
        public string patternShip()
        {
            var shipPattern =
                "------\n" +
                "------\n" +
                "--OOO-\n" +
                "-OOO--\n" +
                "------\n" +
                "------";
            return shipPattern;
        }

        public string patternGlider()
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
        
        string _pattern2 = 
            "------\n" +
            "------\n" +
            "--OOO-\n" +
            "-OOO--\n" +
            "------\n" +
            "------";
        
    }
}