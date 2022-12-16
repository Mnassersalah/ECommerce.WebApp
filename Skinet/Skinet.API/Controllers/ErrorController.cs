using Microsoft.AspNetCore.Mvc;
using Skinet.API.DTOs;

namespace Skinet.API.Controllers
{
    [Route("error/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : APIControllerBase
    {
        [HttpGet]
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ErrorResponse(code));
        }   
    }
}
