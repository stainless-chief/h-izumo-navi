namespace Abstractions.Models
{
    public class HeatZone
    {
        public int Temperature { get; set; }

        public List<ZoneCoordinates> ZoneCoordinates { get; set; } = new();
    }
}
