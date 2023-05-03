namespace Infrastructure.Helpers
{
    internal static class IntegerExtensions
    {
        public static int RoundOff(this double i)
        {
            return ((int)Math.Round(i / 10.0)) * 10;
        }
    }
}
