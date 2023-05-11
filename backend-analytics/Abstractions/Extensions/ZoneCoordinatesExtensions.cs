using Abstractions.Models;

namespace Abstractions.Extensions
{
    public static class ZoneCoordinatesExtensions
    {
        public static bool IsIn(this IZone zone, double x, double y)
        {
            var coordinates = zone.Coordinates;

            bool result = false;
            int j = coordinates.Count - 1;
            for (int i = 0; i < coordinates.Count; i++)
            {
                if (coordinates[i].Y < y && coordinates[j].Y >= y || coordinates[j].Y < y && coordinates[i].Y >= y)
                {
                    if (coordinates[i].X + ((y - coordinates[i].Y) / (coordinates[j].Y - coordinates[i].Y) * (coordinates[j].X - coordinates[i].X)) < x)
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
