using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndPolymorphism
{
    public abstract class Shape
    {
        //an abstract method doesnot have definitiion.
        //it must be implemented by derived class
        public abstract void Draw();
    }
}
