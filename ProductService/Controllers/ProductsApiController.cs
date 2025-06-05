using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsApiController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProducts()
        {
            // This is a placeholder for the actual implementation.
            // In a real application, you would retrieve products from a database or another service.
            var products = new[]
            {
                new { Id = 1, Name = "Product A", Price = 10.00 },
                new { Id = 2, Name = "Product B", Price = 15.50 }
            };
            return Ok(products);
        }
    }
}
