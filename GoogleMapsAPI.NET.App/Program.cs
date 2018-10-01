using System;
using System.Collections.Generic;
using System.Diagnostics;
using GoogleMapsAPI.NET.API.Client;
using GoogleMapsAPI.NET.API.Common.Components.Locations;
using GoogleMapsAPI.NET.API.Common.Components.Locations.Common;
using GoogleMapsAPI.NET.API.Common.Components.Locations.Interfaces;
using GoogleMapsAPI.NET.API.Common.Components.Locations.Interfaces.Combined;
using GoogleMapsAPI.NET.API.Directions.Enums;
using GoogleMapsAPI.NET.API.Geocoding.Responses;
using GoogleMapsAPI.NET.API.Places.Enums;
using GoogleMapsAPI.NET.Requests;

namespace GoogleMapsAPI.NET.App
{
    
    /// <summary>
    /// Program
    /// </summary>
    class Program
    {

        /// <summary>
        /// Main entry point
        /// </summary>
        /// <param name="args">Arguments</param>
        static void Main(string[] args)
        {

            // Get client
            var client = new MapsAPIClient("---YOUR API KEY---");

            //Find Place
            FindPlace(client);

            // Get directions
            GetDirections(client);

            // Geocode address
            var geocode = Geocode(client);

            // Search places nearby
            NearbySearch(client, geocode);

            // Radar search places
            RadarSearch(client, geocode);

            // Get timezone
            GetTimeZone(client);

            // Snap to roads
            SnapToRoads(client);

            // Get distance matrix
            GetDistanceMatrix(client);

            // Get place photo
            GetPlacePhoto(client);

            // Autocomplete            
            AutoComplete(client);

            // Info            
            Console.WriteLine();
            Console.WriteLine(@"Press ENTER to exit...");
            Console.ReadLine();            

        }

        private static void GetTimeZone(MapsAPIClient client)
        {
            var timezone = client.TimeZone.GetTimeZone(35.27801, 149.12958, DateTime.Now);
        }

        private static void AutoComplete(MapsAPIClient client)
        {
            var autoComplete = client.Places.AutoComplete(
                "Google",
                location: new GeoCoordinatesLocation(-33.86746, 151.207090),
                offset: 3,
                language: "en-AU",
                types: new[] {"geocode"},
                components: new ComponentsFilter {["country"] = "au"}
            );
        }

        private static void GetPlacePhoto(MapsAPIClient client)
        {
            var resultPhoto = client.Places.GetPlacePhoto(
                "CnRtAAAATLZNl354RwP_9UKbQ_5Psy40texXePv4oAlgP4qNEkdIrkyse7rPXYGd9D_Uj1rVsQdWT4oRz4QrYAJNpFX7rzqqMlZw2h2E2y5IKMUZ7ouD_SlcHxYq1yL4KbKUv3qtWgTK0A6QbGh87GB3sscrHRIQiG2RrmU_jF4tENr9wGS_YxoUSSDrYjWmrNfeEHSGSc3FyhNLlBU",
                maxWidth: 400);
        }

        private static void GetDistanceMatrix(MapsAPIClient client)
        {
            var matrix = client.DistanceMatrix.GetDistanceMatrix(
                new List<IAddressOrGeoCoordinatesLocation>
                {
                    new AddressLocation("Vancouver BC"),
                    new AddressLocation("Seattle")
                },
                new List<IAddressOrGeoCoordinatesLocation>
                {
                    new AddressLocation("San Francisco"),
                    new AddressLocation("Victoria BC")
                },
                TransportationModeEnum.Bicycling,
                language: "fr-FR");
        }

        private static void SnapToRoads(MapsAPIClient client)
        {
            var snap = client.Roads.SnapToRoads(new List<IGeoCoordinatesLocation>()
            {
                new GeoCoordinatesLocation(35.27801, 149.12958),
                new GeoCoordinatesLocation(-35.28032, 149.12907)
            });
        }

        private static void RadarSearch(MapsAPIClient client, GeocodeResponse geocode)
        {
            var radarPlaces = client.Places.RadarSearch(
                geocode.Results[0]
                    .Geometry.Location,
                10,
                placeType: PlaceSearchTypeEnum.ATM);
        }

        private static void FindPlace(MapsAPIClient client)
        {
            var findPlaceResponse = client.Places.FindPlace(
                "Google",
                FindPlaceInputTypeEnum.TextQuery,
                fields: new []
                {
                    FindPlaceFieldsEnum.place_id,
                    FindPlaceFieldsEnum.name,
                    FindPlaceFieldsEnum.formatted_address,
                    FindPlaceFieldsEnum.id,
                    FindPlaceFieldsEnum.icon,
                    FindPlaceFieldsEnum.geometry,
                    FindPlaceFieldsEnum.permanently_closed,
                    FindPlaceFieldsEnum.photos,
                    FindPlaceFieldsEnum.plus_code,
                    //FindPlaceFieldsEnum.scope,
                    FindPlaceFieldsEnum.types
                });
        }

        private static void NearbySearch(MapsAPIClient client, GeocodeResponse geocode)
        {
            var places = client.Places.NearbySearch(
                geocode.Results[0]
                    .Geometry.Location,
                rankBy: PlaceRankByEnum.Distance,
                placeType: PlaceSearchTypeEnum.ElectronicsStore);
        }

        private static GeocodeResponse Geocode(MapsAPIClient client)
        {
            var geocode = client.Geocoding.Geocode("203-1200 Saint-Jean-Baptiste, Quebec");
            return geocode;
        }

        private static void GetDirections(MapsAPIClient client)
        {
            var directions = client.Directions.GetDirections(
                new AddressLocation("Chicago,IL"),
                new AddressLocation("Los Angeles,CA"),
                waypoints: new List<Location>
                {
                    new AddressLocation("Joplin,MO"),
                    new AddressLocation("Oklahoma City,OK")
                });
        }
    }

}
