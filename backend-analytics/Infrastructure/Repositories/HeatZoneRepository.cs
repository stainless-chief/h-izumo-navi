using Abstractions.Extensions;
using Abstractions.IRepositories;
using Abstractions.Map;
using Abstractions.Models;
using Infrastructure.Helpers;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;

namespace Infrastructure.Repositories
{
    public class HeatZoneRepository : IHeatZoneRepository
    {
        private readonly DataContext _context;
        private readonly IPlaceRepository _placeRepository;
        private IEnumerable<PlaceItem>? _places;


        public HeatZoneRepository(DataContext context, IPlaceRepository placeRepository)
        {
            _context = context;
            _placeRepository = placeRepository;
        }

        public async Task<IEnumerable<HeatZone>> GetAsync(IEnumerable<string> sourceCode)
        {
            await PreparePlaces();

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
                        FillCharacteristics(temp);
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
                    if(item is IzumoNaviLikeHit)
                    {
                        temp.Emotion += (item as IzumoNaviLikeHit).Emotion;
                    }
                }
            }

            NormalizeHeat(result);
            NormalizeEmotions(result);

            return result;
        }

        private static void NormalizeEmotions(IEnumerable<HeatZone> zones)
        {
            foreach (var item in zones)
            {
                if (item.Emotion == 0) { continue; }

                item.Emotion = item.Emotion > 0 ? 100 : -100;
            }
        }

        private static void NormalizeHeat(IEnumerable<HeatZone> zones)
        {
            var max = zones.Max(x => x.Temperature);

            foreach (var item in zones)
            {
                item.Temperature = IntegerExtensions.RoundOff(item.Temperature * 100d / max);
            }
        }

        private async Task PreparePlaces()
        {
            if (_places == null)
            {
                _places = await _placeRepository.GetPlacesAsync();
            }
        }

        private void FillCharacteristics(HeatZone zone)
        {
            foreach (var place in _places)
            {
                if (place.IsIn(zone))
                {
                    place.Characteristics.ToList().ForEach(x => { zone.ZoneCharacteristics.Add(x); });
                }
            }
        }
    }
}
