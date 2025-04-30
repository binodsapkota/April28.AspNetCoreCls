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

        public void IfElseStatement()
        {
            int num = 10;
            bool isValie = num > 0;
            if (isValie)//num > 0 is condition,it returns bool
            {
                Console.WriteLine("Positive number");
            }
        }
    }
}
