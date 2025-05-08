using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenricsAndCollections
{
    internal class HashTableExample
    {
        public HashTableExample()
        {
            Hashtable employess = new Hashtable();
            employess.Add(1, "binod");
            employess.Add(2, "Ruja");
            employess.Add(3.5, "binod");

            var employee = employess[2];
            Console.WriteLine(employee);
        }
    }
}
