using System;
using GoogleMapsAPI.NET.API.Common.Components.Locations.Interfaces;

namespace GoogleMapsAPI.NET.API.Places.Components
{
    public class LocationBias
    {
        private readonly string _param;

        private LocationBias(string param)
        {
            _param = param;
        }

        /// <summary>
        /// IP bias: Instructs the API to use IP address biasing.
        /// </summary>
        public static LocationBias IP()
        {
            return new LocationBias("ipbias");
        }

        /// <summary>
        /// Point: A single lat/lng coordinate
        /// </summary>
        public static LocationBias Point(IGeoCoordinatesLocation location)
        {
            return Point(location.Latitude, location.Longitude);
        }

        public static LocationBias Point(double latitude, double longitude)
        {
            return new LocationBias($"point:{latitude},{longitude}");
        }

        /// <summary>
        /// A string specifying radius in meters, plus lat/lng in decimal degrees.
        /// </summary>        
        public static LocationBias Circular(int radius, IGeoCoordinatesLocation location)
        {
            return Circular(radius, location.Latitude, location.Longitude);
        }

        public static LocationBias Circular(int radius, double latitude, double longitude)
        {
            return new LocationBias($"circle:{radius}@{latitude},{longitude}");
        }

        /// <summary>
        /// A string specifying two lat/lng pairs in decimal degrees, representing the south/west and north/east points of a rectangle.
        /// </summary>
        public static LocationBias Rectangular(IGeoCoordinatesLocation southWest, IGeoCoordinatesLocation northEast)
        {
            if(southWest.Longitude < -180 || southWest.Longitude > 180)
                throw new ArgumentOutOfRangeException(nameof(southWest));
            if(northEast.Longitude< -180 || northEast.Longitude > 180)
                throw new ArgumentOutOfRangeException(nameof(northEast));

            if(southWest.Latitude < -90 || southWest.Latitude > 90)
                throw new ArgumentOutOfRangeException(nameof(southWest));
            if(northEast.Latitude< -90 || northEast.Latitude > 90)
                throw new ArgumentOutOfRangeException(nameof(northEast));

            return new LocationBias($"rectangle:{southWest.Latitude},{southWest.Longitude}|{northEast.Latitude},{northEast.Longitude}");
        }

        public override string ToString()
        {
            return _param;
        }
    }
}
