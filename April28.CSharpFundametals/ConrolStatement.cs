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

        public void IfElseStatement(int num=0,int num2=0)//params=> parameter
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
    }
}
