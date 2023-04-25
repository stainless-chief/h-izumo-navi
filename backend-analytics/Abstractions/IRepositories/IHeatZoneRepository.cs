using Abstractions.Models;

namespace Abstractions.IRepositories
{
    public interface IHeatZoneRepository
    {
        Task<IEnumerable<HeatZone>> GetAsync(IEnumerable<string> sourceCode);
    }
}
