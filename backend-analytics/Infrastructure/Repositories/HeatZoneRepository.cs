using Abstractions.Models;
using Abstractions.IRepositories;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Helpers;

namespace Infrastructure.Repositories
{
    public class HeatZoneRepository : IHeatZoneRepository
    {
        private static readonly double Xmin = 132.617758;
        private static readonly double Xmax = 132.922474;
        private static readonly double Ymin = 35.281593;
        private static readonly double Ymax = 35.514545;

        private static readonly double size = 0.005765;

        private readonly DataContext _context;

        private static IEnumerable<HeatZone> GenerateMap()
        {
            var lst = new List<HeatZone>();

            for (var x = Xmin; x < Xmax; x += size)
            {
                for (var y = Ymin; y < Ymax; y += size)
                {
                    lst.Add(new HeatZone
                    {
                        Temperature = 0,
                        ZoneCoordinates = new()
                        {
                            new ZoneCoordinates { X = x, Y =  y},
                            new ZoneCoordinates { X = x, Y =  y + size},
                            new ZoneCoordinates { X = x + size, Y =  y + size},
                            new ZoneCoordinates { X = x + size, Y =  y },
                        }
                    });
                }
            }

            return lst;
        }

        public HeatZoneRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HeatZone>> GetAsync(IEnumerable<string> sourceCode)
        {
            if (sourceCode == null || !sourceCode.Any())
            {
                return Enumerable.Empty<HeatZone>();
            }

            var result = GenerateMap();

            if (sourceCode.Contains(SourcesNames.Example))
            {
                foreach (var item in _context.ExampleHits)
                {
                    var tmp = result.FirstOrDefault(x => x.IsIn(item.Longitude, item.Latitude));
                    if (tmp != null)
                    {
                        tmp.Temperature++;
                    }
                }
            }
            if (sourceCode.Contains(SourcesNames.Twitter))
            {
                foreach (var item in _context.TwitterHit)
                {
                    var tmp = result.FirstOrDefault(x => x.IsIn(item.Longitude, item.Latitude));
                    if (tmp != null)
                    {
                        tmp.Temperature++;
                    }
                }
            }

            var maxTemp = result.Max(x => x.Temperature);

            // normalize heat
            foreach (var item in result)
            {
                item.Temperature = IntegerExtensions.RoundOff(item.Temperature * 100d / maxTemp);
            }

            return result;
        }
    }
}
