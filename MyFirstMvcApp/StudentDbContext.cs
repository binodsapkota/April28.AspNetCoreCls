
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyFirstMvcApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMvcApp
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentProfile> StudentProfiles { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Course> Courses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Student>()
            //    .HasOne(s => s.Profile)
            //    .WithOne(sp => sp.Student)
            //    .HasForeignKey<StudentProfile>(sp => sp.StudentId)
            //    ;

            //modelBuilder.Entity<Teacher>()
            //    .HasMany(t => t.Students)
            //    .WithOne(s => s.Teacher)
            //    .HasForeignKey(s => s.TeacherId);



            //modelBuilder.Entity<StudentCourse>()
            //    .HasKey(sc => new { sc.StudentId, sc.CourseId });

            //modelBuilder.Entity<StudentCourse>()
            //    .HasOne(sc => sc.Student)
            //    .WithMany(s => s.StudentCourses)
            //    .HasForeignKey(sc => sc.StudentId);

            //modelBuilder.Entity<StudentCourse>()
            //    .HasOne(sc => sc.Course)
            //    .WithMany(c => c.StudentCourses)
            //    .HasForeignKey(sc => sc.CourseId);

        }
        //public DbSet<MyFirstMvcApp.Model.RegisterModel> RegisterModel { get; set; } = default!;

        //we need a connection string to connect to the database
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=StudentDb;Integrated Security=true;TrustServerCertificate=true;");
        //    //for local db 
        //    //optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Lenovo\\source\\repos\\April28.CSharpFundametals\\EFCoreChapter\\Data\\SchoolDb.mdf;Integrated Security=True;Connect Timeout=30");
        //}
    }
}
