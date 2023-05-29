using Abstractions.Extensions;
using Abstractions.IRepositories;
using Abstractions.Map;
using Abstractions.Models;
using Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class HeatZoneRepository : IHeatZoneRepository
    {
        private readonly DataContext _context;
        private readonly IStatisticsRepository _statisticsRepository;

        public HeatZoneRepository(DataContext context, IStatisticsRepository statisticsRepository)
        {
            _context = context;
            _statisticsRepository = statisticsRepository;
        }

        public async Task<IEnumerable<HeatZone>> GetAsync(IEnumerable<string> sourceCode)
        {
            if (sourceCode == null || !sourceCode.Any())
            {
                return Enumerable.Empty<HeatZone>();
            }

            var result = MapGenerator.CreateIzumo();

            foreach ( var code in sourceCode) 
            {
                await foreach (var item in _context.GetHits(code).AsNoTracking().AsAsyncEnumerable())
                {
                    var temp = result.FirstOrDefault(x => x.IsIn(item.Longitude, item.Latitude));
                    if (temp != null)
                    {
                        temp.Temperature++;
                        if (temp.HitStatistics.ContainsKey(code))
                        {
                            temp.HitStatistics[code]++;
                        }
                        else
                        {
                            temp.HitStatistics.Add(code, 1);
                        }
                    }
                }
            }

            NormalizeHeat(result);

            return result;
        }

        private static void NormalizeHeat(IEnumerable<HeatZone> zones)
        {
            var maxTemp = zones.Max(x => x.Temperature);

            foreach (var item in zones)
            {
                item.Temperature = IntegerExtensions.RoundOff(item.Temperature * 100d / maxTemp);
            }
        }

        private async Task<List<PlaceCharacteristics>> SeekForCharacteristics(HeatZone zone)
        {
            var ss = new List<PlaceCharacteristics>();

            var places = await _statisticsRepository.GetAsync();


            return ss;
        }
    }
}
