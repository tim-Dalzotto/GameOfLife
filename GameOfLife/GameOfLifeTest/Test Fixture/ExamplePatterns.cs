namespace GameOfLifeTest
{
    public static class ExamplePatterns
    {
        public static readonly string[] EveryCellAlive = new string[5]
        {
            "OOOOO", 
            "OOOOO",
            "OOOOO",
            "OOOOO",
            "OOOOO"
        };
        // public static string[] EveryCellAlive()
        // {
        //     var EverythingAlive = new string[]
        //     {
        //         "OOOOO", 
        //         "OOOOO",
        //         "OOOOO",
        //         "OOOOO",
        //         "OOOOO"
        //     };
        //     return EverythingAlive;
        // }

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
            "OOOOO", 
            "-----",
            "-----",
            "-----",
            "-----"
        };
        
        public static string[] ExampleBoxPattern = new string[2]
        {
            "--OOO-\n",
            "-OOO--\n"
        };
    }
}