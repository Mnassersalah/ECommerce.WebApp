using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skinet.API.Data;
using Skinet.API.Entities;
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
        [Route("{id}")]
        public async Task<ActionResult<List<Product>>> GetProductsAsync(int id)
        {
            var products = await _context.Products.ToListAsync();
            return base.Ok(products);
        }


        [HttpGet]
        public ActionResult<string> GetProduct()
        {
            return "all products";
        }


    }
}
