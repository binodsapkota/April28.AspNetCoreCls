using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndPolymorphism
{
    public class Animal
    {
        public virtual void MakeSound()
        {
            Console.WriteLine("Animal Makes Sound...");
            //this implementation or defination is not enough
        }
    }
}
