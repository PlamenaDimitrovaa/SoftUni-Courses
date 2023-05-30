namespace HouseRentingSystem.Data
{
    public static class DataConstants
    {
        public class Category
        {
            public const int NameMaxLength = 50;    
        }

        public class House
        {
            public const int TitleMinLength = 10;

            public const int TitleMaxLength = 50;

            public const int AddressMinLength = 30;

            public const int AddressMaxLength = 150;

            public const int DescriptionMinLength = 50;

            public const int DescriptionMaxLength = 500;

            public const int PricePerMonthMin = 0;

            public const int PricePerMonthMax = 2000;
        }

        public class Agent
        {
            public const int PhoneNumberMinLength = 7;

            public const int PhoneNumberMaxLength = 15;
        }
    }
}
