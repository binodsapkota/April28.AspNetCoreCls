using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace April28.CSharpFundametals
{
    public class TypeCasting
    {
        public void Implicit()
        {
            int num = 100;
            long lg = num;
            double dbl = num;
            decimal dec = (decimal)dbl;

            //
            // only works with same base type
        }

        public void Eplicit()
        {
            double dbl = 3.14;
            int num = (int)dbl;
        }

        public void ParsingExample()
        {
            int num = 35;
            //some changes
            string str = num.ToString();
            num =int.Parse(str);
            double dbl = double.Parse(str);
        }
    }
}
