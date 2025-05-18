// See https://aka.ms/new-console-template for more information
using EFCoreChapter;
using EFCoreChapter.Model;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        //lets add data in student table


        var context = new StudentDbContext();
        string command = "";
        do
        {
            Console.WriteLine("Please input command");
            Console.WriteLine("C from Create, R From Read, U for Update, D for delete,exit to exit");
            command = Console.ReadLine().ToUpper();

            switch (command)
            {
                case "C":
                    //create
                    Console.WriteLine("Please input name");
                    var student = new Student
                    {
                        Name = Console.ReadLine(),
                        Age = 25,
                        TeacherId = 1
                    };
                    context.Students.Add(student);
                    context.SaveChanges();//commit recent changes to the database
                                          //this will add the data in the database
                    Console.WriteLine("Data added successfully");
                    break;
                case "R":
                    //read
                    int pageSize = 5;
                    int pageNumber = 1;
                    var students = await context.Students
                        .Include(x => x.Teacher)    //i have to include teacher from student table
                        .Include(x => x.StudentCourses)
                        .ThenInclude(c => c.Course)
                        .OrderByDescending(x => x.Name)
                        .Skip(pageSize * (pageNumber - 1))
                        .Take(pageSize).ToListAsync();
                    foreach (var s in students)
                    {
                        Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Age: {s.Age}, Teacher :[ id: {s.TeacherId}, Name: {s.Teacher.Name} ");


                    }




                    var studentCourses = (from sc in context.StudentCourses
                                          join c in context.Courses
                                          on sc.CourseId equals c.Id
                                          join s in context.Students
                                            on sc.StudentId equals s.Id into sjoined
                                          from s in sjoined.DefaultIfEmpty()
                                          select new
                                          {
                                              sc.StudentId,
                                              s.Name,
                                              c.CourseName
                                          })
                                          .ToList();
                    foreach (var sc in studentCourses)
                    {
                        Console.WriteLine($"Student: {sc.Name}, CourseName: {sc.CourseName}");

                    }

                    var teacherStudent = (from t in context.Teacher
                                          join s in context.Students on t.Id equals s.TeacherId
                                          into tsJoin
                                          from j in tsJoin.DefaultIfEmpty()
                                          select new
                                          {
                                              TeacherName = t.Name,
                                              StudentName = j.Name
                                          }
                                        ).ToList();

                    foreach (var ts in teacherStudent)
                    {
                        Console.WriteLine($"Teacher: {ts.TeacherName}, Student: {ts.StudentName}");
                    }

                    break;
                case "U":
                    //update\
                    Console.WriteLine("Please input id to update");
                    int.TryParse(Console.ReadLine(), out int id);
                    //find the student with id 
                    var studentToUpdate = context.Students.FirstOrDefault(s => s.Id == id);

                    if (studentToUpdate != null)
                    {
                        Console.WriteLine("Please input new name");
                        studentToUpdate.Name = Console.ReadLine();
                        Console.WriteLine("Please input new age");
                        studentToUpdate.Age = int.Parse(Console.ReadLine());
                        context.SaveChanges();
                        Console.WriteLine("Data updated successfully");
                    }
                    break;
                case "D":
                    //delete
                    Console.WriteLine("Please input id to delete");
                    int.TryParse(Console.ReadLine(), out int idToDelete);
                    //find the student with id 
                    var studentToDelete = context.Students.FirstOrDefault(s => s.Id == idToDelete);
                    if (studentToDelete != null)
                    {
                        context.Students.Remove(studentToDelete);
                        context.SaveChanges();
                        Console.WriteLine("Data deleted successfully");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid command");
                    break;
            }
        } while (command != "EXIT");
    }
}