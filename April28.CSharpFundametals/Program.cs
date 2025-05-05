using April28.CSharpFundametals;
using April28.CSharpFundametals.OOP;
using InternalExamplePrj;
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

        //MethodExample example = new MethodExample("binod");
        //example.Greet();//calling method

        //MethodExample example1 = new MethodExample();
        //example1.Greet();

        //MethodExample example2 = new MethodExample("Ruja");
        //example2.Greet();

        //example.Add(1, 2);
        //example.Add(num1: 1, num2: 2);
        //example.Add(num2: 2, num1: 3);


        //var person= example.GetPerson();
        //Console.WriteLine($"{person.name} {person.age}");
  

        //Console.WriteLine("Please Enter Height of rectangle");
        //int.TryParse(Console.ReadLine(), out int height);
        //Console.WriteLine("Please Enter Width of rectangle");
        //int.TryParse(Console.ReadLine(), out int width);

        //var rectangle = example.GetRectangle(out height,ref width,out double area);
        //Console.WriteLine($"Area: {rectangle.area} height {rectangle.height}, original Height {height}, Area {area}");

        //OOPExample oOPExample = new OOPExample();
        ////oOPExample.Id
        //MyOOPExample myOOPExample = new MyOOPExample();
        //myOOPExample.



        Car myCar = new Car();//creating a new instant of a object
        myCar.Brand = "TATA";
        myCar.Model = "Nexon";
        myCar.Year = 2022;

        myCar.Drive();


        Car myAnotherCar = new Car();
        myAnotherCar.Brand = "Tesla";
        myAnotherCar.Model = "Model 3";
        myAnotherCar.Year = 2023;
        
        myAnotherCar.Drive();

        Student myStudent = new Student();
        myStudent.Name = "Ruja";
        myStudent.Address = "nepal";
        myStudent.Faculty = "IT";
        myStudent.Year = 2021;

        myStudent.Register();

        Student myAnotherStudent = new Student("Binod","china","humanities",2024);
        myAnotherStudent.Register();
        Student myAnotherStudent1 = new Student("Ram");
        myAnotherStudent1.Register();

        //InternalClass internalClass = new InternalClass();
        PublicClass publicClass = new PublicClass();
        publicClass.GetInternalValue();


        BankAccount account = new BankAccount();
        account.Deposit(1000);
        
        Console.WriteLine(account.GetBalance());

    }
}