using Microsoft.EntityFrameworkCore;
using Skinet.Core.Entities;
using Skinet.Core.Interfaces;
using Skinet.Core.Specificatios;
using Skinet.Infrastructure.Data;
using Skinet.Infrastructure.Helpers;

namespace Skinet.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
    {
        private readonly StoreContext _context;

        public GenericRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIDAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> specification)
        {
            return await _context.Set<T>()
                                 .AsQueryable()
                                 .ApplySpecification(specification)
                                 .ToListAsync();
        }

        public async Task<T> GetWithSpecAsync(ISpecification<T> specification)
        {
            return await _context.Set<T>()
                                 .AsQueryable()
                                 .ApplySpecification(specification)
                                 .FirstOrDefaultAsync();
        }
    }
}
