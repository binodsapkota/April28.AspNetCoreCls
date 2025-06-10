using Microsoft.AspNetCore.Mvc;

namespace ShopSphere.Web.Views
{
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
