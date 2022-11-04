using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skinet.Core.Entities;
using Skinet.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skinet.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext? _context;

        public ProductsController(StoreContext? context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProductsAsync()
        {
            var products = await _context.Products.ToListAsync();
            return base.Ok(products);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Product>> GetProductAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }


    }
}
