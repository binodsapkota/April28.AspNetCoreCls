using Microsoft.AspNetCore.Mvc;
using MyFirstMvcApp.Model;

namespace MyFirstMvcApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
               // ModelState.AddModelError("Email", "This email is already taken");
            }
            return View(model);
        }
    }
}
