namespace Abstractions.Models
{
    public class StatisticItem
    {
        public string PlaceName { get; set; }
        public int Temperature { get; set; }
        public List<ZoneCoordinates> PlaceCoordinates { get; set; } = new();

        public List<Source> Sources { get; set; } = new();

        public bool IsIn(double x, double y)
        {
            bool result = false;
            int j = PlaceCoordinates.Count - 1;
            for (int i = 0; i < PlaceCoordinates.Count; i++)
            {
                if (PlaceCoordinates[i].Y < y && PlaceCoordinates[j].Y >= y || PlaceCoordinates[j].Y < y && PlaceCoordinates[i].Y >= y)
                {
                    if (PlaceCoordinates[i].X + ((y - PlaceCoordinates[i].Y) / (PlaceCoordinates[j].Y - PlaceCoordinates[i].Y) * (PlaceCoordinates[j].X - PlaceCoordinates[i].X)) < x)
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
