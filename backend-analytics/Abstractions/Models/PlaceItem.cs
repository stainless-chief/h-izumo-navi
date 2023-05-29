namespace Abstractions.Models
{
    public class PlaceItem : IZone
    {
        public string PlaceName { get; set; } = string.Empty;
        public int Temperature { get; set; }
        public List<ZoneCoordinates> Coordinates { get; set; } = new();
        public List<Source> Sources { get; set; } = new();

        public List<string> Characteristics { get; set; } = new();
    }
}
