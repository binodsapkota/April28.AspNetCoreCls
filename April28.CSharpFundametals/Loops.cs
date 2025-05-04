using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace April28.CSharpFundametals
{
    public class Loops
    {
        public void ForLoop()
        {
            //to repeat the statement

            //untill the condition is valid

            //LENGTH MUST BE DEFINED
            for (int i = 0; i <= 5; i++)
            {
                Console.WriteLine(i);
            }

        }
        public void WhileLoop()
        {
            //to repeat the statement untill the condition is valid
            //untill the escape condition appears;
            //lenth cannot be defined
            int length = 0;
            while (length < 5)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Binod");
                length++;
            }
        }
        public void DoWhile()
        {
            int length = 5;
            do
            {
                Console.WriteLine("Binod");
                length++;
            }
            while (length < 5);
        }

        public void PrimeNumber()
        {
            Console.WriteLine("Enter A Positive number");
            int num = int.Parse(Console.ReadLine());
            int divider = 2;
            bool prime = true;
            while (prime && (divider < num))
            {
                if (num % divider == 0)
                {
                    prime = false;
                }
                divider++;
            }

            Console.WriteLine(prime ? "Prime" : "Not Prime");
        }
    }
}