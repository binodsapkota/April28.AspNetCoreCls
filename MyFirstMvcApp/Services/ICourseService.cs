using MyFirstMvcApp.Model;

namespace MyFirstMvcApp.Services
{
    public interface ICourseService
    {
       Task<List<Course>> GetAllCoursesAsync();
        Task<Course> GetCourseByIdAsync(int id);
        Task<Course> CreateCourseAsync(Course course);
        Task<Course> UpdateCourseAsync(int id, Course course);
        Task<bool> DeleteCourseAsync(int id);
        Task<DateTime> GetDateTime();

    }
}
