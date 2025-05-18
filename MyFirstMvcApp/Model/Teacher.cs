using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMvcApp.Model
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation property for the one-to-one relationship with Student
        public List<Student>? Students { get; set; }
    }
}
