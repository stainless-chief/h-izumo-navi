using Abstractions.Extensions;
using Abstractions.IRepositories;
using Abstractions.Models;
using Infrastructure.Converters;
using Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<IEnumerable<PlaceItem>> GetAsync()
        {
            var sources = await _sourceRepository.GetAsync(false);

            var result = _context.Places.ToList().Select(x => new PlaceItem
            {
                PlaceName = x.DisplayName,
                 Characteristics = x.Characteristics.ToList(),
                    Coordinates = x.Region!
                    .Select((x, i) => new { Index = i, Value = x })
                    .GroupBy(x => x.Index / 2)
                    .Select(x => x.Select(v => v.Value).ToList())
                    .Select( x => new ZoneCoordinates { Y = x[0], X = x[1] })
                    .ToList()

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

        private static void NormalizeHeat(List<PlaceItem> result)
        {
            var maxTemp = result.Max(x => x.Temperature);

            foreach (var item in result)
            {
                item.Temperature = IntegerExtensions.RoundOff(item.Temperature * 100d / maxTemp);
            }
        }
    }
}
