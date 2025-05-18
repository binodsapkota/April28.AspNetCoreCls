using EFCoreChapter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentCourseApp.Model;

namespace StudentCourseApp.Controller
{
    /// <summary>
    /// get,post,put,delete
    /// </summary>




    [Route("api/Teacher")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        StudentDbContext _context;
        public TeacherController(StudentDbContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeachers()
        {
            // Simulate async operation

            return Ok(await _context.Teacher.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacher(int id)
        {
            // Simulate async operation

            return Ok(await _context.Teacher.FindAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateTeacher(Teacher teacher)
        {
            _context.Teacher.Add(teacher);
            await _context.SaveChangesAsync();

            return Ok(teacher);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return BadRequest();
            }

            _context.Teacher.Update(teacher);
            await _context.SaveChangesAsync();

            return Ok(teacher);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var teacher =await _context.Teacher.FindAsync(id);
            if (teacher == null) return NotFound();

            _context.Teacher.Remove(teacher);
            await _context.SaveChangesAsync();

            return Ok(teacher);

        }
    }
}
