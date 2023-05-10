using Abstractions.Models;

namespace Abstractions.IRepositories
{
    public interface ISourceRepository
    {
        Task<IEnumerable<Source>> GetAsync(bool countHits);
    }
}
