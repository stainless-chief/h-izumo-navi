using Abstractions.IRepositories;
using Abstractions.Map;
using Abstractions.Models;
using Infrastructure.Models;
using System.Security.Policy;

namespace Infrastructure.Repositories
{
    public class HitRepository : IHitRepository
    {
        private readonly DataContext _context;

        public HitRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveAsync(IEnumerable<Hit> hits)
        {
            // looks messy
            foreach (var hit in hits)
            {
                //if (!MapGenerator.IsInIzumo(hit.Longitude, hit.Latitude))
                //{
                //    throw new ArgumentOutOfRangeException
                //    (
                //        nameof(hits), 
                //        $"ERROR: HAPPY FOX: Longitude: {hit.Longitude}: Latitude: {hit.Latitude} out of Izumo range."
                //    );
                //}

                if (string.Equals(hit.Source, FakeTwitterHit.Code, StringComparison.OrdinalIgnoreCase))
                {
                    await _context.FakeTwitterHits.AddAsync(new FakeTwitterHit
                    {
                        Id = Guid.NewGuid(),
                        DateTime = DateTime.UtcNow,
                        Latitude = hit.Latitude,
                        Longitude = hit.Longitude,
                        Person = hit.PersonId,
                    });
                }
                if (string.Equals(hit.Source, ExampleHit.Code, StringComparison.OrdinalIgnoreCase))
                {
                    await _context.ExampleHits.AddAsync(new ExampleHit
                    {
                        Id = Guid.NewGuid(),
                        DateTime = DateTime.UtcNow,
                        Latitude = hit.Latitude,
                        Longitude = hit.Longitude,
                        Person = hit.PersonId,
                    });
                }
                if (string.Equals(hit.Source, IzumoNaviLikeHit.Code, StringComparison.OrdinalIgnoreCase))
                {
                    await _context.IzumoNaviLikeHits.AddAsync(new IzumoNaviLikeHit
                    {
                        Id = Guid.NewGuid(),
                        DateTime = DateTime.UtcNow,
                        Latitude = hit.Latitude,
                        Longitude = hit.Longitude,
                        Person = hit.PersonId,
                    });
                }
            }

            return await _context.SaveChangesAsync() == hits.Count();
        }
    }
}
