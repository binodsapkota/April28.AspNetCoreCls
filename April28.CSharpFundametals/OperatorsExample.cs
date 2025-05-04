using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace April28.CSharpFundametals
{
    public class OperatorsExample
    {
        public OperatorsExample() { }

        public void Arithmatic()
        {
            //int,long,short
            //float,decimal,double

            int age;
            decimal money;

            age = 30;
            money = 500000;
            money = money + 1000;
            age = age - 2;

            money = money * 10;
            money = money / 10;
        }

        public void Increment()
        {
            //++
            //--
            //+=
            //-=
            int i = 0, j = 0, k = 0;
            Console.WriteLine(i);
            j = ++i;
            //j=i++
            j = i;
            i = i + 1;

            //++j\
            i = i + 1;
            j = i;




            Console.WriteLine(i++);
            Console.WriteLine(++j);
            i += 1;
            Console.WriteLine(i);



        }

        public void Assignment()
        {
            int i = 0;

            i += 1;//i = i + 1;

            i -= 1;// i = i - 1;

        }

        public void Comparision()
        {
            int i = 0;
            int j = 0;

            //compare equal to
            bool isEqual = i == j;
            if (isEqual)
            {

            }
            bool isNotEqual = i != j;
            if (!isEqual)
            {

            }

            bool isLessThan = i < j;
            if (isLessThan)
            {

            }

            bool isGreaterThan = i > j;
            if (isGreaterThan)
            {

            }

            bool isLessThanOrEqual = i <= j;
            if (isLessThanOrEqual)
            {

            }
            bool isGreaterThanOrEqual = i >= j;
            if (isGreaterThanOrEqual)
            {

            }

            //

        }

        public void Logical()
        {
            bool conditionA = true;
            bool conditionB = true;

            if (conditionA && conditionB)
            {
                //both condition is satisfied

                Console.WriteLine("Booth Condiation Is Ok");
            }
            if (conditionA || conditionB)
            {
                //either or
                Console.WriteLine("Or Example");
            }

            conditionA = !conditionA;
            //not
            if (!conditionA)//inversion
            {
                //if condition is not true
            }
        }

        public void StrConcat()
        {
            string fName = "binod";//obj1
            string lName = "Sapkota";//obj2
            string fullName = fName + " " + lName;//obj4

            fullName = $"{fName} {lName}";//using literal

            //not the good practice

            StringBuilder sb = new StringBuilder();
            sb.Append("binod");
            sb.Append(" ");
            sb.Append("sapkota");

            fullName = sb.ToString();







        }
        public void TerneryOperator()
        {
            int a = 4;
            int b = 5;

            //print small one

            if (a < b)
            {
                Console.WriteLine("a");
            }
            else
            {
                Console.WriteLine("b");
            }

            //

            Console.WriteLine($"Smallest Number is:{ (a < b ? a : b)}");
        }
    }
}
