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
            if (hit.Source == SourcesNames.Twitter)
            {
                return await SaveTwitter(hit) == 1;
            }

            throw new ArgumentException($"{nameof(hit.Source)} not found");
        }

        private async Task<int> SaveTwitter(Hit hit)
        {
            await _context.TwitterHit.AddAsync(new TwitterHit
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
