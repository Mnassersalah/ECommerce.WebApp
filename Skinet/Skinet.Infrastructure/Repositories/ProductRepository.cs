﻿using Microsoft.EntityFrameworkCore;
using Skinet.Core.Entities;
using Skinet.Core.Interfaces;
using Skinet.Infrastructure.Data;

namespace Skinet.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext? _context;

        public ProductRepository(StoreContext? context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Product>> GetAllAsync()
        {
            return await _context.Products
                                 .Include(p => p.ProductBrand)
                                 .Include(p => p.ProductType)
                                 .ToListAsync();
        }

        public async Task<Product> GetByIDAsync(int id)
        {
            return await _context.Products
                                 .Include(p => p.ProductBrand)
                                 .Include(p => p.ProductType)
                                 .FirstOrDefaultAsync(p => p.Id == id);
        }

        
    }
}
    