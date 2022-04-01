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
            "00000", 
            "-----",
            "-----",
            "-----",
            "-----"
        };
        
        public static string[] ExampleBoxPattern = new string[2]
        {
            "--000-\n",
            "-000--\n"
        };
    }
}