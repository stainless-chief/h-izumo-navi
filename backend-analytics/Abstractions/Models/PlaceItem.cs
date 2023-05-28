namespace Abstractions.Models
{
    public class PlaceItem : IZone
    {
        public string PlaceName { get; set; } = string.Empty;
        public int Temperature { get; set; }
        public List<ZoneCoordinates> Coordinates { get; set; } = new();
        public List<Source> Sources { get; set; } = new();

        public List<PlaceCharacteristics> Characteristics { get; set; } = new();
    }

    public enum PlaceCharacteristics
    {
        None,
        ImpassableTerrain,

        TransportationHub,
        Transportation,
        Parking,

        Shop,
        
        Dinery,

        Hotel,

        Landmark,
        Museum,
        Park,
        Camping,

        Shrine,

        Education,
        Office,
    }
}
