using Skinet.Core.Entities;

namespace Skinet.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<IReadOnlyList<Product>> GetAllAsync();
        Task<Product> GetByIDAsync(int id);
    }
}
