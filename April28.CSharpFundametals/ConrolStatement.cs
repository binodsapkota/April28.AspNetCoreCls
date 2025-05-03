using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace April28.CSharpFundametals
{
    internal class ControlStatement
    {//ctor => shortcut for constructor
        public ControlStatement()
        {

        }

        public void IfElseStatement(int num = 0, int num2 = 0)//params=> parameter
                                                              //int num=0 optional parameters
        {

            bool isPositive = num % 2 == 0;//if reminder is zero
            if (isPositive)//num > 0 is condition,it returns bool
            {
                Console.WriteLine("Positive number");
            }
            else
            {
                Console.WriteLine("Negetive number");
            }
        }
        public void SwitchExample(int day=0)
        {
            
            switch (day)
            {
                case 1:
                    Console.WriteLine("Sunday");
                    break;
                case 2:
                    Console.WriteLine("Monday");
                    break;
                case 3:
                    Console.WriteLine("Tuesday");
                    break;
                case 4:
                    Console.WriteLine("Wednesday");
                    break;
                case 5:
                    Console.WriteLine("Thursday");
                    break;
                case 6: Console.WriteLine("Friday");
                    break;
                    case 7:
                        Console.WriteLine("Saturday");
                    break;
                default:
                    Console.WriteLine("Invalid Code");
                    break;
            }
        }

        public int FindSmall(int a, int b)
        {
            bool condition = a > b;//B is small

            if (condition)
            {
                return b;
            }
            else
            {
                return a;
            }

            
        }
    }
}
