internal class Program
{
    //this is entry point of the application
    private static void Main(string[] args)
    {
        //variables in c#

        //syntax

        //datatype variable_name=value

        //let me creat a variable to store my name

        string myName = "binod Sapkota";
        myName = null;
        int? age = 34;//this question mark will make the variable nullable
        //the same logic or syntax for all other datatype
        age = null;

        //timeand date

        DateTime? dob = new DateTime(1990, 04, 02);
        dob = null;

        float a = 22f / 7f;
        decimal b = 22m / 7m;
        double c = 22d / 7d;

        Console.WriteLine("float " + a);
        Console.WriteLine("double " + c);
        Console.WriteLine("decimal " + b);

        bool isNepali = false;//it is use as logic or condition it returns/stores true or false

        char charr = 'a';
        int ascii = (int)charr;

        Console.WriteLine(charr + " : ascii = " + ascii);

        Console.WriteLine("my name is " + myName + ", i ma " + age + " years old." + " I was born on " + dob);


        //reference type
        var varValue = "this is value";

        object obj = "this is a value in object";
        object objInt = 12;
        obj = objInt;
        Console.WriteLine(obj);
        Console.WriteLine(objInt);

        dynamic dObj = "string value";
        dObj = 12;

        const double pi = 3.142;//value cant be alterd

        int dayvalue =(int) Days.Sunday;
        
       
        //
    }
    //enums

    //week days 
    //month
    //gender
    //

    enum Days
    {
        Sunday=5, Monday=7, Tuesday=9, Wednesday=11, Thursday=13, Friday=15, Saturday=17
    }

    public enum Month
    {
        January = 1,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }

}