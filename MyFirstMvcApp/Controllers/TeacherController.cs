using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstMvcApp.Model;

namespace MyFirstMvcApp.Controllers
{
    public class TeacherController : Controller
    {
        //private readonly ILogger<TeacherController> _logger;
        private readonly StudentDbContext _context;
        public TeacherController(StudentDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Teacher> teachers = new List<Teacher>();
            teachers = await _context.Teacher.ToListAsync();
            return View(teachers);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var teacher = new Teacher() { Name = "" };
            return View(teacher);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Teacher model)
        {
            if (ModelState.IsValid)
            {
                _context.Teacher.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var teacher = await _context.Teacher.FindAsync(id);
            return View(teacher);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Teacher model)
        {
            if (id != model.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Teacher.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var teacher = await _context.Teacher.FindAsync(id);
            return View(teacher);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id,Teacher model)
        {
            var teacher = await _context.Teacher.FindAsync(id);
            if (teacher == null)
                return NotFound();

            
                _context.Teacher.Remove(teacher);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            
            return View(teacher);
        }
        [Route("{lang}/Teacher/Message/{text}")]
        public IActionResult Test(string lang, string text)
        {
            switch (lang)
            {
                case "np":
                    text = "Nepali text";
                    break;

                default:
                    text = "English text";
                    break;
            }
            return Content(text);
        }
    }
}
