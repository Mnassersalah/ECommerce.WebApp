using Microsoft.AspNetCore.Mvc;
using Skinet.Core.Entities;
using Skinet.Core.Interfaces;
using Skinet.Core.Specificatios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skinet.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepo;

        public ProductsController(IGenericRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProductsAsync()
        {
            var spec = new ProductsWithTypeAndBrandSpecification();
            var products = await _productRepo.GetAllWithSpecAsync(spec);
            return base.Ok(products);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Product>> GetProductAsync(int id)
        {
            var spec = new ProductsWithTypeAndBrandSpecification(id);
            return await _productRepo.GetWithSpecAsync(spec);
        }


    }
}
