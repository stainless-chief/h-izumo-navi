using Abstractions.Models;
using Abstractions.IRepositories;

namespace Infrastructure.Repositories
{
    public class HeatZoneRepository : IHeatZoneRepository
    {
        public Task<IEnumerable<HeatZone>> GetAsync(IEnumerable<string> sourceCode)
        {
            throw new NotImplementedException();
        }
    }
}
