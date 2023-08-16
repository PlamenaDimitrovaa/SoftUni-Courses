namespace Library.Common
{
    public static class EntityValidationConstants
    {
        public static class Book
        {
            public const int TitleMaxLength = 50;
            public const int TitleMinLength = 10;

            public const int AuthorMaxLength = 50;
            public const int AuthorMinLength = 5;

            public const int DescriptionMaxLength = 5000;
            public const int DescriptionMinLength = 5;

            public const int RatingMaxLength = 10;
            public const int RatingMinLength = 0;
        }

        public static class Category
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 5;
        }
    }
}
