using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMvcApp.Model
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }

        public List<StudentCourse>? StudentCourses { get; set; }

    }
}
