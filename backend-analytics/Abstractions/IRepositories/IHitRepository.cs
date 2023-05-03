using Abstractions.Models;

namespace Abstractions.IRepositories
{
    public interface IHitRepository
    {
        Task<bool> SaveAsync(Hit hit);
        Task<bool> SaveAsync(IEnumerable<Hit> hits);
    }
}
