using Microsoft.AspNetCore.Mvc;
using ShopSphere.Web.Data;
using ShopSphere.Web.Models;
using ShopSphere.Web.ViewModels;
using System.Diagnostics;

namespace ShopSphere.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var items = _context.Products
                .Select(p => new ItemViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl
                })
                .ToList();
            var viewModel = new ShopViewModel { Items = items };
            return View(viewModel);
        }

        [HttpGet()]
        [Route("/home/{id}/details")]
        public async  Task<IActionResult> Details(int id)
        {
            var model =await _context.Products.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
