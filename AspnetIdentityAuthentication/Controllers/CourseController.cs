using AspnetIdentityAuthentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspnetIdentityAuthentication.Controllers
{
    public class CourseController : Controller
    {

        public IActionResult Index()
        {
            return Json(new Course() { Id = 1, CourseName = "Asp.net" });
        }
        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Create()
        {
            return Json(new Course() {Id=1,CourseName="Asp.net" });
        }

        [HttpGet]
        [Authorize(Policy = "MinimumAge")]
        public IActionResult CheckPolicy14()
        {
            return Content("You are eligible");
        }
    }
}
