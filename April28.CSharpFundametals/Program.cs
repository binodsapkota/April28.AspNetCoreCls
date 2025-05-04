using April28.CSharpFundametals;
using System.Net.Http.Json;

internal class Program
{
    //this is entry point of the application
    private static void Main(string[] args)
    {
        //ControlStatement controlStatement = new ControlStatement();
        //controlStatement.IfElseStatement(num2:5);//argument//named argument  num2:5

        //controlStatement.SwitchExample(4);

        //write a condition to find the smallest number among two
        // a and b

        //get user input

        //Loops loops = new Loops();
        //loops.PrimeNumber();

        MethodExample example = new MethodExample("binod");
        example.Greet();//calling method

        MethodExample example1 = new MethodExample();
        example1.Greet();

        MethodExample example2 = new MethodExample("Ruja");
        example2.Greet();

        example.Add(1, 2);
        example.Add(num1: 1, num2: 2);
        example.Add(num2: 2, num1: 3);


        var person= example.GetPerson();
        Console.WriteLine($"{person.name} {person.age}");
  

        Console.WriteLine("Please Enter Height of rectangle");
        int.TryParse(Console.ReadLine(), out int height);
        Console.WriteLine("Please Enter Width of rectangle");
        int.TryParse(Console.ReadLine(), out int width);

        var rectangle = example.GetRectangle(out height,ref width,out double area);
        Console.WriteLine($"Area: {rectangle.area} height {rectangle.height}, original Height {height}, Area {area}");
        
    }
}