using FiltersInAspNet.Filters;
using FiltersInAspNet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FiltersInAspNet.Controllers
{
    // Applying the LogActionFilter globally to all actions in this controller
    [ServiceFilter(typeof(LogActionFilter))]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("In action : {Action}", "Index");
           // throw new Exception("My test exception");
            return View();
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
        [ServiceFilter(typeof(JsonResultFilter))]
        public Student TestJsonData()
        {

            return new Student { Name = "Binod" };
        }
        [ServiceFilter(typeof(XmlResultFilter))]
        public Student TestXmlData()
        {

            return new Student { Name = "Binod" };
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
