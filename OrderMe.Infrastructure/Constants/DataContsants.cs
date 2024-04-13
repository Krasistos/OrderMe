using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMe.Infrastructure.Constants
{
    public static class DataConstants
    {
        public const int OrderMeAgencyNameMaxLength = 100;


        public const double LocationLatitudeMin = -90;
        public const double LocationLatitudeMax = 90;

        public const double LocationLongitudeMin = -180;
        public const double LocationLongitudeMax = 180;

        public static class Vehicle
        {
            public const int LicensePlateLength = 10;

            public const int MakeMinLength = 1;
            public const int MakeMaxLength = 50;

            public const int ModelMinLength = 1;
            public const int ModelMaxLength = 50;
        }

        public static class Garage
        {
            public const int NameMinLength = 1;
            public const int NameMaxLength = 50;
        }

        public static class Restaurant
        {
            public const int NameMinLength = 1;
            public const int NameMaxLength = 50;

            public const int RatingMinValue = 0;
            public const int RatingMaxValue = 10;
        }

        public static class MenuItem
        {
            public const int NameMinLength = 1;
            public const int NameMaxLength = 50;

            public const int DescriptionMinLength = 1;
            public const int DescriptionMaxLength = 100;

            public const int PriceMinValue = 1;
            public const int PriceMaxValue = 300;

            public const int QuantityMinValue = 1;
            public const int QuantityMaxValue = 100;
        }
    }
}
