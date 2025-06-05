using Microsoft.AspNetCore.Mvc;

namespace MyFirstMvcApp.Areas.Public.Controllers
{
    [Area("Public")]
    public class Home1Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
