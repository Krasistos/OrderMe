using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMe.Infrastructure.Constants
{
    public static class DataConstants
    {
        /// <summary>
        /// Constants for the locations used in the application
        /// </summary>
        public const double LocationLatitudeMin = -90;
        public const double LocationLatitudeMax = 90;

        public const double LocationLongitudeMin = -180;
        public const double LocationLongitudeMax = 180;
        public static class Driver
        {
            public const int RatingMinValue = 0;
            public const int RatingMaxValue = 10;
        }

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

        public static class Ride
        {
            public const int StatusMinLength = 0; // not needed
            public const int StatusMaxLength = 50;
        }

        public static class Restaurant
        {
            public const int NameMinLength = 1;
            public const int NameMaxLength = 50;

            public const int RatingMinValue = 0;
            public const int RatingMaxValue = 10;
        }
    }
}
