using Microsoft.AspNetCore.Mvc;
using MyFirstMvcApp.Models;
using MyFirstMvcApp.Services;
using System.Diagnostics;

namespace MyFirstMvcApp.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITimeService _timeService;
        public HomeController(ILogger<HomeController> logger,ITimeService timeService)
        {
            _logger = logger;
            _timeService = timeService;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Index action called at {Time}", DateTime.Now);

            var model = new HomeModel
            {
                Title = "Hello All! Welcome Server Time "+_timeService.GetCurrentTime(),
                Description = "I am making the field dynamic",
                Link = "https://google.com",
                LinkText = "Search More"
            };
            //throw new Exception("My test exception");

            //store a cookie
            Response.Cookies.Append("User","Binod Sapkota",new CookieOptions { 
                Expires=DateTimeOffset.Now.AddDays(1),

            });
            Response.Headers.Append("set-cookie", "test cookie=my another value from header; expires=Wed, 04 Jun 2025 13:03:24 GMT; path=/");


            //store value in session
            //to use session we have to enable it  in program .cs 

            HttpContext.Session.SetString("UserName", "Binod Sapkota");

            return View(model);
        }

        public IActionResult Privacy()
        {
            var user = HttpContext.Session.GetString("UserName");
            ViewBag.UserName = user ?? "Guest";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
