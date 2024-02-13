namespace SoftUniBazar.Constraints
{
    public static class ValidationValues
    {
        public const string DateFormat= "yyyy-MM-dd H:mm";
        public static class AdConstraints
        {
            public const int MaxName = 25;
            public const int MinName = 5;
            public const int MaxDescription = 250;
            public const int MinDescription = 15;

        }
        public static class CategoryConstraints
        {
            public const int MaxName = 15;
            public const int MinName = 3;

        }

    }
}
