using Abstractions.IRepositories;
using Abstractions.Models;
using Infrastructure.Helpers;

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
            var sources = await _sourceRepository.GetAsync();
            sources.ToList().ForEach(x => x.TotalEvents = 0);

            var result = _context.Places.Select(x => new StatisticItem
            {
                PlaceName = x.DisplayName,
                PlaceCoordinates = new List<ZoneCoordinates>
                 {
                     new() { X = x.LongitudeMin, Y =  x.LatitudeMin},
                     new() { X = x.LongitudeMin, Y =  x.LatitudeMax},
                     new() { X = x.LongitudeMax, Y =  x.LatitudeMax},
                     new() { X = x.LongitudeMax, Y =  x.LatitudeMin },
                 },
                //Sources = sources.Select(x => new Source(x)).ToList(),
            }).ToList();

            result.ForEach(x => x.Sources = sources.Select(x => new Source(x)).ToList());

            await foreach (var item in _context.ExampleHits.AsAsyncEnumerable())
            {
                var tmp = result.FirstOrDefault(x => x.IsIn(item.Longitude, item.Latitude));
                if (tmp != null)
                {
                    tmp.Temperature++;
                    tmp.Sources.First(x => x.Code == SourcesNames.Example).TotalEvents++;
                }
            }

            await foreach (var item in _context.FakeTwitterHit.AsAsyncEnumerable())
            {
                var tmp = result.FirstOrDefault(x => x.IsIn(item.Longitude, item.Latitude));
                if (tmp != null)
                {
                    tmp.Temperature++;
                    tmp.Sources.First(x => x.Code == SourcesNames.FakeTwitter).TotalEvents++;
                }
            }

            var maxTemp = result.Max(x => x.Temperature);

            // normalize heat
            foreach (var item in result)
            {
                item.Temperature = IntegerExtensions.RoundOff(item.Temperature * 100d / maxTemp);

                if (item.Temperature == 0) { item.Temperature = 10; }
            }

            return result;
        }

    }
}
