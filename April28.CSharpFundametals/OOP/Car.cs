using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace April28.CSharpFundametals.OOP
{
    public class Car
    {
        public string Brand;
        public string Model;
        public int Year;

        public void Drive()//method
        {
            Console.WriteLine($"{Brand} {Model} is Driving..");
        }
    }
}
