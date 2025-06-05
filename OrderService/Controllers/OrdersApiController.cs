using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersApiController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetOrders()
        {
            // This is a placeholder for the actual implementation.
            // In a real application, you would retrieve orders from a database or another service.
            var orders = new[]
            {
                new { Id = 1, ProductName = "Product A", Quantity = 2, Price = 20.00 },
                new { Id = 2, ProductName = "Product B", Quantity = 1, Price = 15.50 }
            };
            return Ok(orders);
        }
    }
}
