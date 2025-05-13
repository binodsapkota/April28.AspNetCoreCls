using EFCoreChapter.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreChapter
{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext()
        {
            
        }
        public DbSet<Student> Students { get; set; }


        //we need a connection string to connect to the database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=StudentDb;Integrated Security=true;TrustServerCertificate=true;");
            //for local db 
            //optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Lenovo\\source\\repos\\April28.CSharpFundametals\\EFCoreChapter\\Data\\SchoolDb.mdf;Integrated Security=True;Connect Timeout=30");
        }
    }
}
