using Abstractions.IRepositories;
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

        public async Task<bool> SaveAsync(Hit hit)
        {
            if (hit.Source == SourcesNames.FakeTwitter)
            {
                return await SaveTwitter(hit) == 1;
            }

            throw new ArgumentException($"{nameof(hit.Source)} not found");
        }

        public async Task<bool> SaveAsync(IEnumerable<Hit> hits)
        {
            if (hits.All(x =>  x.Source == SourcesNames.FakeTwitter))
            {
                foreach (Hit hit in hits) 
                {
                    await _context.FakeTwitterHit.AddAsync(new FakeTwitterHit
                    {
                        Id = Guid.NewGuid(),
                        DateTime = DateTime.UtcNow,
                        Latitude = hit.Latitude,
                        Longitude = hit.Longitude,
                        Person = hit.PersonId,
                        Reliability = 100,
                    });
                }

                return await _context.SaveChangesAsync() == hits.Count();
            }

            throw new ArgumentException($"Inconsistent sources ");
        }

        private async Task<int> SaveTwitter(Hit hit)
        {
            await _context.FakeTwitterHit.AddAsync(new FakeTwitterHit
            {
                Id = Guid.NewGuid(),
                DateTime = DateTime.UtcNow,
                Latitude = hit.Latitude,
                Longitude = hit.Longitude,
                Person = hit.PersonId,
                Reliability = 100,
            });

            return await _context.SaveChangesAsync();
        }
    }
}
