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
        //j?=> nullable
        //pageSize=4 => default page size=> optional parameter
        public async Task<IActionResult> Index(string? search, int? categoryId, int page = 1, int pageSize = 4)
        {
            var query = _context.Products
                .AsQueryable();
            #region filter
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Name.Contains(search) || p.Description.Contains(search));
            }
            if (categoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == categoryId.Value);

                //final query is always append with previous query

            } 
            #endregion


            var finalQuery = query.Select(p => new ItemViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                ImageUrl = p.ImageUrl
            });


            var viewModel = new ShopViewModel
            {
                PaginatedItems = await PaginatedList<ItemViewModel>.Create(finalQuery, page, pageSize)
            };
            return View(viewModel);
        }

        [HttpGet()]
        [Route("/home/{id}/details")]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _context.Products.FindAsync(id);
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
