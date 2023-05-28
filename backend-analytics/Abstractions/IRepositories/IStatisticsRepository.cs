using Abstractions.Models;

namespace Abstractions.IRepositories
{
    public interface IStatisticsRepository
    {
        Task<IEnumerable<PlaceItem>> GetAsync();
    }
}
