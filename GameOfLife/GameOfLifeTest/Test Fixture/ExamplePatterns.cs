namespace GameOfLifeTest
{
    public static class ExamplePatterns
    {
        public static readonly string[] EveryCellAlive = new string[5]
        {
            "00000",
            "00000",
            "00000",
            "00000",
            "00000"
        };

        public static string[] EveryCellDead = new string[5]
        {
            "-----",
            "-----",
            "-----",
            "-----",
            "-----"
        };

        public static string[] PatternTopRowAlive = new string[5]
        {
            "00000",
            "-----",
            "-----",
            "-----",
            "-----"
        };

        public static string[] ExampleBoxPattern = new string[2]
        {
            "--000-",
            "-000--"
        };

        public static string[] ExampleDuckPattern = new string[6]
        {
            "--------",
            "-000000-",
            "0-----0-",
            "------0-",
            "0----0--",
            "--00----"
        };
        
        public static string[] Only00Alive = new string[5]
        {
            "0----",
            "-----",
            "-----",
            "-----",
            "-----"
        };

        public static string[,] ExampleMultidimensionalStringArrayOnly00Alive2()
        {
            var only00Alive= new string[5, 5];
            only00Alive[0, 0] = "0";
            only00Alive[0, 1] = "-";
            only00Alive[0, 2] = "-";
            only00Alive[0, 3] = "-";
            only00Alive[0, 4] = "-";

            only00Alive[1, 0] = "-";
            only00Alive[1, 1] = "-";
            only00Alive[1, 2] = "-";
            only00Alive[1, 3] = "-";
            only00Alive[1, 4] = "-";

            only00Alive[2, 0] = "-";
            only00Alive[2, 1] = "-";
            only00Alive[2, 2] = "-";
            only00Alive[2, 3] = "-";
            only00Alive[2, 4] = "-";

            only00Alive[3, 0] = "-";
            only00Alive[3, 1] = "-";
            only00Alive[3, 2] = "-";
            only00Alive[3, 3] = "-";
            only00Alive[3, 4] = "-";

            only00Alive[4, 0] = "-";
            only00Alive[4, 1] = "-";
            only00Alive[4, 2] = "-";
            only00Alive[4, 3] = "-";
            only00Alive[4, 4] = "-";

            return only00Alive;
        }
        public static string[,] ExampleMultidimensionalStringArrayAllCellsDead()
        {
            var only00Alive= new string[5, 5];
            only00Alive[0, 0] = "-";
            only00Alive[0, 1] = "-";
            only00Alive[0, 2] = "-";
            only00Alive[0, 3] = "-";
            only00Alive[0, 4] = "-";

            only00Alive[1, 0] = "-";
            only00Alive[1, 1] = "-";
            only00Alive[1, 2] = "-";
            only00Alive[1, 3] = "-";
            only00Alive[1, 4] = "-";

            only00Alive[2, 0] = "-";
            only00Alive[2, 1] = "-";
            only00Alive[2, 2] = "-";
            only00Alive[2, 3] = "-";
            only00Alive[2, 4] = "-";

            only00Alive[3, 0] = "-";
            only00Alive[3, 1] = "-";
            only00Alive[3, 2] = "-";
            only00Alive[3, 3] = "-";
            only00Alive[3, 4] = "-";

            only00Alive[4, 0] = "-";
            only00Alive[4, 1] = "-";
            only00Alive[4, 2] = "-";
            only00Alive[4, 3] = "-";
            only00Alive[4, 4] = "-";

            return only00Alive;
        }
}
}