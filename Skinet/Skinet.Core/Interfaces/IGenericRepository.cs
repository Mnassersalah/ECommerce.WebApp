using Skinet.Core.Entities;
using Skinet.Core.Specificatios;

namespace Skinet.Core.Interfaces
{
    public interface IGenericRepository<T> where T : EntityBase
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIDAsync(int id);
        Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> specification);
        Task<T> GetWithSpecAsync(ISpecification<T> specification);
    }
}
