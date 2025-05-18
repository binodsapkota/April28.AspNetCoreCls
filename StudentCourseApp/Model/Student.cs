using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseApp.Model
{
    [Table("Students")]
    //by default class name is used as table name
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [StringLength(150), Column("StudentName", TypeName = "varchar")]
        public string Name { get; set; }
        [Range(1, 100)]
        public int Age { get; set; }

        public int TeacherId { get; set; }

        //foreign key   
        public Teacher Teacher { get; set; }
        public StudentProfile Profile { get; set; }
        public List<StudentCourse>? StudentCourses { get; set; }
    }

    /// <summary>
    /// one to one relationship between Student and StudentProfile
    /// Define one to one relationship between Student and StudentProfile
    /// 
    /// </summary>
    public class StudentProfile
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
