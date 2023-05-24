using Abstractions.IRepositories;
using Abstractions.Map;
using Abstractions.Models;
using Infrastructure.Models;

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
                if (!MapGenerator.IsInIzumo(hit.Longitude, hit.Latitude))
                {
                    continue;
                }

                if (hit.Source == FakeTwitterHit.Code)
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
                if (hit.Source == ExampleHit.Code)
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
            }

            return await _context.SaveChangesAsync() == hits.Count();
        }
    }
}
