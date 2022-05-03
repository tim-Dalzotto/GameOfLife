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
    }
}