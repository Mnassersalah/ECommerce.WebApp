using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Skinet.API.DTOs;
using Skinet.Core.Entities;
using Skinet.Core.Interfaces;
using Skinet.Core.Specificatios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skinet.API.Controllers
{
    public class ProductsController : APIControllerBase
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDTO>>> GetProductsAsync()
        {
            var spec = new ProductsWithTypeAndBrandSpecification();
            var products = await _productRepo.GetAllWithSpecAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<ProductDTO>>(products));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductAsync(int id)
        {
            var spec = new ProductsWithTypeAndBrandSpecification(id);
            var product = await _productRepo.GetWithSpecAsync(spec);
            
            if (product is null)
            {
                return NotFound(new ErrorResponse(StatusCodes.Status404NotFound));
            }
            return Ok(_mapper.Map<ProductDTO>(product));
        }
    }
}
