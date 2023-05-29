namespace Abstractions.Models
{
    public class HeatZone : IZone
    {
        public int Temperature { get; set; }
        public List<ZoneCoordinates> Coordinates { get; set; } = new();
        public Dictionary<string, int> HitStatistics { get; set; } = new();
        public HashSet<string> ZoneCharacteristics { get; set; } = new();
        public int Emotion { get; set; }
    }
}
