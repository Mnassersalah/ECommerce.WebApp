using Microsoft.AspNetCore.Mvc;

namespace Skinet.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {

        [HttpGet]
        [Route("/{id}")]
        public string Get(int id)
        {
            return $"product with id : {id}";
        }


        [HttpGet]
        public string Get()
        {
            return "all products";
        }


    }
}
