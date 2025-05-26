using Microsoft.EntityFrameworkCore;
using MyFirstMvcApp.Model;

namespace MyFirstMvcApp.Services
{
    public class CourseService : ICourseService
    {
        private readonly StudentDbContext _context;
        private readonly ITimeService _timeService;
        public CourseService(StudentDbContext context, ITimeService timeService)
        {
            _context = context;
            _timeService = timeService;
        }
        public async Task<Course> CreateCourseAsync(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
           var model=await GetCourseByIdAsync(id);
            if (model == null)
            {
                return false;
            }
            _context.Courses.Remove(model);
            await _context.SaveChangesAsync();
            return (true);
        }

        public async Task<List<Course>> GetAllCoursesAsync()
        {
          return await _context.Courses.ToListAsync();
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
           return await _context.Courses
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public  Task<DateTime> GetDateTime()
        {
            return Task.FromResult(  _timeService.GetCurrentTime());
        }

        public async Task<Course> UpdateCourseAsync(int id, Course course)
        {
            uint result = 0;
            var model = await GetCourseByIdAsync(id);
            if (model != null)
            {
                model.CourseName = course.CourseName;
                await _context.SaveChangesAsync();

            }
            return model;
        }
    }
}
