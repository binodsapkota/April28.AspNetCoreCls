using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstMvcApp.Model;

namespace MyFirstMvcApp.Controllers
{
    public class CourseController : Controller
    {
        //private readonly ILogger<TeacherController> _logger;
        private readonly StudentDbContext _context;
        public CourseController(StudentDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Course> teachers = new List<Course>();
            teachers = await _context.Courses.ToListAsync();
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
                _context.Courses.Add(model);
                await _context.SaveChangesAsync();
                TempData["message"] = $"{model.CourseName} Created Successfully";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            return View(course);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            return View(course);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Course model)
        {
            if (id != model.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Courses.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var teacher = await _context.Courses.FindAsync(id);
            return View(teacher);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id, Course model)
        {
            var teacher = await _context.Courses.FindAsync(id);
            if (teacher == null)
                return NotFound();


            _context.Courses.Remove(teacher);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

            return View(teacher);
        }
    }
}
