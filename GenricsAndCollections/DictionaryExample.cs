using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenricsAndCollections
{
    internal class DictionaryExample
    {
        //key:House
        //value:Where family lives in harmony n,
        //
        public DictionaryExample()
        {
            //id and name
            Dictionary<int, string> employess = new Dictionary<int, string>();
            employess.Add(1, "binod");
            employess.Add(2, "Ruja");
            employess.Add(3, "binod");


            string employee = employess[2];

            Console.WriteLine(employee);

            foreach (var item in employess)
            {

                Console.WriteLine(item.Key);
            }
        }
    }
}
