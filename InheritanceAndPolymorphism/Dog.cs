using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndPolymorphism
{
    public class Dog:Animal
    {
        public override void MakeSound()
        {
            //base.MakeSound();
            Console.WriteLine("Dogs Barks...");

        }
    }
}
