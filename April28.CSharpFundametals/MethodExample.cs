using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace April28.CSharpFundametals
{
    public class MethodExample//pascal case (naming convention)
    {
        //data//character
        //behavior/action
        //the method with class name and doesnot have return type= constructor
        //to construct object
        //to instantiate a object we need constructor

        private string _param;//private fields name starts from "_" (naming convention)


        public MethodExample(string param = "Programmer")
        {
            //set value during initialization
            //
            _param = param;

        }

        public void Greet()
        {
            Console.WriteLine($"Hello {_param}, welcome to c#!");
        }

        public int Add(int num1, int num2)
        {
            Console.WriteLine(num1 + "+" + num2 + "=" + (num1 + num2));
            return num1 + num1;
        }


        public void PrintMessage(string message = "Hello, World!")
        {
            Console.WriteLine(message);
        }
        /// <summary>
        /// tuple Example
        /// Tuples allow returning multiple values from a method.
        /// </summary>
        /// <returns></returns>
        public (string name, int age) GetPerson()
        {
            return ("Binod", 30);
        }
        /// <summary>
        /// tupple example
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public (double area, double perimeter,int  height,int width) GetRectangle(out int height,ref int width,out double area)
        {
            height = 25;//you must asign value while using out type
            width = width + 1;
            area = height * width;
            double perimeter = 2 * (height + width);
            return (area, perimeter,height,width);
        }
        /// <summary>
        /// in example
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public int Square(in int number)
        {
            //number = 45;param is read only
            return number*number; 
        }
        /// <summary>
        /// ref example
        /// </summary>
        /// <param name="x"></param>
        void Increment(ref int x)
        {
            x++;
        }
        /// <summary>
        /// out example
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        void GetStats(out int min, out int max)
        {
            min = 1;
            max = 100;
        }
    }
}
