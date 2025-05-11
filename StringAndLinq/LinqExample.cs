

namespace StringAndLinq
{
    internal class LinqExample
    {
        public LinqExample()
        {
            
        }

        public void LamdaExpExample()
        {
            //list of int
            List<int> ints = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //list of string
            List<string> strings = new List<string>() { "Binod", "Ram", "Shyam", "Hari", "Gita", "Sita" };

            ints.Add(11);//add new element
            ints.AddRange(12, 13, 14, 15);


            //filter 
            List<int> filteredItem = ints//source
                                        .Where(num => num > 5)//expresion
                                        .ToList();//tolist
            filteredItem.ForEach(num => Console.WriteLine(num));

            var doubleValueList = filteredItem
                    .Select(num => num * 2).ToList();
            foreach (int i in doubleValueList)
            {
                Console.WriteLine(i);
            }
            int sum = ints.Sum(x => x);
            int count = ints.Count();
            int max = ints.Max(x => x);
            int min = ints.Min(x => x);
            double average = ints.Average(x => x);
            Console.WriteLine($"Sum {sum}, count {count}, min {min}, max {max}, average {average} ");

            strings.AddRange("modi", "amit");

            strings = strings.OrderBy(x => x).ToList();
            foreach (string s in strings)
            {
                Console.WriteLine(s);
            }
        }

        public void QueryExample()
        {
            //list of string
            List<string> strings = new List<string>() { "Binod", "Ram", "Shyam", "Hari", "Gita", "Sita" };

            var result = (from s in strings
                          where s.Length > 3
                          select s
                        );
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

        }

        public void ClassWork()
        {
            List<Student> students = new List<Student>();

            Student ram = new Student() { Name = "ram", Marks = 55.5 };
            Student shyam = new Student() { Name = "shyam", Marks = 65.5 };
            Student hari = new Student() { Name = "hari", Marks = 75.5 };
            Student sita = new Student() { Name = "sita", Marks = 87 };
            Student gita = new Student() { Name = "gita", Marks = 97.7 };

            students.AddRange(ram, shyam, hari, sita, gita);

            var filteredStudent = students
                                    .Where(x => x.Marks > 75)
                                    .OrderByDescending(x => x.Marks)
                                    .ToList();
            Console.WriteLine( string.Join(",", filteredStudent.Select(x => ($"{x.Name}: {x.Marks}"))));
        }
    }
}
