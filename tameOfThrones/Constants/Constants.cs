namespace geektrust.Constants
{
    public enum Kingdom
    {
        SPACE = 0,
        LAND = 1,
        WATER = 2,
        ICE = 3,
        AIR = 4,
        FIRE = 5
    }

    public enum Emblem
    {
        Gorilla = 0,
        Panda = 1,
        Octopus = 2,
        Mammoth = 3,
        Owl = 4,
        Dragon = 5
    }

    public static class ExceptionMessage
    {
        public static readonly string LessThanTwo = "Less than two words encountered in a line. Please input a valid file.";
        public static readonly string InvalidText = "Invalid Text in the given file. Please input a valid file.";
        public static readonly string SpecifyFilePath = "Please specify filepath.";
    }

    public static class TameOfThroneMessage
    {
        public static readonly string None = "NONE";
    }
}
