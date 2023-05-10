using Abstractions.Models;
using Abstractions.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SourceRepository : ISourceRepository
    {
        private readonly DataContext _context;

        public SourceRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Source>> GetAsync(bool countHits)
        {
            var sources = await _context.Sources
                                      .AsNoTracking()
                                      .Select(x => new Source
                                      {
                                          Code = x.Code,
                                          Description = x.Description,
                                          Name = x.DisplayName,
                                          TotalEvents = 0,
                                      })
                                      .ToListAsync();

            if (countHits)
            {
                foreach (var item in sources)
                {
                    item.TotalEvents = await CountHits(item.Code);
                }
            }

            return sources;
        }

        private async Task<int> CountHits(string sourceCode)
        {
            if (sourceCode == Models.FakeTwitterHit.Code)
            {
                return await _context.FakeTwitterHits.CountAsync();
            }

            if (sourceCode == Models.ExampleHit.Code)
            {
                return await _context.ExampleHits.CountAsync();
            }

            if (sourceCode == Models.HiWebHit.Code)
            {
                return await _context.HiIzumoHits.CountAsync();
            }

            throw new ArgumentException($"{nameof(sourceCode)} {sourceCode} not found");
        }
    }
}
