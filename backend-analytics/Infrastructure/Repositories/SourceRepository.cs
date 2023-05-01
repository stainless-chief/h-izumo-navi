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

        public async Task<IEnumerable<Source>> GetAsync()
        {
            var items = await _context.Sources
                                    .AsNoTracking()
                                    .Select
                                    (x => new Source
                                    {
                                         Code = x.Code,
                                         Description = x.Description,
                                         Name = x.DisplayName,
                                         TotalEvents = -1,
                                    })
                                    .ToListAsync();

            foreach (var item in items)
            {
                item.TotalEvents = CoutHits(item.Code);
            }

            return items;
        }

        public int CoutHits(string sourceCode)
        {
            switch (sourceCode.ToLower())
            {
                case "example": return _context.ExampleHits.Count();
            }

            throw new ArgumentException($"{nameof(sourceCode)} not found");
        }
    }
}
