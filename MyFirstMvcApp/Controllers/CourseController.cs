using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstMvcApp.Model;
using MyFirstMvcApp.Services;

namespace MyFirstMvcApp.Controllers
{
    public class CourseController : Controller
    {
        //private readonly ILogger<TeacherController> _logger;
        //private readonly StudentDbContext _context;
        private readonly ICourseService _courseService;
        private readonly ITimeService _timeService;
        public CourseController(ICourseService service,ITimeService timeService)
        {
            _courseService = service;
            _timeService = timeService;

        }
        public async Task<IActionResult> Index()
        {
            List<Course> teachers = new List<Course>();
            teachers = await _courseService.GetAllCoursesAsync();
            TempData["message"] = $"Controller Time :{ _timeService.GetCurrentTime()}, service time :{await _courseService.GetDateTime()}";
            return View(teachers);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.User = "Binod";
            var teacher = new Course() { CourseName = "" };
            return View(teacher);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Course model)
        {
            if (ModelState.IsValid)
            {
                await _courseService.CreateCourseAsync(model);
                TempData["message"] = $"{model.CourseName} Created Successfully";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            return View(course);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            return View(course);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Course model)
        {
            if (id != model.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _courseService.UpdateCourseAsync(id, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var teacher = await _courseService.GetCourseByIdAsync(id);
            return View(teacher);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id, Course model)
        {
            var teacher = await _courseService.GetCourseByIdAsync(id);
            if (teacher == null)
                return NotFound();


            await _courseService.DeleteCourseAsync(id);
            return RedirectToAction("Index");

            return View(teacher);
        }
    }
}
