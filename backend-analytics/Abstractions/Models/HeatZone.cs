namespace Abstractions.Models
{
    public class HeatZone
    {
        public int Temperature { get; set; }

        public List<ZoneCoordinates> ZoneCoordinates { get; set; } = new();

        public bool IsIn(double x, double y)
        {
            bool result = false;
            int j = ZoneCoordinates.Count - 1;
            for (int i = 0; i < ZoneCoordinates.Count; i++)
            {
                if (ZoneCoordinates[i].Y < y && ZoneCoordinates[j].Y >= y || ZoneCoordinates[j].Y < y && ZoneCoordinates[i].Y >= y)
                {
                    if (ZoneCoordinates[i].X + ((y - ZoneCoordinates[i].Y) / (ZoneCoordinates[j].Y - ZoneCoordinates[i].Y) * (ZoneCoordinates[j].X - ZoneCoordinates[i].X)) < x)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }
    }
}
