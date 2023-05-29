using Abstractions.Models;

namespace Infrastructure.Converters
{
    internal static class StringToPlaceCharacteristicsConverter
    {
        public static PlaceCharacteristics Convert(string value)
        {
            switch (value)
            {
                case "None": return PlaceCharacteristics.None;
                case "ImpassableTerrain": return PlaceCharacteristics.ImpassableTerrain;
                case "TransportationHub": return PlaceCharacteristics.TransportationHub;
                case "Transportation": return PlaceCharacteristics.Transportation;
                case "Parking": return PlaceCharacteristics.Parking;
                case "Taxi": return PlaceCharacteristics.Taxi;
                case "Shop": return PlaceCharacteristics.Shop;
                case "Dinery": return PlaceCharacteristics.Dinery;
                case "Hotel": return PlaceCharacteristics.Hotel;
                case "Landmark": return PlaceCharacteristics.Landmark;
                case "Museum": return PlaceCharacteristics.Museum;
                case "Park": return PlaceCharacteristics.Park;
                case "Camping": return PlaceCharacteristics.Camping;
                case "Shrine": return PlaceCharacteristics.Shrine;
                case "Education": return PlaceCharacteristics.Education;
                case "Office": return PlaceCharacteristics.Office;
            }

            throw new NotImplementedException();
        }
    }
}
