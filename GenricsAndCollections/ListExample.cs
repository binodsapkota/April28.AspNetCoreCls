using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenricsAndCollections
{
    internal class ListExample
    {
        public ListExample()
        {
            List<string> names = new List<string>() { "Binod", "Ruja", "Hari","Shyam","Uttam","Govind" };//instantiate

            names.Add("Sita");
            names.Add("Binod");

           // names.Remove("Binod");

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }

    }
}
