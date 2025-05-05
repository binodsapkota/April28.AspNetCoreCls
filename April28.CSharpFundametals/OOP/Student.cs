using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace April28.CSharpFundametals.OOP
{
    public class Student
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Faculty { get; set; }
        public int Year { get; set; }

        public Student()
        {

        }
        public Student(string name, string address, string faculty, int year)
        {
            this.Name = name;
            this.Address = address;
            this.Faculty = faculty;
            this.Year = year;
        }
        public Student(string name)
        {
            this.Name = name;
            this.Address = "Nepal";
            this.Faculty = "IT";
            this.Year = 2025;
        }

        public void Register()
        {
            Console.WriteLine($"Student {Name} from {Address} for {Faculty} is registered on {Year}");
        }
    }
}
