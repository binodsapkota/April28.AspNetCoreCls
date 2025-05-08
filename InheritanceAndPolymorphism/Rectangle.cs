using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndPolymorphism
{
    internal class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing A Rectangle");
        }
    }
}
