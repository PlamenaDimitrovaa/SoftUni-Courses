
namespace Artillery.Common
{
    public static class ValidationConstants
    {
        public const int CountryNameMaxLength = 60;
        public const int CountryNameMinLength = 4;
        public const int ArmySizeFrom = 50000;
        public const int ArmySizeTo = 10000000;

        public const int ManufacturerNameMaxLength = 40;
        public const int ManufacturerNameMinLength = 4;
        public const int FoundedMaxLength = 100;
        public const int FoundedMinLength = 10;

        public const int ShellWeightFrom = 2;
        public const int ShellWeightTo = 1680;
        public const int CaliberMaxLength = 30;
        public const int CaliberMinLength = 4;

        public const int GunWeightFrom = 100;
        public const int GunWeightTo = 1350000;
        public const double BarrelLengthFrom = 2.00;
        public const double BarrelLengthTo = 35.00;
        public const int RangeFrom = 1;
        public const int RangeTo = 100000;
    }
}
