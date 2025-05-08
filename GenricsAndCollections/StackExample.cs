using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenricsAndCollections
{
    internal class StackExample
    {
        //Card is example of stack;
        //it follows LIFO

        public StackExample()
        {

            Stack<int> ints = new Stack<int>();
            ints.Push(1);
            ints.Push(2);
            ints.Push(3);

            Console.WriteLine("POP "+ints.Pop());

            Console.WriteLine("Peak " + ints.Peek());
        }

    }
}
