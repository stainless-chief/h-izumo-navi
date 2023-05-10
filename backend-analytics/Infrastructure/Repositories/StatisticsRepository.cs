using Abstractions.Extensions;
using Abstractions.IRepositories;
using Abstractions.Models;
using Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace Infrastructure.Repositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly DataContext _context;
        private readonly ISourceRepository _sourceRepository;

        public StatisticsRepository(DataContext context, ISourceRepository sourceRepository)
        {
            _context = context;
            _sourceRepository = sourceRepository;
        }

        public async Task<IEnumerable<StatisticItem>> GetAsync()
        {
            var sources = await _sourceRepository.GetAsync(false);

            var result = _context.Places.Select(x => new StatisticItem
            {
                PlaceName = x.DisplayName,
                Coordinates = new List<ZoneCoordinates>
                {
                    new() { X = x.LongitudeMin, Y =  x.LatitudeMin},
                    new() { X = x.LongitudeMin, Y =  x.LatitudeMax},
                    new() { X = x.LongitudeMax, Y =  x.LatitudeMax},
                    new() { X = x.LongitudeMax, Y =  x.LatitudeMin },

                    // HACK, because polygons broke down on higher zoom levels: 
                    new() { X = x.LongitudeMin, Y =  x.LatitudeMin}, 
                },
            }).ToList();

            result.ForEach(x => x.Sources = sources.Select(x => new Source(x)).ToList());

            foreach (var source in sources)
            {
                await foreach (var item in _context.GetHits(source.Code).AsNoTracking().AsAsyncEnumerable())
                {
                    var temp = result.FirstOrDefault(x => x.IsIn(item.Longitude, item.Latitude));
                    if (temp != null)
                    {
                        temp.Temperature++;
                        temp.Sources.First(x => x.Code == source.Code).TotalEvents++;
                    }
                }
            }

            NormalizeHeat(result);
            return result;
        }

        private static void NormalizeHeat(List<StatisticItem> result)
        {
            var maxTemp = result.Max(x => x.Temperature);

            foreach (var item in result)
            {
                item.Temperature = IntegerExtensions.RoundOff(item.Temperature * 100d / maxTemp);
            }
        }
    }
}
