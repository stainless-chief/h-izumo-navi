using Abstractions.Models;
using Abstractions.IRepositories;

namespace Infrastructure.Repositories
{
    public class SourceRepository : ISourceRepository
    {
        public async Task<IEnumerable<Source>> GetAsync()
        {
            var ss = new List<Source>()
            {
                new Source { Code = "source-dummy", Description = "dummy", Name = "dummy", TotalEvents = 1000 },
                new Source { Code = "source-twitter", Description = "We are", Name = "Twitter", TotalEvents = 9 },
            };

            return ss;
        }
    }
}
