namespace SeminarHub.Constraints.ValidationValues
{
    public static class ValidationValues
    {
        public static class Seminar
        {
            public const int TopicMin = 3;
            public const int TopicMax = 100;
            public const int LecturerMin = 5;
            public const int LecturerMax = 60;
            public const int DetailsMin = 10;
            public const int DetailsMax = 500;
            public const int DurationMin = 30;
            public const int DurationMax = 180;
            public const string DateFormat = "dd/MM/yyyy HH:mm";
        }
        public static class Category
        {
            public const int NameMin = 3;
            public const int NameMax = 50;
        }



    }
}
