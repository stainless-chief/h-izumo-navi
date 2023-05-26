using Abstractions.Models;
using System.Drawing;

namespace Abstractions.Map
{
    public static class MapGenerator
    {
        private static readonly double LongitudeMin = 132.617758;
        private static readonly double LongitudeMax = 132.922474;
        private static readonly double LatitudeMin = 35.281593;
        private static readonly double LatitudeMax = 35.514545;
        private static readonly double Size = 0.005765;

        public static IEnumerable<HeatZone> CreateIzumo()
        {
            var lst = new List<HeatZone>();

            for (var longitude = LongitudeMin; longitude < LongitudeMax; longitude += Size)
            {
                for (var latitude = LatitudeMin; latitude < LatitudeMax; latitude += Size)
                {
                    lst.Add(new HeatZone
                    {
                        Temperature = 0,
                        Coordinates = new()
                        {
                            new ZoneCoordinates { X = longitude, Y =  latitude},
                            new ZoneCoordinates { X = longitude, Y =  latitude + Size},
                            new ZoneCoordinates { X = longitude + Size, Y =  latitude + Size},
                            new ZoneCoordinates { X = longitude + Size, Y =  latitude },

                            // HACK, because polygons broke down on higher zoom levels: 
                            new ZoneCoordinates { X = longitude, Y =  latitude},
                        }
                    });
                }
            }

            return lst;
        }
    }
}
